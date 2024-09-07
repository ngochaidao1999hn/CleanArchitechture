using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitechture.Infrastructure.Services
{
    public class S3Config
    {
        public string BucketName { get; set; }
        public string AccessID { get; set; }
        public string SecretKey { get; set; }
    }
}
