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
        int totalAttack = this.Character.Attack;
        int totalDefense = attacked.Defense;
        foreach (IItem item in this.Character.Item)
        {
            if (item is IOffensiveItemElement offensive)
                totalAttack += offensive.AttackValue;
        }
        foreach (IItem item in attacked.Item)
        {
            if (item is IDefensiveItemElement defensive)
                totalDefense += defensive.DefenseValue;
        }
        if (totalDefense > totalAttack)
            attacked.CurrentHealth -= 1;
        else
            attacked.CurrentHealth -= (totalAttack - totalDefense);
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
    public void AddItem(IItem item)//Todos los items son IItem
    {
        if (item is ISpecialItemElement special && !special.CanBeEquipped)
        {
            return;//No devuelve nada en particular, solo finaliza el metodo, esto permite que el metodo sea void
        }
        this.Character.Item.Add(item);
    }
    /// <summary>
    /// Recibe el item que se desea remover, devuelve true en caso de que se haya removido con exito, false en caso
    /// contrario(el item no se encuentra en el inventario)
    /// </summary>
    public bool RemoveItem(IItem item)
    {
        return this.Character.Item.Remove(item);
    }
}