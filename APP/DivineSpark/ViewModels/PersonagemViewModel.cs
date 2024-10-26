using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using DivineSpark.Models;
using DivineSpark.Services;

namespace DivineSpark.ViewModels
{
    partial class PersonagemViewModel : ObservableObject, INotifyPropertyChanged
    {

        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public string nome;

        [ObservableProperty]
        public int vidaMax;

        [ObservableProperty]
        public int vidaAtual;

        [ObservableProperty]
        public int forca;

        [ObservableProperty]
        public int agilidade;

        [ObservableProperty]
        public int nivel;

        [ObservableProperty]
        public int equipamento;

        [ObservableProperty]
        public string image;

        PersonagemService personagemService = new PersonagemService();


        public ICommand EscolherCommand { get; set; }
        public PersonagemViewModel()
        {
            Debug.WriteLine("PersonagemViewModel inicializado");
            EscolherCommand = new Command<int>(async (id) => await Escolher(id));
            //EscolherCommand.Execute(1);
        }

        public async Task Escolher(int id)
        {
            Personagem personagem = await personagemService.GetPersonagemByIdAsync(id);
            Debug.WriteLine($"Parâmetro: {id}");
            Id =personagem.Id;
            Nome=personagem.Nome;
            VidaMax=personagem.VidaMax;
            VidaAtual=personagem.VidaAtual;
            Forca = personagem.Forca;
            Agilidade = personagem.Agilidade;
            Nivel = personagem.Nivel;
            Equipamento = personagem.Equipamento;
            Image = personagem.Image;
            Debug.WriteLine($"id={Id}---Nome={Nome}---VidaMax={VidaMax}---VidaAtual={VidaAtual}---Força={Forca}---Agili={Agilidade}---Equipamento={Equipamento}");

        }

    }
}
