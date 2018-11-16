using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Factories
{
    public class AppointementFactory
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

        #region GetUnconfirmed
        public Appointement[] GetUnconfirmed()
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);
            List<Appointement> list = new List<Appointement>();

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM appointments WHERE confirmed = false AND deletionDate IS NULL"; 
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Appointement appointement = new Appointement();
                    int _appointmentId = (Int32)reader["appointment_id"];
                    int _userId = (Int32)reader["user_id"];
                    int _availabilityId = (Int32)reader["availability_id"];
                    bool _confirmed = false;
                    string _message = reader["message"].ToString();
                    DateTime creationDate = (DateTime)reader["creationDate"];

                    appointement.appointementId = _appointmentId;
                    appointement.userId = _userId;
                    appointement.availabilityId = _availabilityId;
                    appointement.confirmed = _confirmed;
                    appointement.message = _message;
                    
                    if (creationDate.CompareTo(DateTime.Now) > 0)
                    {
                        
                        appointement.outdated = true;
                        // APPELER LA FONCTION POUR UPDATE 
                    }
                    else
                    {
                        appointement.outdated = false;
                        list.Add(appointement);
                    }

                    
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }
            return list.ToArray();
        }
        #endregion


        #region GetConfirmed
        public Appointement[] GetConfirmed()
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);
            List<Appointement> list = new List<Appointement>();

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM appointments WHERE confirmed = true AND deletionDate IS NULL";
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Appointement appointement = new Appointement();
                    int _appointmentId = (Int32)reader["appointment_id"];
                    int _userId = (Int32)reader["user_id"];
                    int _availabilityId = (Int32)reader["availability_id"];
                    bool _confirmed = false;
                    string _message = reader["message"].ToString();
                    DateTime creationDate = (DateTime)reader["creationDate"];

                    appointement.appointementId = _appointmentId;
                    appointement.userId = _userId;
                    appointement.availabilityId = _availabilityId;
                    appointement.confirmed = _confirmed;
                    appointement.message = _message;

                    if (creationDate.CompareTo(DateTime.Now) > 0)
                    {
                        appointement.outdated = true;
                        // APPELER LA FONCTION POUR UPDATE 
                    }
                    else
                    {
                        appointement.outdated = false;
                        list.Add(appointement);
                    }


                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }
            return list.ToArray();
        }
        #endregion
    }
}
