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
using Application = Microsoft.Maui.Controls.Application;

namespace DivineSpark.ViewModels
{
    public partial class InventarioViewModel : ObservableObject, INotifyPropertyChanged
    {
        [ObservableProperty]
        private string armaSelecionadaImagem;

        [ObservableProperty]
        private string armaSelecionadaDescricao;

        [ObservableProperty]
        private string armaSelecionadaDano;

        [ObservableProperty]
        private string ganhoNivel;

        ArmaService armaService = new ArmaService();
        PocaoService pocaoService = new PocaoService();
        public ObservableCollection<ItemVisual> ImagensInventario { get; set; } = new();

        public ICommand SelecionarArmaCommand { get; }
        public ICommand CarregarInventarioCommand { get; set; }
        public InventarioViewModel() {
            CarregarInventarioCommand = new AsyncRelayCommand(CarregarInventario);
            Debug.WriteLine("InventsrioViewmodel inicializdo");
            CarregarInventarioCommand.Execute(null);
            SelecionarArmaCommand = new RelayCommand<ItemVisual>(item => SelecionarItem(item));
        }

        public async Task CarregarInventario()
        {
            Debug.WriteLine("carregar inventario inicializdo");
            List<int> ArmasPossuidas = new List<int>() { 1, 2, 3, 4, 5 , 6, 7, 8, 9, 10, 11, 12};
            List<int> PocoesPossuidas = new List<int>() { 1, 2, 3, 4, 5 , 6, 7, 8};

            //to adicionando artificialmente para teste, o certo é quando você ganhar um item ele vim parar com o id nessas listas
           

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
                if(item.Tipo==1)
                {
                    ArmaSelecionadaImagem = item.Source;
                    ArmaSelecionadaDescricao = item.Descricao;
                    ArmaSelecionadaDano = "Dano: "+item.Dano.ToString("F2");
                    GanhoNivel = null;
                }
                if(item.Tipo == 2)
                {
                ArmaSelecionadaImagem = item.Source;
                ArmaSelecionadaDescricao = item.Descricao;
                ArmaSelecionadaDano = "Ganho de vida: " + item.Dano.ToString("F1");
                GanhoNivel = "Ganho de nivel: " + item.GanhoNivel.ToString("F1");
            }
            }
    }
}
