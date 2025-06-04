namespace Library.Interfaces;

/// <summary>
/// En caso de que el item aporte defensa, debe implementarse esta interfaz.
/// </summary>
public interface IDefensiveItemElement : IItem//En caso de que aporte defensa se usara esta interfaz
{
    public int DefenseValue { get ; }//DefenseValue contiene la defensa que proporcionara este item al personaje
}