using ModelLayer.ModelsRequest;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRepo
    {
        public UserEntityRequestModel Register(UserEntityRequestModel model);
        public Object[] UserLogin(UserLoginRequest loginModel);
        public string ForgotPassword(string email);

        public string ResetPassword(string email, string password);


    }
}
