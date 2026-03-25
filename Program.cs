using System;
class SimuladorStreaming
{
    static void Main()
    {
        int evaluados = 0; // Total de contenidos evaluados
        int publicados = 0; // Publicados sin ajustes
        int pubAjustes = 0; // Publicados con ajustes
        int revision = 0; // Enviados a revisión
        int rechazados = 0; // Rechazados por incumplir reglas

        // Contadores de impacto
        int impAlto = 0;
        int impMedio = 0;
        int impBajo = 0;

        int menu; // Variable para el menu
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
                case 1:  // ingreso de el contenido 
                    evaluados++;   // Contador de entradas evaluadas
                    Console.WriteLine("--- INGRESAR CONTENIDO ---");
                    Console.Write("Nombre del contenido: ");
                    string nombre = Console.ReadLine();
                    int tipo;
                    do
                    {
                        // pide tipo y repite si no es de 1 a 4
                        Console.Write("Tipo: 1) Pelicula 2) Serie 3) Documental 4) Evento");
                        tipo = int.Parse(Console.ReadLine());
                        if (tipo < 1 || tipo > 4)
                        {
                            Console.WriteLine("Opcion invalida, intente nuevamente.");
                        }
                    } while (tipo < 1 || tipo > 4);

                    int duracion;
                    do
                    {
                        // pide minutos y no deja pasar si es 0 o menos
                        Console.Write("Duracion del contenido en minutos?");
                        duracion = int.Parse(Console.ReadLine());
                        if (duracion <= 0)
                        {
                            Console.WriteLine("La duracion debe ser mayor a 0.");
                        }
                    } while (duracion <= 0);

                    int opClas;
                    do
                    {
                        // pide clasificacion del 1 al 3
                        Console.Write("Clasificacion: 1) Todo publico  2) +13  3) +18");
                        opClas = int.Parse(Console.ReadLine());
                        if (opClas < 1 || opClas > 3)
                        {
                            Console.WriteLine("Opcion invalida, intente nuevamente.");
                        }
                    } while (opClas < 1 || opClas > 3);

                    int clasificacion;
                    // convierte la opcion a numero de edad real
                    if (opClas == 1)
                    {
                        clasificacion = 0;
                    }
                    else if (opClas == 2)
                    {
                        clasificacion = 13;
                    }
                    else
                    {
                        clasificacion = 18;
                    }

                    int hora;
                    do
                    {
                        // pide hora militar entre 0 y 23
                        Console.Write("Hora programada (0 a 23): ");
                        hora = int.Parse(Console.ReadLine());
                        if (hora < 0 || hora > 23)
                        {
                            Console.WriteLine("Hora invalida, ingrese entre 0 y 23.");
                        }
                    } while (hora < 0 || hora > 23);

                    int produccion;
                    do
                    {
                        // pide nivel de calidad 1 a 3
                        Console.Write("Nivel de produccion (1=Bajo  2=Medio  3=Alto): ");
                        produccion = int.Parse(Console.ReadLine());
                        if (produccion < 1 || produccion > 3)
                        {
                            Console.WriteLine("Opcion invalida, intente nuevamente.");
                        }
                    } while (produccion < 1 || produccion > 3);

                    // variable para saber si todo esta bien
                    bool valido = true;

                    // revisa si la edad y hora coinciden
                    if (ValidarHorario(clasificacion, hora) == false)
                    {
                        valido = false;
                        Console.WriteLine("RECHAZADO: horario no permitido para esa clasificacion.");
                    }

                    // revisa si el tiempo de video es correcto segun el tipo
                    if (valido == true)
                    {
                        if (ValidarDuracion(tipo, duracion) == false)
                        {
                            valido = false;
                            Console.WriteLine("RECHAZADO: duracion fuera de rango para ese tipo.");
                        }
                    }

                    // revisa que no sea produccion barata si es para adultos
                    if (valido == true)
                    {
                        if (ValidarProduccion(produccion, clasificacion) == false)
                        {
                            valido = false;
                            Console.WriteLine("RECHAZADO: prod. baja no permitida en clasificacion +18.");
                        }
                    }

                    // si paso todas las pruebas calcula que tan importante es
                    if (valido == false)
                    {
                        rechazados = rechazados + 1;
                    }
                    else
                    {
                        int impacto = CalcularImpacto(produccion, duracion, hora);
                        string decision = DecisionFinal(impacto, duracion, hora, clasificacion, tipo);

                        Console.WriteLine("--- RESULTADO: ---");

                        // muestra el nivel de impacto con texto
                        if (impacto == 1)
                        {
                            Console.WriteLine("Impacto : Bajo");
                        }
                        else if (impacto == 2)
                        {
                            Console.WriteLine("Impacto : Medio");
                        }
                        else
                        {
                            Console.WriteLine("Impacto : Alto");
                        }

                        Console.WriteLine("Decision: " + decision);

                        // Actualizar contadores de impacto
                        if (impacto == 3)
                        {
                            impAlto++;
                        }
                        else if (impacto == 2)
                        {
                            impMedio++;
                        }
                        else
                        {
                            impBajo++;
                        }
                          
                        // Actualizar contadores de decisión
                        if (decision == "Publicar")
                        {
                            publicados++;
                        }
                        else if (decision == "Enviar a revision")
                        {
                            revision++;
                        }
                        else
                        {
                            pubAjustes++;
                        }
                    }
                    break;
                case 2:
                    // Mostrar reglas
                    MostrarReglas();
                    break;
                case 3:
                // Mostrar estadísticas
                    Console.WriteLine("ESTADISTICAS");
                    Console.WriteLine("Total evaluados       : " + evaluados);
                    Console.WriteLine("Publicados            : " + publicados);
                    Console.WriteLine("Publicados c/ajustes  : " + pubAjustes);
                    Console.WriteLine("En revision           : " + revision);
                    Console.WriteLine("Rechazados            : " + rechazados);

                    double porcentaje;
                    if (evaluados > 0)
                    {
                        porcentaje = ((publicados + pubAjustes) * 100.0) / evaluados;
                        Console.WriteLine("Porcentaje aprobacion : " + porcentaje + "%");
                    }
                    else
                    {
                        Console.WriteLine("Porcentaje aprobacion : 0%");
                    }

                    Console.WriteLine("Impactos - Alto: " + impAlto + " | Medio: " + impMedio + " | Bajo: " + impBajo);

                    if (impAlto + impMedio + impBajo > 0)
                    {
                        string predominante;
                        if (impAlto >= impMedio && impAlto >= impBajo)
                        {
                            predominante = "Alto";
                        }
                        else if (impMedio >= impBajo)
                        {
                            predominante = "Medio";
                        }
                        else
                        {
                            predominante = "Bajo";
                        }
                        Console.WriteLine("Impacto predominante  : " + predominante);
                    }
                    break;
                    break;
                case 4:
                    // Reiniciar estadísticas
                    evaluados = 0;
                    publicados = 0;
                    pubAjustes = 0;
                    revision = 0;
                    rechazados = 0;
                    impAlto = 0;
                    impMedio = 0;
                    impBajo = 0;
                    Console.WriteLine("Estadisticas reiniciadas.");
                    break;
                case 5:
                    Console.WriteLine("=== RESUMEN FINAL ===");
                    Console.WriteLine("Total evaluados       : " + evaluados);
                    Console.WriteLine("Publicados            : " + publicados);
                    Console.WriteLine("Publicados c/ajustes  : " + pubAjustes);
                    Console.WriteLine("En revision           : " + revision);
                    Console.WriteLine("Rechazados            : " + rechazados);

                    if (evaluados > 0)
                    {
                        double porcentajeFinal = ((publicados + pubAjustes) * 100.0) / evaluados;
                        Console.WriteLine("Porcentaje aprobacion : " + porcentajeFinal + "%");
                    }
                    else
                    {
                        Console.WriteLine("Porcentaje aprobacion : 0%");
                    }

                    Console.WriteLine("Impactos - Alto: " + impAlto + " | Medio: " + impMedio + " | Bajo: " + impBajo);

                    if (impAlto + impMedio + impBajo > 0)
                    {
                        string predominanteFinal;
                        if (impAlto >= impMedio && impAlto >= impBajo)
                        {
                            predominanteFinal = "Alto";
                        }
                        else if (impMedio >= impBajo)
                        {
                            predominanteFinal = "Medio";
                        }
                        else
                        {
                            predominanteFinal = "Bajo";
                        }
                        Console.WriteLine("Impacto predominante  : " + predominanteFinal);
                    }
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
    static bool ValidarHorario(int clasificacion, int hora)
    {
        bool resultado = true;
        if (clasificacion == 13)
        {
            if (hora < 6 || hora > 22)
            {
                resultado = false;
            }
        }
        else if (clasificacion == 18)
        {
            if (hora >= 6 && hora <= 21)
            {
                resultado = false;
            }
        }
        return resultado;
    }
    static bool ValidarDuracion(int tipo, int duracion)
    {
        bool resultado = false;

        if (tipo == 1) // Pelicula
        {
            if (duracion >= 60 && duracion <= 180)
            {
                resultado = true;
            }
        }
        else if (tipo == 2) // Serie
        {
            if (duracion >= 20 && duracion <= 90)
            {
                resultado = true;
            }
        }
        else if (tipo == 3) // Documental
        {
            if (duracion >= 30 && duracion <= 120)
            {
                resultado = true;
            }
        }
        else if (tipo == 4) // Evento en vivo
        {
            if (duracion >= 30 && duracion <= 240)
            {
                resultado = true;
            }
        }
        return resultado;
    }
    static bool ValidarProduccion(int produccion, int clasificacion)
    {
        bool resultado = true;

        // Si producción es baja (1) y clasificación es +18 (18), no es válido
        if (produccion == 1 && clasificacion == 18)
        {
            resultado = false;
        }

        return resultado;
    }
    static int CalcularImpacto(int produccion, int duracion, int hora)
    {
        int impacto;

        // Primero verificar impacto alto
        if (produccion == 3 || duracion > 120 || (hora >= 20 && hora <= 23))
        {
            impacto = 3; // Alto
        }
        else if (produccion == 2 || (duracion >= 60 && duracion <= 120))
        {
            impacto = 2; // Medio
        }
        else
        {
            impacto = 1; // Bajo
        }

        return impacto;
    }
    static string DecisionFinal(int impacto, int duracion, int hora, int clasificacion, int tipo)
    {
        string decision;
        string razon = "";

        if (impacto == 3)
        {
            decision = "Enviar a revision";
        }
        else
        {
            // Verificar duracion limite
            if (tipo == 1)
            {
                if (duracion == 60 || duracion == 180)
                {
                    razon = "duracion limite";
                }
            }
            else if (tipo == 2)
            {
                if (duracion == 20 || duracion == 90)
                {
                    razon = "duracion limite";
                }
            }
            else if (tipo == 3)
            {
                if (duracion == 30 || duracion == 120)
                {
                    razon = "duracion limite";
                }
            }
            else // tipo == 4
            {
                if (duracion == 30 || duracion == 240)
                {
                    razon = "duracion limite";
                }
            }

            // Verificar horario limite
            if (clasificacion == 13)
            {
                if (hora == 6 || hora == 22)
                {
                    if (razon != "")
                    {
                        razon = razon + " y horario limite";
                    }
                    else
                    {
                        razon = "horario limite";
                    }
                }
            }
            else if (clasificacion == 18)
            {
                if (hora == 22 || hora == 5)
                {
                    if (razon != "")
                    {
                        razon = razon + " y horario limite";
                    }
                    else
                    {
                        razon = "horario limite";
                    }
                }
            }

            if (razon != "")
            {
                decision = "Publicar con ajustes: " + razon;
            }
            else
            {
                decision = "Publicar";
            }
        }

        return decision;
    }
}