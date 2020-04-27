using DomainOO.Ataques;

namespace DomainOO.Classes
{
    public class Mage : Enemy
    {
        public void Blizzard(Enemy enemy)
        {
            AplicarDano(new Blizzard(), enemy);
        }

        public void ThrowFlames(Enemy enemy)
        {
            AplicarDano(new ThrowFlames(), enemy);
        }
    }
}