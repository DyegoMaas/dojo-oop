using DomainOO.Classes;

namespace DomainOO.Ataques
{
    public abstract class AtaqueMagico : IAtaque
    {
        public float CalcularDano(Enemy enemy)
        {
            float resistence = enemy.MagicResistance;
            return (DanoBase * (1 - resistence));
        }
        
        protected abstract float DanoBase { get; }
    }
}