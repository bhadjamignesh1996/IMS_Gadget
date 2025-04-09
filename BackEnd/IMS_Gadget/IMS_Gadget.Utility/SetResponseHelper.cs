using Microsoft.AspNetCore.Http;
using static IMS_Gadget.Utility.CommonEnum;

namespace IMS_Gadget.Utility
{
    public static class SetResponseHelper
    {

        public static ResponseHelper SetRequestResponseForSuccess(object data = null, string message = null)
        {
            ResponseHelper objHelper = new ResponseHelper();
            objHelper.Status = StatusCodes.Status200OK;
            objHelper.Message = String.IsNullOrEmpty(message) ? Message.GetSuccessfully : message;
            objHelper.Data = data;

            return objHelper;
        }


        public static ResponseHelper SetRequestResponseForError(Exception ex)
        {
            ResponseHelper objHelper = new ResponseHelper();
            objHelper.Status = InternalServerErrorException.Error(Convert.ToInt16(ex.Data["ErrorCode"]));
            objHelper.Message = ex.Message;

            return objHelper;
        }

        public static ResponseHelper SetRequestResponseForModelStateInvalid(string MSG)
        {
            ResponseHelper objHelper = new ResponseHelper();
            objHelper.Status = StatusCodes.Status424FailedDependency;
            objHelper.Message = MSG;

            return objHelper;
        }


    }
}
