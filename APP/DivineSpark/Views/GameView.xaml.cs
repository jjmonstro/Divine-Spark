using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DivineSpark.ViewModels;

namespace DivineSpark.Views;

public partial class GameView : ContentPage
{
    public GameView()
    {
        InitializeComponent();  
        BindingContext = App.Services.GetService<SalaViewModel>();

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