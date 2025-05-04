using Library;
class Program
{
    static void Main(string[] args)
    {
        
        // Creo dos personajes para que se enfrenten
        var jugador  = CharacterPrompter.Prompt("Selecciona tu personaje");
        Console.WriteLine($"Has creado a el {jugador.Race} {jugador.Name} con {jugador.CurrentHealth} de vida, {jugador.Ataque} de ataque y {jugador.Defensa} de defensa");

        var oponente = CharacterPrompter.Prompt("Selecciona un oponente");
        Console.WriteLine($"Has creado a el {oponente.Race} {oponente.Name} con {oponente.CurrentHealth} de vida, {oponente.Ataque} de ataque y {oponente.Defensa} de defensa");
        
        
        
            // Llamamos al prompter para crear un ítem
            Items miItem = ItemPrompter.Prompt("Elegí tu ítem inicial:");

            // Mostramos en consola la información del ítem creado
            Console.WriteLine("\n¡Ítem creado con éxito!");
            Console.WriteLine($"Nombre: {miItem.WeaponName}");
            Console.WriteLine($"Daño: {miItem.Damage}");
            Console.WriteLine($"Defensa: {miItem.Defense}");
        
    }
    
    
}


    