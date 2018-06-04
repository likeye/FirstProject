using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Characters
{
    public class Mage : Character
    {
        public int magicPower;
        
        public Mage(int health, int attack, int mana, int magicPower) : base(health, attack, mana)
        {
            this.magicPower = magicPower;
        }
        public Mage(CharacterInitializer characterInitializer, int magicPower) : base(characterInitializer)
        {
            this.magicPower = magicPower;
        }
        public override void PrintHealth()
        {
            base.PrintHealth();
        }
        public override void PrintAttack()
        {
            base.PrintAttack();
        }
        public override void PrintMana()
        {
            base.PrintMana();
        }
        public override void TakeDamage(int attack)
        {
            base.TakeDamage(attack);
        }
        public override void Attack(Character character)
        {
            base.Attack(character);
        }
        private bool ArcaneRune()
        {
            Random random = new Random();
            int rune = random.Next(0, 2);
            if (rune == 1)
                return true;
            else
                return false;
        }
    }
}
