using MealWheel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MealWheel.Controllers
{
    public class FavoritesController : Controller
    {
        public MealDbContext MealDbContext;

        public FavoritesController(MealDbContext mealDbContext)
        {
            this.MealDbContext = mealDbContext;
        }

        public IActionResult Index()
        {
            return View(MealDbContext.favorites.Include(e => e.product).ToList());
        }
        public IActionResult Details(int? id)
        {
            return View(MealDbContext.favorites.Include(e => e.product).FirstOrDefault(e => e.id == id));

        }
        public IActionResult Delete(int? id)
        {
            return View(MealDbContext.favorites.Include(e=>e.product).FirstOrDefault(e => e.id == id));
        }
        [HttpPost]
        public IActionResult Delete(favorite fav)
        {
            favorite fav1=MealDbContext.favorites.Where(e=>e.uname==fav.uname).Where(e=>e.pid==fav.pid).FirstOrDefault();
            MealDbContext.Remove(fav1);
            MealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
