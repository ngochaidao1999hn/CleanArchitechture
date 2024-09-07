using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitechture.Infrastructure.Services
{
    public class SendGridConfig
    {
        public string APIKey { get; set; }
        public string From { get; set; }
    }
}
