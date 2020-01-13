using Xamarin.Forms;

namespace YETI.Views
{
    public partial class TraductorPage : ContentPage
    {
        public TraductorPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Ientrada.Text = "Español";
            Isalida.Text = "Salida";
        }

        private void traduccir_Clicked(object sender, System.EventArgs e)
        {
            string aux = Ientrada.Text;
            Ientrada.Text = Isalida.Text;
            Isalida.Text = aux;
        }
    }
}
