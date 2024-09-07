using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitechture.Infrastructure.Services
{
    public interface IEmailService
    {
        Task SendEmail();
    }
}
