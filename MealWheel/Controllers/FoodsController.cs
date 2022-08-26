using MealWheel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MealWheel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FoodsController : Controller
    {
        public MealDbContext mealDbContext;
        public IHostingEnvironment _env;

        public FoodsController(MealDbContext mealDbContext, IHostingEnvironment env)
        {
            this.mealDbContext = mealDbContext;
            this._env = env;
        }
        public IActionResult Index()
        {
            return View(mealDbContext.Food_Products.Include(e => e.category).ToList());
        }
        public IActionResult Create()
        {
            ViewData["savecat"] = new SelectList(mealDbContext.categories, "id", "name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Food_Products food)
        {
            var nam = Path.Combine(_env.WebRootPath + "/Images", Path.GetFileName(food.pic.FileName));
            food.pic.CopyTo(new FileStream(nam, FileMode.Create));
            food.picurl = "Images/" + food.pic.FileName;
            mealDbContext.Add(food);
            mealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            return View(mealDbContext.Food_Products.Include(e=>e.category).FirstOrDefault(e => e.Id == id));
        }

        public IActionResult Edit(int? id)
        {
            ViewData["savecat"] = new SelectList(mealDbContext.categories, "id", "name");
            var prod = mealDbContext.Food_Products.FirstOrDefault(e => e.Id == id);
            return View(prod);
        }

        [HttpPost]
        public IActionResult Edit(Food_Products food)
        {
            if (food.pic != null)
            {
                var nam = Path.Combine(_env.WebRootPath + "/Images", Path.GetFileName(food.pic.FileName));
                food.pic.CopyTo(new FileStream(nam, FileMode.Create));
                food.picurl = "Images/" + food.pic.FileName;
            }
            mealDbContext.Food_Products.Update(food);
            mealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            return View(mealDbContext.Food_Products.Include(e => e.category).FirstOrDefault(e => e.Id == id));
        }
        [HttpPost]
        public IActionResult Delete(Food_Products food)
        {
            mealDbContext.Remove(food);
            mealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
       
    }
}
