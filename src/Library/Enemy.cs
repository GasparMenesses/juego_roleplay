using Library.Interfaces;

namespace Library;

public class Enemy : ICharacter
{
    
    public Actions Actions { get; }
    public string Name { get; }
    public string Race { get; }
    public int CurrentHealth { get; set; }
    public  int MaxHealth { get; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public List<IItem> Item { get; set; } 
    public int Wp { get; }
    


    public Enemy(string name,string race, int maxhealth, int attack, int defense, int wp)
    {
        Name = name;
        Race = race;
        CurrentHealth = maxhealth;
        MaxHealth = maxhealth;
        Attack = attack;
        Defense = defense;
        Item = new List<IItem>();
        this.Actions = new Actions(this);
        Wp = wp;
    }
    
}