using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using YETI.DTO;

namespace YETI.ViewModels
{
    [AddINotifyPropertyChangedInterface]

    public class MenuPageViewModel : ViewModelBase
    {
        public DelegateCommand NavegacionCommmand { get; set; }
        public MenuMD MenuMD { get; set; }

        public MenuPageViewModel(INavigationService navigationService, IUserDialogs userDialogs)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            MenuMD = new MenuMD();
            NavegacionCommmand = new DelegateCommand(Navegar);
        }

        private async void Navegar()
        {

        }


        #region Helpers
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        #endregion Helpers
    }
}
