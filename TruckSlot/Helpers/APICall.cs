using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TruckSlot.Models;

namespace TruckSlot.Helpers
{
   public class APICall
    {
       
        public  async Task<string> PostURI(Uri uri, HttpContent context)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {

                HttpResponseMessage result = await client.PostAsync(uri, context);
               var Data= result.Content.ReadAsStringAsync().Result;
                if (result.IsSuccessStatusCode)
                {
                    response = Data.ToString();
             
                }
            }
            return response;
        }

       public async Task<string> GetURL(Uri path)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {

                HttpResponseMessage result = await client.GetAsync(path);
               var Data  = result.Content.ReadAsStringAsync().Result;
                if (result.IsSuccessStatusCode)
                {
                    response = Data.ToString();
                }
            }
            return response;

        }


    }
}
