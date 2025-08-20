using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class Banco
    {
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public List<Cuenta> Cuentas { get; set; } = new List<Cuenta>();

        public void AgregarCliente(Cliente c)
        {
            if (Clientes.Any(x => x.DNI == c.DNI))
                throw new Exception("El cliente ya está registrado.");
            Clientes.Add(c);
        }

        public Cliente BuscarClientePorDni(string dni)
        {
            return Clientes.FirstOrDefault(x => x.DNI == dni);
        }

        public List<Cliente> BuscarClientePorNombre(string nombre)
        {
            return Clientes.Where(x => x.NombreApellido.Contains(nombre)).ToList();
        }

        public void ListarClientes()
        {
            foreach (var c in Clientes)
                Console.WriteLine(c);
        }
    }
}
