using Library.Interfaces;

namespace Library.Elementos;

public class Item
{
    public class Sword : IItem, IOffensiveItemElement , IDefensiveItemElement
    {
        public int AttackValue { get; }
        public int DefenseValue { get; }
        public Sword()
        {
            AttackValue = 5;
            DefenseValue = 1;
        }
    }
    public class MagicStaff : IItem, IOffensiveItemElement , IDefensiveItemElement
    {
        public int AttackValue { get; }
        public int DefenseValue { get; }
        public MagicStaff()
        {
            AttackValue = 3;
            DefenseValue = 3;
        }
    }
    public class Axe : IItem, IOffensiveItemElement 
    {
        public int AttackValue { get; }
        public Axe()
        {
            AttackValue = 6;
        }
    }
    public class Shield : IItem, IOffensiveItemElement , IDefensiveItemElement
    {
        public int AttackValue { get; }
        public int DefenseValue { get; }
        public Shield()
        {
            AttackValue = 1;
            DefenseValue = 4;
        }
    }
    public class Armor : IItem, IDefensiveItemElement
    {
        public int DefenseValue { get; }
        public Armor()
        {
            DefenseValue = 5;
        }
    }
    public class Helmet : IItem, IDefensiveItemElement
    {
        public int DefenseValue { get; }
        public Helmet()
        {
            DefenseValue = 4;
        }
    }
    public class SpellBook : IItem, IOffensiveItemElement, IDefensiveItemElement, ISpecialItemElement
    {
        public int AttackValue { get; }
        public int DefenseValue { get; }
        public bool CanBeEquipped { get; }
        
        /// <summary>
        /// Recibe el personaje al que se desea equipar
        /// </summary>
        public SpellBook(ICharacter character)
        {
            AttackValue = 6;
            DefenseValue = 3;
            CanBeEquipped = character.Race == "Wizard";
        }
    }
}