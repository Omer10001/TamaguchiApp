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
            //public async Task<List<MyDto>> GetSomethingAsync()
            //{

            //calls server, server returns message to this function.



            //}
        }
        public async Task<PlayerDTO> LoginAsync(string email, string password)
        {
            try
            {
                PlayerDTO p = new PlayerDTO { Email = email, Password = password };
                string playerJson = JsonSerializer.Serialize(p);
                StringContent stringContent = new StringContent(playerJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/Login", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    PlayerDTO newP = JsonSerializer.Deserialize<PlayerDTO>(content, options);
                    return newP;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
