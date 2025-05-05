namespace Library.Personajes;

public class Elve : Character
{
    private static readonly Random maxHealth = new Random();
    public Elve(string name)  //Ese : base(...) le dice al compilador “antes de ejecutar el cuerpo de este constructor, invoca el constructor de la clase padre (Character) pasándole estos parámetros”
        : base("Elve", name, maxHealth.Next(70, 101), 10, 5)   
    { }

    public static int sape = maxHealth.Next(10, 80);
}