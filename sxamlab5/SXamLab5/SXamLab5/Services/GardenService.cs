using Newtonsoft.Json;
using SXamLab5.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SXamLab5.Services
{
    public class GardenService
    {
        const string Url = "http://192.168.1.10:3000/api/gardens";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Garden>> Get()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Garden>>(result);
        }

        public async Task<Garden> Add(Garden garden)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(garden),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Garden>(
                await response.Content.ReadAsStringAsync());
        }
  
        public async Task<Garden> Update(Garden garden)
        {
            HttpClient client = GetClient();
            var response = await client.PutAsync(Url + "/" + garden.Id,
                new StringContent(
                    JsonConvert.SerializeObject(garden),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Garden>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<Garden> Delete(int id)
        {
            HttpClient client = GetClient();
            var response = await client.DeleteAsync(Url + "/" + id);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Garden>(
               await response.Content.ReadAsStringAsync());
        }
    }
}
