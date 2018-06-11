using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Characters
{
    public class Sniper : Ranger
    {
        private int dexterityBoost =0;
        public Sniper(int health, int attack, int mana, int dexterity) : base(health, attack, mana, dexterity)
        {

        }
        public Sniper(CharacterInitializer characterInitializer, int dexterity) : base(characterInitializer, dexterity)
        {

        }
        public override void PrintHealth()
        {
            Console.WriteLine("Sniper health: " + this.health + "\n");
        }
        public override void PrintAttack()
        {
            Console.WriteLine("Sniper attack: " + this.attack + "\n");
        }
        public override void PrintMana()
        {
            Console.WriteLine("Sniper mana: " + this.mana + "\n");
        }
        public override void TakeDamage(int attack)
        {
            base.TakeDamage(attack);
        }
        public override void Attack(Character character)
        {
            if (EyeOfHunter())
            {
                Console.WriteLine("Eye of hunter activated!");
                dexterityBoost = (this.dexterity / 2) + 10;
                this.dexterity += dexterityBoost;
                if (Headshot())
                {
                    Console.WriteLine("Sniper use Headshoot!!!");
                    Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.attack * 5} damage");
                    character.TakeDamage(this.attack * 5);
                }
                else if (PiercingShoot())
                {
                    Console.WriteLine("Sniper use piercing shoot!!!");
                    Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.attack * 3} damage");
                    character.TakeDamage(this.attack * 3);
                }
                else
                {
                    base.Attack(character);
                }
                this.dexterity -= dexterityBoost;
            }
            else
            {
                if (Headshot())
                {
                    Console.WriteLine("Sniper use Headshoot!!!");
                    Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.attack * 5} damage");
                    character.TakeDamage(this.attack * 5);
                }
                else if (PiercingShoot())
                {
                    Console.WriteLine("Sniper use piercing shoot!!!");
                    Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.attack * 3} damage");
                    character.TakeDamage(this.attack * 3);
                }
                else
                    base.Attack(character);
            }
        }
        private bool Headshot() // moze stunowac
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            if (number <= this.dexterity - 10)
                return true;
            else
                return false;
        }
        private bool PiercingShoot() // przebija pancerz (w przypadku wojowników)
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            if (number <= this.dexterity)
                return true;
            else
                return false;
        }
        private bool EyeOfHunter()
        {
            Random random = new Random();
            int number = random.Next(0, 2);
            if (number == 1)
                return true;
            else
                return false;
        } 

    }
}
