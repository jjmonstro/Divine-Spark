using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using DivineSpark.Models;
using DivineSpark.Services;
using Application = Microsoft.Maui.Controls.Application;

namespace DivineSpark.ViewModels
{
    class InventarioViewModel
    {


        ArmaService armaService = new ArmaService();
        PocaoService pocaoService = new PocaoService();
        public ObservableCollection<Image> ImagensInventario { get; set; } = new();

        public ICommand CarregarInventarioCommand { get; set; }
        public InventarioViewModel() {
            CarregarInventarioCommand = new AsyncRelayCommand(CarregarInventario);
            Debug.WriteLine("InventsrioViewmodel inicializdo");
            CarregarInventarioCommand.Execute(null);
        }

        public async Task CarregarInventario()
        {
            Debug.WriteLine("carregar inventario inicializdo");
            List<int> ArmasPossuidas = new List<int>();
            List<int> PocoesPossuidas = new List<int>();

            //to adicionando artificialmente para teste, o certo é quando você ganhar um item ele vim parar com o id nessas listas
            ArmasPossuidas.Add(1);
            ArmasPossuidas.Add(2);
            ArmasPossuidas.Add(3);
            ArmasPossuidas.Add(4);
            ArmasPossuidas.Add(5);
            ArmasPossuidas.Add(6);
            ArmasPossuidas.Add(7);
            ArmasPossuidas.Add(8);
            ArmasPossuidas.Add(9);
            ArmasPossuidas.Add(10);
            ArmasPossuidas.Add(11);
            ArmasPossuidas.Add(12);
            PocoesPossuidas.Add(1);
            PocoesPossuidas.Add(2);
            PocoesPossuidas.Add(3);
            PocoesPossuidas.Add(4);
            PocoesPossuidas.Add(5);
            PocoesPossuidas.Add(6);
            PocoesPossuidas.Add(7);
            PocoesPossuidas.Add(8);

            //adicionar no grid
            //armas
            ImagensInventario.Clear();
            foreach (int id in ArmasPossuidas)
            {
                Arma arma = await armaService.GetArmaByIdAsync(id);
                ImagensInventario.Add(new Image
                {
                    Source = arma.Image,
                    Aspect = Aspect.AspectFit
                });

            }

            foreach (int id in PocoesPossuidas)
            {
                Pocao pocao = await pocaoService.GetPocaoByIdAsync(id);
                ImagensInventario.Add(new Image
                {
                    Source = pocao.Image,
                    Aspect = Aspect.AspectFit
                   
                   
                });


            }

        }
    }
}
