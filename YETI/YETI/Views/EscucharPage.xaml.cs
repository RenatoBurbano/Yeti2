using Xamarin.Forms;

namespace YETI.Views
{
    public partial class EscucharPage : ContentPage
    {
        public EscucharPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void steak_Clicked(object sender, System.EventArgs e)
        {
            five.Text = "steak";
        }

        private void fish_Clicked(object sender, System.EventArgs e)
        {
            //five.Text = "fish";
        }

        private void chicken_Clicked(object sender, System.EventArgs e)
        {
            //five.Text = "chicken";
            //ASPNetSpell.Html.SpellAsYouType asYouType = new ASPNetSpell.Html.SpellAsYouType();
            //asYouType.getHtml();
            //ASPNetSpell.SpellChecker spellChecker = new ASPNetSpell.SpellChecker();
            //spellChecker.DictionaryPath;
        }
    }
}
