using BusinessLayer.Interfaces;
using ModelLayer.ModelsRequest;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserBusiness : IUserBusiness
    {
        private IUserRepo _userRepo;

        public UserBusiness(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }


        public UserEntityRequestModel Register(UserEntityRequestModel model)
        {
            return _userRepo.Register(model);
        }

        public Object[] UserLogin(UserLoginRequest loginModel)
        {
            return _userRepo.UserLogin(loginModel);
        }
        public string ForgotPassword(string email)
        {
            return _userRepo.ForgotPassword(email);
        }

        public string ResetPassword(string email, string password)
        {
            return _userRepo.ResetPassword(email, password);
        }
    }
}
