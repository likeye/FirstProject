using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Characters
{
    public class Rouge : Character
    {
        public int agility;
        public Rouge(int health, int attack, int mana, int agility) : base(health, attack, mana)
        {
            this.agility = agility;
        }

        public Rouge(CharacterInitializer characterInitializer, int agility) : base(characterInitializer)
        {
            this.agility = agility;
        }

        public override void PrintHealth()
        {
            Console.WriteLine("Rouge health: " + this.health + "\n");
        }

        public override void PrintAttack()
        {
            Console.WriteLine("Rouge attack" + this.attack + "\n");
        }

        public override void PrintMana()
        {
            Console.WriteLine("Rouge mana" + this.mana + "\n");
        }

        public override void Attack(Character character)
        {
            base.Attack(character);
        }

        public override void TakeDamage(int attack)
        {
            if (Dodge())
            {
                Console.WriteLine("Dodge!! \n");
                return;
            }
            base.TakeDamage(attack);
        }

        private bool Dodge()
        {
            Random random = new Random();

            if (random.Next(1, 300) <= this.agility)
            {
                return true;
            }

            return false;
        }
    }
}
