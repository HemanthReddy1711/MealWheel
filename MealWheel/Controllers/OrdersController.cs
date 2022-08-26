using MealWheel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MealWheel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        
        public MealDbContext mealDbContext;
            public IHostingEnvironment _env;

            public OrdersController(MealDbContext mealDbContext, IHostingEnvironment env)
            {
                this.mealDbContext = mealDbContext;
                this._env = env;
            }
            public IActionResult Index()
            {
                return View(mealDbContext.myOrders.Include(e => e.bill).Include(e=>e.bill.product).ToList());
            }
        public IActionResult Details(int? id)
        {
            return View(mealDbContext.myOrders.Include(e => e.bill).Include(e => e.bill.product).FirstOrDefault(e => e.id == id));

        }
        public IActionResult Delete(int? id)
        {
            return View(mealDbContext.myOrders.Include(e => e.bill).Include(e=>e.bill.product).FirstOrDefault(e => e.id == id));
        }
        [HttpPost]
        public IActionResult Delete(MyOrder or)
        {
            MyOrder billing = mealDbContext.myOrders.FirstOrDefault(e => e.bid == or.bid);
            mealDbContext.Remove(billing);
            mealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

    }
           
    
}
