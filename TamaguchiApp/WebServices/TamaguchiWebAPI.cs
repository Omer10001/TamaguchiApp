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
        
        public async Task<AnimalDTO> AddAnimal(AnimalDTO newanimal)
        {
            try
            {
                string url = $"{this.baseUri}solve";
                

                string json = JsonSerializer.Serialize(newanimal);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                
                if (response.IsSuccessStatusCode)
                {
                    
                    string resContent = await response.Content.ReadAsStringAsync();
                    
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    AnimalDTO result = JsonSerializer.Deserialize<AnimalDTO>(resContent, options);
                    return result;
                }
                else
                {
                    AnimalDTO animalResult = new AnimalDTO
                    {
                        //Success = false
                    };
                    return animalResult;
                }
            }
            catch (Exception ex)
            {
                AnimalDTO animalResult = new AnimalDTO
                {
                    //Success = false
                };
                return animalResult;
            }
        }





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
    }
}
