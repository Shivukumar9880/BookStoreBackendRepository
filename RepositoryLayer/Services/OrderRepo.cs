using Microsoft.AspNetCore.Razor.TagHelpers;
using ModelLayer.ModelResponse;
using ModelLayer.ModelsRequest;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class OrderRepo : IOrderRepo
    {
        string connectionString = "Data Source=ZEROBOOK\\SQLEXPRESS;Initial Catalog=Book_Store_Application;Integrated Security=True;Encrypt=False";


        public List<BookResponse> Addorder(AddOrderRequest orders, long userId)
        {
           using( SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("add_order", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("userId", userId);
                cmd.Parameters.AddWithValue("bookId", orders.bookId);
                cmd.Parameters.AddWithValue("@quantity", orders.quantity);
                //cmd.Parameters.AddWithValue("@addressId", orders.AddressId);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                return GetAllOrders(userId);

            }
            
        }

        public List<BookResponse> GetAllOrders(long userId)
        {
            using(SqlConnection conn=new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("get_all_order", conn);

                cmd.CommandType= CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);
                conn.Open();
                SqlDataReader reader=cmd.ExecuteReader();

                List<BookResponse> orders = new List<BookResponse>();

                while(reader.Read())
                {
                    BookResponse book = new BookResponse();

                    book.Id = Convert.ToInt32(reader["bookId"]);
                    book.Author =( reader["Author"]).ToString();
                    book.Title = (reader["Title"]).ToString();
                    book.Description = reader.GetString("detail");
                    book.quantity = reader.GetInt32("order_quantity");
                    book.price = Convert.ToDouble(reader["price"]);
                    orders.Add(book);
                }
                reader.Close();
                conn.Close();
                return orders;

            }
        }

      



        public async Task<string> SendTokKen(string emailTo, string toSendList, double toSendAmount)
        {
            string fromAddress = "shivub9880@gmail.com";
            string toAddress = emailTo;
            string subject = "Your Order List with price";
            string body = toSendList + "/n" + toSendAmount;

            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("shivub9880@gmail.com", "gtcd wlpq zgeh sxjj");
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage(fromAddress, toAddress, subject, body))
                {
                    try
                    {
                        await smtpClient.SendMailAsync(mailMessage);
                        return "Email sent successfully.";
                    }
                    catch (Exception ex)
                    {
                        return $"Error sending email: {ex.Message}";
                    }
                }
            }
        }
        public List<BookResponse> OrderCart(List<AddOrderRequest> orders, long userId, string email)
        {
            foreach (var order in orders)
            {
                Addorder(order, userId);
            }
            double TotalPrice = GetPriceInOrder(userId);
            List<BookResponse> bookList = GetAllOrders(userId);
            string stringList = bookList.ToString();
            SendTokKen(email, stringList, TotalPrice);
            return bookList;
        }


        public double GetPriceInOrder(long userId)
        {
            List<BookResponse> bookList = GetAllOrders(userId);
            double totalPrice = 0;
            foreach (var book in bookList)
            {
                totalPrice += (book.quantity * book.price);
            }
            return totalPrice;
        }
    }
}

