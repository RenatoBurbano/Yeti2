using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YETI.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand InicioSesionCommand { get; set; }
        public DelegateCommand CrearUsuarioCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService, IUserDialogs userDialogs)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            InicioSesionCommand = new DelegateCommand(IniciarSesion);
            CrearUsuarioCommand = new DelegateCommand(CrearUsuario);
        }

        private async void IniciarSesion()
        {
            try
            {
                await _navigationService.NavigateAsync("InicioSesionPage");
            }
            catch (Exception e)
            {
                _userDialogs.Alert(e.Message);
            }
        }

        private async void CrearUsuario()
        {
            try
            {
                await _navigationService.NavigateAsync("CrearUsuarioPage");
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
