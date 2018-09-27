using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Factories
{
    class AppointementFactory
    {
        #region Constructeur
        private string _cnnStr;
        public AppointementFactory(string cnnStr)
        {
            _cnnStr = cnnStr;
        }
        #endregion

        #region Add
        public void Add(int user_id, int availability_id, string message)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "INSERT INTO Appointements(user_id, availability_id, message) VALUES (@user_id, @availability_id, @message)";
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@availability_id", availability_id);
                cmd.Parameters.AddWithValue("@message", message);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        // Remove
        #region Delete
        public void delete(int id)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {

            }
            finally
            {
                cnn.Close();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "UPDATE appointments SET ";
            }
        }
        #endregion
        // Connexion
        // Get
        // Update
        //
    }
}
