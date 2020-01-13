using FbsMovil_Corresponsales.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace YETI.DTO
{
    public class TraductorMD : PrincipalVM
    {
        public string Entrada { get; set; }
        public string Salida { get; set; }
        public string Isalida { get; set; }
        public string Ientrada { get; set; }
        public bool Seleccion { get; set; }
    }
}
