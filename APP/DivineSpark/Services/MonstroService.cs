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
        Uri uri = new Uri("http://localhost:8080/Monstro");
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

        public async Task<Monstro> GetMonstroByIdAsync(int id) // TASK: usado no await
        {
            Debug.WriteLine("Chamou!! o GetMonstroByIdAsync");
            Monstro monstro = new Monstro();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{uri}/{id}");//quero saber todos os posts;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();// tranforma o conteudo em string;

                    Debug.WriteLine($"Resposta JSON: {content}");

                    monstro = JsonSerializer.Deserialize<Monstro>(content, jsonSerializerOpitons);
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
            Debug.WriteLine($"monstro encontrada: ID={monstro.Id}");
            return monstro;
        }
    }
}
