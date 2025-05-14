using Library.Interfaces;

namespace Library;

public class Character : ICharacter
{
    public string Name { get; set; }
    public string Race { get; set; }
    public int CurrentHealth { get; set; }
    public  int MaxHealth { get; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    
    
    public Character(string nombre,string race, int maxhealth, int attack, int defense)
    {
        Name = nombre;
        Race = race;
        CurrentHealth = maxhealth;
        MaxHealth = maxhealth;
        Attack = attack;
        Defense = defense;
    }

    public void Atacar(ICharacter attacker, ICharacter attacked )
    {
        if (attacked.Defense > attacker.Attack)
            attacked.CurrentHealth -= 1;
        else
            attacked.CurrentHealth -= (attacker.Attack - attacked.Defense);
    }
    
    public void Curar(ICharacter curado)
    {
        curado.CurrentHealth += 5;
        if (curado.CurrentHealth > curado.MaxHealth)
            curado.CurrentHealth = curado.MaxHealth;
    }
    
    public void AgregarItem(ICharacter curado)
    {
        
    }


}