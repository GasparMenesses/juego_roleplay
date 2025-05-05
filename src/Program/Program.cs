using Library;
using Library.Elementos;
using Library.Personajes;

class Program
{
    static void Main(string[] args)
    {

        // Creo dos personajes para que se enfrenten
        var jugador = CharacterPrompter.Prompt("Selecciona tu personaje");
        Console.WriteLine(
            $"Has creado a el {jugador.Race} {jugador.Name} con {jugador.CurrentHealth} de vida, {jugador.Ataque} de ataque y {jugador.Defensa} de defensa");
        for (int i = 0; i < 2; i++)
        {
            bool autenticator = true;
            Console.WriteLine("Es hora de que se equipe, elige dos items");
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
                {
                    Console.WriteLine("ERROR, por favor ingrese una opción válida");

                }
            }

            switch (seleccion_item)
            {
                case "1":
                    OfensiveItems.Sword(jugador);
                    break;
                case "2":
                    OfensiveItems.MagicStaff(jugador);
                    break;
                case "3":
                    OfensiveItems.Axe(jugador);
                    break;
                case "4":
                    DefensiveItems.Shield(jugador);
                    break;
                case "5":
                    DefensiveItems.Armor(jugador);
                    break;
                case "6":
                    DefensiveItems.Helmet(jugador);
                    break;
                case "7":
                    SpecialItems.SpellBook(jugador);
                    autenticator = SpecialItems.SpellBook(jugador);
                    if (autenticator == false)
                    {
                        Console.WriteLine("Solo un mago puede tener esto");
                    }

                    break;
            }

            if (autenticator == false)
            {
                i -= 1;
            }
        }

        Console.WriteLine("Es hora de que se equipe, elige dos items");

        var oponente = CharacterPrompter.Prompt("Selecciona un oponente");
        Console.WriteLine(
            $"Has creado a el {oponente.Race} {oponente.Name} con {oponente.CurrentHealth} de vida, {oponente.Ataque} de ataque y {oponente.Defensa} de defensa");

        for (int i = 0; i < 2; i++)
        {
            bool autenticator = true;
            Console.WriteLine("Es hora de que se equipe, elige dos items");
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
                {
                    Console.WriteLine("ERROR, por favor ingrese una opción válida");

                }
            }

            switch (seleccion_item)
            {
                case "1":
                    OfensiveItems.Sword(oponente);
                    break;
                case "2":
                    OfensiveItems.MagicStaff(oponente);
                    break;
                case "3":
                    OfensiveItems.Axe(oponente);
                    break;
                case "4":
                    DefensiveItems.Shield(oponente);
                    break;
                case "5":
                    DefensiveItems.Armor(oponente);
                    break;
                case "6":
                    DefensiveItems.Helmet(oponente);
                    break;
                case "7":
                    SpecialItems.SpellBook(oponente);
                    autenticator = SpecialItems.SpellBook(oponente);
                    if (autenticator == false)
                    {
                        Console.WriteLine("Solo un mago puede tener esto");
                    }

                    break;
            }

            if (autenticator == false)
            {
                i -= 1;
            }
        }
        
        Console.WriteLine($"Yo, \n {oponente.Name} te derrotare a como de lugar!!\n elige una acción:\n 1 - Atacar\n 2 - Curar");
        string action = "";
        while (action != "1" && action != "2")
        {
            action = Console.ReadLine();
            if (action == "1")
            {
                Actions.Attack(jugador,oponente);
                Console.WriteLine("ATACANDO!..");
                Console.WriteLine($"La vida de {oponente.Name} es {oponente.CurrentHealth}");
            } else if (action == "2")
            {
                Console.WriteLine($"Vida actual de {jugador.Name} es {jugador.CurrentHealth}\n Curando..");
                Actions.Heal(jugador);
                Console.WriteLine($"Ahora la vida actual de {jugador.Name} es {jugador.CurrentHealth}");
                
            } else
            {
                Console.WriteLine("ERROR! Selecciona una opción válida");  
            }
            
            
        }
        
        
        
        
        
        Actions.Heal(oponente);
        Console.WriteLine($"Has creado a el {oponente.Race} {oponente.Name} con {oponente.CurrentHealth} de vida, {oponente.Ataque} de ataque y {oponente.Defensa} de defensa");
    }
}



    