using System;
using System.Collections.Generic;
using System.Linq;
using DomainOO.Ataques;
using DomainOO.Equipamentos;

namespace DomainOO.Classes
{
    public abstract class Enemy
    {
        private readonly List<IEquipment> _inventory = new List<IEquipment>();
        private float _health;

        public float Health
        {
            get => _health;
            private set => _health = value < 0 ? 0 : value;
        }

        public bool IsAlive => Health > 0;

        // public ICollection<IEquipment> Equipped => _equipped.ToArray();

        public float MagicResistance
        {
            get
            {
                var equipmentResistance = _inventory.Sum(x => x.MagicResistance);
                return BasicMagicResistance + equipmentResistance;
            }
        }

        protected virtual float BasicMagicResistance => 0f;

        protected Enemy(int health = 100)
        {
            _health = health;
        }
        
        public void Socar(Enemy enemy)
        {
            AplicarDano(new Soco(), enemy);
        }

        protected void AplicarDano(IAtaque ataque, Enemy enemy)
        {
            enemy.Health -= ataque.CalcularDano(enemy);
        }
        
        public void Equipar(IEquipment equipment)
        {
            if (_inventory.Any(x => x.GetType() == equipment.GetType()))
                throw new InvalidOperationException("Não pode equipar dois equipamentos iguais");
            _inventory.Add(equipment);
        }
    }
}