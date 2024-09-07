using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitechture.Infrastructure.Services
{
    public interface IS3Service
    {
        Task<string> SendFileToS3(string bucketName, string localFilePath);
    }
}
