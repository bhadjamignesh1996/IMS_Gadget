using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS_Gadget.BalLayer.ViewModel
{
    public class AuthenticationViewModel
    {
        public class AuthenticationRequestViewModel
        {
            [Required]
            public string UserName { get; set; }

            public string Password { get; set; }
        }
        public class AuthenticationResponseViewModel
        {
            public long UserId { get; set; }

            public string? UserName { get; set; }

            public string? Email { get; set; }

            public string? Token { get; set; }

        }
    }
}
