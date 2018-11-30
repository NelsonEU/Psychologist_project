﻿using System;
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
        public void Add(DateTime strdt, DateTime enddt)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "INSERT INTO availabilities(Start_time, End_time) VALUES (@Start_time, @End_time)";
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
        public bool delete(int id)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "Select * FROM appointments WHERE availability_id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();
               if(reader.HasRows)
                {
                    reader.Close();
                    return false;
                }
               else
                {
                    reader.Close();
                    cmd = cnn.CreateCommand();
                    cmd.CommandText = "Delete FROM availabilities WHERE availability_id=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    return true;
                }

                
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
                    int _id = (Int32)reader["Availability_id"];
                    DateTime _strdt = Convert.ToDateTime(reader["Start_time"]);
                    DateTime _enddt = Convert.ToDateTime(reader["End_time"]);

                    Availability availability = new Availability();
                    availability.availabilityId = _id;
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

        #region GetAllFree
        public Availability[] GetAllFree()
        {
            List<Availability> availabilityList = new List<Availability>();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM availabilities as b WHERE NOT EXISTS ( SELECT * FROM appointments as a WHERE b.Availability_id = a.availability_id)";

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int _id = (Int32)reader["Availability_id"];
                    DateTime _strdt = Convert.ToDateTime(reader["Start_time"]);
                    DateTime _enddt = Convert.ToDateTime(reader["End_time"]);

                    Availability availability = new Availability();
                    availability.availabilityId = _id;
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

        #region checkifvalid
        public bool checkifvalid(DateTime strdt, DateTime enddt)
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
                    DateTime _strdt = Convert.ToDateTime(reader["Start_time"]);
                    DateTime _enddt = Convert.ToDateTime(reader["End_time"]);

                    Availability availability = new Availability();
                    availability.availabilityId = _id;
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
            if (strdt > enddt)
            {
                legit = false;
            }

            if (legit)
            {
                foreach (Availability av in availabilityList)
                {
                    if (strdt <= av.enddt && enddt >= av.strdt)
                    {
                        legit = false;
                    }
                }
            }
            return legit;
        }
        #endregion

        #region splitavail
        public Availability splitavail(int id, DateTime tdate)
        {
            Availability availability = new Availability();
            AvailabilityFactory af = new AvailabilityFactory(_cnnStr);

            availability = af.GetById(id);


            Availability newavailability = new Availability();

            DateTime endtime = new DateTime();
            endtime = tdate.AddHours(1);

            af.Add(tdate, endtime);

            


            return availability;
        }
        #endregion

        #region getByStartDate
        public void getByStrtDate(DateTime strtdate)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM availabilities as b WHERE NOT EXISTS ( SELECT * FROM appointments as a WHERE b.Availability_id = a.availability_id)";

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int _id = (Int32)reader["Availability_id"];
                    DateTime _strdt = Convert.ToDateTime(reader["Start_time"]);
                    DateTime _enddt = Convert.ToDateTime(reader["End_time"]);

                    Availability availability = new Availability();
                    availability.availabilityId = _id;
                    availability.strdt = _strdt;
                    availability.enddt = _enddt;

                   // availabilityList.Add(availability);
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

          //  return availabilityList.ToArray();
        }
        #endregion

    }

}

