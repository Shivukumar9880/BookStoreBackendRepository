using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ModelsRequest
{
    public class EncryptPasswordClass
    {
        public static string EcryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null;
            }
            else
            {
                
                string salt = BCrypt.Net.BCrypt.GenerateSalt();

                return BCrypt.Net.BCrypt.HashPassword(password, salt);
            }
        }
    }
}
