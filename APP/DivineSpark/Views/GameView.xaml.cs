using System.Diagnostics;
using DivineSpark.ViewModels;

namespace DivineSpark.Views;

public partial class GameView : ContentPage
{
    public GameView()
    {
        InitializeComponent();
        BindingContext = new SalaViewModel();
        
    }
        void OnJogarClicked(object sender, EventArgs e)
        {
            SalaViewModel viewModel = new SalaViewModel();
            viewModel.AtualizaSala(1);
        }
}