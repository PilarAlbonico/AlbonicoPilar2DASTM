using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class Paquete
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private double precioBase;
        public double PrecioBase
        {
            get { return precioBase; }
            set { precioBase = value; }
        }

        public List<Canal> Canales { get; set; } = new List<Canal>();

        public Paquete(string nombre, double precioBase)
        {
            Nombre = nombre;
            PrecioBase = precioBase;
        }

        public double CalcularPrecioFinal()
        {
            if (Nombre.ToLower() == "premium")
                return PrecioBase * 1.20;
            if (Nombre.ToLower() == "silver")
                return PrecioBase * 1.15;
            return PrecioBase;
        }

        public override string ToString()
        {
            return $"{Nombre} | Base: {PrecioBase} | Final: {CalcularPrecioFinal()}";
        }
    }
}
