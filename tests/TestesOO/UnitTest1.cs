using System;
using DomainOO.Classes;
using DomainOO.Equipamentos;
using FluentAssertions;
using NUnit.Framework;

namespace TestesOO
{
    public class Tests
    {
        [Test]
        public void Deve_causar_5_de_dano_no_assassino_com_soco()
        {
            var tanker = new Tanker();
            var assassin = new Assassin();

            tanker.Socar(assassin);
            
            assassin.Health.Should().Be(45);
        }
        
        [Test]
        public void Deve_viscerar_o_inimigo()
        {
            var tanker = new Tanker();
            var assassin = new Assassin();

            assassin.Viscerar(tanker);
            
            tanker.Health.Should().Be(115);
        }
        
        [Test]
        public void Deve_congelar_inimigo_com_ataques_magicos()
        {
            var mage = new Mage();
            var assassin = new Assassin();

            mage.Blizzard(assassin);
            assassin.Health.Should().Be(30);
            
            mage.ThrowFlames(assassin);
            assassin.Health.Should().Be(5);
        }

        [Test]
        public void Deve_considerar_resistencia_magica()
        {
            var mage = new Mage();
            var assassin = new Assassin(); // 50
            assassin.Equipar(new CapaExcusa()); // +18

            mage.Blizzard(assassin);
            assassin.Health.Should().Be(32);
        }
        
        [Test]
        public void Nao_deve_permitir_equipar_dois_equipamentos_iguais()
        {
            var assassin = new Assassin(); // 50
            assassin.Equipar(new CapaExcusa()); // +18

            Action equiparOutraCapa = () => assassin.Equipar(new CapaExcusa());
            equiparOutraCapa.Should().Throw<InvalidOperationException>().WithMessage("Não pode equipar dois equipamentos iguais");
        }

        [Test]
        public void Elfos_tem_resistencia_magica_de_15_porcento()
        {
            var elf = new Elf(); // +.15
            elf.Equipar(new CapaExcusa()); // + .1
            
            var mage = new Mage();
            mage.Blizzard(elf);

            elf.Health.Should().Be(85);
        }
        
        [Test]
        public void Inimigo_de_morrer_se_acabou_a_vida()
        {
            var elf = new Elf();
            var mage = new Mage();
            
            elf.IsAlive.Should().BeTrue();
            for (int i = 0; i < 21; i++)
                mage.Socar(elf);
            elf.Health.Should().Be(0);
            elf.IsAlive.Should().BeFalse();
        }
    }
}