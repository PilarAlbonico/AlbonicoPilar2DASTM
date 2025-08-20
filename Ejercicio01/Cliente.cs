using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class Cliente
    {
        private string dni;
        public string DNI
        {
            get { return dni; }
            set { dni = value; }
        }

        private string nombreApellido;
        public string NombreApellido
        {
            get { return nombreApellido; }
            set { nombreApellido = value; }
        }

        private string telefono;
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private DateTime fechaNacimiento;
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        public List<Cuenta> Cuentas { get; set; } = new List<Cuenta>();

        public int CalcularEdad()
        {
            return DateTime.Now.Year - FechaNacimiento.Year;
        }

        public override string ToString()
        {
            return $"{NombreApellido} (DNI: {DNI}, Edad: {CalcularEdad()})";
        }
    }
}
