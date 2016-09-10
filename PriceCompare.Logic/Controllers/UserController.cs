using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompare.DataAccess;
using PriceCompare.Entities;

namespace PriceCompare.Logic
{
    public class UserController
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _unitOfWork = unitOfWork;
        }

        public User AddNewUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var result = _unitOfWork.Users.AddIfNotExists(user, u => u.UserId.Equals(user.UserId));

            if (result == null)
            {
                result = new User("","");
                result.ResultCode = User.UserResultCode.UserExist;
                return result;
            }
            _unitOfWork.Complete();

            result.ResultCode = User.UserResultCode.Success;
            return result;
        }

        public User LoginUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var result = _unitOfWork.Users.Get(user.UserId);

            if (result == null)
            {
                result = new User("", "");
                result.ResultCode = User.UserResultCode.UserNotExist;
                return result;
            }

            else if (!result.Password.Equals(user.Password))
            {
               
                result.ResultCode = User.UserResultCode.ErrorPassword;
            }
            else if (result.LoggedIn)
            {
                result.ResultCode = User.UserResultCode.UserLoggedIn;
            }
            else
            {
                result.ResultCode = User.UserResultCode.Success;
                _unitOfWork.Users.UpdateLoginUser(user.UserId,true);
            }

            return result;
        }

        public void LogoutUpdate(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _unitOfWork.Users.UpdateLoginUser(user.UserId, false);

        }
    }
}
