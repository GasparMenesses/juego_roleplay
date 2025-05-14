namespace Library;

public class Actions
{
    public static void Attack(Character attacker, Character attacked)
    {
        if (attacked.Defense > attacker.Attack)
            attacked.CurrentHealth -= 1;
        else
            attacked.CurrentHealth -= (attacker.Attack - attacked.Defense);
    }
    public static void Heal(Character healed)
    {
        Random random = new Random();
        int healing = random.Next(20, 51);
        healed.CurrentHealth += healing;
        if (healed.CurrentHealth > healed.MaxHealth)
            healed.CurrentHealth = healed.MaxHealth;
    }
}