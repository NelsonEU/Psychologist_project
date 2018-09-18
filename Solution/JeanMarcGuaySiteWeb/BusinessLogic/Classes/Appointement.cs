using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Appointement
    {

        public int appointementId { get; set; } //PK
        public int userId { get; set; } //FK
        public int availabilityId { get; set; } //FK

        public bool confirmed { get; set; }
        public string message { get; set; } //VARCHAR(500)
        public bool outdated { get; set; }

    }
}
