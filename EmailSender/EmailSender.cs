using MimeKit;
using System;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using EmailSender.Helpers;
using EmailSender.TemplateModels;
using EmailSender.Services;
using Models.Configurations;

namespace EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpConfiguration _smtpConfiguration;

        public EmailSender(ISmtpConfigurationService smtpConfigurationService)
        {
            _smtpConfiguration = smtpConfigurationService.GetConfiguration();
        }

        public async Task SendAsync(TemplateModel message)
        {
            MimeMessage emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Сайт электронной записи", _smtpConfiguration.Email));
            emailMessage.To.Add(new MailboxAddress("", message.User.Email));
            emailMessage.Subject = message.Subject;
            emailMessage.Body = message.GetMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpConfiguration.Host, _smtpConfiguration.Port, _smtpConfiguration.UseSsl);
                await client.AuthenticateAsync(_smtpConfiguration.Email, _smtpConfiguration.Password);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
