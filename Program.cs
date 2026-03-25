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
                    // Aquí iremos agregando la entrada de datos
                    break;
                case 2:
                    // Llamará a MostrarReglas (próximo commit)
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
}