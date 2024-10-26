using System.Diagnostics;
using DivineSpark.ViewModels;
namespace DivineSpark.Views;


public partial class InventarioView : ContentPage
{
	public InventarioView()
	{
		BindingContext = new InventarioViewModel();
		InitializeComponent();
	}


}