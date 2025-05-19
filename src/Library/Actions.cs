using Library.Interfaces;

namespace Library;

public class Actions
{
    private ICharacter Character;
    public Actions(ICharacter character)
    {
        this.Character = character;
    }
    /// <summary>
    /// Recibe el personaje que esta siendo atacado
    /// </summary>
    public void Attack(ICharacter attacked)
    {
        if (attacked.Defense > this.Character.Attack)
            attacked.CurrentHealth -= 1;
        else
            attacked.CurrentHealth -= (this.Character.Attack - attacked.Defense);
        if (attacked.CurrentHealth < 0)
            attacked.CurrentHealth = 0;
    }
    /// <summary>
    /// Cura al personaje actual
    /// </summary>
    public void Heal()
    {
        this.Character.CurrentHealth += 10;
        if (this.Character.CurrentHealth > this.Character.MaxHealth)
            this.Character.CurrentHealth = this.Character.MaxHealth;
    }
    /// <summary>
    /// Recibe el item que se desea agregar
    /// </summary>
    public bool AddItem(IItem item)//Todos los items son IItem
    {
        if (item is ISpecialItemElement special && !special.CanBeEquipped)
        {
            return false;//Devuelve false si no pudo ser equipado
        }
        this.Character.Item.Add(item);
        if (item is IOffensiveItemElement offensive)
            this.Character.Attack += offensive.AttackValue;
        if (item is IDefensiveItemElement defensive)
            this.Character.Defense += defensive.DefenseValue;
        return true;
    }
    /// <summary>
    /// Recibe el item que se desea remover, devuelve true en caso de que se haya removido con exito, false en caso
    /// contrario(el item no se encuentra en el inventario)
    /// </summary>
    public bool RemoveItem(IItem item)
    {
        bool wasRemoved = this.Character.Item.Remove(item);
        if (wasRemoved)
        {
            if (item is IOffensiveItemElement offensive)
                this.Character.Attack -= offensive.AttackValue;
            if (item is IDefensiveItemElement defensive)
                this.Character.Defense -= defensive.DefenseValue;
        }
        return wasRemoved;
    }
}