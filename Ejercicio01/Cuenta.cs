using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public abstract class Cuenta
    {
        private string codigoCuenta;
        public string CodigoCuenta
        {
            get { return codigoCuenta; }
            set { codigoCuenta = value; }
        }

        private decimal saldo;
        public decimal Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        private Cliente titular;
        public Cliente Titular
        {
            get { return titular; }
            set { titular = value; }
        }

        public List<Operacion> Historial { get; set; } = new List<Operacion>();

        public void Depositar(decimal importe)
        {
            Saldo += importe;
            Historial.Add(new Operacion { Fecha = DateTime.Now, Tipo = "Depósito", Importe = importe });
        }

        public abstract bool Extraer(decimal importe);
    }
}
