﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Factories
{
    public class RequestFactory
    {
        #region Constructeur
        private string _cnnStr;
        public RequestFactory(string cnnStr)
        {
            _cnnStr = cnnStr;
        }
        #endregion

        #region Add
        public void Add(int userId, string subject, string content)
        {

            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "INSERT INTO requests(user_id, subject, content, creationDate) VALUES (@userId, @subject, @content, @creationDate)";
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@subject", subject);
                cmd.Parameters.AddWithValue("@content", content);
                cmd.Parameters.AddWithValue("@creationDate", DateTime.Now);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }

        }
        #endregion

        #region GetAll
        public Request[] GetAll()
        {

            List<Request> requestList = new List<Request>();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM requests WHERE deletionDate IS NULL ORDER BY creationDate DESC";
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    requestList.Add(CreateRequest(reader));
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return requestList.ToArray();

        }
        #endregion

        #region GetLastMonth
        public Request[] GetLastMonth()
        {

            List<Request> requestList = new List<Request>();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM requests WHERE deletionDate IS NULL AND creationDate >= DATE_SUB(NOW(), INTERVAL 30 DAY) ORDER BY creationDate DESC";
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    requestList.Add(CreateRequest(reader));
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return requestList.ToArray();

        }
        #endregion

        #region GetLastWeek
        public Request[] GetLastWeek()
        {

            List<Request> requestList = new List<Request>();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM requests WHERE deletionDate IS NULL AND creationDate >= DATE_SUB(NOW(), INTERVAL 7 DAY) ORDER BY creationDate DESC";
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    requestList.Add(CreateRequest(reader));
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return requestList.ToArray();

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
                cmd.CommandText = "UPDATE requests SET deletionDate = NOW() WHERE request_id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region CreateRequest 
        private Request CreateRequest(MySqlDataReader reader)
        {
            Request request = new Request();
            int _requestId = (Int32)reader["request_id"];
            int _userId = (Int32)reader["user_id"];
            string _subject = reader["subject"].ToString();
            string _content = reader["content"].ToString();
            DateTime _creationDate = (DateTime)reader["creationDate"];

            request.requestId = _requestId;
            request.userId = _userId;
            request.subject = _subject;
            request.content = _content;
            request.creationDate = _creationDate;
            return request;
        }
        #endregion
    }
}
