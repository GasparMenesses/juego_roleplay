using System.Security.Cryptography;

namespace Library.Personajes.Enemigos;

public class Shrek : Enemy
{
    
    private static readonly Random maxHealth = new Random(); // usamos random static para inicializar la salud en el valor máximo
    private static readonly Random Wp = new Random();
    public Shrek(string name)  // Ese : base(...) le dice al compilador “antes de ejecutar el cuerpo de este constructor, invoca el constructor de la clase padre (Character) pasándole estos parámetros”
        : base(name, "Enemy", maxHealth.Next(70, 101), 10, 5,Wp.Next(3,20))   
    { }

    public static int vida = maxHealth.Next(10, 80); //Campo estático llamado 'vida' que se inicializa con un valor aleatorio entre 10 y 79.
    // Este valor se comparte entre todas las instancias de Shrek.
    public static int puntosvictoria = Wp.Next(3, 20);
}
