namespace DivineSpark.Views;

public partial class CreditosView : ContentPage
{
	public CreditosView()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}