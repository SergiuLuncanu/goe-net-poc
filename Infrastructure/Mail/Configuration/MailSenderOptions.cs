using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mail.Configuration
{
    public class MailSenderOptions
    {
        public string ApiKey { get; set; }
        public string ConfirmationFrom { get; set; }
        public string ContactTo { get; set; }
    }
}
