using Library;
using Library.Elementos;
using Library.Personajes.Heroes;

namespace LibraryTests;

public class Tests
{
    private Hero _character1;
    private Hero _character2;
    /// <summary>
    /// Inicializa dos personajes: un Enano y un Mago
    /// </summary>
    [SetUp]
    public void Setup()
    { 
        _character1 = new Dwarve("Juan");
        _character2 = new Wizard("MiniMago");
    }
    /// <summary>
    /// Este test verifica que un personaje que no puede equipar un SpellBook
    /// efectivamente no lo equipe. Esto asegura que la logica de restriccion de items funciona.
    /// </summary>
    [Test]
    public void FalseEquipTest()
    { 
        Item.SpellBook spellbook = new Item.SpellBook(_character1);
        Assert.IsFalse(_character1.Actions.AddItem(spellbook),"Deberia ser false");
    }
    /// <summary>
    /// Este test verifica que un personaje que si puede equipar un SpellBook 
    /// lo equipe correctamente. Esto comprueba que el SpellBook efectivamente puede ser equipado en caso de que se cumplan las condiciones.
    /// </summary>
    [Test]
    public void TrueEquipTest()
    {
        Item.SpellBook spellBook = new Item.SpellBook(_character2);
        Assert.IsTrue(_character2.Actions.AddItem(spellBook),"Deberia ser true");
    }
    /// <summary>
    /// Este test comprueba que al equipar un ítem ofensivo
    /// la estadística de ataque del personaje cambia. Esto valida que los ítems afectan las estadísticas.
    /// </summary>
    [Test]
    public void ChangeStats()
    {
        int beforeEquip = _character1.Attack;
        Item.Axe axe = new Item.Axe();
        _character1.Actions.AddItem(axe);
        int afterEquip = _character1.Attack;
        Assert.That(afterEquip, Is.Not.EqualTo(beforeEquip), "El ataque no cambio despues de equipar el hacha");
    }
    /// <summary>
    /// Este test verifica que un personaje pierde vida al ser atacado.
    /// Es fundamental para confirmar que el sistema de combate funciona y aplica daño correctamente.
    /// </summary>
    [Test]
    public void TakeDamage()
    {
        int maxHealth = _character2.MaxHealth;
        _character1.Actions.Attack(_character2);
        int currentHealth = _character2.CurrentHealth;
        Assert.That(currentHealth, Is.Not.EqualTo(maxHealth), "La vida actual no se redujo despues de ser atacado");
    }
    /// <summary>
    /// Este test comprueba que un personaje puede recuperar vida al usar una habilidad de curacion.
    /// Es esencial para validar que las mecanicas de curacion funcionan correctamente.
    /// </summary>
    [Test]
    public void AutoHeal()
    {
        _character1.CurrentHealth = 1;
        _character1.Actions.Heal();
        Assert.That(_character1.CurrentHealth, Is.Not.EqualTo(1), "La vida actual no aumento despues de curarse");
    }
    /// <summary>
    /// Este test comprueba si la vida de el personaje al ser atacado disminuye a menos de cero
    /// </summary>
    [Test]
    public void LifeIsntLessThanZero()
    {
        _character2.CurrentHealth = 1;
        _character1.Actions.Attack(_character2);
        Assert.That(_character2.CurrentHealth, Is.EqualTo(0));
    }
}