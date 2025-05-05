namespace Library
{
    public class CharacterPrompter
    {
        // Cumple con SRP porque su única responsabilidad es interactuar con el usuario para elegir la raza y el nombre del personaje y,
        // a partir de eso, crear la instancia adecuada. No gestiona combate, equipamiento ni ninguna otra lógica del juego
        // ============================================
        // Propiedad promptTitle
        // Almacena el título o mensaje que se mostrará al invocar el prompt.
        // Protegida para permitir lectura externa y modificación interna.
        // ============================================
        public string promptTitle { get; protected set; }

        // ============================================
        // Método estático Prompt
        // Responsabilidad: solicitar al usuario la raza y el nombre del personaje,
        // crear la instancia correspondiente y devolverla.
        // ============================================
        public static Character Prompt(string promptTitle)
        {
            // Muestra el título recibido como parámetro
            Console.WriteLine(promptTitle);

            string SeleccionPersonaje = "";
            string Nombre = "";

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
            Console.WriteLine("Ingrese un nombre para su personaje: ");
            Nombre = Console.ReadLine();

            // ============================================
            // Creación del objeto Character
            // Utiliza expresión switch para instanciar la subclase adecuada
            // según la selección de raza.
            // ============================================
            Character jugador = SeleccionPersonaje switch
            {
                "1" => new Personajes.Wizard(Nombre),
                "2" => new Personajes.Elve(Nombre),
                "3" => new Personajes.Dwarve(Nombre),
            };

            // Devuelve el personaje creado
            return jugador;
        }
    }
}
