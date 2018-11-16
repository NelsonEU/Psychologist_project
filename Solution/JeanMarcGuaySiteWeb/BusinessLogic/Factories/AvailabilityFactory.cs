using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public Availability GetById(int id)
        {

            Availability availability = new Availability();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM availabilities WHERE Availability_id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int _availabilityId = (Int32)reader["Availability_id"];
                    DateTime _schedule = (DateTime)reader["schedule"];
                    availability.availabilityId = _availabilityId;
                    availability.schedule = _schedule;
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }
    

            return availability;
        }
    }
}
