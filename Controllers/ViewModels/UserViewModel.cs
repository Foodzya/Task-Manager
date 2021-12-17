using System;
using Taskmanager.Data.Entities;

namespace Taskmanager.Controllers.ViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public static UserViewModel MapUser(User user)
        {
            if (user != null)
            {
                return new UserViewModel
                { 
                    Email = user.Email, 
                    Username = user.Username 
                };
            }

            throw new NullReferenceException("User was null");
        }
    }
}