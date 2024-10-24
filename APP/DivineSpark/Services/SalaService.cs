﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DivineSpark.Models;

namespace DivineSpark.Services
{
    internal class SalaService
    {
        private HttpClient httpClient;
        private ObservableCollection<Sala> salas;
        private Sala sala;
        private JsonSerializerOptions jsonSerializerOptions; // configurar/formatar o JSON
        Uri uri = new Uri("http://localhost:8080/Sala");

        public SalaService()
        {
         
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                //propriedades dos serializer options
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            
        }

        public async Task<ObservableCollection<Sala>> GetSalasAsync() // TASK: usado no await
        {

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);//quero saber todos os posts;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();// tranforma o conteudo em string;
                    salas = JsonSerializer.Deserialize<ObservableCollection<Sala>>(content, jsonSerializerOptions);
                }
            }
            catch
            {

            }
            return salas;
        }



        public async Task<Sala> GetSalaByIdAsync(int id) // TASK: usado no await
        {
            Debug.WriteLine("Chamou!! o GetSalaByIdAsync");
            Sala sala = new Sala();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{uri}/{id}");//quero saber todos os posts;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();// tranforma o conteudo em string;

                    Debug.WriteLine($"Resposta JSON: {content}");

                    sala = JsonSerializer.Deserialize<Sala>(content, jsonSerializerOptions);
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
            Debug.WriteLine($"Sala encontrada: ID={sala.Id}");
            return sala;
        }

       
    }
}
