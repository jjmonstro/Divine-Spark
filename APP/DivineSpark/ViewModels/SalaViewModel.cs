using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using DivineSpark.Models;
using DivineSpark.Services;
using DivineSpark.Views;
using DivineSpark.ViewModels;



namespace DivineSpark.ViewModels
{
    internal partial class SalaViewModel : ObservableObject, INotifyPropertyChanged
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
        public string image = "salaf.jpg";

        [ObservableProperty]
        public bool podeEsquerda = false;

        [ObservableProperty]
        public bool podeDireita = false;

        [ObservableProperty]
        public bool podeFrente = true;

        [ObservableProperty]
        public bool podeTras = false;

        [ObservableProperty]
        public bool atacarButton = false;

        [ObservableProperty]
        public string image2;

        /*        [ObservableProperty]
                public bool logoVisible = true;

                [ObservableProperty]
                public bool jogarVisible = true;

                [ObservableProperty]
                public bool creditosVisible = true;*/

        SalaService salaService = new SalaService();
        MonstroService monstroService = new();
        private readonly PersonagemViewModel personagemViewModel;
        ArmaService armaService = new ArmaService();
        BauService bauService;
        
        public ICommand TesteCommand { get; set; }
        public ICommand AtualizaSalaCommand { get; set; }
        public ICommand EsquerdaButtonCommand { get; set; }
        public ICommand DireitaButtonCommand { get; set; }
        public ICommand FrenteButtonCommand { get; set; }
        public ICommand TrasButtonCommand { get; set; }
        public ICommand AtacarCommand { get; set; }

        public SalaViewModel(PersonagemViewModel personagemViewModel)
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
            AtacarCommand = new Command(Atacar);
            this.personagemViewModel = personagemViewModel;
        }


            //essa lista guarda as salas de monstro que você ja passou e faz com que o monstro não apareça mais nela
            List<int> SalasJaDerrotadas = new List<int>();
        public async Task AtualizaSala(int id)
        {
            /*            
                        Debug.WriteLine($"parâmetro: {id}");
                        Console.WriteLine($"parâmetro: {id}");
            Debug.WriteLine($"Chamou atualiza sala");*/

            // Buscando a sala
            Sala sala = await salaService.GetSalaByIdAsync(id);

            // Atualizando as propriedades
            Id = sala.Id;
            MonstroId = sala.MonstroId;
            BauId = sala.BauId;
            Image = sala.Image;

            // Atualizando botões
            AtualizaBotoes(sala);

            //Batalha
            
            if (MonstroId != null && !SalasJaDerrotadas.Contains(Id))  
            {
                SalasJaDerrotadas.Add(Id);
                Debug.WriteLine($"SALAS JÁ DERROTADAS----{SalasJaDerrotadas}----");
                IniciarBatalha();
            }
        }



        public async void AtualizaBotoes(Sala sala)
        {
            //Debug.WriteLine($"CHAMOU atualizaBotoes    parametro: {sala}     id do parametro {sala.Id}    esquerda {sala.Esquerda}   direita {sala.Direita}     tras {sala.Tras}     frente {sala.Frente}    Image {Image}");
            PodeEsquerda = (sala.Esquerda == null) ? false : true;
            PodeDireita = (sala.Direita == null) ? false : true;
            PodeFrente = (sala.Frente == null) ? false : true;
            PodeTras = (sala.Tras == null) ? false : true;
            AtacarButton = false;
            //Debug.WriteLine($"CHAMOU atualizaBotoes    parametro: {sala}     id do parametro {sala.Id}    esq {PodeEsquerda}   dir {PodeDireita}     tras {PodeTras}     fr {PodeFrente}");
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

        public async void IniciarBatalha()
        {
            PodeEsquerda = false;
            PodeDireita = false;
            PodeFrente = false;
            PodeTras = false;
            AtacarButton = true;

            Monstro monstro = await monstroService.GetMonstroByIdAsync((int)MonstroId);
            Image2 = monstro.Image;
        }
        
        public async void Atacar()
        {
            Debug.WriteLine("Atacou!!");
            //TODAS AS VEZES QUE RODA ELE RECOLOCA OS VALORES NA VARIAVEIS ENTÃO ACABA QUE A VIDA DO MONSTRO NÃO DIMINUI, TEM QUE ARRUMAR A LÓGICA 
            //tem que pegar a vida max uma só vez e cada vez que tirar um dano tu guarda esse valor em outra variavel
            Monstro monstro = await monstroService.GetMonstroByIdAsync((int)MonstroId);
            int vidaMonstro = monstro.VidaMax;

            int idArma = personagemViewModel.Equipamento;
            Debug.WriteLine($"personagem.equipamento: {personagemViewModel.Equipamento}     idarma: {idArma}");
            Arma arma = await armaService.GetArmaByIdAsync(idArma);
            int forcaArma = (int)arma.Dano;
            
            int forcaPersonagem = personagemViewModel.Forca;
            vidaMonstro = vidaMonstro - forcaArma*forcaPersonagem;

            Debug.WriteLine($"força da arma: {forcaArma}     froça personagem: {forcaPersonagem}    ");
            Debug.WriteLine($"vidaAtualMonstro: {vidaMonstro}");
            if (vidaMonstro <= 0)
            {
                FinalizarBatlha();
            }
        }

        private async void FinalizarBatlha()
        {
            AtualizaBotoes(await salaService.GetSalaByIdAsync(Id));
            Image2 = null;
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