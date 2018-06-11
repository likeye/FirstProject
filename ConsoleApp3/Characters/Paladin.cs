using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Characters
{
    public class Paladin : Warrior
    {
        private int defence;
        public Paladin(int health, int attack, int mana, int rage, int defence) : base(health, attack, mana, rage)
        {
            this.defence = defence;
        }
        public Paladin(CharacterInitializer characterInitializer, int rage, int defence) : base(characterInitializer, rage)
        {
            this.defence = defence;
        }
        public override void PrintHealth()
        {
            Console.WriteLine("Paladin health: " + this.health +"\n");
        }
        public override void PrintAttack()
        {
            Console.WriteLine("Paladin attack: " + this.attack + "\n");
        }
        public override void PrintMana()
        {
            Console.WriteLine("Paladin mana: " + this.mana + "\n");
        }
        public override void TakeDamage(int attack)
        {
            base.TakeDamage(attack/(this.defence/20));
        }
        public override void Attack(Character character)
        {
            if (HolyLight())
            {
                Console.WriteLine("Palading is using Holy Light!");
                this.health  += (this.defence*2);
                this.PrintHealth();
            }

            if (HolyAspect())
            {
                Console.WriteLine("Palading is using Holy Aspect! \n");
                Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.attack + (this.defence *2)} damage \n");
                character.TakeDamage(this.attack + (this.defence * 2));
            }
            else
                base.Attack(character);
        }

        private bool HolyLight() // healing
        {
            Random random = new Random();
            if (random.Next(1, 300) >= this.defence + (this.health/2))
            {
                return true;
            }
            else
                return false;
        }

        private bool HolyAspect() //ultimate
        {
            Random random = new Random();
            if (random.Next(1, 500) <= this.defence + this.rage)
            {
                return true;
            }
            else
                return false;
        }
    }
}
