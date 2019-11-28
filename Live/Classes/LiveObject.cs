namespace Live.Classes
{

    public enum PoisonType { Not, Half, Full }

    public abstract class LiveObject
    {
        /// <summary>
        /// ИД обьекта
        /// </summary>
        public readonly int ID;

        /// <summary>
        /// Запас здоровья существа
        /// </summary>
        public float HitPoints;

        /// <summary>
        /// Возраст растенья
        /// </summary>
        public int Age;


        /// <summary>
        /// 
        /// </summary>
        public readonly PoisonType PoisonLevel;

        public bool Moved;

        /// <summary>
        /// Размножение
        /// </summary>
        public abstract void Reproduce();

        public abstract bool CheckHP();
    }
}