﻿using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using PirateTARpe23.Core.Dto;
using PirateTARpe23.Core.ServiceInterface;

namespace PirateTARpe23.ApplicationServices.Services
{
    public class EmailsServices : IEmailsServices
    {
        private readonly IConfiguration _configuration;

        public EmailsServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(EmailDto dto)
        {
            var email = new MimeMessage();

            _configuration.GetSection("EmailUserName").Value = "l6he";
            _configuration.GetSection("EmailHost").Value = "green@day.com";
            _configuration.GetSection("EmailPassword").Value = "!23aBC";


            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;
            var builder = new BodyBuilder
            {
                HtmlBody = dto.Body,
            };

            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            //google smtp app password = GalacticTitansSMTP ucgp mjrl bdbh ilyh 
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public void SendEmailToken(EmailTokenDto dto, string token)
        {
            dto.Token = token;
            var email = new MimeMessage();

            _configuration.GetSection("EmailUserName").Value = "l6he";
            _configuration.GetSection("EmailHost").Value = "green@day.com";
            _configuration.GetSection("EmailPassword").Value = "!23aBC";


            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;
            var builder = new BodyBuilder
            {
                HtmlBody = dto.Body,
            };

            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            //google smtp app password = GalacticTitansSMTP ucgp mjrl bdbh ilyh                   what the fuck does this mean
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
