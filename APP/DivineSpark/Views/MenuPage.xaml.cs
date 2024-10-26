using DivineSpark.ViewModels;

namespace DivineSpark.Views;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
        
    }
    private async void JogarBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EscolhaPage());
    }
}