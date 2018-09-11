using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class User
    {
        public int userId { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool admin { get; set; }
        public bool subscriber { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime modificationDate { get; set; }
        public DateTime deletionDate { get; set; }
    }
}
