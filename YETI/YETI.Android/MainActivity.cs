using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Prism;
using Prism.Ioc;
using System.IO;
using Xamarin.Forms;

namespace YETI.Droid
{
    [Activity(Label = "YETI", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        MediaPlayer player;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            UserDialogs.Init(() => this);

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            string nombreArchivo = "bd_Usuarios";
            string rutaCarpeta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string ruta = Path.Combine(rutaCarpeta, nombreArchivo);

            player = MediaPlayer.Create(this, Resource.Raw.audio1);
            //player.Start();
            App.player = this.player;
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

