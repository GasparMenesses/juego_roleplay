namespace Library.Interfaces;

public interface IItem//Esta interfaz sin importar que la aplican todos los items, sin excepcion, esto permite recibir
        //un item del tipo IItem como parametro en un metodo sin obligar a un item a aplicar una funcion en particular
{ }
/// <summary>
/// En caso de que el item aporte ataque, debe implementarse esta interfaz.
/// </summary>
public interface IOffensiveItemElement//En caso de que aporte ataque se usara esta interfaz
{
    public int AttackValue { get; } //AttackValue contiene el ataque que proporcionara este item al personaje
}
/// <summary>
/// En caso de que el item aporte defensa, debe implementarse esta interfaz.
/// </summary>
public interface IDefensiveItemElement//En caso de que aporte defensa se usara esta interfaz
{
    public int DefenseValue { get ; }//DefenseValue contiene la defensa que proporcionara este item al personaje
}
/// <summary>
/// En caso de que el item sea especial, debe implementarse esta interfaz.
/// El item debera recibir un personaje (ICharacter) para evaluar si puede ser equipado.
/// </summary>
public interface ISpecialItemElement//En caso de que el item sea un item especial se usara esta interfaz
{
    public bool CanBeEquipped { get; }//CanBeEquipped contiene un valor booleano que nos dice si el item puede ser equipado o no
}