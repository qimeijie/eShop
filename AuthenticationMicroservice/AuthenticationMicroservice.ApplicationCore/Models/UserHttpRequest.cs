using AuthenticationMicroservice.ApplicationCore.Entities;

namespace AuthenticationMicroservice.ApplicationCore.Models
{
    public class UserHttpRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
