using DivineSpark.ViewModels;
using DivineSpark.Views;
using Microsoft.Extensions.DependencyInjection;
using Plugin.Maui.Audio;

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

            service.AddSingleton<IAudioManager>(AudioManager.Current);

            service.AddSingleton<PersonagemViewModel>();

            service.AddSingleton<InventarioViewModel>(provider =>
            {
                var personagemViewModel = provider.GetService<PersonagemViewModel>();
                var audioManager = provider.GetService<IAudioManager>();
                return new InventarioViewModel(personagemViewModel,audioManager);
            });

            service.AddTransient<SalaViewModel>(provider =>
            {
                var personagemViewModel = provider.GetService<PersonagemViewModel>();
                var audioManager = provider.GetService<IAudioManager>();
                var inventarioViewModel = provider.GetService<InventarioViewModel>();
                return new SalaViewModel(personagemViewModel,inventarioViewModel,audioManager);
            });

            Services = service.BuildServiceProvider();

            //aqui é meu page ocerto
            MainPage = new NavigationPage(new MenuPage());
        }

    }
}
