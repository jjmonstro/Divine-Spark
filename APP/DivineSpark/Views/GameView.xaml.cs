using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DivineSpark.ViewModels;

namespace DivineSpark.Views;

public partial class GameView : ContentPage, INotifyPropertyChanged
{
    public GameView()
    {
        InitializeComponent();  
        BindingContext = App.Services.GetService<SalaViewModel>();

    }

    private void InventarioButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new InventarioView());
    }
}