namespace Library;

public abstract class Character // clase abstracta
{
    public string Race { get; protected set; }
    public string Name { get; protected set; }
    public int MaxHealth { get; protected set; }
    public int CurrentHealth { get;  set; }
    
    public int Ataque { get;  set; }
    
    public int Defensa { get;  set; }
    
    protected Character(string race ,string name, int maxHealth, int ataque, int defensa) //protected es para que solo puedan acceder la clase y subclases
    {
        Race = race;
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        Ataque = ataque;
        Defensa = defensa;
    }
}