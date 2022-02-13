using GOE.Application.Common.Interfaces;
using GOE.Infrastructure.Mail.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GOE.Infrastructure.Mail
{
    public class MailService : IMailSender
    {
        private readonly MailSenderOptions _options;
        private readonly SendGridClient _client;

        public MailService(IOptions<MailSenderOptions> options)
        {
            _options = options.Value;
            _client = new SendGridClient(_options.ApiKey);
        }

        public async Task<bool> SendConfirmationEmail(string emailTo, string token)
        {
            var email = MailHelper.CreateSingleTemplateEmail(
                new EmailAddress(_options.ConfirmationFrom),
                new EmailAddress(emailTo),
                ConfirmationEmailTemplate.TemplateId,
                new ConfirmationEmailTemplate
                {
                    ConfirmationLink = token
                }
            );
            return await SendEmail(email);
        }

        public async Task<bool> SendContactEmail(string from, string message)
        {
            var email = MailHelper.CreateSingleTemplateEmail(
                new EmailAddress(_options.ContactTo),
                new EmailAddress(_options.ContactTo),
                ContactEmailTemplate.TemplateId,
                new ContactEmailTemplate
                {
                    From = from,
                    Message = message
                }
            );
            return await SendEmail(email);
        }

        private async Task<bool> SendEmail(SendGridMessage email)
        {
            var response = await _client.SendEmailAsync(email);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }
    }
}
