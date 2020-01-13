using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System.Net.Http;
using System.Collections;
using Json.Net;
using System;
using YETI.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using PropertyChanged;

namespace YETI.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TraductorPageViewModel : ViewModelBase
    {
        public DelegateCommand TraducirCommand { get; set; }
        public DelegateCommand SeleccionarIdiomaCommand { get; set; }
        public TraductorMD TraductorMD { get; set; }
        public TraductorPageViewModel(INavigationService navigationService, IUserDialogs userDialogs)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            TraductorMD = new TraductorMD();
            TraductorMD.Ientrada = "ES";
            TraductorMD.Isalida = "EN";
            TraducirCommand = new DelegateCommand(Traducir);
            SeleccionarIdiomaCommand = new DelegateCommand(Seleccionar);
        }

        private void Seleccionar()
        {
            string aux = TraductorMD.Ientrada;
            TraductorMD.Ientrada = TraductorMD.Isalida;
            TraductorMD.Isalida = aux;
        }

        private async void Traducir()
        {
            TraductorMD.Salida = null;
            using (_userDialogs.Loading("Cargando"))
            {
                // Set the language from/to in the url (or pass it into this function)
                string url = String.Format
                ("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
                 TraductorMD.Ientrada, TraductorMD.Isalida, Uri.EscapeUriString(TraductorMD.Entrada));
                HttpClient httpClient = new HttpClient();
                try
                {
                    var result = await httpClient.GetStringAsync(url);
                    for (int j = 0; j < result.Length; j++)
                    {
                        if (result[j] == 34)
                        {
                            for (int i = j + 1; i < result.Length; i++)
                            {
                                if (result[i] == 34)
                                {
                                    i = result.Length;
                                    j = result.Length;
                                }
                                else
                                {
                                    TraductorMD.Salida += string.Format("{0}", result[i]);
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    _userDialogs.Alert(e.Message);
                }
            }
        }

        #region Helpers
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        #endregion Helpers

    }
}
