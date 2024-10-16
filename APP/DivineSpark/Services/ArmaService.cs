using DivineSpark.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DivineSpark.Services
{
    public class ArmaService
    {
        private HttpClient httpClient;
        private Arma arma;
        Uri uri = new Uri("http://localhost:8080/Sala");
        private ObservableCollection<Arma> armas;
        private JsonSerializerOptions jsonSerializerOptions;

        public ArmaService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }
        public async Task<ObservableCollection<Arma>> GetArmasAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    armas = JsonSerializer.Deserialize<ObservableCollection<Arma>>(content, jsonSerializerOptions);
                }
            }
            catch
            {

            }
            return armas;
        }

        public async Task<Arma> PostArmaAsync(Arma item)
        {
            try
            {
                string json = JsonSerializer.Serialize<Arma>(item, jsonSerializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(response.Content);
                }
            }
            catch (Exception e) 
            {
                Debug.WriteLine(e.Message);
            }
            return arma;
        }     
    }
}
