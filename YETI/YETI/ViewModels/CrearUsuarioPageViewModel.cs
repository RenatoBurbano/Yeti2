using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YETI.DTO;

namespace YETI.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CrearUsuarioPageViewModel : ViewModelBase
    {
        public DelegateCommand CrearUsuarioCommand { get; set; }
        public Usuario UsuarioMD { get; set; }

        public CrearUsuarioPageViewModel(INavigationService navigationService, IUserDialogs userDialogs)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            UsuarioMD = new Usuario();
            CrearUsuarioCommand = new DelegateCommand(CrearUsuario);
        }

        private async void CrearUsuario()
        {
            try
            {
                string nombreArchivo = "bd_Usuarios";
                string rutaCarpeta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string ruta = Path.Combine(rutaCarpeta, nombreArchivo);
                using (var conn = new SQLiteConnection(ruta))
                {
                    conn.CreateTable<Usuario>();
                    conn.Insert(UsuarioMD);
                    await _navigationService.NavigateAsync("/NavigationPage/InicioSesionPage");
                }
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
