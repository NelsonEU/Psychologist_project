using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class User
    {

        public int userId { get; set; } //PK

        public string lastname { get; set; } //VARCHAR(40)
        public string firstname { get; set; } //VARCHAR(40)
        public string email { get; set; } //VARCHAR(50)
        public string password { get; set; } //VARCHAR(150)
        public bool admin { get; set; }
        public bool subscriber { get; set; }

    }
}
