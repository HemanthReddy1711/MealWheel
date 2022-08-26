using MealWheel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealWheel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DiscountController : Controller
    {
        public MealDbContext MealDbContext;

        public DiscountController(MealDbContext mealDbContext)
        {
            this.MealDbContext = mealDbContext;
        }

        public IActionResult Index()
        {
            return View(MealDbContext.discounts.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(discount discount)
        {

            MealDbContext.Add(discount);
            MealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            var discount = MealDbContext.discounts.FirstOrDefault(e => e.id == id);
            return View(discount);
        }

        [HttpPost]
        public IActionResult Edit(discount discount)
        {

            MealDbContext.Update(discount);
            MealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            return View(MealDbContext.discounts.FirstOrDefault(e => e.id == id));
        }


        public IActionResult Delete(int? id)
        {
            return View(MealDbContext.discounts.FirstOrDefault(e => e.id == id));
        }
        [HttpPost]
        public IActionResult Delete(discount discount)
        {
            MealDbContext.Remove(discount);
            MealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

