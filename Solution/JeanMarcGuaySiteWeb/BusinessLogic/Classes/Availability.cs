﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Availability
    {

        public int availabilityId { get; set; } //PK

        public DateTime strdt { get; set; } //Date debut

        public DateTime enddt { get; set; } //Date fin 
    }
}
