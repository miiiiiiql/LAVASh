using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using LAVASh.Models;
using LAVASh.DBmodels;
using Microsoft.EntityFrameworkCore;
namespace LAVASh.Controllers
{
    public class SubordinateController : Controller
    {
        DBcontext _context;
        public SubordinateController (DBcontext context)
        {
            _context = context;
        }
        [Authorize()]
        [HttpGet]
        public IActionResult list()
        {
            string userName = User.Identity.Name;
            User curentUser = _context.Users.FirstOrDefault(u => u.Email == userName);
            List<TaskModel> taskModels = new List<TaskModel>();
            foreach (var task in _context.Tasks.Include(u=> u.Place).Where(t=> t.ExecutorId == curentUser.Id && !t.IsDone).ToList())
            {
                taskModels.Add((TaskModel)task);
            }

            SubordinateTaskModel model = new SubordinateTaskModel { UserId = curentUser.Id, Tasks = taskModels };
            return View(model);
        }
        [Authorize()]
        [HttpGet]
        public IActionResult Check(int id)
        {
            LAVASh.DBmodels.Task task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                task.IsDone = true;
            }
            return RedirectToAction("list", "Subordinate");
        }

    }
}
