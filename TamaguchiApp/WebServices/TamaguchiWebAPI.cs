using TamaguchiApp.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TamaguchiApp.WebServices
{
    public class TamaguchiWebAPI
    {
        private HttpClient client;
        private string baseUri;

        public TamaguchiWebAPI(string baseUri)
        {
            //Set client handler to support cookies!!
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new System.Net.CookieContainer();

            //Create client with the handler!
            this.client = new HttpClient(handler, true);
            this.baseUri = baseUri;
        }
        public async Task<List<ExerciseDTO>> GetExByTypeAsync(int typeID)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetExListByType?typeID={typeID}");
            }
            catch ()
            {

            }
        }
    }
}
