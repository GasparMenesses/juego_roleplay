using Library.Interfaces;

namespace Library;

public class Character : ICharacter
{
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
    }

    public void Atacar(ICharacter attacked)
    {
        if (attacked.Defense > this.Attack)
            attacked.CurrentHealth -= 1;
        else
            attacked.CurrentHealth -= (this.Attack - attacked.Defense);
    }
    
    public void Curar()
    {
        this.CurrentHealth += 10;
        if (this.CurrentHealth > this.MaxHealth)
            this.CurrentHealth = this.MaxHealth;
    }
    
    public void AgregarItem(IItem item)//Todos los items son IItem
    {
        if (item is ISpecialItemElement special && !special.CanBeEquipped)
        {
            return;//No devuelve nada en particular, solo finaliza el metodo, esto permite que el metodo sea void
        }
        this.Item.Add(item);
    }

    public bool RemoverItem(IItem item)
    {
        return this.Item.Remove(item);
    }
}