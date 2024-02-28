using ModelLayer.ModelsRequest;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.ModelResponse;

namespace RepositoryLayer.Services
{
    public class AddressRepo : IAddresseRepo
    {


        string connectionString = "Data Source=ZEROBOOK\\SQLEXPRESS;Initial Catalog=Book_Store_Application;Integrated Security=True;Encrypt=False";


        public void AddAddress(AddressRequest address)
        {
            using (SqlConnection sql = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("add_Address", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", address.userId);
                cmd.Parameters.AddWithValue("@fullAddress", address.fullAddress);
                cmd.Parameters.AddWithValue("@city", address.city);
                cmd.Parameters.AddWithValue("@state", address.state);
                cmd.Parameters.AddWithValue("@type", address.type);
                sql.Open();
                cmd.ExecuteNonQuery();
           
            }
        }



        public IEnumerable<AddressResponse> GetAddress(long userId)
        {
            using (SqlConnection sql = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("get_address", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                sql.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<AddressResponse> addresses = new List<AddressResponse>();
                while (reader.Read())
                {
                    AddressResponse response = new AddressResponse();
                    response.fullAddress = reader.GetString("fullAddress");
                    response.state = reader.GetString("state");
                    response.city = reader.GetString("city");
                    response.type = reader.GetInt32("type");
                    response.id= reader.GetInt32("AddressId");
                    addresses.Add(response);
                }
                return addresses;
            }
        }

        public void UpdateAddress(AddressUpdateRequest address)
        {

            using (SqlConnection sql = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("update_Address", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", address.userId);
                cmd.Parameters.AddWithValue("@fullAddress", address.fullAddress);
                cmd.Parameters.AddWithValue("@city", address.city);
                cmd.Parameters.AddWithValue("@state", address.state);
                cmd.Parameters.AddWithValue("@id", address.id);

                sql.Open();
                cmd.ExecuteNonQuery();
            }
                
        }
    }



}
