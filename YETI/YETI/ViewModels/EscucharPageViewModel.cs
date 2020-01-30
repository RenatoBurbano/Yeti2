using Acr.UserDialogs;
using Android;
using Android.Media;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YETI.ViewModels
{
    public class EscucharPageViewModel : ViewModelBase
    {
        public DelegateCommand ReproducirCommand { get; set; }

        MediaPlayer player = new MediaPlayer();

        public EscucharPageViewModel(INavigationService navigationService, IUserDialogs userDialogs)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            player = App.player;
            ReproducirCommand = new DelegateCommand(Iniciar);
        }
        private void Iniciar()
        {
            try
            {
                player.Start();
            }
            catch (Exception e)
            {
                _userDialogs.Alert(e.Message);
            }

        }
        #region Helpers
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        #endregion Helpers

    }
}
