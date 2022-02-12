using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mail.Configuration
{
    internal class ContactEmailTemplate
    {
        public static string TemplateId = "d-bcf06df134d44489873e31e3a4287efb";
        public string From { get; set; }
        public string Message { get; set; }
    }
}
