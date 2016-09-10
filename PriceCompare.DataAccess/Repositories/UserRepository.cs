using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.DataAccess.Interfaces;
using PriceCompare.Entities;

namespace PriceCompare.DataAccess.Repositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public User Get(string userId)
        {
           return DbSet.Find(userId);
        }

        public void UpdateLoginUser(string userId, bool value)
        {
            User user = Get(userId);
            user.LoggedIn = value;
            Save();
        }
        
    }
}
