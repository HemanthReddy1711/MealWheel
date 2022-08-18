using MealWheel.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealWheel.Controllers
{
    public class DiscountController : Controller
    {
        public MealDbContext MealDbContext;

        public DiscountController(MealDbContext mealDbContext)
        {
            this.MealDbContext = mealDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(discount med)
        {

            MealDbContext.Add(med);
            MealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            var med = MealDbContext.discounts.FirstOrDefault(e => e.id == id);
            return View(med);
        }

        [HttpPost]
        public IActionResult Edit(discount med)
        {

            MealDbContext.Update(med);
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
        public IActionResult Delete(discount med)
        {
            MealDbContext.Remove(med);
            MealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

