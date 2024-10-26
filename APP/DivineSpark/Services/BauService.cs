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
    public class BauService
    {
        private HttpClient httpClient;
        private Bau bau;
        Uri uri = new Uri("http://localhost:8080/Bau");
        private ObservableCollection<Bau> baus;
        private JsonSerializerOptions jsonSerializerOptions;

        public BauService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }
        public async Task<ObservableCollection<Bau>> GetBausAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    baus = JsonSerializer.Deserialize<ObservableCollection<Bau>>(content, jsonSerializerOptions);
                }
            }
            catch
            {

            }
            return baus;
        }
    }
}
