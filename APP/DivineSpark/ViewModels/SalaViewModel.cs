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
using Plugin.Maui.Audio;



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

        [ObservableProperty]
        private int image2Rotation=0;

        [ObservableProperty]
        private double image2Scale=1;

        [ObservableProperty]
        public bool jogarDNV = false;

        [ObservableProperty]
        public bool bauVisible = false;

        [ObservableProperty]
        public bool inventarioVisible = true;

        [ObservableProperty]
        public bool nivelVisible = true;

        [ObservableProperty]
        public string? vidaExibirSala = "";

 



        SalaService salaService = new SalaService();
        MonstroService monstroService = new();
        private readonly PersonagemViewModel personagemViewModel;
        ArmaService armaService = new ArmaService();
        BauService bauService = new BauService();
        private readonly InventarioViewModel inventarioViewModel;
        private readonly IAudioManager audioManager;

        public ICommand TesteCommand { get; set; }
        public ICommand AtualizaSalaCommand { get; set; }
        public ICommand EsquerdaButtonCommand { get; set; }
        public ICommand DireitaButtonCommand { get; set; }
        public ICommand FrenteButtonCommand { get; set; }
        public ICommand TrasButtonCommand { get; set; }
        public ICommand AtacarCommand { get; set; }
        public ICommand JogarNovamenteCommand { get; set; }
        public ICommand AbrirBauCommand { get; set; }
        public ICommand AtualizaVidaCommand { get; set; }
        public SalaViewModel(PersonagemViewModel personagemViewModel, InventarioViewModel inventarioViewModel, IAudioManager audioManager)
        {
            //GerarSalaCommand = new Command(GerarSala);
            Debug.WriteLine("SalaViewModel inicializado");
            salaService = new SalaService();
            /*StartCommand = new Command(AtualizaSala);*/
            AtualizaSalaCommand = new Command<int>(async (id) => await AtualizaSala(id));
            EsquerdaButtonCommand = new Command(EsquerdaButton);
            DireitaButtonCommand = new Command(DireitaButton);
            FrenteButtonCommand = new Command(FrenteButton);
            TrasButtonCommand = new Command(TrasButton);
            AtacarCommand = new Command(Atacar);
            JogarNovamenteCommand = new Command(JogarNovamente);
            AbrirBauCommand = new Command(AbrirBau);
            AtualizaVidaCommand = new Command(AtualizaVida);
            this.personagemViewModel = personagemViewModel;
            this.inventarioViewModel = inventarioViewModel;
            this.audioManager = audioManager;
            AtualizaSalaCommand.Execute(1);

            // Cria um timer que atualiza a vida a cada 1 segundo, não precisa ficar chamando atualizaVida
            // em lugar nenhum mais porém estou com preguiça de tirar tudo
            // (pode estar sugando processamento mas não ligo)
            var timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(2); // Define o intervalo de 2 segundos
            timer.Tick += (s, e) =>
            {
                AtualizaVida();
            };
            timer.Start(); // Inicia o timer
        }


            //essa lista guarda as salas de monstro que você ja passou e faz com que o monstro não apareça mais nela, tbm ta servindo para bau
            List<int> SalasJaDerrotadas = new List<int>();
        public async Task AtualizaSala(int id)
        {
           
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
/*                Debug.WriteLine($"SALAS JÁ DERROTADAS----{SalasJaDerrotadas}----");
*/                IniciarBatalha();
            }

            //Bau
            if (BauId != null && !SalasJaDerrotadas.Contains(Id))
            {
                SalasJaDerrotadas.Add(Id);
/*                Debug.WriteLine($"SALAS JÁ furtadas ou derrotadas----{SalasJaDerrotadas}----");
*/                BauVisible = true;
                PodeEsquerda = false;
                PodeDireita = false;
                PodeFrente = false;
                PodeTras = false;
            }
             AtualizaVida();
        }

        public async void AtualizaVida()
        {
            Debug.WriteLine("AtualizaVida Chamado!!!!!!!!!!!!!");
            VidaExibirSala = "vida: " + Convert.ToString(personagemViewModel.VidaAtual) + "/" + Convert.ToString(personagemViewModel.VidaMax);
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

        private async void AbrirBau()
        {
            Bau bau = await bauService.GetBauByIdAsync((int)BauId);

            if (bau.ArmaId != null)
            {
                inventarioViewModel.ArmasPossuidas.Add((int)bau.ArmaId);
            }
            else if (bau.PocaoId != null)
            {
                inventarioViewModel.PocoesPossuidas.Add((int)bau.PocaoId);
            }

            BauVisible = false;
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("abrirbau.mp3"));
            player.Volume = 100;
           
            player.Play();
            AtualizaBotoes(await salaService.GetSalaByIdAsync(Id));

        }

        public async void EsquerdaButton()
        {
            Sala sala = await salaService.GetSalaByIdAsync(Id);
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("andar.mp3"));
            player.Volume = 100;
            player.SetSpeed(1.5);
            player.Play();
            AtualizaSala((int)sala.Esquerda);
        }

        public async void DireitaButton()
        {
            Sala sala = await salaService.GetSalaByIdAsync(Id);
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("andar.mp3"));
            player.Volume = 100;
            player.SetSpeed(1.5);
            player.Play();
            AtualizaSala((int)sala.Direita);
        }


        public async void FrenteButton()
        {
            try
            {
                Sala sala = await salaService.GetSalaByIdAsync(Id);
                var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("andar.mp3"));
                player.Volume=100;
                player.SetSpeed(1.5);
                player.Play();
                


                AtualizaSala((int)sala.Frente);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public async void TrasButton()
        {
            Sala sala = await salaService.GetSalaByIdAsync(Id);
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("andar.mp3"));
            player.Volume = 100;
            player.SetSpeed(1.5);
            player.Play();
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

        private int vidaMonstro;
        public async void Atacar()
        {
            //som
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("hit.mp3"));
            player.Volume = 100;
            player.Play();

            //faz a img balançar
            Image2Rotation += 7;
            image2Scale += 0.5;
            await Task.Delay(50);
            Image2Rotation -= 14;
            image2Scale -= 0.8;
            await Task.Delay(50);
            Image2Rotation += 7;
            image2Scale += 0.3;
            await Task.Delay(50);


            Debug.WriteLine("Atacou!!");
            Monstro monstro = await monstroService.GetMonstroByIdAsync((int)MonstroId);
            if (vidaMonstro == 0)
            {
                vidaMonstro = monstro.VidaMax;
            }

            int idArma = personagemViewModel.Equipamento;
           // Debug.WriteLine($"personagem.equipamento: {personagemViewModel.Equipamento}     idarma: {idArma}");
            Arma arma = await armaService.GetArmaByIdAsync(idArma);
            int forcaArma = (int)arma.Dano;
            int forcaPersonagem = personagemViewModel.Forca;

            //tirando vida do monstro
            //vidaMonstro = vidaMonstro - forcaArma*forcaPersonagem;

            //tirando vida do personagem
            //personagemViewModel.vidaAtual = personagemViewModel.vidaAtual - monstro.Forca;
            //Debug.WriteLine($"monstro.Forca{monstro.Forca}---VIDA PERSONAGEM-- {personagemViewModel.vidaAtual} ---");
            int velocidade;
            if (monstro.Agilidade>personagemViewModel.Agilidade)
            {
                velocidade = 1; //monstro é mais rápido
            }
            else
            {
                velocidade = 2; //personagem é mais rápido
            }

            switch (velocidade)
            {
                case 1:
                    
                    personagemViewModel.vidaAtual = personagemViewModel.vidaAtual - monstro.Forca;
                    AtualizaVida();
                    if (personagemViewModel.vidaAtual <= 0)
                    {
                        Perder();
                        return;
                    }
                    vidaMonstro = vidaMonstro - forcaArma * forcaPersonagem;
                    if (vidaMonstro <= 0)
                    {
                        FinalizarBatlha();
                        vidaMonstro = 0;
                        return;
                    }
                    break;
                case 2:
                    vidaMonstro = vidaMonstro - forcaArma * forcaPersonagem;
                    if (vidaMonstro <= 0)
                    {
                        FinalizarBatlha();
                        vidaMonstro = 0;
                        return;
                    }
                    personagemViewModel.vidaAtual = personagemViewModel.vidaAtual - monstro.Forca;
                    AtualizaVida();
                    if (personagemViewModel.vidaAtual <= 0)
                    {
                        Perder();
                        return;
                    }
                    break;
            }

            

        }

        public void JogarNovamente()
        {
            // Obter o nome do arquivo atual
            var fileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

            // Iniciar uma nova instância do processo
            System.Diagnostics.Process.Start(fileName);
            
            // Encerrar a instância atual
            Environment.Exit(0);
        }

        private async void FinalizarBatlha()
        {
            AtualizaBotoes(await salaService.GetSalaByIdAsync(Id));
            Image2 = null;
            personagemViewModel.Nivel += 2;
        }

        private async void Perder()
        {
            Image2 = "perdeu.png";
            PodeEsquerda = false;
            PodeDireita = false;
            PodeFrente = false;
            PodeTras = false;
            AtacarButton = false;
            InventarioVisible = false;
            NivelVisible = false;
            JogarDNV = true;
        }
    }
}
