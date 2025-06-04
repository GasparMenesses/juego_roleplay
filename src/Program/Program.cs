using Library;
using Library.Elementos;
using Library.Personajes.Heroes;
using Library.Personajes.Enemigos;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // cumple con SRP ya que es la clase que se encarga de rquestar el flujo general de la partida (título, selección de personajes, equipamiento, combate y cierre)
            // ============================================
            // 1. Título del juego
            // Muestra en pantalla el nombre de la partida.
            // ============================================
            Console.WriteLine($"ENCUENTROS FUTUROS DE LA TIERRA MEDIA");

            // ============================================
            // 2. Creación del jugador
            // Invoca al prompt que permite seleccionar y construir un personaje.
            // Luego imprime sus atributos iniciales.
            // ============================================
            
            Console.WriteLine($"\nSelecciona tu personaje");
            
            string SeleccionPersonaje = "";
            string Nombre = "";
            string SeleccionEnemigo = "";//nuevo
            string NombreEnemigo = "";      //nuevo

            // ============================================
            // Bucle de validación de raza
            // Permite elegir entre Mago (1), Elfo (2) o Enano (3).
            // Repite hasta que la entrada sea válida.
            // ============================================
            while (SeleccionPersonaje != "1" && SeleccionPersonaje != "2" && SeleccionPersonaje != "3")
            {
                Console.WriteLine(" 1 - Mago\n 2 - Elfo\n 3 - Enano");
                SeleccionPersonaje = Console.ReadLine();
                if (SeleccionPersonaje != "1" && SeleccionPersonaje != "2" && SeleccionPersonaje != "3")
                {
                    Console.WriteLine("ERROR, por favor ingrese una opción válida");
                }
            }
            
            // ============================================
            // Solicitud del nombre del personaje
            // Lee una cadena desde la consola y la asigna.
            // ============================================
            Console.WriteLine("Ingrese un nombre para su heroe: ");
            Nombre = Console.ReadLine();

            // ============================================
            // Creación del objeto Character
            // Utiliza expresión switch para instanciar la subclase adecuada
            // según la selección de raza.
            // ============================================
            Hero jugador = SeleccionPersonaje switch
            {
                "1" => new Wizard(Nombre),
                "2" => new Elve(Nombre),
                "3" => new Dwarve(Nombre),
            };
            
            
            
            Console.WriteLine(
                $"Has creado al {jugador.Race} {jugador.Name} con {jugador.CurrentHealth} de vida, {jugador.Attack} de ataque y {jugador.Defense} de defensa\n");

            // ============================================
            // 3. Equipamiento del jugador
            // Permite elegir dos ítems, valida la entrada y aplica los cambios
            // en los atributos según el tipo de ítem seleccionado.
            // ============================================
            Console.WriteLine("Es hora de que se equipe, elige dos items");
            while (jugador.Item.Count < 2)
            {
                string seleccion_item = "0";
                int numero = Convert.ToInt32(seleccion_item);

                // Validación de la opción (1–7)
                while (numero > 7 || numero < 1)
                {
                    Console.WriteLine($"{jugador.Item.Count}/2");
                    Console.WriteLine(
                        " 1 - Espada\n 2 - Baculo Magico\n 3 - Hacha \n 4 - Shield\n 5 - Armor\n 6 - Helmet \n 7 - SpellBook");
                    seleccion_item = Console.ReadLine();
                    numero = Convert.ToInt32(seleccion_item);
                    if (numero > 7 || numero < 1)
                    {
                        Console.WriteLine("ERROR, por favor ingrese una opción válida");
                    }
                }

                // Aplicación del ítem sobre el jugador
                switch (seleccion_item)
                {
                    case "1":
                        Item.Sword sword = new Item.Sword();
                        jugador.Actions.AddItem(sword);
                        Console.WriteLine($"La espada ha aumentado tu poder de ataque a {jugador.Attack}");
                        break;
                    case "2":
                        Item.MagicStaff magicstaff = new Item.MagicStaff();
                        jugador.Actions.AddItem(magicstaff);
                        Console.WriteLine($"El bastón mágico ha aumentado tu poder de ataque a {jugador.Attack}");
                        break;
                    case "3":
                        Item.Axe axe = new Item.Axe();
                        jugador.Actions.AddItem(axe);
                        Console.WriteLine($"El hacha ha aumentado tu poder de ataque a {jugador.Attack}");
                        break;
                    case "4":
                        Item.Shield shield = new Item.Shield();
                        jugador.Actions.AddItem(shield);
                        Console.WriteLine($"El escudo ha aumentado tu poder de defensa a {jugador.Defense}");
                        break;
                    case "5":
                        Item.Armor armor = new Item.Armor();
                        jugador.Actions.AddItem(armor);
                        Console.WriteLine($"La armadura ha aumentado tu poder de defensa a {jugador.Defense}");
                        break;
                    case "6":
                        Item.Helmet helmet = new Item.Helmet();
                        jugador.Actions.AddItem(helmet);
                        Console.WriteLine($"El casco ha aumentado tu poder de defensa a {jugador.Defense}");
                        break;
                    case "7":
                        Item.SpellBook spellBook = new Item.SpellBook(jugador);
                        if (jugador.Actions.AddItem(spellBook))
                            Console.WriteLine($"El libro de hechizos ha aumentado tu ataque a {jugador.Attack} y tu defensa a {jugador.Defense}");
                        else
                            Console.WriteLine("Lo siento, solo un mago puede usar este ítem. Elige otro");
                        break;
                }
            }
            
            
            
            ////////////////////////////////////OPONENTE//////////////////////////////////////
            // ============================================
            // 4. Creación y equipamiento del Enemigo
            // Mismo flujo que para el jugador, usando la variable 'Enemigo'.
            // ============================================
            Console.WriteLine($"\nSelecciona a tu enemigo");
            

            // ============================================
            // Bucle de validación de raza
            // Permite elegir entre Mago (1), Elfo (2) o Enano (3).
            // Repite hasta que la entrada sea válida.
            // ============================================
            while (SeleccionEnemigo != "1" && SeleccionEnemigo != "2" && SeleccionEnemigo != "3") 
            {
                Console.WriteLine(" 1 - Gato con Botas\n 2 - Shrek\n 3 - Goblin");    //nuevo
                SeleccionEnemigo = Console.ReadLine();
                if (SeleccionEnemigo != "1" && SeleccionEnemigo != "2" && SeleccionEnemigo != "3")
                {
                    Console.WriteLine("ERROR, por favor ingrese una opción válida");
                }
            }
            
            // ============================================
            // Solicitud del nombre del oponente
            // Lee una cadena desde la consola y la asigna.
            // ============================================
            Console.WriteLine("Ingrese un nombre para su Enemigo: ");// quizas sacar
            NombreEnemigo = Console.ReadLine();

            // ============================================
            // Creación del objeto Character
            // Utiliza expresión switch para instanciar la subclase adecuada
            // según la selección de raza.
            // ============================================
            Enemy oponente = SeleccionEnemigo switch
            {
                "1" => new Shrek(NombreEnemigo),
                "2" => new Goblin(NombreEnemigo),                // nuevo
                "3" => new GatoConBotas(NombreEnemigo),
            };
            
            
            
            Console.WriteLine("Es hora de que se equipe, elige dos items");
            while (oponente.Item.Count < 2)
            {
                string seleccion_item = "0";
                int numero = Convert.ToInt32(seleccion_item);

                while (numero > 7 || numero < 1)
                {
                    Console.WriteLine($"{oponente.Item.Count}/2");
                    Console.WriteLine(
                        " 1 - Espada\n 2 - Baculo Magico\n 3 - Hacha \n 4 - Shield\n 5 - Armor\n 6 - Helmet \n 7 - SpellBook");
                    seleccion_item = Console.ReadLine();
                    numero = Convert.ToInt32(seleccion_item);
                    if (numero > 7 || numero < 1)
                        Console.WriteLine("ERROR, por favor ingrese una opción válida");
                }

                switch (seleccion_item)
                {
                    case "1":
                        Item.Sword sword = new Item.Sword();
                        oponente.Actions.AddItem(sword);
                        Console.WriteLine($"La espada ha aumentado tu poder de ataque a {oponente.Attack}");
                        break;
                    case "2":
                        Item.MagicStaff magicstaff = new Item.MagicStaff();
                        oponente.Actions.AddItem(magicstaff);
                        Console.WriteLine($"El bastón mágico ha aumentado tu poder de ataque a {oponente.Attack}");
                        break;
                    case "3":
                        Item.Axe axe = new Item.Axe();
                        oponente.Actions.AddItem(axe);
                        Console.WriteLine($"El hacha ha aumentado tu poder de ataque a {oponente.Attack}");
                        break;
                    case "4":
                        Item.Shield shield = new Item.Shield();
                        oponente.Actions.AddItem(shield);
                        Console.WriteLine($"El escudo ha aumentado tu poder de defensa a {oponente.Defense}");
                        break;
                    case "5":
                        Item.Armor armor = new Item.Armor();
                        oponente.Actions.AddItem(armor);
                        Console.WriteLine($"La armadura ha aumentado tu poder de defensa a {oponente.Defense}");
                        break;
                    case "6":
                        Item.Helmet helmet = new Item.Helmet();
                        oponente.Actions.AddItem(helmet);
                        Console.WriteLine($"El casco ha aumentado tu poder de defensa a {oponente.Defense}");
                        break;
                    case "7":
                        Item.SpellBook spellBook = new Item.SpellBook(oponente);
                        if (oponente.Actions.AddItem(spellBook))
                            Console.WriteLine($"El libro de hechizos ha aumentado tu ataque a {oponente.Attack} y tu defensa a {oponente.Defense}");
                        else
                            Console.WriteLine("Lo siento, solo un mago puede usar este ítem. Elige otro");
                        break;
                }
            }

            // ============================================
            // 5. Bucle de combate
            // Alterna turnos de ataque o curación hasta que uno pierda toda su vida.
            // ============================================
            while (jugador.CurrentHealth > 0 && oponente.CurrentHealth > 0)
            {
                Console.WriteLine(
                    $"VIDA {jugador.Name} = {jugador.CurrentHealth}          VIDA {oponente.Name} = {oponente.CurrentHealth} \n");

                // Turno del jugador
                Console.WriteLine($"\n{jugador.Name}, elige una acción:\n 1 - Atacar\n 2 - Curar\n");
                string action = "";
                while (action != "1" && action != "2")
                {
                    action = Console.ReadLine();
                    if (action == "1")
                    {
                        jugador.Actions.Attack(oponente);
                        Console.WriteLine("Atacando…");
                        Console.WriteLine($"La vida de {oponente.Name} es {oponente.CurrentHealth}\n");
                    }
                    else if (action == "2")
                    {
                        Console.WriteLine($"Vida actual de {jugador.Name}: {jugador.CurrentHealth}\nCurando…");
                        jugador.Actions.Heal();
                        Console.WriteLine($"Nueva vida de {jugador.Name}: {jugador.CurrentHealth}\n");
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Selecciona una opción válida\n");
                    }
                }

                // Turno del oponente
                if (oponente.CurrentHealth > 0)
                {
                    Console.WriteLine($"\n{oponente.Name}, elige una acción:\n 1 - Atacar\n 2 - Curar\n");
                    string action2 = "";
                    while (action2 != "1" && action2 != "2")
                    {
                        action2 = Console.ReadLine();
                        if (action2 == "1")
                        {
                            oponente.Actions.Attack(jugador);
                            Console.WriteLine("Atacando…");
                            Console.WriteLine($"La vida de {jugador.Name} es {jugador.CurrentHealth}\n");
                        }
                        else if (action2 == "2")
                        {
                            Console.WriteLine($"Vida actual de {oponente.Name}: {oponente.CurrentHealth}\nCurando…");
                            oponente.Actions.Heal();
                            Console.WriteLine($"Nueva vida de {oponente.Name}: {oponente.CurrentHealth}\n");
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Selecciona una opción válida\n");
                        }
                    }
                }
            }

            // ============================================
            // 6. Determinación del ganador
            // Compara las vidas finales y anuncia el resultado.
            // ============================================
            if (jugador.CurrentHealth > oponente.CurrentHealth)
                Console.WriteLine($"\nHa ganado: {jugador.Name}!!");
            else if (oponente.CurrentHealth > jugador.CurrentHealth)
                Console.WriteLine($"\nHa ganado: {oponente.Name}!!");
            else
                Console.WriteLine("\nHa sido un empate");

            // ============================================
            // 7. Despedida
            // Muestra el mensaje de cierre de la partida.
            // ============================================
            Console.WriteLine("Gracias por jugar ENCUENTROS FUTUROS DE LA TIERRA MEDIA.");
        }
    }
}