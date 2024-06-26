using EntityLayer.Concrete;
using MessageProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace MessageProject.Controllers
{
    [Authorize]
    public class ProfileInformationController : Controller
    {
        private readonly UserManager<User> _userManager; 

        public ProfileInformationController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var name = User.Identity.Name;
            var user=await _userManager.FindByNameAsync(name);
            ViewBag.username = user.UserName;
            ViewBag.surname = user.SurName;
            ViewBag.mail=user.Email;
            ViewBag.name=user.Name;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Profile(PasswordChangeModel model)
        {
            var name = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(name);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, model.password);
            if(result.Succeeded)
            {
                return RedirectToAction("Mailbox", "Mail");
            }
            return View();
        }
    }
}
