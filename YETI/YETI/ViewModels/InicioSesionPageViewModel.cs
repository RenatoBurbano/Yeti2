using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YETI.DTO;

namespace YETI.ViewModels
{
    public class InicioSesionPageViewModel : ViewModelBase
    {
        public DelegateCommand IngresarCommand { get; set; }
        public LoginMD LoginMD { get; set; }


        public InicioSesionPageViewModel(INavigationService navigationService, IUserDialogs userDialogs)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            LoginMD = new LoginMD();
            IngresarCommand = new DelegateCommand(Ingresar);
        }

        private async void Ingresar()
        {
            try
            {
                string nombreArchivo = "bd_Usuarios";
                string rutaCarpeta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string ruta = Path.Combine(rutaCarpeta, nombreArchivo);
                using (var conn = new SQLiteConnection(ruta))
                {
                    conn.CreateTable<Usuario>();
                    LoginMD.Usuarios = conn.Table<Usuario>().ToList();
                }
                bool navegar = false;
                foreach (Usuario item in LoginMD.Usuarios)
                {
                    if (item.NombreUsuario == LoginMD.Usuario && item.Contrasenia == LoginMD.Contrasenia)
                    {
                        navegar = true;
                    }
                }
                if (navegar)
                {
                    await _navigationService.NavigateAsync("MenuPage");
                }
                else
                {
                    _userDialogs.Alert("La contraseña o el usuario es incorrecta","Error de Autentificación", "Retroceder");
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
