using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Entities
{
    public class User
    {
        public enum UserResultCode
        {
            UserExist,
            UserNotExist,
            ErrorPassword,
            UserLoggedIn,
            Success

        }

        public User()
        {
            
        }
        public User(string userId,string password)
        {
            UserId = userId;
            Password = password;
            LoggedIn = false;
        }

        [Key]
        public string UserId   { get; set; }

        public string Password { get; set; }

        public bool   LoggedIn { get; set; }

        [NotMapped]
        public UserResultCode ResultCode { get; set; }
    }
}
