namespace Library
{
    // ============================================
    // Clase base abstracta para todos los personajes.
    // Cumple con SRP porque su única responsabilidad es definir y almacenar los atributos básicos que comparten todos los personajes
    // ============================================
    public abstract class Character
    {
        // Nombre de la raza (Mago, Elfo, Enano, etc.)
        public string Race { get; protected set; }

        // Nombre personalizado del personaje
        public string Name { get; protected set; }

        // Salud máxima que el personaje puede tener
        public int MaxHealth { get; protected set; }

        // Salud actual, puede disminuir o restaurarse durante el juego
        public int CurrentHealth { get; set; }

        // Poder de ataque del personaje
        public int Ataque { get; set; }

        // Poder de defensa del personaje
        public int Defensa { get; set; }

        // ============================================
        // Constructor protegido
        // Inicializa todos los valores básicos de un personaje:
        // raza, nombre, salud máxima y atributos de combate.
        // Protected para que solo subclases puedan invocarlo.
        // ============================================
        protected Character(string race, string name, int maxHealth, int ataque, int defensa)
        {
            Race = race;
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;  // Empieza con salud completa
            Ataque = ataque;
            Defensa = defensa;
        }
    }
}