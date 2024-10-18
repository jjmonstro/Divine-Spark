﻿using DivineSpark.Models;
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
    public class PersonagemService
    {
        private HttpClient httpClient;
        private Personagem personagem;
        Uri uri = new Uri("http://localhost:8080/Sala");
        private ObservableCollection<Personagem> personagens;
        private JsonSerializerOptions jsonSerializerOptions;

        public PersonagemService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<ObservableCollection<Personagem>> GetPersonagensAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode) 
                {
                    string content = await response.Content.ReadAsStringAsync();
                    personagens = JsonSerializer.Deserialize<ObservableCollection<Personagem>>(content, jsonSerializerOptions);
                }

            }
            catch
            {

            }
            return personagens;
        }

        public async Task<Personagem> PostPersonagemAsync(Personagem item)
        {
            try
            {
                string json = JsonSerializer.Serialize<Personagem>(item, jsonSerializerOptions);
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
            return personagem;
        }

    }
}