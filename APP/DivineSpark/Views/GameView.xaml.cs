using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DivineSpark.ViewModels;
using System.Threading;
using System.Threading.Tasks;
namespace DivineSpark.Views;

public partial class GameView : ContentPage
{
    public GameView()
    {
        InitializeComponent();  
        BindingContext = App.Services.GetService<SalaViewModel>();

        // Cria um timer que exibe uma mensagem a cada 1 segundo
        var timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1); // Define o intervalo de 1 segundo
        timer.Tick += (s, e) =>
        {
            SalaViewModel svm = App.Services.GetService<SalaViewModel>();
            svm.AtualizaVida();
        };
        timer.Start(); // Inicia o timer
    }

    private async void InventarioButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InventarioView());
        InventarioViewModel ivm = App.Services.GetService<InventarioViewModel>();
        ivm.CarregarInventario();
    }

    private async void NivelButtonClicked(object sender, EventArgs e)
    {
        PersonagemViewModel pvm = App.Services.GetService<PersonagemViewModel>();
        pvm.AtualizaSatatus();
        await Navigation.PushAsync(new NivelView());
    }
}