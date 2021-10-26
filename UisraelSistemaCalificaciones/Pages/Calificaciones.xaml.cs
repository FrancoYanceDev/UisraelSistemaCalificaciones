using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UisraelSistemaCalificaciones
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calificaciones : ContentPage
    {

        /*
         * Declarar variables
         */
        string TxtNotaSeguimineto1;
        string TxtNotaExamen1;
        string TxtNotaSeguimineto2;
        string TxtNotaExamen2;

        double NotaSeguimineto1 = 0;
        double NotaExamen1 = 0;
        double NotaParcial1 = 0;

        double NotaSeguimineto2 = 0;
        double NotaExamen2 = 0;
        double NotaParcial2 = 0;

        double NotaFinal = 0;
        public Calificaciones(string user)
        {
            InitializeComponent();
            txtUser.Text = $"Bienvenido(a), {user}";
        }

        private void btnCalcularNotaFinal(object sender, EventArgs e)
        {
            try
            {

                TxtNotaSeguimineto1 = txtNotaSeguimineto1.Text;
                TxtNotaExamen1 = txtNotaExamen1.Text;
                TxtNotaSeguimineto2 = txtNotaSeguimineto2.Text;
                TxtNotaExamen2 = txtNotaExamen2.Text;


                /*
                 * Validar valores nulos
                 */
                validarNumero(TxtNotaSeguimineto1, "Nota de seguimiento 1");
                validarNumero(TxtNotaExamen1, "Nota de exàmen 1");
                validarNumero(TxtNotaSeguimineto2, "Nota de seguimiento 2");
                validarNumero(TxtNotaExamen2, "Nota de exàmen 2");

                /*
                 * Realizar la operaciòn
                 */

                NotaSeguimineto1 = Convert.ToDouble(TxtNotaSeguimineto1) * 0.3;
                NotaExamen1 = Convert.ToDouble(TxtNotaExamen1) * 0.2;
                NotaParcial1 = NotaSeguimineto1 + NotaExamen1;
                txtNotaParcial1.Text = $"{NotaParcial1}";

                NotaSeguimineto2 = Convert.ToDouble(TxtNotaSeguimineto2) * 0.3;
                NotaExamen2 = Convert.ToDouble(TxtNotaExamen2) * 0.2;
                NotaParcial2 = NotaSeguimineto2 + NotaExamen2;
                txtNotaParcial2.Text = $"{NotaParcial2}";

                NotaFinal = NotaParcial1 + NotaParcial2;
                txtNotaFinal.Text = $"{NotaFinal}";
                mostrarMensaje();
            }
            catch (Exception ex)
            {
                DisplayAlert("No se pudo realizar la operaciòn", ex.Message, "Ok");
            }
        }

        private void validarNumero(string value, string input)
        {
            validarNulos(value, input);
            validarNumeroMaximo(value, input);
        }

        private void validarNulos(string value, string input)
        {
            if (value == null)
            {
                throw new Exception($"Debe de proporcionar un valor para {input}");
            }    
        }

        private void validarNumeroMaximo(string value, string input)
        {
            if (Convert.ToDouble(value) > 10)
            {
                throw new Exception($"No puede ingresar un nùmero mayor a 10 en  {input}");
            }
        }

        private void mostrarMensaje()
        {
            if (NotaFinal >= 7)
            {
                DisplayAlert("Estado", "Aprobado", "Ok");
            }else if (NotaFinal >= 5 && NotaFinal <= 6.9)
            {
                DisplayAlert("Estado", "Complementario", "Ok");
            }
            else if(NotaFinal < 5)
            {
                DisplayAlert("Estado", "Reprovado", "Ok");
            }
        }
    }
}