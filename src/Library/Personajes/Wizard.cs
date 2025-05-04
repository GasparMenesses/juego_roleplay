namespace Library;

public class Wizard : Character
{
    private static readonly Random maxHealth = new Random();
    public Wizard(string name)  //Ese : base(...) le dice al compilador “antes de ejecutar el cuerpo de este constructor, invoca el constructor de la clase padre (Character) pasándole estos parámetros”
        : base("Mago", name, maxHealth.Next(70, 101))    // vida mago random entre 70 y 100
    { }
}