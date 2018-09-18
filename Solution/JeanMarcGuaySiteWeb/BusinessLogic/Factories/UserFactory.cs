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

        #region requests

        /* Add */
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
    }
}
