using DomainOO.Classes;

namespace DomainOO.Ataques
{
    public class Viscerar : IAtaque
    {
        public float CalcularDano(Enemy enemy)
        {
            return 35f;
        }
    }
}