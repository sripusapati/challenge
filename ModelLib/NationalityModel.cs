﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class NationalityModel
    {
        public int ID { get; set; }
        public string Nation { get; set; }
        public string Code { get; set; }
        public string Logo { get; set; }
        public bool IsActive { get; set; }
    }
}
