using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DivineSpark.Models;
using DivineSpark.Services;
using Plugin.Maui.Audio;
using Application = Microsoft.Maui.Controls.Application;

namespace DivineSpark.ViewModels
{
    internal partial class InventarioViewModel : ObservableObject, INotifyPropertyChanged
    {
        [ObservableProperty]
        private string armaSelecionadaImagem;

        [ObservableProperty]
        private string armaSelecionadaDescricao;

        [ObservableProperty]
        private string armaSelecionadaDano;

        [ObservableProperty]
        private string ganhoNivel;

        [ObservableProperty]
        private bool equiparVisible = false;

        [ObservableProperty]
        private bool usarVisible = false;

        [ObservableProperty]
        ObservableCollection<int> armasPossuidas = new ObservableCollection<int>();

        [ObservableProperty]
        ObservableCollection<int> pocoesPossuidas = new ObservableCollection<int>();


        ArmaService armaService = new ArmaService();
        PocaoService pocaoService = new PocaoService();
        private readonly PersonagemViewModel personagemViewModel;
        private readonly IAudioManager audioManager;

        public ObservableCollection<ItemVisual> ImagensInventario { get; set; } = new();

        public ICommand SelecionarArmaCommand { get; }
        public ICommand CarregarInventarioCommand { get; set; }
        public ICommand EquiparCommand { get; set; }
        public ICommand UsarCommand { get; set; }
        public InventarioViewModel(PersonagemViewModel personagemViewModel, IAudioManager audioManager) {
            CarregarInventarioCommand = new AsyncRelayCommand(CarregarInventario);
            EquiparCommand = new Command(Equipar);
            UsarCommand = new Command(Usar);
            Debug.WriteLine("InventsrioViewmodel inicializdo");
            SelecionarArmaCommand = new RelayCommand<ItemVisual>(item => SelecionarItem(item));
            this.personagemViewModel = personagemViewModel;
            this.audioManager = audioManager;
            /*tira o comentario que o inv fica lotado de tudo*/
            armasPossuidas.Add(2);
            armasPossuidas.Add(3);
            armasPossuidas.Add(4);
            armasPossuidas.Add(5);
            armasPossuidas.Add(6);
            armasPossuidas.Add(7);
            armasPossuidas.Add(8);
            armasPossuidas.Add(9);
            armasPossuidas.Add(10);
            armasPossuidas.Add(11);
            armasPossuidas.Add(12);

            pocoesPossuidas.Add(1);
            pocoesPossuidas.Add(2);
            pocoesPossuidas.Add(3);
            pocoesPossuidas.Add(4);
            pocoesPossuidas.Add(5);
            pocoesPossuidas.Add(6);
            pocoesPossuidas.Add(7);
            pocoesPossuidas.Add(8);
            //deixa só esse 1
            ArmasPossuidas.Add(1);
        }
        
        public async Task CarregarInventario()
        {

            //adicionar no grid
           
            //armas
            ImagensInventario.Clear();
            foreach (int id in ArmasPossuidas)
            {
                Arma arma = await armaService.GetArmaByIdAsync(id);
                ImagensInventario.Add(new ItemVisual
                {
                    Source = arma.Image,
                    Descricao = arma.Descricao,
                    Dano = arma.Dano,
                    Tipo = 1
                });
                Debug.WriteLine($"adicionou uma arma na lista!!---{id}");
            }

            //pocao
            foreach (int id in PocoesPossuidas)
            {
                Pocao pocao = await pocaoService.GetPocaoByIdAsync(id);
                ImagensInventario.Add(new ItemVisual
                {
                    Source = pocao.Image,
                    Descricao = pocao.Descricao,
                    Dano = (int)pocao.GanhoVida,
                    GanhoNivel = (int)pocao.GanhoNivel,
                    Tipo = 2
                });
                Debug.WriteLine("adicionou uma pocao na lista!!");

            }
        }

            private void SelecionarItem(ItemVisual item)
            {
                if (item == null)
                {
                    Debug.WriteLine("item é nulo ao clicar. Verifique o binding do CommandParameter.");
                    return;
                }
                if(item.Tipo==1) //Arma
                {
                    ArmaSelecionadaImagem = item.Source;
                    ArmaSelecionadaDescricao = item.Descricao;
                    ArmaSelecionadaDano = "Dano: "+item.Dano.ToString("F2");
                    GanhoNivel = null;
                    EquiparVisible=true;
                    UsarVisible=false;
                }
                if(item.Tipo == 2) //Pocao
                {
                    ArmaSelecionadaImagem = item.Source;
                    ArmaSelecionadaDescricao = item.Descricao;
                    ArmaSelecionadaDano = "Ganho de vida: " + item.Dano.ToString("F1");
                    GanhoNivel = "Ganho de nivel: " + item.GanhoNivel.ToString("F1");
                    EquiparVisible = false;
                    UsarVisible = true;
            }
            }

        public async void Equipar()
        {
            ObservableCollection<Arma> armas = await armaService.GetArmasAsync();
            foreach (Arma arma in armas)
            {
                if (arma.Descricao == ArmaSelecionadaDescricao)
                {
                    personagemViewModel.Equipamento = arma.Id;
                    break;
                }
            }
            //aqui ele ta só tirando as coias da tela para quando carregar denovo o itm não estar lá
            ArmaSelecionadaImagem = null;
            ArmaSelecionadaDescricao = null;
            ArmaSelecionadaDano = null;
            GanhoNivel = null;
            EquiparVisible = false;

            //tocando som equipar
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("equipar.ogg"));
            player.Volume = 100;
            
            player.Play();
        }

        public async void Usar()
        { //nesse contexto o armaselecionadaDano é o ganho de vida bb <-----ATENÇÃO!!!!!!!111
            try
            {
                //isso aqui é um malabarismo para transformar a string com virgula de lá em int pra ca
                //ArmaSelecionadaDano = ArmaSelecionadaDano.Replace(",", ".");
                string prefixo = "Ganho de vida: ";
                ArmaSelecionadaDano = ArmaSelecionadaDano.Substring(prefixo.Length).Trim();
                //Debug.WriteLine(ArmaSelecionadaDano);
                double.TryParse(ArmaSelecionadaDano, out double ArmaSelecionadaDanoDouble);
                personagemViewModel.VidaAtual += (int)ArmaSelecionadaDanoDouble;
                //Debug.WriteLine(ArmaSelecionadaDanoDouble);

                if (personagemViewModel.VidaAtual > personagemViewModel.VidaMax)
                {
                    personagemViewModel.VidaAtual = personagemViewModel.VidaMax;
                }


                //msm malabarismo
                //GanhoNivel = GanhoNivel.Replace(",", ".");
                string prefixo2 = "Ganho de nivel: ";
                GanhoNivel = GanhoNivel.Substring(prefixo.Length).Trim();
                //Debug.WriteLine(GanhoNivel);
                double.TryParse(GanhoNivel, out double GanhoNivelDouble);
                //Debug.WriteLine(GanhoNivelDouble);
                personagemViewModel.Nivel += (int)GanhoNivelDouble;
            }catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            //malabarismo para tirar a poção da lista de possuidas
            ObservableCollection<Pocao> pocoes = await pocaoService.GetPocoesAsync();
            foreach (Pocao pocao in pocoes)
            {
                if (pocao.Descricao == ArmaSelecionadaDescricao)
                {
                    pocoesPossuidas.Remove(pocao.Id); 
                    break;
                }
            }
            //aqui ele ta só tirando as coias da tela para quando carregar denovo o itm não estar lá
            ArmaSelecionadaImagem = null;
            ArmaSelecionadaDescricao = null;
            ArmaSelecionadaDano = null;
            GanhoNivel = null;
            UsarVisible = false;

            

            //tocando som de beber
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("beber.mp3"));
            player.Volume = 100;
            
            player.Play();
        }

    }
}
