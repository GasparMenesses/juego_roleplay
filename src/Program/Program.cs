using Library;
class Program
{
    static void Main(string[] args)
    {
        
        // Creo dos personajes para que se enfrenten
        var jugador  = CharacterPrompter.Prompt("Selecciona tu personaje");
        Console.WriteLine($"Has creado a el {jugador.Race} {jugador.Name} con {jugador.CurrentHealth} de vida.");

        var oponente = CharacterPrompter.Prompt("Selecciona un oponente");
        Console.WriteLine($"Has creado a el {oponente.Race} {oponente.Name} con {oponente.CurrentHealth} de vida.");
        
    }
}


    