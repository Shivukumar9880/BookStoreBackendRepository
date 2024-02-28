using ModelLayer.ModelResponse;
using ModelLayer.ModelsRequest;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class WishListRepo : IwishListRepo
    {
        string connectionString = "Data Source=ZEROBOOK\\SQLEXPRESS;Initial Catalog=Book_Store_Application;Integrated Security=True;Encrypt=False";

        public List<BookResponse> AddToWishList(int bookId, long userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("add_to_wishList", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@bookId",bookId);
                    //cmd.Parameters.AddWithValue("@quantity", cartRequest.quantity);
                    //SqlParameter cartId = new SqlParameter("@cartId", SqlDbType.Int);
                    //cartId.Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add(cartId);
                    cmd.ExecuteNonQuery();
                    return GetWishListBooks(userId);
                }
            }
            catch (SqlException ex)
            {
                // Handle the exception appropriately, e.g., log the error or notify the user
                Console.WriteLine("Error: " + ex.Message);
                // Return an empty list or null to indicate the failure
                return new List<BookResponse>();
            }
        }

        public List<BookResponse> GetWishListBooks(long userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("get_wishList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                SqlDataReader reader = cmd.ExecuteReader();
                List<BookResponse> boolList = new List<BookResponse>();
                while (reader.Read())
                {
                    BookResponse book = new BookResponse();
                    book.Id = Convert.ToInt32(reader["bookId"]);
                    book.Author = (reader["author"]).ToString();
                    book.Title = reader.GetString("Title");
                    book.Description = reader.GetString("detail");
                    //book.quantity = reader.GetInt32("cart_quantity");
                    book.price = Convert.ToDouble(reader["price"]);
                    book.image = reader.GetString("image");
                    boolList.Add(book);
                }
                return boolList;
            }
        }
    }
}
