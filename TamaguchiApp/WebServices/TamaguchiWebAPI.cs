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
        
        public async Task<bool> AddAnimal(PetDTO newanimal)
        {
            try
            {
                string url = $"{this.baseUri}solve";

                string url = $"{this.baseUri}/AddAnimal";
                

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

                    //string resContent = await response.Content.ReadAsStringAsync();

                    //JsonSerializerOptions options = new JsonSerializerOptions
                    //{
                    //    PropertyNameCaseInsensitive = true
                    //};
                    //PetDTO result = JsonSerializer.Deserialize<PetDTO>(resContent, options);
                    //return result;
                    return true;
                }
                else
                {
                    
                    return false;
                }
            }
            catch (Exception ex)
            {
                PetDTO animalResult = new PetDTO
                {
                    //Success = false
                };
                return animalResult;
            }
        }





    







        public async Task<List<ExerciseDTO>> GetExByTypeAsync(int typeID)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetExListByType?typeID={typeID}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<ExerciseDTO>>(content, options);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
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
                PlayerDTO p = new PlayerDTO { Email = email, UserPassword = password };
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
        public async Task<bool> DoExerciseAsync(ExerciseDTO exDTO)
        {
            string exJson = JsonSerializer.Serialize(exDTO);
            StringContent stringContent = new StringContent(exJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/DoExercise", stringContent);
            return (response.IsSuccessStatusCode);
        }
        public async Task<bool> SignUpAsync (PlayerDTO p)
        {
            string playerJson = JsonSerializer.Serialize(p);
            StringContent stringContent = new StringContent(playerJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/SignUp", stringContent);
            return response.IsSuccessStatusCode;
        }
    }
}
