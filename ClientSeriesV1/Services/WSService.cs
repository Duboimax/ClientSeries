using ClientSeriesV1.Models;
using Microsoft.UI.Windowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace ClientSeriesV1.Services
{
    public class WSService : IService
    {
        private readonly HttpClient client = new HttpClient();

        public WSService(string uriString)
        {
            client.BaseAddress = new Uri(uriString);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



        public async Task<bool> DeleteSeriesAsync(int id)
        {
            try
            {
                var result = await client.DeleteAsync($"/api/series/{id}");
                result.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<Series> GetSeriesAsync(int id)
        {
            try
            {
                return await client.GetFromJsonAsync<Series>($"/api/series/{id}");
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<bool> PostSeriesAsync(string nomController, Series newSeries)
        {
            try
            { 
                var result = await client.PostAsJsonAsync(nomController, newSeries);
                result.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> PutSeriesAsync(int id, Series updateSerie)
        {

            try
            {
                var result = await client.PutAsJsonAsync($"/api/series/{id}", updateSerie);
                result.EnsureSuccessStatusCode();
                return true;

            }
            catch (Exception)   
            {

                return false;
            }
        }
    }
}
