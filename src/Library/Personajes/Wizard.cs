namespace Library.Personajes;

public class Wizard : Character // la clase Elve hereda de la clase character
{
    private static readonly Random maxHealth = new Random(); //usamos random static para inicializar la salud en el valor máximo
    public Wizard(string name)  //Ese : base(...) le dice al compilador “antes de ejecutar el cuerpo de este constructor, invoca el constructor de la clase padre (Character) pasándole estos parámetros”
        : base(name, "Wizard", maxHealth.Next(70, 101), 10, 5)    
    { }
}       //Se le asigna un tipo ("Wizard"), un nombre, una salud máxima aleatoria entre 70 y 100 y valores fijos de ataque (10) y defensa (5).