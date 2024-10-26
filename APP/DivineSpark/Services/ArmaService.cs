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
        Uri uri = new Uri("http://localhost:8080/Arma");
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

        public async Task<Arma> GetArmaByIdAsync(int id) // TASK: usado no await
        {
            Debug.WriteLine("Chamou!! o GetArmaByIdAsync");
            Arma arma = new Arma();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{uri}/{id}");//quero saber todos os posts;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();// tranforma o conteudo em string;

                    Debug.WriteLine($"Resposta JSON: {content}");

                    arma = JsonSerializer.Deserialize<Arma>(content, jsonSerializerOptions);
                }
                else
                {
                    // se der erro na chama da API mostra
                    Debug.WriteLine($"Erro na chamada à API: {response.StatusCode}");
                }
            }
            catch (JsonException ex)
            {
                // se der alguma exeption ai mostra
                Debug.WriteLine($"Exceção json ocorrida: {ex.Message}");
            }
            catch (Exception ex)
            {
                // se der alguma exeption ai mostra
                Debug.WriteLine($"Exceção ocorrida: {ex.Message}");
            }
            Debug.WriteLine($"Arma encontrada: ID={arma.Id}");
            return arma;
        }
    }
}
