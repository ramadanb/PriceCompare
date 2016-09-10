using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.DataAccess.Repositories;
using PriceCompare.Entities;

namespace PriceCompare.DataAccess.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        User Get(string userId);
        void UpdateLoginUser(string userId, bool value);
    }
}
