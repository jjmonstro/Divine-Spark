using System.Diagnostics;
using DivineSpark.ViewModels;

namespace DivineSpark.Views;

public partial class NivelView : ContentPage
{
	public NivelView()
	{
		InitializeComponent();
        BindingContext = App.Services.GetService<PersonagemViewModel>();
    }

    private async void ConfirmarButton_Clicked(object sender, EventArgs e)
    {
        
        SalaViewModel svm = App.Services.GetService<SalaViewModel>();
        svm.AtualizaVida();


        PersonagemViewModel pvm = App.Services.GetService<PersonagemViewModel>();
        pvm.PontosRetorno = 0;

        Navigation.PopAsync();
    }
}