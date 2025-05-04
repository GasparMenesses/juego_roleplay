namespace Library;

public class Wizard : Character
{
    private static readonly Random maxHealth = new Random();
    public Wizard(string name)
        : base(name, maxHealth.Next(70, 101))    // vida mago random entre 70 y 100
    { }
}