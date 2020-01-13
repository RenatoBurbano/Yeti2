using FbsMovil_Corresponsales.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace YETI.DTO
{
    public class Usuario : PrincipalVM
    {
        public string NombreCompleto { get; set; }
        public string  NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string ConfirmarContrasenia { get; set; }
        public string  Telefono { get; set; }
    }
}
