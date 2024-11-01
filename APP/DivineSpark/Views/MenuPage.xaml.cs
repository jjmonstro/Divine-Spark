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
        //o correto é new EscolhaPage
        await Navigation.PushAsync(new EscolhaPage());
    }

    private async void CreditosButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreditosView());
    }


}