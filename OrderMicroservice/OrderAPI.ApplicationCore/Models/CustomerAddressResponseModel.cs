using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Models
{
    public class CustomerAddressResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string ProfilePic { get; set; }
        public int UserId { get; set; }

        IEnumerable<UserAddressResponseModel> UserAddressResponseModels { get; set; }
    }
}
