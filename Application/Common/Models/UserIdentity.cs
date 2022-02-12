using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class UserIdentity
    {
        public Guid UserId { get; set; }
        public string Role { get; set; }
    }
}
