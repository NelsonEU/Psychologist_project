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
        public void Add(int categoryId, string titre, string url, string fileName)
        {

            MySqlConnection cnn = new MySqlConnection(_cnnStr);
            MySqlTransaction trans = null;

            try
            {               
                //Requête 1:
                cnn.Open();
                trans = cnn.BeginTransaction();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "INSERT INTO publications(title, url, fileName,creationDate) VALUES (@title, @url, @fileName, @creationDate)";
                cmd.Parameters.AddWithValue("@title", titre);
                cmd.Parameters.AddWithValue("@url", url);
                cmd.Parameters.AddWithValue("@fileName", fileName);
                cmd.Parameters.AddWithValue("@creationDate", DateTime.Now);
                cmd.ExecuteNonQuery();

                //Récupère le ID ajouté
                long publicationId = cmd.LastInsertedId;

                //Requête 2:
                MySqlCommand cmd2 = cnn.CreateCommand();
                cmd2.CommandText = "INSERT INTO publicationsCategories(publication_id, category_id) VALUES (@publication_id, @category_id)";
                cmd2.Parameters.AddWithValue("@publication_id", publicationId);
                cmd2.Parameters.AddWithValue("@category_id", categoryId);
                cmd2.ExecuteNonQuery();

                trans.Commit();
            }
            catch(Exception e)
            {
                trans.Rollback();
                throw(e);
            }
            finally
            {   
                cnn.Close();
            }

        }
        #endregion

        #region Get
        public Publication Get(int id)
        {

            Publication publication = null;
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM publications WHERE publication_id = @id AND deletionDate IS NULL";
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    publication = CreatePublication(reader);

                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return publication;

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
                    publicationList.Add(CreatePublication(reader));
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

        #region GetAllByCategoryId
        public Publication[] GetAllByCategoryId(int categoryId)
        {

            List<Publication> publicationList = new List<Publication>();
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();

                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM publications p, publicationscategories pc WHERE p.publication_id = pc.publication_id AND p.deletionDate IS NULL AND pc.category_id=@id;";
                cmd.Parameters.AddWithValue("@id", categoryId);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    publicationList.Add(CreatePublication(reader));
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

        #region GetByFileName
        //Vérifie si ce pdf à déjà été poster
        public Publication GetByFileName(string fileName)
        {

            Publication publication = null;
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM publications WHERE fileName = @fileName AND deletionDate IS NULL";
                cmd.Parameters.AddWithValue("@fileName", fileName);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    publication = CreatePublication(reader);

                }
                reader.Close();
            }
            finally
            {
                cnn.Close();
            }

            return publication;

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
                cmd.CommandText = "UPDATE Publications SET deletionDate = NOW() WHERE publication_id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region DeleteByArray
        public void DeleteByArray(string[] ids)
        {
            MySqlConnection cnn = new MySqlConnection(_cnnStr);

            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                string commande = "UPDATE Publications SET deletionDate = NOW() WHERE publication_id IN (" + String.Join(",", ids) + ")";
                cmd.CommandText = commande;
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region CreatePublication
        private Publication CreatePublication(MySqlDataReader reader)
        {
            Publication publication = new Publication();
            int _publicationId = (Int32)reader["publication_id"];
            string _title = reader["title"].ToString();
            string _url = reader["url"].ToString();
            string _fileName = reader["fileName"].ToString();

            publication.publicationId = _publicationId;
            publication.title = _title;
            publication.url = _url;
            publication.fileName = _fileName;
            return publication;
        }
        #endregion

    }
}
