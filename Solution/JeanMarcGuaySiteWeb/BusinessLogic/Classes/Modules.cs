using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Modules
    {

        public int moduleId { get; set; } //PK

        public string title { get; set; } //VARCHAR(40)
        public bool active { get; set; }

    }
}
