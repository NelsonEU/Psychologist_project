using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class Publications
    {

        public int publicationId { get; set; } //PK

        public string title { get; set; } //VARCHAR(40)
        public string url { get; set; } //VARCHAR(150)

    }
}
