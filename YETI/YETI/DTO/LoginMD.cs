using System;
using System.Collections.Generic;
using System.Text;

namespace YETI.DTO
{
    public class LoginMD
    {
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public List<Usuario> Usuarios { get; set; }

        public LoginMD()
        {
            Usuarios = new List<Usuario>();
        }
    }
}
