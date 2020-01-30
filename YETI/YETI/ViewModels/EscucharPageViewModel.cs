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
        public DelegateCommand PausarCommand { get; set; }
        public DelegateCommand PararCommand { get; set; }

        MediaPlayer player = new MediaPlayer();

        public EscucharPageViewModel(INavigationService navigationService, IUserDialogs userDialogs)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            player = App.player;
            ReproducirCommand = new DelegateCommand(Iniciar);
            PausarCommand = new DelegateCommand(Pausar);
            PararCommand = new DelegateCommand(Parar);
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

        private void Pausar()
        {
            try
            {
                if (player.IsPlaying)
                    player.Pause();
            }
            catch (Exception e)
            {
                _userDialogs.Alert(e.Message);
            }

        }

        private void Parar()
        {
            try
            {
                player.Stop();
                player.Reset();
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
