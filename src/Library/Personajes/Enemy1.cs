// namespace Library.Personajes;
//
// public class Enemy1 : Character
// {
//     
//     private static readonly Random maxHealth = new Random(); //usamos random static para inicializar la salud en el valor máximo
//     public Enemy1(string name)  //Ese : base(...) le dice al compilador “antes de ejecutar el cuerpo de este constructor, invoca el constructor de la clase padre (Character) pasándole estos parámetros”
//         : base(name, "Enemy", maxHealth.Next(70, 101), 10, 5)   
//     { }
//
//     public static int sape = maxHealth.Next(10, 80); //Campo estático llamado 'sape' que se inicializa con un valor aleatorio entre 10 y 79.
//     //Este valor se comparte entre todas las instancias de Elve.
// }
