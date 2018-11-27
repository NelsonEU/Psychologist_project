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
                    string _day = reader["day"].ToString();
                    DateTime _strdt = Convert.ToDateTime(reader["Start_time"]);
                    DateTime _enddt = Convert.ToDateTime(reader["End_time"]);

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

        #region GetById
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
                    DateTime time1 = (DateTime)reader["Start_time"];
                    DateTime time2 = (DateTime)reader["End_time"];
                    availability.availabilityId = _availabilityId;
                    availability.strdt = time1;
                    availability.enddt = time2;
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }


            return availability;
        }
        #endregion

        #region checkifexit
        public bool checkifvalid(string Day, DateTime strtd, DateTime enddt)
        {
            List<Availability> availabilityList = new List<Availability>();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM availabilities WHERE day=@day ";

                cmd.Parameters.AddWithValue("@day", Day);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int _id = (Int32)reader["availability_id"];
                    string _day = reader["day"].ToString();
                    DateTime _strdt = Convert.ToDateTime(reader["Start_time"]);
                    DateTime _enddt = Convert.ToDateTime(reader["End_time"]);

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

            bool legit = true;
            if (strtd > enddt)
            {
                legit = false;
            }

            if (legit)
            {
                foreach (Availability av in availabilityList)
                {
                    //if (StartA <= EndB) and (EndA >= StartB) BAD


                    if (strtd <= av.enddt && enddt >= av.strdt)
                    {
                        legit = false;
                    }
                }
            }
            return legit;
        }
        #endregion

    }

}

