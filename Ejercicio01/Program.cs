using Ejercicio01;

internal class Program
{
    static void Main(string[] args)
    {
        Banco banco = new Banco();

        int opcion = -1;  // inicializada para que siempre tenga algo

        do
        {
            Console.WriteLine("\n=== SISTEMA BANCO ===");
            Console.WriteLine("1. Gestionar Clientes");
            Console.WriteLine("2. Gestionar Cuentas");
            Console.WriteLine("3. Operaciones (Depósitos / Extracciones)");
            Console.WriteLine("4. Listar Clientes");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            try
            {
                opcion = int.Parse(Console.ReadLine());  // acá se asigna un valor real
                switch (opcion)
                {
                    case 1:
                        MenuClientes(banco);
                        break;
                    case 2:
                        MenuCuentas(banco);
                        break;
                    case 3:
                        MenuOperaciones(banco);
                        break;
                    case 4:
                        banco.ListarClientes();
                        break;
                    case 0:
                        break;
                    default:
                        throw new Exception("El número ingresado no es válido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        } while (opcion != 0);
    }


    static void MenuClientes(Banco banco)
    {
        Console.WriteLine("\n--- Gestión de Clientes ---");
        Console.WriteLine("1. Agregar Cliente");
        Console.WriteLine("2. Buscar Cliente por DNI");
        Console.WriteLine("3. Buscar Cliente por Nombre");
        Console.Write("Seleccione: ");

        if (!int.TryParse(Console.ReadLine(), out int op) || op < 1 || op > 3)
        {
            Console.WriteLine("Opción inválida. Debe ser 1, 2 o 3.");
            return; 
        }

        if (op == 1)
        {
            Cliente c = new Cliente();

            Console.Write("DNI: ");
            string dni = Console.ReadLine();
            if (banco.BuscarClientePorDni(dni) != null)
            {
                Console.WriteLine("Error: ya existe un cliente con ese DNI.");
                return; 
            }
            c.DNI = dni;

            Console.Write("Nombre y Apellido: ");
            c.NombreApellido = Console.ReadLine();

            Console.Write("Teléfono: ");
            c.Telefono = Console.ReadLine();

            Console.Write("Email: ");
            c.Email = Console.ReadLine();

            Console.Write("Fecha de nacimiento (yyyy-mm-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                Console.WriteLine("Fecha inválida.");
                return;
            }
            c.FechaNacimiento = fecha;

            try
            {
                banco.AgregarCliente(c);
                Console.WriteLine("Cliente agregado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        else if (op == 2)
        {
            Console.Write("Ingrese DNI: ");
            string dni = Console.ReadLine();
            var cliente = banco.BuscarClientePorDni(dni);
            Console.WriteLine(cliente != null ? cliente.ToString() : "No encontrado :(");
        }
        else if (op == 3)
        {
            Console.Write("Ingrese nombre: ");
            string nombre = Console.ReadLine();
            var lista = banco.BuscarClientePorNombre(nombre);
            foreach (var cli in lista)
                Console.WriteLine(cli);
        }
    }

    static void MenuCuentas(Banco banco)
    {
        Console.WriteLine("\n--- Gestión de Cuentas ---");
        Console.WriteLine("1. Crear Caja de Ahorro");
        Console.WriteLine("2. Crear Cuenta Corriente");
        Console.Write("Seleccione: ");

        if (!int.TryParse(Console.ReadLine(), out int op) || (op != 1 && op != 2))
        {
            Console.WriteLine("Opción inválida. Debe ser 1 o 2.");
            return;
        }

        Console.Write("Ingrese DNI del titular: ");
        string dni = Console.ReadLine();
        var cliente = banco.BuscarClientePorDni(dni);

        if (cliente == null)
        {
            Console.WriteLine("Cliente no encontrado.");
            return;
        }

        Console.Write("Ingrese código de cuenta: ");
        string codigo = Console.ReadLine();

        switch (op)
        {
            case 1:
                Console.Write("Máximo por extracción: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal max))
                {
                    Console.WriteLine("Valor inválido.");
                    return;
                }
                var ca = new CajaAhorro { CodigoCuenta = codigo, Titular = cliente, MaximoPorExtraccion = max };
                cliente.Cuentas.Add(ca);
                banco.Cuentas.Add(ca);
                Console.WriteLine("Caja de Ahorro creada con éxito.");
                break;

            case 2:
                Console.Write("Descubierto permitido: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal desc))
                {
                    Console.WriteLine("Valor inválido.");
                    return;
                }
                var cc = new CuentaCorriente { CodigoCuenta = codigo, Titular = cliente, DescubiertoPermitido = desc };
                cliente.Cuentas.Add(cc);
                banco.Cuentas.Add(cc);
                Console.WriteLine("Cuenta Corriente creada con éxito.");
                break;
        }
    }

    static void MenuOperaciones(Banco banco)
    {
        Console.Write("Ingrese código de cuenta: ");
        string codigo = Console.ReadLine();
        var cuenta = banco.Cuentas.FirstOrDefault(c => c.CodigoCuenta == codigo);

        if (cuenta == null)
        {
            Console.WriteLine("Cuenta no encontrada.");
            return; 
        }

        Console.WriteLine("\n--- Operaciones ---");
        Console.WriteLine("1. Depósito");
        Console.WriteLine("2. Extracción");
        Console.Write("Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out int op) || (op != 1 && op != 2))
        {
            Console.WriteLine("Opción inválida.");
            return;
        }

        Console.Write("Importe: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal importe) || importe <= 0)
        {
            Console.WriteLine("Importe inválido.");
            return;
        }

        if (op == 1)
        {
            cuenta.Depositar(importe);
            Console.WriteLine("Depósito realizado.");
        }
        else 
        {
            bool ok = cuenta.Extraer(importe);
            Console.WriteLine(ok ? "Extracción realizada." : "No se pudo extraer (fondos insuficientes o límite superado).");
        }

        Console.WriteLine($"Saldo actual: ${cuenta.Saldo}");
    }

}