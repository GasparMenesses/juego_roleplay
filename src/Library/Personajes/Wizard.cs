namespace Library.Personajes;

public class Wizard : Character
{
    private static readonly Random maxHealth = new Random();
    public Wizard(string name)  //Ese : base(...) le dice al compilador “antes de ejecutar el cuerpo de este constructor, invoca el constructor de la clase padre (Character) pasándole estos parámetros”
        : base("Wizard", name, maxHealth.Next(70, 101), 10, 5)    
    { }
}