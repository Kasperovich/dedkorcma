using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DedKorchma.BL.Service;
using DedKorchma.Models;
using DedKorchma.Models.ViewModels.AdminViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DedKorchma.Controllers
{
   [Authorize(Roles = "TechAdmin,Admin")]
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>(); }
            private set { _roleManager = value; }
        }

        // GET: Admin
        public ActionResult Index()
        {
            var users = UserSevice.GetAll()
                .Select(s => new UserViewModel(s, UserManager.GetRoles(s.Id).ToList()))
                .ToList();

            return View(users);
        }
        [HttpGet]
        public ActionResult EditUser(string userId)
        {
            var user = UserManager.FindById(userId);

            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var roles = RoleManager.Roles.ToList();
            var userRoles = UserManager.GetRoles(userId);
            var model = new EditUserViewModel(user);

            model.RolesList = roles.ToList()
                .Select(x => new SelectListItem
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                })
                .ToList();


            return View(model);
        }
        [HttpPost]
        public ActionResult EditUser(EditUserViewModel editUser, List<string> selectedRole)
        {
            if (editUser.Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = UserManager.FindById(editUser.Id);

            if (!ModelState.IsValid) return View(editUser);

            var userRoles = UserManager.GetRoles(user.Id);

            var result = UserManager.AddToRoles(user.Id,
                selectedRole.Except(userRoles).ToArray());

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", result.Errors.First());
                return View(editUser);
            }

            result = UserManager.RemoveFromRoles(user.Id,
                userRoles.Except(selectedRole).ToArray());

            user.IsDeleted = editUser.isDeleted;
            user.Email = editUser.Email;
            user.UserName = editUser.Email;

            UserManager.Update(user);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", result.Errors.First());
                return View(editUser);
            }
            return RedirectToAction("Index");
        }
    }
}