using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio02
{
    internal class Cliente
    {
        
        
            private string dni;
            public string DNI
            {
                get { return dni; }
                set { dni = value; }
            }

            private string nombre;
            public string Nombre
            {
                get { return nombre; }
            set { nombre = value; }
            }

        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

            private DateTime fechaNacimiento;
            public DateTime FechaNacimiento
            {
                get { return fechaNacimiento; }
                set { fechaNacimiento = value; }
            }

        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public Paquete PaqueteContratado { get; set; }

        public Cliente(int codigo, string nombre, string apellido, string dni, DateTime fechaNac)
        {
            Codigo = codigo;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            FechaNacimiento = fechaNac;
        }

        public override string ToString()
        {
            return $"{Codigo} - {Nombre} {Apellido} | DNI: {DNI} | Paquete: {(PaqueteContratado != null ? PaqueteContratado.Nombre : "Ninguno")}";
        }

    }
}
