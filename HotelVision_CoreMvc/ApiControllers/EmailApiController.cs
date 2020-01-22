using System.Net;
using System.Net.Mail;
using HotelVision_CoreMvc.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelVision_CoreMvc.ApiControllers
{
    /// <summary>
    /// Email Api Controller
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [Route("Api/Email")]
    public class EmailApiController : Controller
    {
        private readonly ILogger<EmailApiController> logger;
        private readonly DatabaseContext databaseContext;

        public EmailApiController(ILogger<EmailApiController> logger, DatabaseContext databaseContext)
        {
            this.logger = logger;
            this.databaseContext = databaseContext;
        }
        //// <summary>
        /// POST: Email
        /// </summary>
        /// <param name="customer"></param>
        /// <response code="201">Returns the newly created Customer</response>
        /// <response code="400">If the Customer is null or invalid</response>            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ValidateAntiForgeryToken]
        [Route("/SendAndSave")]
        public IActionResult SendAndSaveMail([Bind("From,To,Body,Subject")] MailMessage mailMessage)
        {
            if (ModelState.IsValid)
            {
                //Send Email
                SmtpClient client = new SmtpClient("mysmtpserver");
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("username", "password");
                mailMessage.From = new MailAddress("whoever@me.com");
                mailMessage.To.Add("receiver@me.com");
                mailMessage.Body = "body";
                mailMessage.Subject = "subject";
                client.Send(mailMessage);

                //Save Email
                databaseContext.Add(mailMessage);
                databaseContext.SaveChanges();
                return CreatedAtRoute("Api/Email/SendAndSave", mailMessage);
            }
            return BadRequest(ModelState);
        }
    }
}
