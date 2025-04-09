using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IMS_Gadget.BalLayer.ViewModel.AuthenticationViewModel;

namespace IMS_Gadget.BalLayer.Interfaces
{
    public interface IAuthentication
    {
        Task<AuthenticationResponseViewModel> SignIn(AuthenticationRequestViewModel ARVM);
    }
}
