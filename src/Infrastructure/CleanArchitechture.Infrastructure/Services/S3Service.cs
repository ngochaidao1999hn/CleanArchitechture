using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Options;

namespace CleanArchitechture.Infrastructure.Services
{
    public class S3Service : IS3Service
    {
        private S3Config _config;
        public S3Service(IOptions<S3Config> config)
        {
            _config = config.Value;
        }
        public async Task<string> SendFileToS3(string bucketName, string localFilePath)
        {
            using (var client = new AmazonS3Client(_config.AccessID, _config.SecretKey))
            {
                var fileTransferUtility = new TransferUtility(client);
                await fileTransferUtility.UploadAsync(localFilePath, bucketName);
                return Path.GetFileName(Path.GetFullPath(localFilePath));
            }
        }
    }
}
