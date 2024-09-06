using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
namespace Ocbuu.Services
{
    public class EmailSenderServ : IEmailSender
    {
        private readonly ILogger<EmailSenderServ> _logger;
        public EmailSenderServ(ILogger<EmailSenderServ> logger)
        {
            _logger = logger; 
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Log the email details to the console for now
            _logger.LogInformation($"Sending email to {email}, Subject: {subject}, Message: {htmlMessage}");
            return Task.CompletedTask;
        }
    }
}