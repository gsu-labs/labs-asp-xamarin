using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamLab5
{
    public class SouvenirService
    {
        const string Url = "http://192.168.1.10:3000/api/souvenirs";
        // настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        // получаем все сувениры
        public async Task<IEnumerable<Souvenir>> Get()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Souvenir>>(result);
        }

        // добавляем один сувенир
        public async Task<Souvenir> Add(Souvenir souvenir)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(souvenir),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Souvenir>(
                await response.Content.ReadAsStringAsync());
        }
        // обновляем сувенир
        public async Task<Souvenir> Update(Souvenir souvenir)
        {
            HttpClient client = GetClient();
            var response = await client.PutAsync(Url + "/" + souvenir.Id,
                new StringContent(
                    JsonConvert.SerializeObject(souvenir),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Souvenir>(
                await response.Content.ReadAsStringAsync());
        }
        // удаляем сувенир
        public async Task<Souvenir> Delete(int id)
        {
            HttpClient client = GetClient();
            var response = await client.DeleteAsync(Url + "/" + id);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Souvenir>(
               await response.Content.ReadAsStringAsync());
        }
    }
}
