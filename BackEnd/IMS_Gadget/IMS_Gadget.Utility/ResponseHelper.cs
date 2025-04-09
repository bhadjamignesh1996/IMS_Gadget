﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Gadget.Utility
{
    sealed public class ResponseHelper
    {
        public Int16 Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; } = null; 
    }
}
