using IMS_Gadget.BalLayer.Interfaces;
using IMS_Gadget.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static IMS_Gadget.BalLayer.ViewModel.AuthenticationViewModel;
using static IMS_Gadget.Utility.CommonEnum;

namespace IMS_Gadget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthentication authenticationService;

        public AuthenticationController(IAuthentication _authenticationService)
        {
            authenticationService = _authenticationService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(AuthenticationRequestViewModel ARVM)
        {
            try
            {
                AuthenticationResponseViewModel authenticationResponseViewModel = await authenticationService.SignIn(ARVM);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(authenticationResponseViewModel, Message.GetSuccessfully);

                return await Task.FromResult(Ok(objHelper));

            }
            catch (Exception ex)
            {

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }
    }
}
