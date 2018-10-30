﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Category
    {

        public int categoryId { get; set; } //PK

        public string name { get; set; } //VARCHAR(40)

        public string pictureUrl { get; set; } //VARCHAR (150)

        public string urlRedirect { get; set; } //VARCHAR(30)

    }
}
