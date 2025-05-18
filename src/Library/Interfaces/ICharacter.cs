namespace Library.Interfaces;

public interface ICharacter
{
    public string Name { get; }
    public string Race { get; }
    public int CurrentHealth { get; set; }
    public int MaxHealth { get;  }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public List<IItem> Item { get ; set; }
    
    
    /// <summary>
    /// Recibe el personaje que esta siendo atacado
    /// </summary>
    void Atacar(ICharacter attacked );
    /// <summary>
    /// Cura al personaje actual
    /// </summary>
    void Curar();
    /// <summary>
    /// Recibe el item que se desea agregar
    /// </summary>
    void AgregarItem(IItem item);
    /// <summary>
    /// Recibe el item que se desea remover, devuelve true en caso de que se haya removido con exito, false en caso
    /// contrario(el item no se encuentra en el inventario)
    /// </summary>
    bool RemoverItem(IItem item);
}