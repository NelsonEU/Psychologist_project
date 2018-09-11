using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class Request
    {
        public const string WAITING = "waiting";
        public const string ACCEPTED = "accepted";
        public const string CONFIRMED = "confirmed";

        public int requestId { get; set; }
        public int userId { get; set; }
        public string content { get; set; }
        public bool videoCall { get; set; }
        public string state { get; set; }
        public DateTime creationDate { get; set; }
    }
}
