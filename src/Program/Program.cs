using Library;
using Library.Elementos;

class Program
{
    static void Main(string[] args)
    {
        // cumple con SRP ya que es la clase que se encarga de orquestar el flujo general de la partida (título, selección de personajes, equipamiento, combate y cierre)
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
        var jugador = CharacterPrompter.Prompt($"\nSelecciona tu personaje");
        Console.WriteLine(
            $"Has creado al {jugador.Race} {jugador.Name} con {jugador.CurrentHealth} de vida, {jugador.Ataque} de ataque y {jugador.Defensa} de defensa\n");

        // ============================================
        // 3. Equipamiento del jugador
        // Permite elegir dos ítems, valida la entrada y aplica los cambios
        // en los atributos según el tipo de ítem seleccionado.
        // ============================================
        Console.WriteLine("Es hora de que se equipe, elige dos items");
        for (int i = 0; i < 2; i++)
        {
            bool autenticator = true;
            string seleccion_item = "0";
            int numero = Convert.ToInt32(seleccion_item);
            Console.WriteLine($"{i + 1}/2");

            // Validación de la opción (1–7)
            while (numero > 7 || numero < 1)
            {
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
                    OfensiveItems.Sword(jugador);
                    Console.WriteLine($"La espada ha aumentado tu poder de ataque a {jugador.Ataque}");
                    break;
                case "2":
                    OfensiveItems.MagicStaff(jugador);
                    Console.WriteLine($"El bastón mágico ha aumentado tu poder de ataque a {jugador.Ataque}");
                    break;
                case "3":
                    OfensiveItems.Axe(jugador);
                    Console.WriteLine($"El hacha ha aumentado tu poder de ataque a {jugador.Ataque}");
                    break;
                case "4":
                    DefensiveItems.Shield(jugador);
                    Console.WriteLine($"El escudo ha aumentado tu poder de defensa a {jugador.Defensa}");
                    break;
                case "5":
                    DefensiveItems.Armor(jugador);
                    Console.WriteLine($"La armadura ha aumentado tu poder de defensa a {jugador.Defensa}");
                    break;
                case "6":
                    DefensiveItems.Helmet(jugador);
                    Console.WriteLine($"El casco ha aumentado tu poder de defensa a {jugador.Defensa}");
                    break;
                case "7":
                    autenticator = SpecialItems.SpellBook(jugador);
                    if (autenticator)
                        Console.WriteLine($"El libro de hechizos ha aumentado tu defensa a {jugador.Defensa}");
                    else
                        Console.WriteLine("Lo siento, solo un mago puede usar este ítem. Elige otro");
                    break;
            }

            // Si el SpellBook no fue válido, repetir selección
            if (!autenticator)
                i -= 1;
        }

        // ============================================
        // 4. Creación y equipamiento del oponente
        // Mismo flujo que para el jugador, usando la variable 'oponente'.
        // ============================================
        var oponente = CharacterPrompter.Prompt($"\nSelecciona un oponente");
        Console.WriteLine(
            $"Has creado al {oponente.Race} {oponente.Name} con {oponente.CurrentHealth} de vida, {oponente.Ataque} de ataque y {oponente.Defensa} de defensa\n");
        Console.WriteLine("Es hora de que se equipe, elige dos items");
        for (int i = 0; i < 2; i++)
        {
            bool autenticator = true;
            string seleccion_item = "0";
            int numero = Convert.ToInt32(seleccion_item);
            Console.WriteLine($"{i + 1}/2");

            while (numero > 7 || numero < 1)
            {
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
                    OfensiveItems.Sword(oponente);
                    Console.WriteLine($"La espada ha aumentado tu poder de ataque a {oponente.Ataque}");
                    break;
                case "2":
                    OfensiveItems.MagicStaff(oponente);
                    Console.WriteLine($"El bastón mágico ha aumentado tu poder de ataque a {oponente.Ataque}");
                    break;
                case "3":
                    OfensiveItems.Axe(oponente);
                    Console.WriteLine($"El hacha ha aumentado tu poder de ataque a {oponente.Ataque}");
                    break;
                case "4":
                    DefensiveItems.Shield(oponente);
                    Console.WriteLine($"El escudo ha aumentado tu poder de defensa a {oponente.Defensa}");
                    break;
                case "5":
                    DefensiveItems.Armor(oponente);
                    Console.WriteLine($"La armadura ha aumentado tu poder de defensa a {oponente.Defensa}");
                    break;
                case "6":
                    DefensiveItems.Helmet(oponente);
                    Console.WriteLine($"El casco ha aumentado tu poder de defensa a {oponente.Defensa}");
                    break;
                case "7":
                    autenticator = SpecialItems.SpellBook(oponente);
                    if (autenticator)
                        Console.WriteLine($"El libro de hechizos ha aumentado tu defensa a {oponente.Defensa}");
                    else
                        Console.WriteLine("Lo siento, solo un mago puede usar este ítem. Elige otro");
                    break;
            }

            if (!autenticator)
                i -= 1;
        }

        // ============================================
        // 5. Bucle de combate
        // Alterna turnos de ataque o curación hasta que uno pierda toda su vida.
        // ============================================
        while (jugador.CurrentHealth > 0 && oponente.CurrentHealth > 0)
        {
            Console.WriteLine($"VIDA {jugador.Name} = {jugador.CurrentHealth}          VIDA {oponente.Name} = {oponente.CurrentHealth} \n");

            // Turno del jugador
            Console.WriteLine($"\n{jugador.Name}, elige una acción:\n 1 - Atacar\n 2 - Curar\n");
            string action = "";
            while (action != "1" && action != "2")
            {
                action = Console.ReadLine();
                if (action == "1")
                {
                    Actions.Attack(jugador, oponente);
                    Console.WriteLine("Atacando…");
                    Console.WriteLine($"La vida de {oponente.Name} es {oponente.CurrentHealth}\n");
                }
                else if (action == "2")
                {
                    Console.WriteLine($"Vida actual de {jugador.Name}: {jugador.CurrentHealth}\nCurando…");
                    Actions.Heal(jugador);
                    Console.WriteLine($"Nueva vida de {jugador.Name}: {jugador.CurrentHealth}\n");
                }
                else
                {
                    Console.WriteLine("ERROR: Selecciona una opción válida\n");
                }
            }

            // Turno del oponente
            Console.WriteLine($"\n{oponente.Name}, elige una acción:\n 1 - Atacar\n 2 - Curar\n");
            string action2 = "";
            while (action2 != "1" && action2 != "2")
            {
                action2 = Console.ReadLine();
                if (action2 == "1")
                {
                    Actions.Attack(oponente, jugador);
                    Console.WriteLine("Atacando…");
                    Console.WriteLine($"La vida de {jugador.Name} es {jugador.CurrentHealth}\n");
                }
                else if (action2 == "2")
                {
                    Console.WriteLine($"Vida actual de {oponente.Name}: {oponente.CurrentHealth}\nCurando…");
                    Actions.Heal(oponente);
                    Console.WriteLine($"Nueva vida de {oponente.Name}: {oponente.CurrentHealth}\n");
                }
                else
                {
                    Console.WriteLine("ERROR: Selecciona una opción válida\n");
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
