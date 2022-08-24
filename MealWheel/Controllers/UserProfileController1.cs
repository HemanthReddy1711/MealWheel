using Microsoft.AspNetCore.Mvc;
using MealWheel.Models;

namespace MealWheel.Controllers
{
    public class UserProfileController1 : Controller
    {
        public MealDbContext _meal;
        public UserProfileController1(MealDbContext meal)
        {
            _meal = meal;
        }

        public IActionResult Index()
        {
            string uname = HttpContext.User.Identity.Name.ToString();
           // MyProfile myProfile = _meal.myProfiles;
            return View();
        }
    }
}
