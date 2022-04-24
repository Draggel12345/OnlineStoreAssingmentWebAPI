namespace StoreWebAPI_Assingment.Models.User
{
    public class UserRequest
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string City { get; set; } = null!;

        public string StreetAddress { get; set; } = null!;

        public string ZipCode { get; set; } = null!;
    }
}
