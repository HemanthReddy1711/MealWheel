using MealWheel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MealWheel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AddressesController : Controller
    {
        public MealDbContext mealDbContext;
        public IHostingEnvironment _env;

        public AddressesController(MealDbContext mealDbContext, IHostingEnvironment env)
        {
            this.mealDbContext = mealDbContext;
            this._env = env;
        }
        public IActionResult Index()
        {
            return View(mealDbContext.addresses.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Address add)
        {

            mealDbContext.Add(add);
            mealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            var addr = mealDbContext.addresses.FirstOrDefault(e => e.id == id);
            return View(addr);
        }
        [HttpPost]
        public IActionResult Edit(Address add)
        {
            mealDbContext.Update(add);
            mealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Details(int? id)
        {
            return View(mealDbContext.addresses.FirstOrDefault(e => e.id == id));

        }
        public IActionResult Delete(int? id)
        {
            return View(mealDbContext.addresses.FirstOrDefault(e => e.id == id));
        }
        [HttpPost]
        public IActionResult Delete(Address add)
        {
            mealDbContext.Remove(add);
            mealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

    }
}
