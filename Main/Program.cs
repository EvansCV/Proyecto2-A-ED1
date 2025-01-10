using Sonidos;

class Program
{
    static void Main()
    {
        Console.WriteLine("Selecciona una opcion");
        Console.WriteLine("1 - Reproducir DO");
        Console.WriteLine("2 - Reproducir RE");
        Console.WriteLine("3 - Reproducir MI");
        Console.WriteLine("4 - Reproducir FA");
        Console.WriteLine("5 - Reproducir SOL");
        Console.WriteLine("6 - Reproducir SI");
        Console.WriteLine("7 - Reproducir LA");
        Console.WriteLine("8 - Reproducir Salir");

        bool running = true;

        while (running){
            Console.Write("Seleccion: ");
            var input = Console.ReadKey();
            Console.WriteLine();

            if (input.Key == ConsoleKey.D8){
                running = false;
                break;
            }

            Console.Write("Ingresa una Figura (0,5 , 2): ");
            if (float.TryParse(Console.ReadLine(), out float velocidad)){
            switch (input.Key){

                case ConsoleKey.D1:
                    Figura.ReproducirDo(velocidad);
                    break;

                case ConsoleKey.D2:
                    Figura.ReproducirRe(velocidad);
                    break;

                case ConsoleKey.D3:
                    Figura.ReproducirMi(velocidad);
                    break;

                case ConsoleKey.D4:
                    Figura.ReproducirFa(velocidad);
                    break;

                case ConsoleKey.D5:
                    Figura.ReproducirSol(velocidad);
                    break;

                case ConsoleKey.D6:
                    Figura.ReproducirSi(velocidad);
                    break;

                case ConsoleKey.D7:
                    Figura.ReproducirLa(velocidad);
                    break;


                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
            }
            else{
                Console.WriteLine("Modificador no valido.");
            }
        }
        Console.WriteLine("Saliendo del programa");
    }
}