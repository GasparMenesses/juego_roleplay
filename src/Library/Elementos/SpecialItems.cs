namespace Library.Elementos;

public class SpecialItems
{
    public static bool SpellBook(Character name)
    {
        if (name.Race != "Wizard") 
        {
            return false;
        }
        name.Attack += 10;
        return true;
    }
}