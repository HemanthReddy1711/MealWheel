using MealWheel.Models;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MealWheel.Controllers
{
    public class MyprofileController : Controller
    {
        public MealDbContext MealDbContext;
        public IHostingEnvironment _env;

        public MyprofileController(MealDbContext mealDbContext, IHostingEnvironment env)
        {
            this.MealDbContext = mealDbContext;
            this._env = env;
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

            if (myProfile.profileImage != null)
            {
                var nam = Path.Combine(_env.WebRootPath + "/Images", Path.GetFileName(myProfile.profileImage.FileName));
                myProfile.profileImage.CopyTo(new FileStream(nam, FileMode.Create));
                myProfile.profileurl = "Images/" + myProfile.profileImage.FileName;
            }

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
            if (myProfile.profileImage != null)
            {
                var nam = Path.Combine(_env.WebRootPath + "/Images", Path.GetFileName(myProfile.profileImage.FileName));
                myProfile.profileImage.CopyTo(new FileStream(nam, FileMode.Create));
                myProfile.profileurl = "Images/" + myProfile.profileImage.FileName;
            }

            MealDbContext.Update(myProfile);
            MealDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            return View(MealDbContext.myProfiles.FirstOrDefault(e => e.id == id));
        }


        public IActionResult Delete(int? id)
        {
            return View(MealDbContext.myProfiles.FirstOrDefault(e => e.id == id));
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

