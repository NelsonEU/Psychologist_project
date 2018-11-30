using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Factories
{
    public class SubsectionFactory
    {
        #region Constructeur
        private string _cnnStr;
        public SubsectionFactory(string cnnStr)
        {
            _cnnStr = cnnStr;
        }
        #endregion

        #region Update
        public void Update(string name, string content)
        {

            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "UPDATE subsections SET content = @content, modificationDate = NOW() WHERE name = @name";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@content", content);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }

        }
        #endregion

        #region Get
        public Subsection Get(string name)
        {

            Subsection subsection = null;
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM subsections WHERE name = @name";
                cmd.Parameters.AddWithValue("@name", name);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    subsection = CreateSubsection(reader);
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return subsection;

        }
        #endregion

        #region GetAll
        public Subsection[] GetAll()
        {

            List<Subsection> subsectionList = new List<Subsection>();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM subsections ORDER BY subsection_id";

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                     subsectionList.Add(CreateSubsection(reader));
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return subsectionList.ToArray();

        }
        #endregion

        #region GetAllInModule
        public Subsection[] GetAllInModule(int moduleId)
        {

            List<Subsection> subsectionList = new List<Subsection>();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);
            
            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM subsections WHERE module_id = @module_id ORDER BY subsection_id ";
                cmd.Parameters.AddWithValue("@module_id", moduleId);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    subsectionList.Add(CreateSubsection(reader));
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return subsectionList.ToArray();

        }
        #endregion

        #region CreateSubsection
        private Subsection CreateSubsection(MySqlDataReader reader)
        {
            Subsection subsection = new Subsection();
            int _subsectionId = (Int32)reader["subsection_id"];
            int _moduleId = (Int32)reader["module_id"];
            string _name = reader["name"].ToString();
            string _content = reader["content"].ToString();

            subsection.subsectionId = _subsectionId;
            subsection.moduleId = _moduleId;
            subsection.name = _name;
            subsection.content = _content;
            return subsection;
        }
        #endregion
    }
}
