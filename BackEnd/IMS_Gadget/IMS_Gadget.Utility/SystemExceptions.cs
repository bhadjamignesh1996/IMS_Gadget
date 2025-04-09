namespace IMS_Gadget.Utility
{
    public class SystemExceptions : Exception
    {
        public SystemExceptions(string message, object inner) : base(message)
        {
            base.Data.Add("ErrorCode", inner);
        }
    }
}
