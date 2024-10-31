using System.Diagnostics;
using DivineSpark.ViewModels;

namespace DivineSpark.Views;

public partial class EscolhaPage : ContentPage
{

	public EscolhaPage()
	{
		InitializeComponent();
        BindingContext = new PersonagemViewModel();
	}

    private void OnButton1Clicked(object sender, EventArgs e)
    {
        EscolhaButton1.IsVisible = true;
        EscolhaButton2.IsVisible = false;
        EscolhaButton3.IsVisible = false;
    }

    private void OnButton2Clicked(object sender, EventArgs e)
    {
        EscolhaButton2.IsVisible = true;
        EscolhaButton1.IsVisible = false;
        EscolhaButton3.IsVisible = false;
    }

    private void OnButton3Clicked(object sender, EventArgs e)
    {
        EscolhaButton3.IsVisible = true;
        EscolhaButton2.IsVisible = false;
        EscolhaButton1.IsVisible = false;
    }

    private async void Escolher1Clicked(object sender, EventArgs e)
    {
        var pv = App.Services.GetService<PersonagemViewModel>();
        await pv.Escolher(1);
        Navigation.PushAsync(new GameView());

        
    }

    private async void EscolhaButton2_Clicked(object sender, EventArgs e)
    {
        var pv = App.Services.GetService<PersonagemViewModel>();

        await pv.Escolher(2);
        Navigation.PushAsync(new GameView());
        
    }

    private async void EscolhaButton3_Clicked(object sender, EventArgs e)
    {
        var pv = App.Services.GetService<PersonagemViewModel>();
        await pv.Escolher(3);
        Navigation.PushAsync(new GameView());
        
    }

}