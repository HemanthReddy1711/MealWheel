using Microsoft.AspNetCore.Mvc;
using MealWheel.Models;

namespace MealWheel.Controllers
{
    public class UserProfileController : Controller
    {
        public MealDbContext _meal;
        public UserProfileController(MealDbContext meal)
        {
            _meal = meal;
        }

        public IActionResult Index()
        {
            string uname = HttpContext.User.Identity.Name.ToString();
            MyProfile myProfile = _meal.myProfiles.FirstOrDefault(e=>e.email==uname);

            return View(myProfile);
        }
        [HttpPost]
        public IActionResult Index(MyProfile myProfile)
        {

            return View(myProfile);
        }
    }
}
