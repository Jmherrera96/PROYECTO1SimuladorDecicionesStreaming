using System;
class SimuladorStreaming
{
    static void Main()
    {
        int menu;
        do
        {
            Console.WriteLine("       SIMULADOR DE STREAMING");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. Evaluar nuevo contenido");
            Console.WriteLine("2. Ver reglas");
            Console.WriteLine("3. Mostrar estadisticas de la sesion");
            Console.WriteLine("4. Reiniciar estadisticas");
            Console.WriteLine("5. Salir");
            Console.Write("Ingrese opcion: ");
            menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    Console.WriteLine("--- INGRESAR CONTENIDO ---");
                    // Entrada de datos
                    break;
                case 2:
                    // Mostrar reglas
                    MostrarReglas();
                    break;
                case 3:
                    // Mostrar estadísticas
                    break;
                case 4:
                    // Reiniciar estadísticas
                    break;
                case 5:
                    Console.WriteLine("Gracias por usar el simulador. Hasta luego.");
                    break;
                default:
                    Console.WriteLine("Opcion invalida. Ingrese un numero del 1 al 5.");
                    break;
            }
        } while (menu != 5);
    }
    static void MostrarReglas()
    {
        Console.WriteLine("= REGLAS DEL SISTEMA =");
        Console.WriteLine("HORARIO PERMITIDO:");
        Console.WriteLine("  Todo publico : cualquier hora");
        Console.WriteLine("  +13          : entre 6 y 22 horas");
        Console.WriteLine("  +18          : entre 22 y 5 horas");
        Console.WriteLine("DURACION POR TIPO:");
        Console.WriteLine("  Pelicula       : 60 a 180 min");
        Console.WriteLine("  Serie          : 20 a 90 min");
        Console.WriteLine("  Documental     : 30 a 120 min");
        Console.WriteLine("  Evento en vivo : 30 a 240 min");
        Console.WriteLine("PRODUCCION:");
        Console.WriteLine("  Baja         : solo Todo publico o +13");
        Console.WriteLine("  Media o Alta : cualquier clasificacion");
        Console.WriteLine("IMPACTO:");
        Console.WriteLine("  Alto   : prod. alta, duracion > 120 min, o entre 20-23 h");
        Console.WriteLine("  Medio  : prod. media o duracion entre 60-120 min");
        Console.WriteLine("  Bajo   : prod. baja y duracion menor a 60 min");
        Console.WriteLine("DECISION:");
        Console.WriteLine("  Publicar           : impacto bajo o medio sin limites");
        Console.WriteLine("  Publicar c/ajustes : impacto bajo/medio en valor limite");
        Console.WriteLine("  Enviar a revision  : impacto alto");
        Console.WriteLine("  Rechazar           : incumple regla obligatoria");
    }
}