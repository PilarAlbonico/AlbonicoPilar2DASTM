using Ejercicio02;

internal class Program
{
    //HIIIII
    static List<Cliente> clientes = new List<Cliente>();
    static List<Paquete> paquetes = new List<Paquete>();

    static void Main()
    {
        InicializarDatos();

        int opcion;
        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Listar Clientes");
            Console.WriteLine("2. Listar Paquetes");
            Console.WriteLine("3. Asignar Paquete a Cliente");
            Console.WriteLine("4. Mostrar Total Recaudado");
            Console.WriteLine("5. Paquete más vendido");
            Console.WriteLine("6. Series con ranking > 3.5");
            Console.WriteLine("0. Salir");

            opcion = LeerOpcion(0, 6);

            switch (opcion)
            {
                case 1: ListarClientes(); break;
                case 2: ListarPaquetes(); break;
                case 3: AsignarPaquete(); break;
                case 4: MostrarTotalRecaudado(); break;
                case 5: MostrarPaqueteMasVendido(); break;
                case 6: MostrarSeriesRanking(); break;
            }

        } while (opcion != 0);
    }

    static int LeerOpcion(int min, int max)
    {
        int opcion;
        while (true)
        {
            Console.Write("Elija opción: ");
            if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= min && opcion <= max)
                return opcion;
            Console.WriteLine($"Opción inválida. Debe ser entre {min} y {max}.");
        }
    }

    static void InicializarDatos()
    {
        Paquete premium = new Paquete("Premium", 1000);
        Paquete silver = new Paquete("Silver", 800);

        Canal hbo = new Canal("HBO");
        hbo.Series.Add(new Serie("Game of Thrones", 8, 73, 60, 4.5, "Fantasia", "Benioff & Weiss"));
        hbo.Series.Add(new Serie("Chernobyl", 1, 5, 60, 4.8, "Drama", "Johan Renck"));

        Canal netflix = new Canal("Netflix");
        netflix.Series.Add(new Serie("Stranger Things", 4, 34, 50, 4.2, "Sci-Fi", "Duffer Brothers"));
        netflix.Series.Add(new Serie("Dark", 3, 26, 45, 4.6, "Sci-Fi", "Baran bo Odar"));

        premium.Canales.Add(hbo);
        premium.Canales.Add(netflix);
        silver.Canales.Add(netflix);

        paquetes.Add(premium);
        paquetes.Add(silver);

        clientes.Add(new Cliente(1, "Juan", "Perez", "12345678", new DateTime(1990, 5, 12)));
        clientes.Add(new Cliente(2, "Ana", "Lopez", "87654321", new DateTime(1985, 8, 30)));
    }

    static void ListarClientes()
    {
        Console.WriteLine("\nClientes:");
        foreach (var c in clientes) Console.WriteLine(c);
    }

    static void ListarPaquetes()
    {
        Console.WriteLine("\nPaquetes:");
        foreach (var p in paquetes)
        {
            Console.WriteLine(p);
            foreach (var canal in p.Canales)
            {
                Console.WriteLine($"  Canal: {canal.Nombre}");
                foreach (var s in canal.Series)
                    Console.WriteLine($"    {s}");
            }
        }
    }

    static void AsignarPaquete()
    {
        ListarClientes();
        Console.Write("Ingrese código de cliente: ");
        int cod = int.Parse(Console.ReadLine());
        var cliente = clientes.FirstOrDefault(c => c.Codigo == cod);
        if (cliente == null) { Console.WriteLine("Cliente no encontrado"); return; }

        ListarPaquetes();
        Console.Write("Ingrese nombre del paquete: ");
        string nombre = Console.ReadLine();
        var paquete = paquetes.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (paquete == null) { Console.WriteLine("Paquete no encontrado"); return; }

        cliente.PaqueteContratado = paquete;
        Console.WriteLine($"Asignado {paquete.Nombre} a {cliente.Nombre}");
    }

    static void MostrarTotalRecaudado()
    {
        double total = clientes.Where(c => c.PaqueteContratado != null)
                               .Sum(c => c.PaqueteContratado.CalcularPrecioFinal());
        Console.WriteLine($"Total recaudado: {total}");
    }

    static void MostrarPaqueteMasVendido()
    {
        var masVendido = clientes.Where(c => c.PaqueteContratado != null)
                                 .GroupBy(c => c.PaqueteContratado)
                                 .OrderByDescending(g => g.Count())
                                 .FirstOrDefault();

        if (masVendido == null)
        {
            Console.WriteLine("Ningún paquete vendido todavía.");
            return;
        }

        Console.WriteLine($"Paquete más vendido: {masVendido.Key.Nombre} ({masVendido.Count()} ventas)");
        foreach (var canal in masVendido.Key.Canales)
        {
            Console.WriteLine($"  Canal: {canal.Nombre}");
            foreach (var s in canal.Series) Console.WriteLine($"    {s}");
        }
    }

    static void MostrarSeriesRanking()
    {
        Console.WriteLine("Series con ranking > 3.5:");
        foreach (var p in paquetes)
            foreach (var canal in p.Canales)
                foreach (var s in canal.Series)
                    if (s.Ranking > 3.5) Console.WriteLine(s);
    }
}