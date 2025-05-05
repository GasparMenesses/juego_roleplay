namespace Library.Elementos;

public class OfensiveItems
{
     /*
     Cumple con SRP ya que esta clase conoce todos los items que pueden llevar equipados los personajes sin ninguna restriccion
     Los items que conoce son aquellos que unicamente proporcionan ataque al personaje
     Teniendo esta informacion en caso de equipar el item se modificara un atributo del personaje, siendo este atributp el ataque
     */
     /*
     Cada metodo recibe un objeto Character y se encarga de modificar los atributos de ese objeto
     */
    public static void Sword(Character name)
    {
        name.Ataque += 5;//Modifica ataque
    }
    public static void MagicStaff(Character name)
    {
        name.Ataque += 5;//Modifica ataque
    }
    public static void Axe(Character name)
    {
        name.Ataque += 5;//Modifica ataque
    }
}