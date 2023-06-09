﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Tracking_Task.IRepository.Repository
{
    public class EmailSender: IEmailSender
    {
        private EmailSetting _emailSetting { get; }
        public EmailSender(IOptions<EmailSetting> emailsetting)
        {
            _emailSetting = emailsetting.Value;
        }




        public Task Execute(string email, string Subject, string message)
        {
            Execute(email, Subject, message).Wait();
            return Task.FromResult(0);
        }

        public async Task SendEmailAsync(string email, string subject, string Message)
        {
            try
            {
                //  string ToEmail = string.IsNullOrEmpty(email) ? _emailSetting.ToEmail : email;
                string ToEmail = email;
                MailMessage Mail = new MailMessage()
                {
                    From = new MailAddress(_emailSetting.UsernameEmail, "User Tracking")
                };
                Mail.To.Add(ToEmail);
                Mail.CC.Add(_emailSetting.CcEmail);
                Mail.Subject = "Tracking User" + subject;
                Mail.Body = Message;
                Mail.IsBodyHtml = true;

                Mail.Priority = MailPriority.High;
                using (SmtpClient smtp = new SmtpClient(_emailSetting.PrimaryDomain, _emailSetting.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSetting.UsernameEmail, _emailSetting.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(Mail);
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
    }
   
}
