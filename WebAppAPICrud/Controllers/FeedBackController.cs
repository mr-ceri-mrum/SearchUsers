using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WebAppAPICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {

        [HttpPost]
        public IActionResult FeedBack(string name, string phone, string text)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("devante34@ethereal.email"));
                email.To.Add(MailboxAddress.Parse("devante34@ethereal.email"));
                email.Subject = "Navi Connect";
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text =
                    "<h3>Name :" + name + "</br> Phone:" +
                    phone + "</br></h3>" +
                    "<h1> Text :" + text + "</h1>"
                };

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("devante34@ethereal.email", "pass");
                smtp.Send(email);
                smtp.Disconnect(true);

                return Ok();
            }
            catch
            {
                return BadRequest("Send Eror");
            }
            
        }
        [HttpGet]
        public async Task<ActionResult> Execute(string text, string name, string phone)
        {
            
            var apiKey = "key";

            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("supnaviconnect@gmail.com", "Navi Connect");

            var subject = "Sending with SendGrid is Fun";

            var to = new EmailAddress("zhunussoffilias0216@gmail.com", "Ilyas");
            var plainTextContent = text;
            var htmlContent
               = $"<h3>User info: {name}</h3></br> <b>{phone}</br></b> </br>" +
                 $"<strong>{text}</strong>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
          

            var response = await client.SendEmailAsync(msg); 
            return Ok(response);
        }
    }
}
