using Core.Utilities.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers
{
  
    public class MailController : BaseController
    {
        private readonly IMailHelper _mailHelper;
        public MailController(IMailHelper mailHelper)
        {
            _mailHelper = mailHelper;
        }

        [HttpPost]
        public async Task<IActionResult> SendMail([FromBody] SendMailModel mail)
        {
            try
            {
                await _mailHelper.SendMailAsync(mail.Subject, mail.Mail, mail.Recepients);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
