using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Api.Models.User
{
    public class UserDto : LogingUserDto
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
