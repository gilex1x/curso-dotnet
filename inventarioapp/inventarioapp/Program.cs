using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;

//Variables

int cantidad = 0;
decimal totalPrecio = 0.00m;
bool sistemaActivo = true;

MostrarBanner();
if(args.Length > 0){
    switch(args[0]){
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


//string? nombre = null;
//Console.WriteLine("Ingrese un nombre:");
//nombre = Console.ReadLine();
//int longidtud = nombre?.Length ?? 0;
//Console.WriteLine($"La longitud del nombre es: {longidtud}");

while (sistemaActivo)
{
    MostrarMenu();
    Console.Write("Ingrese un comando (o 'salir' para salir)>");
    string? entrada = Console.ReadLine();

    string comando = string.IsNullOrEmpty(entrada) ? "salir" : entrada.Trim().ToLower();
    switch (comando)
    {
        case "listar":
            Console.WriteLine($"Cantidad: {cantidad}");
            break;
        case "":
        case "salir":
            sistemaActivo = false;
            Console.WriteLine("Hasta Luego");
            break;
        default:
            Console.WriteLine($"Comando: {comando} no reconocido");
            break;
    }
}

Environment.Exit(0);

//if(entrada == "salir" || entrada == "exit" || string.IsNullOrEmpty(entrada)){
//    Console.WriteLine("Saliendo de la aplicacion...");
//    Environment.Exit(0);
//}else{
//    Console.WriteLine("Ingrese una Cantidad:");
//    entrada = Console.ReadLine();
//}

void MostrarAyuda(){
    Console.WriteLine("Uso: InventarioApp [opciones]");
    Console.WriteLine("Opciones:");
    Console.WriteLine("  -h, --help     Mostrar esta ayuda");
    Console.WriteLine("  -v, --version  Mostrar la versión");
    Console.WriteLine("  -a, --add <product_name> Agregar un prodcuto con contidad inicial de 0");

}

void MostrarBanner(){
    Console.Clear();
    Console.WriteLine("===================================");
    Console.WriteLine("=         Inventario App          =");
    Console.WriteLine("===================================");
    
    Console.WriteLine($"InventarioApp - Version {version}");
    Console.WriteLine($"Plataforma: {Environment.OSVersion.Platform}");
    Console.WriteLine($"NetVersion: {Environment.OSVersion.Version}");
}

void MostrarMenu() {
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Listar");
    Console.WriteLine("2. Agregar producto");
    Console.WriteLine("3. Salir");
}