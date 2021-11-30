using System;
using System.ComponentModel.DataAnnotations;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.InputModels
{
    public class UserInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Wrong email address format. Please, try again")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password length must be between 6 and 30 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public static User MapUser(UserInputModel newUser)
        {
            if (newUser != null)
            {
                return new User() { Email = newUser.Email, Password = newUser.Password, Username = newUser.Username };
            }
            throw new Exception("User was null");
        }
    }
}