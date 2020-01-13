using System.ComponentModel;

namespace FbsMovil_Corresponsales.ViewModels
{
    public class PrincipalVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            //INICIALIZAR EL EVENTO DE PROPIEDAD CAMBIADA
            PropertyChangedEventHandler handler = PropertyChanged;
            //VERIFICAR SI EL EVENTO ES DIFERENTE DE NULO ES DECIR SI NO SE INICIALIZO EL EVENTO
            if (handler != null)
            {
                //SI ES DIFERENTE DE NULO DISPARA EL EVENTO CON EL NOMBRE DE LA PROPIEDAD QUE SERA EL PARAMETRO STRING DEL METODO
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
