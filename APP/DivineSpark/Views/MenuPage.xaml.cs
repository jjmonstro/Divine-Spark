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
        //aqui eu to fazendo o teste levando direto para o invent�rio, o correto � EscolhaPage
        await Navigation.PushAsync(new InventarioView());
    }
}