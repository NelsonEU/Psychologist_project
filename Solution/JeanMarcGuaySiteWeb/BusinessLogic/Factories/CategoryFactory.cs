using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Factories
{
    public class CategoryFactory
    {
        #region Constructeur
        private string _cnnStr;
        public CategoryFactory(string cnnStr)
        {
            _cnnStr = cnnStr;
        }
        #endregion

        #region GetAll
        public Category[] GetAll()
        {
            List<Category> categoryList = new List<Category>();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM categories WHERE deletionDate IS NULL";

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int _id = (Int32)reader["category_id"];
                    string _name = reader["name"].ToString();
                    string _pictureUrl = reader["picture_url"].ToString();
                    string _redirectUrl = reader["redirect_url"].ToString();

                    Category category = new Category();
                    category.categoryId = _id;
                    category.name = _name;
                    category.pictureUrl = _pictureUrl;
                    category.urlRedirect = _redirectUrl;

                    categoryList.Add(category);
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return categoryList.ToArray();
        }
        #endregion

        #region GetCategoryById
        public Category GetCategoryById(int id)
        {
            Category category = new Category();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM categories WHERE category_id=@id AND deletionDate IS NULL";
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int _id = (Int32)reader["category_id"];
                    string _name = reader["name"].ToString();
                    string _pictureUrl = reader["picture_url"].ToString();
                    string _redirectUrl = reader["redirect_url"].ToString();

                    category.categoryId = _id;
                    category.name = _name;
                    category.pictureUrl = _pictureUrl;
                    category.urlRedirect = _redirectUrl;

                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return category;
        }
        #endregion

        #region Add
        public void Add(int category_id, string name, string url)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "INSERT INTO Categories(category_id, name, picture_url, creationDate) VALUES (@category_id, @name, @url, NOW())";
                cmd.Parameters.AddWithValue("@category_id", category_id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@url", url);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region Delete
        public void delete(int id)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "UPDATE categories SET deletionDate = NOW() WHERE category_id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region Count
        public int Count()
        {
            int total;
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM categories WHERE deletionDate IS NULL";
                total = (int)cmd.ExecuteScalar();
            }
            finally
            {
                cnn.Close();
            }

            return total;
        }


        #endregion
    }
}
