using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var version = assembly.GetName().Version;


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
        default:
            Console.WriteLine($"Opcion desconocida: {args[0]}");
            Console.WriteLine("Use -h o --help para ver la ayuda");
            Environment.Exit(2);
            break;
    }
}

Console.WriteLine($"InventarioApp - Version {version}");
Console.WriteLine($"Plataforma: {Environment.OSVersion.Platform}");
Console.WriteLine($"NetVersion: {Environment.OSVersion.Version}");

void MostrarAyuda(){
    Console.WriteLine("Uso: InventarioApp [opciones]");
    Console.WriteLine("Opciones:");
    Console.WriteLine("  -h, --help     Mostrar esta ayuda");
    Console.WriteLine("  -v, --version  Mostrar la versión");
}