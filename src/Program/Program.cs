using Library;
using Library.Personajes;

class Program
{
    static void Main(string[] args)
    {
        
        // Creo dos personajes para que se enfrenten
        var jugador  = CharacterPrompter.Prompt("Selecciona tu personaje");
        Console.WriteLine($"Has creado a el {jugador.Race} {jugador.Name} con {jugador.CurrentHealth} de vida, {jugador.Ataque} de ataque y {jugador.Defensa} de defensa");
 
        var oponente = CharacterPrompter.Prompt("Selecciona un oponente");
        Console.WriteLine($"Has creado a el {oponente.Race} {oponente.Name} con {oponente.CurrentHealth} de vida, {oponente.Ataque} de ataque y {oponente.Defensa} de defensa");
        
        Actions.Attack(jugador,oponente);
        Console.WriteLine($"Has creado a el {oponente.Race} {oponente.Name} con {oponente.CurrentHealth} de vida, {oponente.Ataque} de ataque y {oponente.Defensa} de defensa");
        
        Actions.Heal(oponente);
        Console.WriteLine($"Has creado a el {oponente.Race} {oponente.Name} con {oponente.CurrentHealth} de vida, {oponente.Ataque} de ataque y {oponente.Defensa} de defensa");
    }
}


    