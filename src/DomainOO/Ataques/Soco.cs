using DomainOO.Classes;

namespace DomainOO.Ataques
{
    public class Soco : IAtaque
    {
        public float CalcularDano(Enemy enemy)
        {
            return 5f;
        }
    }
}