using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Module
    {

        public enum AllModules
        {
            Appointment = 1,
            Contact = 2,
            Publications = 3,
            Subscription = 4
        }

        public int moduleId { get; set; } //PK
        public string description { get; set; }
        public string title { get; set; } //VARCHAR(40)
        public bool active { get; set; }

    }
}
