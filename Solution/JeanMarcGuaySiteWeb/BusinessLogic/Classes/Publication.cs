using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Publication
    {

        public int publicationId { get; set; } //PK

        public string title { get; set; } //VARCHAR(40)
        public string url { get; set; } //VARCHAR(150)
        public string fileName { get; set; } //VARCHAR(80)

    }
}
