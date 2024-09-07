using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitechture.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private string apiKey;
        private string from;
        private readonly SendGridClient _client;
        private readonly SendGridConfig _config;
        public EmailService(IOptions<SendGridConfig> option)
        {
            _config = option.Value;
            apiKey = _config.APIKey;
            from = _config.From;
        }
        public Task SendEmail()
        {
            throw new NotImplementedException();
        }
    }
}
