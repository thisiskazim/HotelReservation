using HotelProjectEntityLayer.Concrete;
using HotelProjectWebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProjectWebUI.Controllers
{
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var  values=_userManager.Users.ToList();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult>AssignRole(int id)
        {
            var user=_userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userId"]=user.Id;
            var roles=_roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel>roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach(var item in roles)
            {
                RoleAssignViewModel roleAssignViewModel = new RoleAssignViewModel();
                roleAssignViewModel.RoleID = item.Id;
                roleAssignViewModel.RoleName = item.Name;
                roleAssignViewModel.RoleExist = userRoles.Contains(item.Name);
                roleAssignViewModels.Add(roleAssignViewModel);
            }
            return View(roleAssignViewModels);

        }


        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roleAssignViews)
        {
            var userid = (int)TempData["userId"];
            var user=_userManager.Users.FirstOrDefault(x=>x.Id ==userid);
            foreach(var item in roleAssignViews)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else 
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("Index");
        }

    }
}
