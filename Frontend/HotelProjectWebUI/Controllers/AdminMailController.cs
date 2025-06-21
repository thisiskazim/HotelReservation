using HotelProjectWebUI.Models.Mail;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace HotelProjectWebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }   
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage= new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "burası bizim mailimiz");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("user", model.RecevierMail);
            mimeMessage.To.Add(mailboxAddressTo);
            var bodyBuilder= new BodyBuilder();
            bodyBuilder.TextBody=model.Body;
            mimeMessage.Body=bodyBuilder.ToMessageBody();
            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smpt.gmail.com", 587, false);
            client.Authenticate("mail", "password key");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
    }
}
