using MealWheel.Areas.Identity.Data;
using MealWheel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razorpay.Api;
using System.Diagnostics;

namespace MealWheel.Controllers
{
    public class HomeController : Controller
    {
        public const string raz_key = "rzp_test_cfElqRcKNLh6aA";
        public const string raz_secret = "3QaoZiwflNJbQftFonT55elT";
        private readonly ILogger<HomeController> _logger;
        public MealDbContext _meal;
        public UserManager<ApplicationUser> UserManager;
        public SignInManager<ApplicationUser> SignInManager;

        public HomeController(ILogger<HomeController> logger, MealDbContext meal)
        {
            _logger = logger;
            _meal = meal;
        }

        public IActionResult Index(int? i)
        {

            bool val = HttpContext.User.Identity.IsAuthenticated;
            if (val)
            {
                string us = HttpContext.User.Identity.Name.ToString();
                string co = _meal.carts.Where(e=>e.uname==us).Count().ToString();
                ViewData["hello"] = co;
            }
            return View(_meal.Food_Products.ToList());
        }

        public IActionResult add_fav(int id)
        {
            Food_Products f = _meal.Food_Products.ToList().FirstOrDefault(e => e.Id == id);
            if(f.fav==true)
            {
                favorite fa = _meal.favorites.ToList().FirstOrDefault(e => e.pid == f.Id);
                _meal.favorites.Remove(fa);
                _meal.SaveChanges();
                f.fav = false;
            }
            else
            {
                favorite fa = new favorite();
                fa.uname = HttpContext.User.Identity.Name.ToString();
                fa.product = f;
                _meal.favorites.Add(fa);
                _meal.SaveChanges();
                f.fav = true;
            }
            _meal.Food_Products.Update(f);
            _meal.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            return View(_meal.Food_Products.ToList().FirstOrDefault(e=>e.Id==id));
        }
        [HttpPost]
        public IActionResult Details(Food_Products p)
        {
            Cart cart = new Cart();
            cart.pid = p.Id;
            cart.uname = HttpContext.User.Identity.Name.ToString();
            cart.totalPrice = p.quantity * p.Price;
            _meal.carts.Add(cart);
            _meal.SaveChanges();
            return RedirectToAction(nameof(cart));
        }

        public IActionResult cart()
        {
            string us = HttpContext.User.Identity.Name.ToString();
            var cati = _meal.carts.Include(c => c.product).Where(p => p.uname == us).ToList();
            ViewData["hello"] = _meal.carts.Where(p => p.uname == us).Sum(c => c.totalPrice).ToString();
            return View(cati);
        }
        public IActionResult Remove_cart(int? id)
        {
            var cartss = _meal.carts.FirstOrDefault(c => c.id == id);
            _meal.Remove(cartss);
            _meal.SaveChanges();
            return RedirectToAction(nameof(Cart));
        }
        public IActionResult payment(int? id)
        {
            var products = _meal.Food_Products.Include(c => c.category).FirstOrDefault(p => p.Id == id);
            var oid = Createorder(products);
            payOptions pay = new payOptions()
            {
                key = raz_key,
                Amountinsub = products.Price * 100,
                currency = "INR",
                name = "Global Logic MeanWheel",
                Description = "Good dishes for Global Logic Employes",
                ImageUrl = "",
                Orderid = oid,
                productid = products.Id

            };
            return View(pay);

        }

        public IActionResult Success(payOptions pay)
        {
            return View();
        }
        public String Createorder(Food_Products products)
        {
            try
            {
                RazorpayClient client = new RazorpayClient(raz_key, raz_secret);
                Dictionary<string, object> input = new Dictionary<string, object>();
                input.Add("amount", products.Price * 100);
                input.Add("currency", "INR");
                input.Add("receipt", "12121");

                Order ord_Res = client.Order.Create(input);
                var oid = ord_Res.Attributes["id"].ToString();
                return oid;

            }
            catch
            {
                return null;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}