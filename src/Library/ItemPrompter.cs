namespace Library;

public class ItemPrompter
{
    public static Items Prompt(string promptTitle)
    {
        Console.WriteLine($"\nSELECCIÓN DE ÍTEM\n{promptTitle}");

        string seleccion = "";
        while (seleccion != "1" && seleccion != "2" && seleccion != "3")
        {
            Console.WriteLine(" 1 - Espada\n 2 - Arco\n 3 - Escudo");
            seleccion = Console.ReadLine();
            if (seleccion != "1" && seleccion != "2" && seleccion != "3")
            {
                Console.WriteLine("ERROR, por favor ingrese una opción válida");
            }
        }

        Console.Write("Ingrese un nombre para el ítem: ");
        string nombreItem = Console.ReadLine();

        Items item = seleccion switch
        {
            "1" => new Sword(nombreItem, 25, 5),   // Espada: más daño
            "2" => new Bow(nombreItem, 15, 2),     // Arco: menos defensa
            "3" => new Shield(nombreItem, 5,20),  // Escudo: más defensa
            
        };

        return item;
    }
}
