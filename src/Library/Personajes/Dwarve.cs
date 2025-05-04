namespace Library;

public class Dwarve : Character
{
    private static readonly Random maxHealth = new Random();
    public Dwarve(string name)
        : base(name, maxHealth.Next(70, 101))    // vida enano random entre 70 y 100
    { }
}