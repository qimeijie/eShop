namespace AuthenticationMicroservice.ApplicationCore.Models
{
    public class AuthenticationHttpResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public int ExpireIn { get; set; }
    }
}
