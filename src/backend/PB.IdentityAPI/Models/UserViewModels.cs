using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PB.IdentityAPI.Models
{
    public class UserViewModels
    {
        public class UserRegister
        {
            [Required(ErrorMessage = "The field {0} it's necessary")]
            [EmailAddress(ErrorMessage = "The Field {0} is invalid")]
            public string Email { get; set; }

            [Required(ErrorMessage = "The field {0} it's necessary")]
            [StringLength(100, ErrorMessage ="The field {0} needs {2} or {1} characters", MinimumLength =6)]
            public string Password { get; set; }

            [Compare("Password", ErrorMessage ="The password doesn't match")]
            public string RePassword { get; set; }  
        }
        public class UserLogin
        {

            [Required(ErrorMessage = "The field {0} it's necessary")]
            [EmailAddress(ErrorMessage = "The Field {0} is invalid")]
            public string Email { get; set; }

            [Required(ErrorMessage = "The field {0} it's necessary")]
            [StringLength(100, ErrorMessage = "The field {0} needs {2} or {1} characters", MinimumLength = 6)]
            public string Password { get; set; }
        }

        public class UserResponseLogin
        {
            public string AccessToken { get; set; }
            public double ExpiresIn { get; set; }
            public UserToken UserToken { get; set; } 
        }
        public class UserToken
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public IEnumerable<UserClaim> Claims { get; set; }
        }
        public class UserClaim
        {
            public string Value { get; set; }
            public string Type { get; set; }
        }
        public class UserResetPasswordToken
        {
            public string Email { get; set; }
        }
        public class UserResetPassword
        {
            [Required(ErrorMessage = "The field {0} it's necessary")]
            [EmailAddress(ErrorMessage = "The Field {0} is invalid")]
            public string Email { get; set; }

            [Required(ErrorMessage = "The field {0} it's necessary")]
            [StringLength(100, ErrorMessage = "The field {0} needs {2} or {1} characters", MinimumLength = 6)]
            public string Password { get; set; }

            [Compare("Password", ErrorMessage = "The password doesn't match")]
            public string RePassword { get; set; }

            public string Token { get; set; }
        }
    }
}