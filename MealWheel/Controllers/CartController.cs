using MealWheel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MealWheel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CartController : Controller
    {
        public MealDbContext mealDbContext;

        public CartController(MealDbContext mealDbContext)
        {
            this.mealDbContext = mealDbContext;
        }

        public IActionResult Index()
        {
            return View(mealDbContext.carts.Include(e => e.product).ToList());
        }

        public IActionResult Details(int? id)
        {
            return View(mealDbContext.carts.Include(e => e.product).FirstOrDefault(e => e.id == id));

        }

        public IActionResult Delete(int? id)
        {
            return View(mealDbContext.carts.Include(e => e.product).FirstOrDefault(e => e.id == id));
        }
        [HttpPost]
        public IActionResult Delete(Cart car)
        {
            Cart car1 = mealDbContext.carts.Where(e => e.uname == car.uname).Where(e => e.pid == car.pid).FirstOrDefault();
            mealDbContext.Remove(car1);
            mealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


    }
}
