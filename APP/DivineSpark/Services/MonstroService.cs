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
    public class MonstroService
    {
        private HttpClient httpClient;
        private Monstro monstro;
        Uri uri = new Uri("http://localhost:8080/Sala");
        private ObservableCollection<Monstro> monstros;
        private JsonSerializerOptions jsonSerializerOpitons;

        public MonstroService()
        {
            httpClient = new HttpClient();
            jsonSerializerOpitons = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }
        public async Task<ObservableCollection<Monstro>> GetMonstrosAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode) 
                { 
                    string content = await response.Content.ReadAsStringAsync();
                    monstros = JsonSerializer.Deserialize<ObservableCollection<Monstro>>(content, jsonSerializerOpitons);
                }

            }
            catch
            {

            }
            return monstros;
        }
    }
}
