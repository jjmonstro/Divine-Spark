using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using DivineSpark.Models;
using DivineSpark.Services;
using DivineSpark.Views;


namespace DivineSpark.ViewModels
{
    internal partial class SalaViewModel : ObservableObject
    {
        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public int? monstroId;

        [ObservableProperty]
        public int? bauId;

        [ObservableProperty]
        public int? esquerda;

        [ObservableProperty]
        public int? direita;

        [ObservableProperty]
        public int? frente;

        [ObservableProperty]
        public int? tras;

        [ObservableProperty]
        public string image = "fundomenu.jpg";

        [ObservableProperty]
        public bool podeEsquerda = false;

        [ObservableProperty]
        public bool podeDireita = false;

        [ObservableProperty]
        public bool podeFrente = false;

        [ObservableProperty]
        public bool podeTras = false;

        [ObservableProperty]
        public bool logoVisible = true;

        [ObservableProperty]
        public bool jogarVisible = true;

        [ObservableProperty]
        public bool creditosVisible = true;

        SalaService salaService = new SalaService();
        MonstroService monstroService;
        BauService bauService;
        
        public ICommand TesteCommand { get; set; }
        public ICommand AtualizaSalaCommand { get; set; }
        public ICommand EsquerdaButtonCommand { get; set; }
        public ICommand DireitaButtonCommand { get; set; }
        public ICommand FrenteButtonCommand { get; set; }
        public ICommand TrasButtonCommand { get; set; }
        public SalaViewModel()
        {
            //GerarSalaCommand = new Command(GerarSala);
            Debug.WriteLine("SalaViewModel inicializado");
            salaService = new SalaService();
            /*StartCommand = new Command(AtualizaSala);*/
            AtualizaSalaCommand = new Command<int>(async (id) => await AtualizaSala(id));
            AtualizaSalaCommand.Execute(1); // Essa linha faz pular a tela de menu, indo direto para a dungeon e fazendo o que o botão jogar deveria fazer
            EsquerdaButtonCommand = new Command(EsquerdaButton);
            DireitaButtonCommand = new Command(DireitaButton);
            FrenteButtonCommand = new Command(FrenteButton);
            TrasButtonCommand = new Command(TrasButton);
            TesteCommand = new Command(async () => await Teste());
        }



        public async Task AtualizaSala(int id)
        {
            LogoVisible = false;
            JogarVisible = false;
            CreditosVisible = false;
            Debug.WriteLine($"parâmetro: {id}");
            Console.WriteLine($"parâmetro: {id}");

            // Buscando a sala
            Sala sala = await salaService.GetSalaByIdAsync(id);

            // Atualizando as propriedades
            Id = sala.Id;
            MonstroId = sala.MonstroId;
            BauId = sala.BauId;
            Image = sala.Image;

            // Atualizando botões
            AtualizaBotoes(sala);
        }



        public async void AtualizaBotoes(Sala sala)
        {
            Debug.WriteLine($"CHAMOU atualizaBotoes    parametro: {sala}     id do parametro {sala.Id}    esquerda {sala.Esquerda}   direita {sala.Direita}     tras {sala.Tras}     frente {sala.Frente}    Image {Image}");
            PodeEsquerda = (sala.Esquerda == null) ? false : true;
            PodeDireita = (sala.Direita == null) ? false : true;
            PodeFrente = (sala.Frente == null) ? false : true;
            PodeTras = (sala.Tras == null) ? false : true;

            Debug.WriteLine($"CHAMOU atualizaBotoes    parametro: {sala}     id do parametro {sala.Id}    esq {PodeEsquerda}   dir {PodeDireita}     tras {PodeTras}     fr {PodeFrente}");
        }

        public async void EsquerdaButton()
        {
            Sala sala = await salaService.GetSalaByIdAsync(Id);
            AtualizaSala((int)sala.Esquerda);
        }

        public async void DireitaButton()
        {
            Sala sala = await salaService.GetSalaByIdAsync(Id);
            AtualizaSala((int)sala.Direita);
        }

        public async void FrenteButton()
        {
            Sala sala = await salaService.GetSalaByIdAsync(Id);
            AtualizaSala((int)sala.Frente);
        }

        public async void TrasButton()
        {
            Sala sala = await salaService.GetSalaByIdAsync(Id);
            AtualizaSala((int)sala.Tras);
        }
        public async Task Teste()
        {
            Image = "salaedf.png";
            Debug.WriteLine("foi");
            Sala sala1 = await salaService.GetSalaByIdAsync(1);
            Debug.WriteLine($"Sala {sala1.BauId}, {sala1.Id}, {sala1.MonstroId}");
            Id=sala1.Id;
        }
        
       

        
        }
    }

//isso aqui foi o delirio do geramento de sala procedural
/*public async void GerarSala()
{
    int contagemSala = 0; //quando chegar a um certo número de salas aparece o boss

    Random random = new Random();
    int id = random.Next(1, 17);

    Sala sala = await salaService.GetSalaByIdAsync(id);

    int caminhos = random.Next(1, 8);
    switch (caminhos)
    {
        case 1:
            PodeEsquerda = true;
            PodeDireita = false;
            PodeFrente = false;
            Image = "salae.png";
            ImageSource = ImageSource.FromFile("salae.png");
            break;

        case 2:
            PodeDireita = true;
            PodeEsquerda = true;
            PodeFrente = false;
            Image = "salaed.png";
            ImageSource = ImageSource.FromFile("salaed.png");
            break;
        case 3:
            PodeDireita = true;
            PodeEsquerda = true;
            PodeFrente = true;
            Image = "salaedf.png";
            ImageSource = ImageSource.FromFile("salaedf.png");
            break;
        case 4:
            PodeDireita = true;
            PodeFrente = false;
            PodeEsquerda = false;
            Image = "salad.png";
            ImageSource = ImageSource.FromFile("salad.png");
            break;
        case 5:
            PodeDireita = true;
            PodeFrente = true;
            PodeEsquerda = false;
            Image = "saladf.png";
            ImageSource = ImageSource.FromFile("saladf.png");
            break;
        case 6:
            PodeFrente = true;
            PodeEsquerda = false;
            PodeDireita = false;
            Image = "salaf.png";
            ImageSource = ImageSource.FromFile("salaf.png");
            break;
        case 7:
            PodeEsquerda = true;
            PodeFrente = true;
            PodeDireita = false;
            Image = "salaef.png";
            ImageSource = ImageSource.FromFile("salaef.png");
            break;
    }*/

//mais coisa da geração procedural
/*public ICommand GerarSalaCommand { get; }
public ImageSource ImageSource { get; private set; }*/