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

        #region Delete
        public void delete(int id)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "UPDATE appointments SET deletionDate = current_date() WHERE appointment_id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();

            }
        }
        #endregion


        #region Outdate
        public void outdate(int id)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "UPDATE appointments SET outdated = true WHERE appointment_id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region Confirm
        public void confirm(int id)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "UPDATE appointments SET confirmed = true WHERE appointment_id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region GetUnconfirmed
        public Appointement[] GetUnconfirmed()
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);
            List<Appointement> list = new List<Appointement>();

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT a.* FROM appointments a, availabilities av WHERE a.availability_id = av.availability_id AND a.confirmed = false AND deletionDate IS NULL ORDER BY av.schedule";
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
                    list.Add(appointement);
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
                cmd.CommandText = "SELECT a.* FROM appointments a, availabilities av WHERE a.availability_id = av.availability_id AND a.confirmed = true AND deletionDate IS NULL ORDER BY av.schedule";
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
                    list.Add(appointement);
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


        #region Get
        public Appointement Get(int id)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);
            Appointement appointement = new Appointement();

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM appointments WHERE appointment_id = @id AND deletionDate IS NULL";
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
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
                    
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }
            return appointement;
        }
        #endregion
    }
}
