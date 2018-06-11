using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Characters
{
    public class Ranger : Character
    {
        public int dexterity;
        public Ranger(int health, int attack, int mana, int dexterity) : base(health, attack, mana)
        {
            this.dexterity = dexterity;
        }
        public Ranger(CharacterInitializer characterInitializer, int dexterity) : base(characterInitializer)
        {
            this.dexterity = dexterity;
        }
        public override void PrintAttack()
        {
            Console.WriteLine("Ranger attack: " + this.attack + "\n");
        }
        public override void PrintHealth()
        {
            Console.WriteLine("Ranger health: " + this.health + "\n");
        }
        public override void PrintMana()
        {
            Console.WriteLine("Ranger mana: " + this.mana + "\n");
        }
        public override void TakeDamage(int attack)
        {
            base.TakeDamage(attack);
        }
        public override void Attack(Character character)
        {
            if (DoubleArrow())
            {
                Console.WriteLine("Double arrow activated!!!");
                Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.attack*2} damage");
                character.TakeDamage(this.attack*2);
            }
            else
                base.Attack(character);
        }
        private bool DoubleArrow()
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            if (number <= this.dexterity + 10)
                return true;
            else
                return false;
        }
    }
}
