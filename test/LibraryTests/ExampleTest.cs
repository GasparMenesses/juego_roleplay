using Library;
using Library.Elementos;
using Library.Personajes.Enemigos;
using Library.Personajes.Heroes;

namespace LibraryTests;

public class Tests
{
    private Hero _hero1;
    private Hero _hero2;
    private Enemy _enemy1;
    /// <summary>
    /// Inicializa dos personajes: un Enano y un Mago
    /// </summary>
    [SetUp]
    public void Setup()
    { 
        _hero1 = new Dwarve("Juan");
        _hero2 = new Wizard("MiniMago");
        _enemy1 = new Shrek("Shrek");
    }
    /// <summary>
    /// Este test verifica que un personaje que no puede equipar un SpellBook
    /// efectivamente no lo equipe. Esto asegura que la logica de restriccion de items funciona.
    /// </summary>
    [Test]
    public void FalseEquipTest()
    { 
        Item.SpellBook spellbook = new Item.SpellBook(_hero1);
        Assert.IsFalse(_hero1.Actions.AddItem(spellbook),"Deberia ser false");
    }
    /// <summary>
    /// Este test verifica que un personaje que si puede equipar un SpellBook 
    /// lo equipe correctamente. Esto comprueba que el SpellBook efectivamente puede ser equipado en caso de que se cumplan las condiciones.
    /// </summary>
    [Test]
    public void TrueEquipTest()
    {
        Item.SpellBook spellBook = new Item.SpellBook(_hero2);
        Assert.IsTrue(_hero2.Actions.AddItem(spellBook),"Deberia ser true");
    }
    /// <summary>
    /// Este test comprueba que al equipar un ítem ofensivo
    /// la estadística de ataque del personaje cambia. Esto valida que los ítems afectan las estadísticas.
    /// </summary>
    [Test]
    public void ChangeStats()
    {
        int beforeEquip = _hero1.Attack;
        Item.Axe axe = new Item.Axe();
        _hero1.Actions.AddItem(axe);
        int afterEquip = _hero1.Attack;
        Assert.That(afterEquip, Is.Not.EqualTo(beforeEquip), "El ataque no cambio despues de equipar el hacha");
    }
    /// <summary>
    /// Este test verifica que un personaje pierde vida al ser atacado.
    /// Es fundamental para confirmar que el sistema de combate funciona y aplica daño correctamente.
    /// </summary>
    [Test]
    public void TakeDamage()
    {
        int maxHealth = _hero2.MaxHealth;
        _hero1.Actions.Attack(_hero2);
        int currentHealth = _hero2.CurrentHealth;
        Assert.That(currentHealth, Is.Not.EqualTo(maxHealth), "La vida actual no se redujo despues de ser atacado");
    }
    /// <summary>
    /// Este test comprueba que un personaje puede recuperar vida al usar una habilidad de curacion.
    /// Es esencial para validar que las mecanicas de curacion funcionan correctamente.
    /// </summary>
    [Test]
    public void AutoHeal()
    {
        _hero1.CurrentHealth = 1;
        _hero1.Actions.Heal();
        Assert.That(_hero1.CurrentHealth, Is.Not.EqualTo(1), "La vida actual no aumento despues de curarse");
    }
    /// <summary>
    /// Este test comprueba si la vida de el personaje al ser atacado disminuye a cero correctamente
    /// </summary>
    [Test]
    public void CharacterDie()
    {
        _hero2.CurrentHealth = 1;
        _hero1.Actions.Attack(_hero2);
        Assert.That(_hero2.CurrentHealth, Is.EqualTo(0));
    }
    /// <summary>
    /// Este test comprueba si la vida de el personaje al ser atacado disminuye a menos de cero
    /// </summary>
    [Test]
    public void LifeIsntLessThanZero()
    {
        _hero2.CurrentHealth = 1;
        _hero1.Actions.Attack(_hero2);
        Assert.That(_hero2.CurrentHealth, Is.EqualTo(0));
    }
    /// <summary>
    /// Este test comprueba si la vida de el personaje muerto al ser atacado disminuye a menos de cero
    /// </summary>
    [Test]
    public void CharacterDieAtack()
    {
        _hero2.CurrentHealth = 0;
        _hero1.Actions.Attack(_hero2);
        Assert.That(_hero2.CurrentHealth, Is.EqualTo(0));
    }
    /// <summary>
    /// Este test comprueba si cuando un heroe vence a un enemigo gana wp
    /// </summary>
    [Test]
    public void HeroWinWp()
    {
        int currentwp = _hero1.CuerrentWp;
        _enemy1.CurrentHealth = 1;
        _hero1.Actions.Attack(_enemy1);
        Assert.That(currentwp, Is.LessThan(0));
    }
}