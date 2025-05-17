namespace Library.Elementos;

public class Items
{
    public static void Sword(Character name)
    {
        name.Attack += 5;
    }
    public static void MagicStaff(Character name)
    {
        name.Attack += 5;
    }
    public static void Axe(Character name)
    {
        name.Attack += 5;
    }
    public static void Shield(Character name)
    {
        name.Defense += 5;
    }

    public static void Armor(Character name)
    {
        name.Defense += 5;
    }
    public static void Helmet(Character name)
    {
        name.Defense += 3;
    }
}