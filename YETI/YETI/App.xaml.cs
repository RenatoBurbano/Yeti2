using Prism;
using Prism.Ioc;
using YETI.ViewModels;
using YETI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;
using Android.Media;
using MediaManager;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace YETI
{
    public partial class App
    {
        public static MediaPlayer player = new MediaPlayer();
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }



        protected override async void OnInitialized()
        {
            InitializeComponent();
            CrossMediaManager.Current.Init();
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        public static string Ruta_DB;

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterInstance<IUserDialogs>(UserDialogs.Instance);
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<InicioSesionPage, InicioSesionPageViewModel>();
            containerRegistry.RegisterForNavigation<CrearUsuarioPage, CrearUsuarioPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<VocabularioPage, VocabularioPageViewModel>();
            containerRegistry.RegisterForNavigation<GramaticaPage, GramaticaPageViewModel>();
            containerRegistry.RegisterForNavigation<EjerciciosPage, EjerciciosPageViewModel>();
            containerRegistry.RegisterForNavigation<TraductorPage, TraductorPageViewModel>();
            containerRegistry.RegisterForNavigation<EscucharPage, EscucharPageViewModel>();
            containerRegistry.RegisterForNavigation<PruebaPage, PruebaPageViewModel>();
        }
    }
}
