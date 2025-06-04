namespace Library.Interfaces;

/// <summary>
/// En caso de que el item sea especial, debe implementarse esta interfaz.
/// El item debera recibir un personaje (ICharacter) para evaluar si puede ser equipado.
/// </summary>
public interface ISpecialItemElement : IItem//En caso de que el item sea un item especial se usara esta interfaz
{
    public bool CanBeEquipped { get; }//CanBeEquipped contiene un valor booleano que nos dice si el item puede ser equipado o no
}