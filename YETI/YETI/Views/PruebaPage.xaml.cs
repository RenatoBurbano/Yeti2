using MediaManager;
using Xamarin.Forms;

namespace YETI.Views
{
    public partial class PruebaPage : ContentPage
    {
        private string videoUrl = "https://youtu.be/Buky15I1PfM";
        public PruebaPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var htmlcontent = new HtmlWebViewSource();
            var htmlcontent2 = new HtmlWebViewSource();
            htmlcontent.Html = "<html><head></head><body>" +
                "<iframe width='FillAndExpand' height='202' src='https://www.youtube.com/embed/RaZWStCMNN0' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" +
            "</body></html>";
            Video.Source = htmlcontent;
            htmlcontent2.Html = "<html><head></head><body>" +
            "<iframe width='FillAndExpand' height='202' src='https://www.youtube.com/embed/k60EJKdoh8o' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" +
            "</body></html>";
            Video2.Source = htmlcontent2;
        }

        private async void playStop_Clicked(object sender, System.EventArgs e)
        {
            if (playStop.Text == "PLAY")
            {
                await CrossMediaManager.Current.Play(videoUrl);
                playStop.Text = "STOP";
            }
            else if (playStop.Text == "STOP")
            {
                await CrossMediaManager.Current.Stop();
                playStop.Text = "PLAY";
            }
        }
    }
}
