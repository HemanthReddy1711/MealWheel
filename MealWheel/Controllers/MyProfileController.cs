using MealWheel.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealWheel.Controllers
{
    public class MyprofileController : Controller
    {
        public MealDbContext MealDbContext;

        public MyprofileController(MealDbContext mealDbContext)
        {
            this.MealDbContext = mealDbContext;
        }

        public IActionResult Index()
        {
            return View(MealDbContext.myProfiles.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MyProfile myProfile)
        {

            MealDbContext.Add(myProfile);
            MealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            var myProfile = MealDbContext.myProfiles.FirstOrDefault(e => e.id == id);
            return View(myProfile);
        }

        [HttpPost]
        public IActionResult Edit(MyProfile myProfile)
        {

            MealDbContext.Update(myProfile);
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
        public IActionResult Delete(MyProfile myProfile)
        {
            MealDbContext.Remove(myProfile);
            MealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

