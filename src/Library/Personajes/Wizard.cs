namespace Library;

public class Wizard : Character
{
    public Wizard(string name)
        : base(name, maxHealth: 100)    // ejemplo de vida para mago
    {
        // aca podemos inicializar el spellbook
    }
}