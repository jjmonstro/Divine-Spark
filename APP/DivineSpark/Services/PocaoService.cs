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
    public class PocaoService
    {
        private HttpClient httpClient;
        private Pocao pocao;
        Uri uri = new Uri("http://localhost:8080/Pocao");
        private ObservableCollection<Pocao> pocoes;
        private JsonSerializerOptions jsonSerializerOptions;

        public PocaoService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<ObservableCollection<Pocao>> GetPocoesAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    pocoes = JsonSerializer.Deserialize<ObservableCollection<Pocao>>(content, jsonSerializerOptions);
                }

            }
            catch
            {

            }
            return pocoes;
        }

        public async Task<Pocao> PostPocoesAsync(Pocao item)
        {
            try
            {
                string json = JsonSerializer.Serialize<Pocao>(item, jsonSerializerOptions);
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
            return pocao;
        }

    }
}
