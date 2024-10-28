using DivineSpark.ViewModels;
using Microsoft.Extensions.DependencyInjection;


namespace DivineSpark
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        public App()
        {
            InitializeComponent();

            // Configurando DI (isso aqui ta servindo para que eu possa usar os valores da personagem viewmodel (setados quando Esolher() roda) na salaviewmodel)
            var service = new ServiceCollection();
            service.AddSingleton<PersonagemViewModel>();
            service.AddTransient<SalaViewModel>(provider =>
            {
                var personagemViewModel = provider.GetService<PersonagemViewModel>();
                return new SalaViewModel(personagemViewModel);
            });
            service.AddTransient<InventarioViewModel>();

            Services = service.BuildServiceProvider();
            MainPage = new NavigationPage(new AppShell());
        }

    }
}
