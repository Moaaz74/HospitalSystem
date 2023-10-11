using HospitalSystem.Models;
using HospitalSystem.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Utilities
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext applicationDbContext;

        public DbInitializer(UserManager<ApplicationUser> _userManager  , RoleManager<IdentityRole> _roleManager,
            ApplicationDbContext _applicationDbContext)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            applicationDbContext = _applicationDbContext;
        }

        public void Initialize()
        {
            try
            {
                if(applicationDbContext.Database.GetPendingMigrations().Count() > 0)
                    applicationDbContext.Database.Migrate(); 


            }catch (Exception ex) { throw; }

            if(!roleManager.RoleExistsAsync(SystemRoles.Admin).GetAwaiter().GetResult())
            {
                 roleManager.CreateAsync(new IdentityRole(SystemRoles.Admin)).GetAwaiter().GetResult();
                 roleManager.CreateAsync(new IdentityRole(SystemRoles.Patient)).GetAwaiter().GetResult();
                 roleManager.CreateAsync(new IdentityRole(SystemRoles.Doctor)).GetAwaiter().GetResult();

                userManager.CreateAsync(new ApplicationUser()
                {
                    UserName = "Moaaz74",
                    Email = "moaazmostafa7474@gmail.com",
                },"Mo@@z_Admin74").GetAwaiter().GetResult();

                var AppUser = applicationDbContext.ApplicationUsers.FirstOrDefault(x => x.Email == "moaazmostafa7474@gmail.com");
                if (AppUser != null)
                    userManager.AddToRoleAsync(AppUser, SystemRoles.Admin).GetAwaiter().GetResult();
            }
        }
    }
}
