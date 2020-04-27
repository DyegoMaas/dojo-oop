using DomainOO.Ataques;

namespace DomainOO.Classes
{
    public class Assassin : Enemy
    {
        public Assassin() : base(health: 50)
        {
        }

        public void Viscerar(Enemy enemy)
        {
            AplicarDano(new Viscerar(), enemy);
        }
    }
}