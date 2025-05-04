namespace Library;

public class Elve : Character
{
    private static readonly Random maxHealth = new Random();
    public Elve(string name)
        : base(name, maxHealth.Next(70, 101))    // vida elfo random entre 70 y 100
    { }
}