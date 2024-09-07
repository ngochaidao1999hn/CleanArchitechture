namespace CleanArchitechture.Application.Dtos.Auth
{
    public class AuthenDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
