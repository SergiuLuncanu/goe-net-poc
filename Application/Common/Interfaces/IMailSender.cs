using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IMailSender
    {
        Task<bool> SendConfirmationEmail(string emailTo, string token);
        Task<bool> SendContactEmail(string from, string message);
    }
}
