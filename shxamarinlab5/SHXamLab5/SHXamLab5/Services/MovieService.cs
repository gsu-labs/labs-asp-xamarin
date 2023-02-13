using Newtonsoft.Json;
using SHXamLab5.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SHXamLab5.Services
{
    public class MovieService
    {
        const string Url = "http://192.168.1.10:3000/api/movies";
        // настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Movie>> Get()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Movie>>(result);
        }

        public async Task<Movie> Add(Movie movie)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(movie),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Movie>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<Movie> Update(Movie movie)
        {
            HttpClient client = GetClient();
            var response = await client.PutAsync(Url + "/" + movie.Id,
                new StringContent(
                    JsonConvert.SerializeObject(movie),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Movie>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<Movie> Delete(int id)
        {
            HttpClient client = GetClient();
            var response = await client.DeleteAsync(Url + "/" + id);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Movie>(
               await response.Content.ReadAsStringAsync());
        }
    }
}
