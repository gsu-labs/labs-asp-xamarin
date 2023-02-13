using KXamLab5.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KXamLab5.Services
{
    public class WallpaperService
    {
        const string Url = "http://192.168.1.10:3000/api/wallpapers";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }


        public async Task<IEnumerable<Wallpaper>> Get()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Wallpaper>>(result);
        }


        public async Task<Wallpaper> Add(Wallpaper wallpaper)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(wallpaper),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Wallpaper>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<Wallpaper> Update(Wallpaper wallpaper)
        {
            HttpClient client = GetClient();
            var response = await client.PutAsync(Url + "/" + wallpaper.Id,
                new StringContent(
                    JsonConvert.SerializeObject(wallpaper),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Wallpaper>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<Wallpaper> Delete(int id)
        {
            HttpClient client = GetClient();
            var response = await client.DeleteAsync(Url + "/" + id);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Wallpaper>(
               await response.Content.ReadAsStringAsync());
        }
    }
}
