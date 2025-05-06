using Library;
using Library.Elementos;
using Library.Personajes;

namespace LibraryTests;

public class Tests
{
    private Character _character1;
    private Character _character2;
    [SetUp]
    public void Setup()
    { 
        // Inicializa dos personajes: un Enano y un Mago
        _character1 = new Dwarve("Juan");
        _character2 = new Wizard("MiniMago");
    }

    [Test]
    public void FalseEquipTest()
    { 
        // Este test verifica que un personaje que no puede equipar un SpellBook
        // efectivamente no lo equipe. Esto asegura que la logica de restriccion de items funciona.
        bool equipped = SpecialItems.SpellBook(_character1);
        Assert.IsFalse(equipped,"Deberia ser false");
    }
    [Test]
    public void TrueEquipTest()
    {
        // Este test verifica que un personaje que si puede equipar un SpellBook 
        // lo equipe correctamente. Esto comprueba que el SpellBook efectivamente puede ser equipado en caso de que se cumplan las condiciones.
        bool equipped = SpecialItems.SpellBook(_character2);
        Assert.IsTrue(equipped,"Deberia ser true");
    }

    [Test]
    public void ChangeStats()
    {
        // Este test comprueba que al equipar un ítem ofensivo
        // la estadística de ataque del personaje cambia. Esto valida que los ítems afectan las estadísticas.
        int beforeEquip = _character1.Ataque;
        OfensiveItems.Axe(_character1);
        int afterEquip = _character1.Ataque;
        Assert.That(afterEquip, Is.Not.EqualTo(beforeEquip), "El ataque no cambio despues de equipar el hacha");
    }

    [Test]
    public void TakeDamage()
    {
        // Este test verifica que un personaje pierde vida al ser atacado.
        // Es fundamental para confirmar que el sistema de combate funciona y aplica daño correctamente.
        int maxHealth = _character2.MaxHealth;
        Actions.Attack(_character1,_character2);
        int currentHealth = _character2.CurrentHealth;
        Assert.That(currentHealth, Is.Not.EqualTo(maxHealth), "La vida actual no se redujo despues de ser atacado");
    }

    [Test]
    public void AutoHeal()
    {
        // Este test comprueba que un personaje puede recuperar vida al usar una habilidad de curacion.
        // Es esencial para validar que las mecanicas de curacion funcionan correctamente.
        _character1.CurrentHealth = 1;
        Actions.Heal(_character1);
        Assert.That(_character1.CurrentHealth, Is.Not.EqualTo(1), "La vida actual no aumento despues de curarse");
    }
}