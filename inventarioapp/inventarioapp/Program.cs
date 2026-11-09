using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

//Variables

int cantidad = 0;
decimal totalPrecio = 0.00m;
bool sistemaActivo = true;


VerificarArgs();

MostrarBanner();

while (sistemaActivo)
{
    MostrarMenu();
    var entrada = LeerEntrada("Ingrese un comando (o 'salir' para salir)>");
    sistemaActivo = ProcesarComando(entrada);

}

Environment.Exit(0);


// Funciones
bool ProcesarComando(string comando)
{
    switch (comando)
    {
        case "listar":
            Console.WriteLine($"Cantidad: {cantidad}");
            break;
        case "":
        case "salir":
            sistemaActivo = false;
            Console.WriteLine("Hasta Luego");
            return false;
        default:
            Console.WriteLine($"Comando: {comando} no reconocido");
            break;
    }
    return true;
}
void VerificarArgs()
{
    if (args.Length > 0)
    {
        switch (args[0])
        {
            case "-h":
            case "--help":
                MostrarAyuda();
                Environment.Exit(0);
                break;
            case "-v":
            case "--version":
                Console.WriteLine($"InventarioApp - Version {version}");
                Environment.Exit(0);
                break;
            case "-a":
            case "--add":
                if (args.Length < 2)
                {
                    Console.WriteLine("Error: Debe especificar el nombre del producto a agregar.");
                    Environment.Exit(1);
                }
                string productName = args[1];
                Console.WriteLine($"Producto '{productName}' agregado con cantidad inicial de 0.");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine($"Opcion desconocida: {args[0]}");
                Console.WriteLine("Use -h o --help para ver la ayuda");
                Environment.Exit(2);
                break;
        }
    }
}

void MostrarAyuda()
{
    Console.WriteLine("Uso: InventarioApp [opciones]");
    Console.WriteLine("Opciones:");
    Console.WriteLine("  -h, --help     Mostrar esta ayuda");
    Console.WriteLine("  -v, --version  Mostrar la versión");
    Console.WriteLine("  -a, --add <product_name> Agregar un prodcuto con contidad inicial de 0");

}

void MostrarBanner()
{
    Console.Clear();
    Console.WriteLine("===================================");
    Console.WriteLine("||         Inventario App         ||");
    Console.WriteLine("===================================");

    Console.WriteLine($"InventarioApp - Version {version}");
    Console.WriteLine($"Plataforma: {Environment.OSVersion.Platform}");
    Console.WriteLine($"NetVersion: {Environment.OSVersion.Version}");
}

void MostrarMenu()
{
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Listar");
    Console.WriteLine("2. Agregar producto");
    Console.WriteLine("3. Salir");
}

string LeerEntrada(string propmt)
{
    Console.Write(propmt);
    return Console.ReadLine()?.Trim().ToLower() ?? "";
}



void MostrarProductos()
{
    Console.WriteLine("Productos en inventario:");
    // Aquí se mostrarían los productos almacenados en el inventario
    Console.WriteLine($"Total de productos: {cantidad}");
}