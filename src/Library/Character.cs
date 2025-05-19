using Library.Interfaces;

namespace Library;

public class Character : ICharacter
{
    public Actions Actions { get; }
    public string Name { get; }
    public string Race { get; }
    public int CurrentHealth { get; set; }
    public  int MaxHealth { get; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public List<IItem> Item { get; set; } 


    public Character(string name,string race, int maxhealth, int attack, int defense)
    {
        Name = name;
        Race = race;
        CurrentHealth = maxhealth;
        MaxHealth = maxhealth;
        Attack = attack;
        Defense = defense;
        Item = new List<IItem>();
        this.Actions = new Actions(this);
    }
}