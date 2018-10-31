using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Factories
{
    public class CategoryPublicationFactory
    {

        #region Constructeur
        private string _cnnStr;
        public CategoryPublicationFactory(string cnnStr)
        {
            _cnnStr = cnnStr;
        }
        #endregion

    }
}
