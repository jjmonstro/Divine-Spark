using System.Diagnostics;
using DivineSpark.ViewModels;
namespace DivineSpark.Views;


public partial class InventarioView : ContentPage
{
	public InventarioView()
	{
		InitializeComponent();
        BindingContext = App.Services.GetService<InventarioViewModel>();
    }
        InventarioViewModel ivm = App.Services.GetService<InventarioViewModel>();
    private async void EquiparButton_ClickedAsync(object sender, EventArgs e)
    {
        ivm.Equipar();
        await Navigation.PopAsync();
    }

    private async void UsarButton_Clicked(object sender, EventArgs e)
    {
        ivm.Usar();
        await Navigation.PopAsync();
    }

    private async void VoltarButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}