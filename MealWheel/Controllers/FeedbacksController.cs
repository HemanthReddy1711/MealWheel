using MealWheel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MealWheel.Controllers
{
    public class FeedbacksController : Controller
    {
        public MealDbContext mealDbContext;
        public IHostingEnvironment _env;

        public FeedbacksController(MealDbContext mealDbContext, IHostingEnvironment env)
        {
            this.mealDbContext = mealDbContext;
            this._env = env;
        }
        public IActionResult Index()
        {
            return View(mealDbContext.feedbacks.Include(e => e.product).ToList());
        }
        public IActionResult Create()
        {
            ViewData["savecat"] = new SelectList(mealDbContext.Food_Products, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(feedback feed)
        {

            mealDbContext.Add(feed);
            mealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Edit(int? id)
        {
            ViewData["savecat"] = new SelectList(mealDbContext.Food_Products, "Id", "Name");
            var prod = mealDbContext.feedbacks.FirstOrDefault(e => e.id == id);
            return View(prod);
        }
        [HttpPost]
        public IActionResult Edit(feedback feed)
        {
            mealDbContext.feedbacks.Update(feed);
            mealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Details(int? id)
        {
            return View(mealDbContext.feedbacks.Include(e => e.product).FirstOrDefault(e => e.id == id));

        }
        public IActionResult Delete(int? id)
        {
            return View(mealDbContext.feedbacks.Include(e =>e.product).FirstOrDefault(e => e.id == id));
        }
        [HttpPost]
        public IActionResult Delete(feedback feed)
        {
            mealDbContext.Remove(feed);
            mealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
