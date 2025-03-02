namespace AuthenticationMicroservice.ApplicationCore.Models
{
    public class UserHttpResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public IEnumerable<RoleHttpResponse> Roles { get; set; }
    }
}
