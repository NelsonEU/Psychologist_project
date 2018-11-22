using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Factories
{
     public class AvailabilityFactory
    {
        #region Constructeur
        private string _cnnStr;

        public AvailabilityFactory(string cnnStr)
        {
            _cnnStr = cnnStr;
        }
        #endregion

        #region Add
        public void Add(string day, DateTime strdt, DateTime enddt)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "INSERT INTO availabilities(Day, Start_time, End_time) VALUES (@Day, @Start_time, @End_time)";
                cmd.Parameters.AddWithValue("@Day", day);
                cmd.Parameters.AddWithValue("@Start_time", strdt);
                cmd.Parameters.AddWithValue("@End_time", enddt);
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
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "DELETE * FROM availabilities WHERE availability_id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region GetAll
        public Availability[] GetAll()
        {
            List<Availability> availabilityList = new List<Availability>();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM availabilities";

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int _id = (Int32)reader["availability_id"];
                    string _day = reader["name"].ToString();
                    DateTime _strdt = Convert.ToDateTime(reader["strdt"]);
                    DateTime _enddt = Convert.ToDateTime(reader["enddt"]);

                    Availability availability = new Availability();
                    availability.availabilityId = _id;
                    availability.day = _day;
                    availability.strdt = _strdt;
                    availability.enddt = _enddt;

                    availabilityList.Add(availability);
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return availabilityList.ToArray();
        }
        #endregion

    }
}
