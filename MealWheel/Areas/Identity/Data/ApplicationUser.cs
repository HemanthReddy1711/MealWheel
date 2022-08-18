using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MealWheel.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public string MobileNumber { get; set; }
    public string? profileurl { get; set; }
    [NotMapped]
    public IFormFile profileImage { get; set; }
}

