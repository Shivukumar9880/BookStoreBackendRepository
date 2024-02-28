using Microsoft.Extensions.Configuration;
using ModelLayer.ModelsRequest;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class UserRepo : IUserRepo
    {
        string connectionString = "Data Source=ZEROBOOK\\SQLEXPRESS;Initial Catalog=Book_Store_Application;Integrated Security=True;Encrypt=False";


        private readonly IConfiguration configuration;

        public UserRepo( IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public UserEntityRequestModel Register(UserEntityRequestModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd=new SqlCommand("InsertUser" , connection);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", model.UserName);
                cmd.Parameters.AddWithValue("@Email", model.Email);

                var Pass=EncryptPasswordClass.EcryptPassword(model.Password);
                cmd.Parameters.AddWithValue("@Password", Pass);
                cmd.Parameters.AddWithValue("MobileNumber", model.MobileNumber);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                return model;

            }
              
        }
        public UserEntity GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null; ;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetUserByEmail", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue ("@Email", email);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    UserEntity user = new UserEntity
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        UserName = reader["UserName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        MobileNumber = reader["MobileNumber"].ToString()

                    };

                    reader.Close();
                    connection.Close();
                    return user;

                }
                reader.Close();
                connection.Close();
                return null;
            }

         
        }

        public Object[] UserLogin(UserLoginRequest loginModel)
        {
            if (string.IsNullOrEmpty(loginModel.Email))
            {
                return null;
            }
            var user= GetUserByEmail(loginModel.Email);
            if (user == null)
            {
                return null;
            }
            //                            input password    ||    database password
            if (!BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password))
            {
                return null;
            }
            String token = new GenerateTokenClass().GenerateSecurityToken(loginModel.Email, user.UserId, configuration);

            return  new Object[] {token,user};

        }

        public string ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }
            var user = GetUserByEmail(email);
            if (user == null)
            {
                return null;
            }
            String token = new GenerateTokenClass().GenerateSecurityToken(email, user.UserId, configuration);

            return token;
        }

        public string ResetPassword(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var user = GetUserByEmail(email);

                if (user == null)
                {
                    return null;
                }
                connection.Open();
                user.Password = EncryptPasswordClass.EcryptPassword(password);
                connection.Close();
                return password;

            }
        }

    }
}
