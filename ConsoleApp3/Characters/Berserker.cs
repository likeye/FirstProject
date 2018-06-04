using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Characters
{
    public class Berserker : Warrior
    {
        public Berserker(int health, int attack, int mana, int rage) : base(health, attack, mana, rage)
        {

        }

        public Berserker(CharacterInitializer characterInitializer, int rage) : base(characterInitializer, rage)
        {

        }

        public override void PrintAttack()
        {
            Console.WriteLine("Berserker attack: " + this.attack + "\n");
        }

        public override void PrintHealth()
        {
            Console.WriteLine("Berserker health: " + this.health + "\n");
        }

        public override void PrintMana()
        {
            Console.WriteLine("Berserker mana: " + this.mana + "\n");
        }

        public override void TakeDamage(int attack)
        {
            base.TakeDamage(attack);
            BloodFurry();
        }

        public override void Attack(Character character)
        {
            if (WildFrenzy())
            {
                Console.WriteLine("Berserker is using Wild Frenzy!!! \n");
                Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.attack * 3} damage \n");
                character.TakeDamage(this.attack * 3);
            }
            else
                base.Attack(character);

            
        }
        private bool WildFrenzy() //dzikafuriaaaa
        {
            Random random = new Random();
            if (random.Next(1,400) <= (this.attack / 3) + this.rage)
                return true;
            else
                return false;
        }
        public int ImmortalRage() //ultimate
        {
            int counter = this.attack / 50;
            return counter;
        }
        private void BloodFurry() //pasywnie zwiększa atak im mniej życia 
        {
            this.attack = this.attack + (this.attack / 30);
        }
    }
}
