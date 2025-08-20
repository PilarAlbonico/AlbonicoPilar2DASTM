using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class Operacion
    {
        private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string tipo;
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private decimal importe;
        public decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public override string ToString()
        {
            return $"{Fecha} - {Tipo}: ${Importe}";
        }
    }
}
