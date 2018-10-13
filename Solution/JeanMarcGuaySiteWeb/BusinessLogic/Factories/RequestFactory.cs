using System;
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

        #endregion

        #region GetLastMonth

        #endregion

        #region GetLastWeek

        #endregion
    }
}
