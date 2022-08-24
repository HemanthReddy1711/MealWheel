using Microsoft.AspNetCore.Mvc;
using MealWheel.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using MealWheel.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace MealWheel.Controllers
{
    public class UserProfileController : Controller
    {
        public MealDbContext _meal;
        IHostingEnvironment _env;
        public ApplicationDbContext _applicationDb;
        public ApplicationUser applicationUser;
        public UserManager<ApplicationUser> UserManager;
        public UserProfileController(MealDbContext meal, IHostingEnvironment env,ApplicationDbContext applicationDb, UserManager<ApplicationUser> _UserManager)
        {
            _meal = meal;
            _env = env;
            _applicationDb=applicationDb;
            UserManager = _UserManager;
        }

        public IActionResult Index()
        {
            string uname = HttpContext.User.Identity.Name.ToString();
            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser.Firstname = _applicationDb.Users.FirstOrDefault(e => e.Email == uname).Firstname;
            applicationUser.Lastname = _applicationDb.Users.FirstOrDefault(e => e.Email == uname).Lastname;
            applicationUser.Email = _applicationDb.Users.FirstOrDefault(e => e.Email == uname).Email;
            applicationUser.Address = _applicationDb.Users.FirstOrDefault(e => e.Email == uname).Address;
            applicationUser.profileurl = _applicationDb.Users.FirstOrDefault(e => e.Email == uname).profileurl;
            applicationUser.MobileNumber = _applicationDb.Users.FirstOrDefault(e => e.Email == uname).MobileNumber;
            return View(applicationUser);
        }
        [HttpPost]
        public IActionResult Index(ApplicationUser myProfile)
        {
            string uname = HttpContext.User.Identity.Name.ToString();
            string uid = UserManager.GetUserId(HttpContext.User);
            myProfile.Id = uid;
            //c47ff13e-a94d-4964-8d8e-be82d530524c
            if (myProfile.profileImage!=null)
            {
                var nam = Path.Combine(_env.WebRootPath + "/Images", Path.GetFileName(myProfile.profileImage.FileName));
                myProfile.profileImage.CopyTo(new FileStream(nam, FileMode.Create));
                myProfile.profileurl = "Images/" + myProfile.profileImage.FileName;
            }
            _applicationDb.Users.Update(myProfile);
            _applicationDb.SaveChanges();
            return View(myProfile);
        }
    }
}
