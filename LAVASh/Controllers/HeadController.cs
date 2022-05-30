using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LAVASh.Models;
using LAVASh.DBmodels;
using Microsoft.EntityFrameworkCore;

namespace LAVASh.Controllers
{
    public class HeadController : Controller
    {
        DBcontext _context;
        public HeadController(DBcontext context)
        {
            _context = context;
        }

        [Authorize()]
        [HttpGet]
        public IActionResult UserPage(int id)
        {
            User curentUser = _context.Users.Include(u => u.HisTasks).FirstOrDefault(u => u.Id == id);
            if (curentUser != null)
            {
                UserPageModel model = new UserPageModel { Id = id, Name = curentUser.FullName, Tasks = curentUser.HisTasks };
                return View(model);
            }
            return NotFound();
        }
        [Authorize()]
        [HttpGet]
        public IActionResult List()
        {
            string userName = User.Identity.Name;
            User curentUser = _context.Users.FirstOrDefault(u => u.Email == userName);
            var Subordinate = _context.Users.Where(u => u.HeadId == curentUser.Id).ToList();

            List<WorkerListModel> model = new List<WorkerListModel>();
            foreach(var sub in Subordinate)
            {
                model.Add((WorkerListModel)sub);
            }
            return View(model);
        }
        [Authorize()]
        [HttpGet]
        public IActionResult AddTask(int id)
        {
            User curentUser = _context.Users.Include(u => u.HisTasks).FirstOrDefault(u => u.Id == id);
            
            if (curentUser != null)
            {
                NewTaskModel model = new NewTaskModel { UserId = curentUser.Id, UserName = curentUser.FullName, Places = new SelectList(_context.Place.ToList(), "Id", "Name") };
                return View(model);
            }
            return NotFound();
        }
        [Authorize()]
        [HttpPost]
        public IActionResult AddTask(NewTaskModel model)
        {
            ModelState.Remove("UserName");
            ModelState.Remove("Places");
            if (ModelState.IsValid)
            {
                string userName = User.Identity.Name;
                User curentUser = _context.Users.Include(u => u.UserSubordinate).FirstOrDefault(u => u.Email == userName);
                LAVASh.DBmodels.Task task = new DBmodels.Task
                {
                    Name = model.Name,
                    Description = model.Description,
                    Author = curentUser,
                    ExecutorId = model.UserId,
                    TimeToDo = model.TimeToDo,
                    EndOfDoing = model.EndOfDoing,
                    PlaceId = model.PlaceId
                };
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return RedirectToAction("list", "Head");
            }
            return RedirectToAction("AddTask", "Head", model.UserId);
        }

        [Authorize()]
        [HttpGet]
        public IActionResult AddPlace()
        {
            return View();
        }
        [Authorize()]
        [HttpPost]
        public IActionResult AddPlace(PlaceModel model)
        {
            if (ModelState.IsValid)
            {
                Place place = new Place { Name = model.Name, HelpStrings = model.HelpStrings };
                _context.Place.Add(place);
                _context.SaveChanges();
            }
            return RedirectToAction("list", "Head");
        }


    }
}
