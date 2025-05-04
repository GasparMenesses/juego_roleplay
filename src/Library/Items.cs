namespace Library;

public class Items
{
   public string WeaponName { get;  protected set; } //uso protected para que otras clases no modifiquen este valor 
   public int Damage { get; protected set; }
   public int Defense { get; protected set; }

   public Items(string weaponname, int damage, int defense)
   {
      WeaponName = weaponname;
      Damage = damage;
      Defense = defense;
   }
   
}