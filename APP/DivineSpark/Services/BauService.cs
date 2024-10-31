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

        public async Task<Bau> GetBauByIdAsync(int id) // TASK: usado no await
        {
            Debug.WriteLine("Chamou!! o GetBauByIdAsync");
            Bau bau = new Bau();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{uri}/{id}");//quero saber todos os posts;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();// tranforma o conteudo em string;

                    Debug.WriteLine($"Resposta JSON: {content}");

                    bau = JsonSerializer.Deserialize<Bau>(content, jsonSerializerOptions);
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
                Debug.WriteLine($"Exceção ocorrida: {ex.Message}");
            }
            catch (Exception ex)
            {
                // se der alguma exeption ai mostra
                Debug.WriteLine($"Exceção ocorrida: {ex.Message}");
            }
            Debug.WriteLine($"Bau encontrada: ID={bau.Id}");
            return bau;
        }
    }
}
