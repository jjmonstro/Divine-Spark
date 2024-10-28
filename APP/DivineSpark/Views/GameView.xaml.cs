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
        Debug.WriteLine("inventario foi clicado");
        await Navigation.PushAsync(new InventarioView());
    }
}