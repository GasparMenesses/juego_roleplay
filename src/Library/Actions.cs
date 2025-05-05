namespace Library;
/*
 RESUMEN DE ATTACK
Realiza una acción de ataque de un personaje a otro.
Si la defensa del atacado es mayor que el ataque del atacante, solo se le resta 1 punto de salud.
En caso contrario, se le resta la diferencia entre ataque y defensa.
 */
public class Actions
{
    public static void Attack(Character attacker, Character attacked)
    {
        if (attacked.Defensa > attacker.Ataque)
            attacked.CurrentHealth -= 1; //si el valor de  defensa del oponente es mayor al valor de ataque del personaje, se hace 1 de daño minimo
        else
            attacked.CurrentHealth -= (attacker.Ataque - attacked.Defensa); //sino la salud luego del ataque se calcula como ataque-defensa
    }
/*
 RESUMEN DE HEAL
 Realiza una acción de curación sobre un personaje.
 Se genera un valor aleatorio entre 20 y 50 para aumentar la salud actual.
 La salud no puede superar el valor máximo permitido.
 */
    public static void Heal(Character healed)
    {
        Random random = new Random();
        int healing = random.Next(20, 51); //se le asigna un valor aleatorio entre 20 y 51
        
        healed.CurrentHealth += healing; // se aumenta la salud actual del personaje
        
        if (healed.CurrentHealth > healed.MaxHealth)
            healed.CurrentHealth = healed.MaxHealth;  //si la nueva salud supera al valor máximo de salud, se le asigna la salud máxima
    }
}