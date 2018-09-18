using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Subsections
    {

        public int subsectionId { get; set; } //PK
        public int moduleId { get; set; } //FK

        public string name { get; set; } //VARCHAR(40)
        public string content { get; set; } //VARCHAR(5000)

    }
}
