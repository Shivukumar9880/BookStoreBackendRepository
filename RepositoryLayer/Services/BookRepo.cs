using ModelLayer.ModelResponse;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RepositoryLayer.Services
{
    public class BookRepo : IBookRepo
    {

        string connectionString = "Data Source=ZEROBOOK\\SQLEXPRESS;Initial Catalog=Book_Store_Application;Integrated Security=True;Encrypt=False";



        public BookResponse GetBookById(int id)
        {
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                sql.Open();
                BookResponse book = new BookResponse();
                SqlCommand cmd = new SqlCommand("get_book", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows) throw new Exception("Book does not exists for given id");
                while (reader.Read())
                {
                    book.Id = reader.GetInt32("bookId");
                    book.Title = reader.GetString("title");
                    book.price = Convert.ToDouble(reader["price"]);
                    book.Author = reader.GetString("author");
                    book.Description = reader.GetString("detail");
                    book.quantity = reader.GetInt32("quantity");
                    book.image = reader.GetString("image");
                }
                return book;
            }
        }
        public List<BookResponse> getAllBooks()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("get_all_books", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                List<BookResponse> books = new List<BookResponse>();
                while (reader.Read())
                {
                    BookResponse book = new BookResponse();
                    book.Id = reader.GetInt32("bookId");
                    book.Title = reader.GetString("title");
                    book.price = Convert.ToDouble(reader["price"]);
                    book.Author = reader.GetString("author");
                    book.Description = reader.GetString("detail");
                    book.quantity = reader.GetInt32("quantity");
                    book.image = reader.GetString("image");
                    books.Add(book);
                }
                return books;
            }
        }

        public BookResponse getBookByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("getBookByName", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                SqlDataReader reader = cmd.ExecuteReader();
                BookResponse book = new BookResponse();

                if (reader.Read())
                {
                    book.Id = reader.GetInt32("bookId");
                    book.Title = reader.GetString("title");
                    book.price = Convert.ToDouble(reader["price"]);
                    book.Author = reader.GetString("author");
                    book.Description = reader.GetString("detail");
                    book.quantity = reader.GetInt32("quantity");
                    book.image = reader.GetString("image");

                }
                reader.Close();
                conn.Close();
                return book;

            }
        }

        public List<BookResponse> GetBookByAuthorName(string authorName)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("getBookByAuthorName", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", authorName);
                SqlDataReader reader = cmd.ExecuteReader();


                List<BookResponse> books = new List<BookResponse>();

                while (reader.Read())
                {
                    BookResponse book = new BookResponse();
                    book.Id = reader.GetInt32("bookId");
                    book.Title = reader.GetString("title");
                    book.price = Convert.ToDouble(reader["price"]);
                    book.Author = reader.GetString("author");
                    book.Description = reader.GetString("detail");
                    book.quantity = reader.GetInt32("quantity");
                    book.image = reader.GetString("image");

                    books.Add(book);
                }
                reader.Close();
                conn.Close();
                return books;

            }
        }

        public List<BookResponse> GetBookByTitleAndAuthorName(string title, string authorName)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("getBookByTitlrAndAuthorName", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", authorName);
                cmd.Parameters.AddWithValue("@title", title);

                SqlDataReader reader = cmd.ExecuteReader();


                List<BookResponse> books = new List<BookResponse>();

                while (reader.Read())
                {
                    BookResponse book = new BookResponse();
                    book.Id = reader.GetInt32("bookId");
                    book.Title = reader.GetString("title");
                    book.price = Convert.ToDouble(reader["price"]);
                    book.Author = reader.GetString("author");
                    book.Description = reader.GetString("detail");
                    book.quantity = reader.GetInt32("quantity");
                    book.image = reader.GetString("image");

                    books.Add(book);
                }
                reader.Close();
                conn.Close();
                return books;

            }

        }
    }

}
