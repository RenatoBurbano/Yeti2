﻿using Xamarin.Forms;

namespace YETI.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Ajustes_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new VocabularioPage());
        }
        private async void Vocabulario_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new VocabularioPage());
        }

        private async void Gramatica_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GramaticaPage());
        }
        private async void Ejercicios_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new EjerciciosPage());
        }
        private async void Escuchar_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new VocabularioPage());
        }
        private async void Pruebas_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new VocabularioPage());
        }
    }
}
