using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Factories
{
    public class PublicationFactory
    {

        #region Constructeur
        private string _cnnStr;
        public PublicationFactory(string cnnStr)
        {
            _cnnStr = cnnStr;
        }
        #endregion

        #region Add
        public void Add(int categoryId, string titre, string url)
        {

            MySqlConnection cnn = new MySqlConnection(_cnnStr);      

            try
            {
                //Requête 1:
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "INSERT INTO publications(title, url, creationDate) VALUES (@title, @url, @creationDate)";
                cmd.Parameters.AddWithValue("@title", titre);
                cmd.Parameters.AddWithValue("@url", url);
                cmd.Parameters.AddWithValue("@creationDate", DateTime.Now);
                cmd.ExecuteNonQuery();

                //Récupère le ID ajouté
                long publicationId = cmd.LastInsertedId;

                //Requête 2:
                //cnn.Open();
                MySqlCommand cmd2 = cnn.CreateCommand();
                cmd2.CommandText = "INSERT INTO publicationsCategories(publication_id, category_id) VALUES (@publication_id, @category_id)";
                cmd2.Parameters.AddWithValue("@publication_id", publicationId);
                cmd2.Parameters.AddWithValue("@category_id", categoryId);
                cmd2.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }

        }
        #endregion

        #region GetAll
        public Publication[] GetAll()
        {
        
            List<Publication> publicationList = new List<Publication>();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);
        
            try
            {
                cnn.Open();
        
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM publications WHERE deletionDate IS NULL";
                MySqlDataReader reader = cmd.ExecuteReader();
        
                while (reader.Read())
                {
                    Publication publication = new Publication();
                    int _publicationId = (Int32)reader["publication_id"];
                    string _title = reader["title"].ToString();
                    string _url = reader["url"].ToString();

                    publication.publicationId = _publicationId;
                    publication.title = _title;
                    publication.url = _url;

                    publicationList.Add(publication);
                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }
        
            return publicationList.ToArray();
        
        }
        #endregion

    }
}
