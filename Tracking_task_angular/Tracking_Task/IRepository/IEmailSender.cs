using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking_Task.IRepository
{
    public interface IEmailSender
    {
        Task Execute(string email, string Subject, string message);
        Task SendEmailAsync(string email, string subject, string Message);
    }
}
