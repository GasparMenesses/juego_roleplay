namespace Library.Elementos;

public class DefensiveItems
{
     /*
     Cumple con SRP ya que esta clase conoce todos los items que pueden llevar equipados los personajes sin ninguna restriccion
     Los items que conoce son aquellos que unicamente proporcionan defensa al personaje
     Teniendo esta informacion en caso de equipar el item se modificara un atributo del personaje, siendo este atributp la defensa
     */
     /*
     Cada metodo recibe un objeto Character y se encarga de modificar los atributos de ese objeto
     */
    public static void Shield(Character name)
    {
        name.Defensa += 5;//Modifica defensa
    }

    public static void Armor(Character name)
    {
        name.Defensa += 5;//Modifica defensa
    }
    public static void Helmet(Character name)
    {
        name.Defensa += 3;//Modifica defensa
    }
}