using MealWheel.Models;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MealWheel.Controllers
{
    public class CategoriesController : Controller
    {
        public MealDbContext mealDbContext;
        public IHostingEnvironment _env;

        public CategoriesController(MealDbContext mealDbContext, IHostingEnvironment env)
        {
            this.mealDbContext = mealDbContext;
            this._env = env;
        }
        public IActionResult Index()
        {
            return View(mealDbContext.categories.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(category categ)
        {

            mealDbContext.Add(categ);
            mealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            var Cat = mealDbContext.categories.FirstOrDefault(e => e.id == id);
            return View(Cat);
        }
        [HttpPost]
        public IActionResult Edit(category Categ)
        {
            mealDbContext.Update(Categ);
            mealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Details(int? id)
        {
            return View(mealDbContext.categories.FirstOrDefault(e => e.id == id));

        }
        public IActionResult Delete(int? id)
        {
            return View(mealDbContext.categories.FirstOrDefault(e => e.id == id));
        }
        [HttpPost]
        public IActionResult Delete(category categ)
        {
            mealDbContext.Remove(categ);
            mealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
