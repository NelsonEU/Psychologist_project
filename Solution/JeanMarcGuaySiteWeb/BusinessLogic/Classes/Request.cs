using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Request
    {

        public int requestId { get; set; } //PK
        public int userId { get; set; } //FK
        public string content { get; set; } //VARCHAR(5000)
        public string subject { get; set; } //VARCHAR(40)

    }
}
