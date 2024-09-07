using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitechture.Application.Abstraction
{
    public class ValidationError
    {
        public ValidationError(string propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }
        public string PropertyName { get; }
        public string Message { get; }
    }
}
