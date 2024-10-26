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

        public async Task<Pocao> GetPocaoByIdAsync(int id) // TASK: usado no await
        {
            Debug.WriteLine("Chamou!! o GetPocaoByIdAsync");
            Pocao pocao = new Pocao();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{uri}/{id}");//quero saber todos os posts;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();// tranforma o conteudo em string;

                    Debug.WriteLine($"Resposta JSON: {content}");

                    pocao = JsonSerializer.Deserialize<Pocao>(content, jsonSerializerOptions);
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
            Debug.WriteLine($"pocao encontrada: ID={pocao.Id}");
            return pocao;
        }


    }
}
