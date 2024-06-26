using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using MessageProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MessageProject.Controllers
{
    [Authorize]
    public class MailController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMessageDal _messageDal;

        public MailController(UserManager<User> userManager, IMessageDal messageDal)
        {
            _userManager = userManager;
            _messageDal = messageDal;
        }

        public async Task<IActionResult> MailSenderList()
        {
            var name = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(name);
            int ID = user.Id;
            var SenderMessages=_messageDal.GetMessagedSenderWithInclude(ID);
            return View(SenderMessages);
        }
        public async Task<IActionResult> MailReceiverList()
        {
            var name = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(name);
            int ID = user.Id;
            var ReceiverMessages=_messageDal.GetMessagedReceiverWithInclude(ID);
            return View(ReceiverMessages);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
       public async Task<IActionResult> SendMessage(Message message)
        {
            var name = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(name);
            int ID= user.Id;
            var xx = new Message
            {
                Title = message.Title,
                Content = message.Content,
                Date = DateTime.Now,
                SenderId = ID,
                ReceiverId=message.ReceiverId,
            };
            _messageDal.SendMessage(xx);
            return RedirectToAction("MailSenderList", "Mail");
        }
    }
}
