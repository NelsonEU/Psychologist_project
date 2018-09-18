using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Factories
{
    public class UserFactory
    {

        #region Constructeur
        private string _cnnStr;
        public UserFactory(string cnnStr)
        {
            _cnnStr = cnnStr;
        }
        #endregion

        #region Add

        public void Add(string lastname, string firstname, string email, string password, bool admin, bool subscriber)
        {

            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "INSERT INTO users(lastname, firstname, email, password, admin, subscriber, creationDate) VALUES (@lastname, @firstname, @email, @password, @admin, @subscriber, @creationDate)";
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@admin", admin);
                cmd.Parameters.AddWithValue("@subscriber", subscriber);
                cmd.Parameters.AddWithValue("@creationDate", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }

        }

        #endregion

        #region GetByEmail

        /* Check if there is already a user associated with this email address */
        /* Returns user = null if no user is associated with this email  */

        public User GetByEmail(string email) 
        {

            //MySqlConnection cnn = new MySqlConnection(_cnnStr);
            User user = new User();

            /*
            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT Count(*) FROM users WHERE deletionDate IS NULL AND email=@email";
                cmd.Parameters.AddWithValue("@email", email);
                int count = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Dispose();

                if(count >= 1)
                {
                    MySqlCommand cmd2 = cnn.CreateCommand();
                    cmd2.CommandText = "SELECT * FROM users WHERE dateSuppression IS NULL AND email=@email";
                    cmd2.Parameters.AddWithValue("@email", email);
                    MySqlDataReader reader = cmd2.ExecuteReader();
                    while (reader.Read())
                    {
                        int _userId = (Int32)reader["user_id"];
                        string _lastname = reader["lastname"].ToString();
                        string _firstname = reader["firstname"].ToString();
                        string _email = reader["email"].ToString();
                        string _password = reader["password"].ToString();
                        bool _admin = (bool)reader["admin"];
                        bool _subscriber = (bool)reader["subscriber"];

                        user.userId = _userId;
                        user.lastname = _lastname;
                        user.firstname = _firstname;
                        user.password = _password;
                        user.admin = _admin;
                        user.subscriber = _subscriber;
                    }
                    reader.Close();
                }
                else
                {
                    user = null;
                }
            }
            finally
            {
                cnn.Close();
            }
            */

            return null;
           // return user;

        }

        #endregion

        #region Connexion
        public User Connexion(string email, string password)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);
            User user = new User();
            CryptographyHelper ch = new CryptographyHelper();
            string hashedPassword = ch.HashPassword(password);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM users WHERE deletionDate IS NULL AND email=@email AND password = @hashedPassword";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("password", hashedPassword);
                int count = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Dispose();

                if (count >= 1)
                {
                    cmd.CommandText = "SELECT * FROM clients WHERE deletionDate ISNULL AND email=@email AND password=@hashedPassword";
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("password", hashedPassword);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int _userId = (Int32)reader["user_id"];
                        string _lastname = reader["lastname"].ToString();
                        string _firstname = reader["firstname"].ToString();
                        string _email = reader["email"].ToString();
                        string _password = reader["password"].ToString();
                        bool _admin = (bool)reader["admin"];
                        bool _subscriber = (bool)reader["subscriber"];

                        user.userId = _userId;
                        user.lastname = _lastname;
                        user.firstname = _firstname;
                        user.password = _password;
                        user.admin = _admin;
                        user.subscriber = _subscriber;
                    }
                    reader.Close();
                }
                else
                {
                    user = null;
                }
            }
            finally
            {
                cnn.Close();
            }

            return user;

        }
        #endregion
    }
}
