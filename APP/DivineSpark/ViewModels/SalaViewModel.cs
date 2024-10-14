using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using DivineSpark.Models;
using DivineSpark.Services;


namespace DivineSpark.ViewModels
{
    internal partial class SalaViewModel : ObservableObject
    {
        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public int monstroId;

        [ObservableProperty]
        public int bauID;

        [ObservableProperty]
        public string image = "salaf.png";

        [ObservableProperty]
        public bool podeEsquerda = false;

        [ObservableProperty]
        public bool podeFrente = true;

        [ObservableProperty]
        public bool podeDireita = false;

        SalaService salaService;

        public ICommand GerarSalaCommand { get; }
        public ImageSource ImageSource { get; private set; }

        public SalaViewModel()
        {
             GerarSalaCommand = new Command(GerarSala);
             salaService= new SalaService();    
        }

        public async void GerarSala()
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
            }

            //atualizando os botões na tela
            

        }
    }
}
