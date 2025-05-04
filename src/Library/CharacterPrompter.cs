
namespace Library
{
    public class CharacterPrompter
    {
        public string promptTitle { get; protected set; }

        public static Character Prompt(string promptTitle)
        {
            Console.WriteLine($"ENCUENTROS FUTUROS DE LA TIERRA MEDIA\n{promptTitle}");
            string SeleccionPersonaje = "";
            string Nombre = "";

            while (SeleccionPersonaje != "1" && SeleccionPersonaje != "2" && SeleccionPersonaje != "3")
            {
                Console.WriteLine(" 1 - Mago\n 2 - Elfo\n 3 - Enano");
                SeleccionPersonaje = Console.ReadLine();
                if (SeleccionPersonaje != "1" && SeleccionPersonaje != "2" && SeleccionPersonaje != "3")
                {
                    Console.WriteLine("ERROR, por favor ingrese una opción válida");
                }
            }
            
            Console.WriteLine("Ingrese un nombre para su personaje: ");
            Nombre = Console.ReadLine();

            Character jugador = SeleccionPersonaje switch
            {
                "1" => new Wizard(Nombre),
                "2" => new Elve(Nombre),
                "3" => new Dwarve(Nombre),
            };
            
            return jugador;
        }
    }
} 


