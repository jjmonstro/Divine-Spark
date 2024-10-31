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
        public int nivel=90; //ta representanto quantos postos de nivel vc tem bb (está ficando como 10 pq no banco os personaggens tão tudo com nivel 10)

        [ObservableProperty]
        public int equipamento;

        [ObservableProperty]
        public string image;

        [ObservableProperty]
        public string vidaExibir;

        [ObservableProperty]
        public string forcaExibir;

        [ObservableProperty]
        public string agilidadeExibir;

        [ObservableProperty]
        public string nivelExibir;

        PersonagemService personagemService = new PersonagemService();


        public ICommand EscolherCommand { get; set; }
        public ICommand AumentarVidaCommand { get; set; }
        public ICommand AumentarForcaCommand { get; set; }
        public ICommand AumentarAgilidadeCommand { get; set; }
        public ICommand DiminuirVidaCommand { get; set; }
        public ICommand DiminuirForcaCommand { get; set; }
        public ICommand DiminuirAgilidadeCommand { get; set; }
        public PersonagemViewModel()
        {
            Debug.WriteLine("PersonagemViewModel inicializado");
            EscolherCommand = new Command<int>(async (id) => await Escolher(id));
            AumentarVidaCommand = new Command(AumentarVida);
            AumentarForcaCommand = new Command(AumentarForca);
            AumentarAgilidadeCommand = new Command(AumentarAgilidade);
            DiminuirVidaCommand = new Command(DiminuirVida);
            DiminuirForcaCommand = new Command(DiminuirForca);
            DiminuirAgilidadeCommand = new Command(DiminuirAgilidade);
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

        public void AumentarVida()
        {
            if ( Nivel>0 )
            {
                VidaMax += 5;
                VidaAtual += 5;
                Nivel -= 1;
            }
            if (VidaAtual>VidaMax)
            {
                VidaAtual = VidaMax;
            }
            AtualizaSatatus();
        }

        public void AumentarForca()
        {
            if (Nivel > 0)
            {
                Forca += 1;
                Nivel -= 1;
            }
            AtualizaSatatus();
        }

        public void AumentarAgilidade()
        {
            if (Nivel > 0)
            {
                Agilidade += 2;
                Nivel -= 1;
            }
            AtualizaSatatus();
        }

        public void DiminuirVida()
        {
            if (VidaMax>5)
            {
                VidaMax -= 5;
                Nivel += 1;
            }
            AtualizaSatatus();
        }

        public void DiminuirForca()
        {
            if (Forca > 1)
            {
                Forca -= 1;
                Nivel += 1;
            }
            AtualizaSatatus();
        }

        public void DiminuirAgilidade()
        {
            if (Agilidade > 2)
            {
                Agilidade -= 2;
                Nivel += 1;
            }
            AtualizaSatatus();
        }

        public void AtualizaSatatus()
        {
            VidaExibir = "❤️Vida Máxima❤️: " + Convert.ToString(VidaMax);
            ForcaExibir = "⚔️Força⚔️: " + Convert.ToString(Forca);
            AgilidadeExibir = "🏃‍Agilidade⚡: " + Convert.ToString(Agilidade);
            NivelExibir = "Pontos de nível: " + Convert.ToString(Nivel);
        }

    }
}
