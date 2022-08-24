using Microsoft.AspNetCore.Mvc;
using MealWheel.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using MealWheel.Areas.Identity.Data;

namespace MealWheel.Controllers
{
    public class UserProfileController : Controller
    {
        public MealDbContext _meal;
        IHostingEnvironment _env;
        public ApplicationDbContext _applicationDb;
        public ApplicationUser applicationUser;
        public UserProfileController(MealDbContext meal, IHostingEnvironment env,ApplicationDbContext applicationDb)
        {
            _meal = meal;
            _env = env;
            _applicationDb=applicationDb;
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
            ApplicationUser a = new ApplicationUser();
            if(myProfile.profileImage!=null)
            {
                var nam = Path.Combine(_env.WebRootPath + "/Images", Path.GetFileName(myProfile.profileImage.FileName));
                myProfile.profileImage.CopyTo(new FileStream(nam, FileMode.Create));
                myProfile.profileurl = "Images/" + myProfile.profileImage.FileName;
            }
            _meal.myProfiles.Update(myProfile);
            _meal.SaveChanges();
            return View(myProfile);
        }
    }
}
