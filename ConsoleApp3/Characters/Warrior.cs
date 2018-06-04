using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Warrior : Character
    {
        public int rage;
        public Warrior(int health, int attack, int mana, int rage) : base(health, attack, mana)
        {
            this.rage = rage;
        }

        public Warrior(CharacterInitializer characterInitializer, int rage) : base(characterInitializer)
        {
            this.rage = rage;
        }

        public override void PrintHealth()
        {
            Console.WriteLine("Warrior health: " + this.health + "\n");
        }

        public override void PrintAttack()
        {
            Console.WriteLine("Warrior attack" + this.attack + "\n");
        }

        public override void PrintMana()
        {
            Console.WriteLine("Warrior mana" + this.mana + "\n");
        }

        public override void Attack(Character character)
        {
            base.Attack(character);

            if (CriticalHit())
            {
                Console.WriteLine("Critical Hit!! \n");
                base.Attack(character);
            }
        }

        public override void TakeDamage(int attack)
        {
            base.TakeDamage(attack);
        }

        private bool CriticalHit()
        {
            Random random = new Random();

            if (random.Next(1, 100) <= this.rage)
            {
                return true;
            }

            return false;
        }
    }
}
