using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LAVASh.Models;
using LAVASh.DBmodels;
using System.Security.Claims;
namespace LAVASh.Controllers
{
    public class AdminController : Controller
    {
        private DBcontext _context;
        public AdminController (DBcontext context)
        {
            _context = context;
        }

        [Authorize()]
        [HttpGet]
        public IActionResult Index()
        {

            string userName = User.Identity.Name;
            User curentUser = _context.Users.FirstOrDefault(u => u.Email == userName);
            if (curentUser.IsAdmin)
            {
                AdminPanelModel model = new AdminPanelModel { Workers = new SelectList(_context.Users.ToList(), "Id", "FullName") };
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize()]
        [HttpPost]
        public async Task<IActionResult> Index(AdminPanelModel model)
        {
            ModelState.Remove("Workers");
            if (ModelState.IsValid)
            {
                User worker = _context.Users.FirstOrDefault(u => u.Id == model.WorkerId);
                worker.HeadId = model.HeadId;
            }
            _context.SaveChanges();
            string userName = User.Identity.Name;
            User curentUser = _context.Users.FirstOrDefault(u => u.Email == userName);
            if (curentUser.IsAdmin)
            {
                AdminPanelModel newmodel = new AdminPanelModel { Workers = new SelectList(_context.Users.ToList(), "Id", "Secondname") };
                return View(newmodel);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
