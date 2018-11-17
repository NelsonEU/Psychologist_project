using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Factories
{
    public class ModuleFactory
    {

        #region Constructeur
        private string _cnnStr;
        public ModuleFactory(string cnnStr)
        {
            _cnnStr = cnnStr;
        }
        #endregion

        #region GetAll
        public Module[] GetAll()
        {

            List<Module> moduleList = new List<Module>();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM modules ORDER BY module_id";

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int _id = (Int32)reader["module_id"];
                    string _title = reader["title"].ToString();
                    string _description = reader["description"].ToString();
                    bool _active = (bool)reader["active"];

                    Module module = new Module();
                    module.moduleId = _id;
                    module.title = _title;
                    module.active = _active;
                    module.description = _description;

                    moduleList.Add(module);
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return moduleList.ToArray();

        }
        #endregion

        #region Update
        /* Update the active parameter of a module */
        public void Update(int id, bool active)
        {

            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "UPDATE modules SET active = @active, modificationDate = NOW() WHERE module_id = @module_id";
                cmd.Parameters.AddWithValue("@module_id", id);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }

        }
        #endregion

        #region Get
        public Module Get(int id)
        {

            Module module = new Module();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM modules WHERE module_id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int _id = (Int32)reader["module_id"];
                    string _title = reader["title"].ToString();
                    string _description = reader["description"].ToString();
                    bool _active = (bool)reader["active"];

                    module.moduleId = _id;
                    module.title = _title;
                    module.description = _description;
                    module.active = _active;
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return module;

        }
        #endregion

    }
}
