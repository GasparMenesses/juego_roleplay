namespace Library.Elementos;

public class SpecialItems
{
     /*
     Cumple con SRP ya que esta clase conoce todos los items que pueden llevar equipados los personajes con restricciones,
     Como esta clase es la que conoce todos los items con restriccion, es esta misma clase la que dira si puede ser equipado el item
     o no al personaje deseado devolviendo true en caso de que si se pueda equipar y devolviendo false en caso contrario
     */
     /*
     Cada metodo recibe un objeto Character y se encarga de verificar si se cumplen las restricciones, en caso afirmativo
     modificara los atributos del objeto, en caso contrario no modificara nada
     */
    public static bool SpellBook(Character name)
    {
        if (name.Race != "Wizard") //Evalua la restriccion de el SpellBook, que es en este caso que solo puede ser equipado a un mago
        {
            return false;//No se puede equipar al personaje
        }
        name.Ataque += 10;
        return true;//Se puede equipar al personaje
    }
}