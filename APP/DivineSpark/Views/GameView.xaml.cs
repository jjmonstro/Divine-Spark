using DivineSpark.ViewModels;

namespace DivineSpark.Views;

public partial class GameView : ContentPage
{
	public GameView()
	{
		InitializeComponent();
		BindingContext = new SalaViewModel();
    }
}