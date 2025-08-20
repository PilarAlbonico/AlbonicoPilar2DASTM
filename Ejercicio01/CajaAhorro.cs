using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class CajaAhorro : Cuenta
    {
        private decimal maximoPorExtraccion;
        public decimal MaximoPorExtraccion
        {
            get { return maximoPorExtraccion; }
            set { maximoPorExtraccion = value; }
        }

        public override bool Extraer(decimal importe)
        {
            if (importe <= Saldo && importe <= MaximoPorExtraccion)
            {
                Saldo -= importe;
                Historial.Add(new Operacion { Fecha = DateTime.Now, Tipo = "Extracción", Importe = importe });
                return true;
            }
            return false;
        }
    }
}
