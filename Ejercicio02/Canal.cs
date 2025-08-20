using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class Canal
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public List<Serie> Series { get; set; } = new List<Serie>();

        public Canal(string nombre) { Nombre = nombre; }

        public override string ToString() => Nombre;
    }
}
