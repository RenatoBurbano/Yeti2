using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YETI.ViewModels
{
    public class GramaticaPageViewModel : ViewModelBase
    {
        public DelegateCommand EjerciciosCommand { get; set; }

        public GramaticaPageViewModel(INavigationService navigationService, IUserDialogs userDialogs)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            EjerciciosCommand = new DelegateCommand(Navegar);
        }

        private async void Navegar()
        {
            using (_userDialogs.Loading("Cargando"))
            {
                try
                {
                    await _navigationService.NavigateAsync("EjerciciosPage");
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
