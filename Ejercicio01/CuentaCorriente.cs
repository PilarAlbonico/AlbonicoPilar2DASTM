using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class CuentaCorriente : Cuenta
    {
        private decimal descubiertoPermitido;
        public decimal DescubiertoPermitido
        {
            get { return descubiertoPermitido; }
            set { descubiertoPermitido = value; }
        }

        public override bool Extraer(decimal importe)
        {
            if (Saldo - importe >= -DescubiertoPermitido)
            {
                Saldo -= importe;
                Historial.Add(new Operacion { Fecha = DateTime.Now, Tipo = "Extracción", Importe = importe });
                return true;
            }
            return false;
        }
    }
}
