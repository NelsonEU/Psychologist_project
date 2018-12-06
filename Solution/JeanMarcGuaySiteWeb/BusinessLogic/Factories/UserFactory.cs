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

        public void Add(string lastname, string firstname, string email, string password, bool admin, bool subscriber, bool activated, DateTime birthday, string token)
        {

            MySqlConnection cnn = new MySqlConnection(_cnnStr);
            CryptographyHelper ch = new CryptographyHelper();
            string hashedPassword = ch.HashPassword(password);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "INSERT INTO users(lastname, firstname, email, password, admin, subscriber, activated , creationDate, birthday, opt_in, token) VALUES (@lastname, @firstname, @email, @password, @admin, @subscriber, @activated , @creationDate, @birthday, @opt_in, @token)";
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@admin", admin);
                cmd.Parameters.AddWithValue("@subscriber", subscriber);
                cmd.Parameters.AddWithValue("@activated", activated);
                cmd.Parameters.AddWithValue("@creationDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@birthday", birthday);
                if (subscriber)
                {
                    cmd.Parameters.AddWithValue("@opt_in", DateTime.Now);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@opt_in", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@token", token);
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

            MySqlConnection cnn = new MySqlConnection(_cnnStr);
            User user = null;

            try
            {
                cnn.Open();


                MySqlCommand cmd2 = cnn.CreateCommand();
                cmd2.CommandText = "SELECT * FROM users WHERE deletionDate IS NULL AND email=@email";
                cmd2.Parameters.AddWithValue("@email", email);
                MySqlDataReader reader = cmd2.ExecuteReader();
                if (reader.Read())
                {
                    user = CreateUser(reader);
                }
                reader.Close();

            }
            finally
            {
                cnn.Close();
            }

            return user;

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
                user = GetByEmail(email);
                if (user != null)
                {
                    bool passwordValidate = ch.ValidateHashedPassword(password, user.password);
                    if (!passwordValidate)
                    {
                        user = null;
                    }
                }
            }
            finally
            {
                cnn.Close();
            }

            return user;

        }
        #endregion

        #region GetAll
        public User[] GetAll()
        {

            List<User> userList = new List<User>();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM users WHERE deletionDate IS NULL ORDER BY lastname";
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    userList.Add(CreateUser(reader));
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return userList.ToArray();

        }
        #endregion

        #region GetAllSubscribed
        public User[] GetAllSubscribed()
        {

            List<User> userList = new List<User>();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM users WHERE deletionDate IS NULL AND subscriber = 1 AND opt_in IS NOT NULL AND opt_out IS NULL AND (CURDATE() >= DATE_ADD(lastNotificationDate, INTERVAL +3 DAY) OR lastNotificationDate IS NULL) ORDER BY lastname";
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    userList.Add(CreateUser(reader));
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return userList.ToArray();

        }
        #endregion

        #region Get
        public User Get(int id)
        {

            User user = null;
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM users WHERE deletionDate IS NULL AND user_id = @user_id";
                cmd.Parameters.AddWithValue("@user_id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user = CreateUser(reader);
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return user;

        }
        #endregion

        #region MOAD
        public bool MOAD(int id)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);
            MySqlTransaction trans = null;

            try
            {
                cnn.Open();
                trans = cnn.BeginTransaction();
                MySqlCommand cmd1 = cnn.CreateCommand();
                cmd1.CommandText = "DELETE FROM appointments WHERE user_id = @id";
                cmd1.Parameters.AddWithValue("@id", id);
                cmd1.ExecuteNonQuery();

                MySqlCommand cmd2 = cnn.CreateCommand();
                cmd2.CommandText = "DELETE FROM requests WHERE user_id = @id";
                cmd2.Parameters.AddWithValue("@id", id);
                cmd2.ExecuteNonQuery();

                MySqlCommand cmd3 = cnn.CreateCommand();
                cmd3.CommandText = "DELETE FROM users WHERE user_id = @id";
                cmd3.Parameters.AddWithValue("@id", id);
                cmd3.ExecuteNonQuery();
                trans.Commit();
                cnn.Close();
            }
            catch (Exception e)
            {
                trans.Rollback();
                cnn.Close();
                return false;
            }
            return true;

        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "UPDATE users SET deletionDate = NOW() WHERE user_id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region DeleteByEmail
        public void DeleteByEmail(String email)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "UPDATE users SET deletionDate = NOW() WHERE email=@email";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region AuthorizeByEmail
        public void AuthorizeByEmail(string email, bool authorized)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Update users SET authorized=@authorized WHERE email=@email";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@authorized", authorized);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region AuthorizeById
        public void AuthorizeById(int id, bool authorized)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Update users SET authorized=@authorized WHERE user_id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@authorized", authorized);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region ActivateByEmail
        public void ActivateByEmail(string email)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Update users SET activated = true WHERE email=@email";
                cmd.Parameters.AddWithValue("@email", email);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region OptOutByEmail
        public void OptOutByEmail(string email)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Update users SET subscriber = false, opt_out = NOW(), opt_in = NULL WHERE email=@email";
                cmd.Parameters.AddWithValue("@email", email);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region OptOutById
        public void OptOutById(int id)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Update users SET subscriber = false, opt_out = NOW(), opt_in = NULL WHERE user_id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region OptInById
        public void OptInById(int id)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Update users SET subscriber = True, opt_out = NULL, opt_in = Now() WHERE user_id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region notifyById

        public void notifyById(int id)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Update users SET lastNotificationDate = NOW() WHERE user_id=@id";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }

        #endregion

        #region NotifyByArray
        public void NotifyByArray(string[] ids)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                string commande = "Update users SET lastNotificationDate = NOW() WHERE  user_id IN (" + String.Join(",", ids) + ")";
                cmd.CommandText = commande;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region Update
        public void Update(int id, string lastname, string firstname, string email, DateTime birthday,  bool subscriber)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Update users SET firstname = @firstname, lastname = @lastname,  email = @email, subscriber = @subscriber WHERE user_id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@birthday", birthday);
                cmd.Parameters.AddWithValue("@subscriber", subscriber);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region CreateUser
        private User CreateUser(MySqlDataReader reader)
        {
            User user = new User();
            int _userId = (Int32)reader["user_id"];
            string _lastname = reader["lastname"].ToString();
            string _firstname = reader["firstname"].ToString();
            string _email = reader["email"].ToString();
            string _password = reader["password"].ToString();
            bool _admin = (bool)reader["admin"];
            bool _subscriber = (bool)reader["subscriber"];
            bool _activated = (bool)reader["activated"];
            bool _authorized = (bool)reader["authorized"];
            DateTime _birthday = (DateTime)reader["birthday"];
            if (reader["opt_in"] != DBNull.Value)
            {
                user.optIn = (DateTime)reader["opt_in"];
            }
            if (reader["opt_out"] != DBNull.Value)
            {
                user.optOut = (DateTime)reader["opt_out"];
            }
            string _token = reader["token"].ToString();
            if (reader["lastNotificationDate"] != DBNull.Value)
            {
                user.lastNotificationDate = (DateTime)reader["lastNotificationDate"];
            }


            user.userId = _userId;
            user.lastname = _lastname;
            user.firstname = _firstname;
            user.email = _email;
            user.password = _password;
            user.admin = _admin;
            user.subscriber = _subscriber;
            user.activated = _activated;
            user.authorized = _authorized;
            user.birthday = _birthday;
            user.token = _token;
            return user;
        }
        #endregion
    }
}
