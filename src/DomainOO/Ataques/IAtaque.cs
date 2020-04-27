using System;
using DomainOO.Classes;

namespace DomainOO.Ataques
{
    public interface IAtaque
    {
        float CalcularDano(Enemy enemy);
    }
}