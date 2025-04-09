using IMS_Gadget.BalLayer.Interfaces;
using IMS_Gadget.BalLayer.ViewModel;
using IMS_Gadget.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static IMS_Gadget.Utility.CommonEnum;

namespace IMS_Gadget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GadgetController : ControllerBase
    {
        private readonly IGadget iGadget;

        public GadgetController(IGadget _iGadget)
        {
            iGadget = _iGadget;
        }


        [HttpGet]
        [ServiceFilter(typeof(ActionFilters.TokenVerify))]
        [Route("GetGadget")]
        public async Task<IActionResult> GetGadget()
        {
            try
            {
                var gadgets = iGadget.GetGadgets();

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(gadgets, Message.GetSuccessfully);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(ActionFilters.TokenVerify))]
        [Route("UpsertGadget")]
        public async Task<IActionResult> UpsertGadget(GadgetsViewModel gadgetsViewModel)
        {
            try
            {
                await iGadget.UpsertGadget(gadgetsViewModel);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(null, Message.SavedSuccessfully);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpGet]
        [ServiceFilter(typeof(ActionFilters.TokenVerify))]
        [Route("GetGadgetById/{id}")]
        public async Task<IActionResult> GetGadgetById(int id)
        {
            try
            {
                var gadget = await iGadget.GetGadgetById(id);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(gadget, Message.GetSuccessfully);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpDelete]
        [ServiceFilter(typeof(ActionFilters.TokenVerify))]
        [Route("DeleteGadget/{GadgetIds}")]
        public async Task<IActionResult> DeleteGadget(string GadgetIds)
        {
            try
            {
                await iGadget.DeleteGadget(GadgetIds);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(null, Message.DeletedSuccessfully);

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
