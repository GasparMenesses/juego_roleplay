namespace Library.Interfaces;

public interface ICharacter
{
    string Name { get; }
    string Race { get; }
    int CurrentHealth { get; set; }
    int MaxHealth { get;  }
    int Attack { get; }
    int Defense { get; }
    
    

    void Atacar(ICharacter attacker, ICharacter attacked );
    void Curar (ICharacter curado);
    void AgregarItem (ICharacter item);
}