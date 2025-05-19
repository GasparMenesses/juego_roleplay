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
}