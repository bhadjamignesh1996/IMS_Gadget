using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IMS_Gadget.BalLayer.Services
{
    public class Service_Common
    {

        private int shift = 5;


        public async Task<string> Encrypt(string value)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in value)
            {
                int charCode = c;
                result.Append((char)(charCode + this.shift));
            }

            string urlEncodedResult = Uri.EscapeDataString(result.ToString());
            string encodedResult = Convert.ToBase64String(Encoding.UTF8.GetBytes(urlEncodedResult));
            return await Task.FromResult(encodedResult);
        }

        public async Task<string> Decrypt(string value)
        {

            string base64DecodedValue = Encoding.UTF8.GetString(Convert.FromBase64String(value));
            string urlDecodedValue = Uri.UnescapeDataString(base64DecodedValue);
            StringBuilder result = new StringBuilder();

            foreach (char c in urlDecodedValue)
            {
                int charCode = c;
                result.Append((char)(charCode - this.shift));
            }
            return await Task.FromResult(result.ToString());
        }

    }
}
