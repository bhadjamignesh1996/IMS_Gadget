using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IMS_Gadget.Utility
{
    public class InternalServerErrorException : Exception
    {
        public static Int16 Error(Int16 errorCode)
        {
            return (errorCode > 0 ? errorCode : Convert.ToInt16(StatusCodes.Status500InternalServerError));
        }
    }
}
