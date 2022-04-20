using System.ComponentModel.DataAnnotations;

namespace StoreWebAPI_Assingment.Models.User
{
    public class UserEntity
    {
        public UserEntity()
        {

        }

        public UserEntity
            (Guid id,
            string firstName,
            string lastName,
            string emailAddress,
            string password,
            string phoneNumber,
            string country,
            string city,
            string streetAddress,
            string zipCode)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Password = password;
            PhoneNumber = phoneNumber;
            Country = country;
            City = city;
            StreetAddress = streetAddress;
            ZipCode = zipCode;
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string EmailAddress { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Country { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        [Required]
        public string StreetAddress { get; set; } = null!;
        [Required]
        public string ZipCode { get; set; } = null!;

    }
}
