namespace Library.Interfaces;
/// <summary>
/// En caso de que el item aporte ataque, debe implementarse esta interfaz.
/// </summary>
public interface IOffensiveItemElement : IItem//En caso de que aporte ataque se usara esta interfaz
{
    public int AttackValue { get; } //AttackValue contiene el ataque que proporcionara este item al personaje
}