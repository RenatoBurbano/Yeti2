using Acr.UserDialogs;
using Android;
using Android.Media;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YETI.DTO;

namespace YETI.ViewModels
{
    [AddINotifyPropertyChangedInterface]

    public class EscucharPageViewModel : ViewModelBase
    {
        public DelegateCommand ReproducirCommand { get; set; }
        public DelegateCommand PausarCommand { get; set; }
        public DelegateCommand PararCommand { get; set; }
        public DelegateCommand ComprobarCommand { get; set; }

        public EscucharMD EscucharMD { get; set; }

        MediaPlayer player = new MediaPlayer();

        public EscucharPageViewModel(INavigationService navigationService, IUserDialogs userDialogs)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            player = App.player;
            EscucharMD = new EscucharMD();
            ReproducirCommand = new DelegateCommand(Iniciar);
            PausarCommand = new DelegateCommand(Pausar);
            PararCommand = new DelegateCommand(Parar);
            ComprobarCommand = new DelegateCommand(Comprobar);
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
                //player.Stop();
                //player.Reset();
            }
            catch (Exception e)
            {
                _userDialogs.Alert(e.Message);
            }

        }

        private void Comprobar()
        {
            int aciertos=0, errores=0;
            if(EscucharMD.Answer1 == "Blue Air")
            {
                aciertos++;
            }
            else
            {
                errores++;
            }

            if (EscucharMD.Answer2 == "4.45")
            {
                aciertos++;
            }
            else
            {
                errores++;
            }
            if (EscucharMD.Answer3 == "3 hours and 50 minutes")
            {
                aciertos++;
            }
            else
            {
                errores++;
            }
            if (EscucharMD.Answer4 == "France, Italy and Greece")
            {
                aciertos++;
            }
            else
            {
                errores++;
            }
            if (EscucharMD.Answer5 == "steak")
            {
                aciertos++;
            }
            else
            {
                errores++;
            }
            if (EscucharMD.Answer6 == "Snakes on a Plane")
            {
                aciertos++;
            }
            else
            {
                errores++;
            }

            _userDialogs.Alert("Aciertos: "+aciertos+" Errores: "+errores,"RESULTS","OK");
        }


        #region Helpers
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        #endregion Helpers

    }
}
