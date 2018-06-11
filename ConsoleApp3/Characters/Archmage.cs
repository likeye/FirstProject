using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Characters
{
    public class Archmage : Mage
    {
        private int attackBoost = 0;
        private int elementarCounter = 0;
        public Archmage(int health, int attack, int mana, int magicPower) : base(health, attack, mana, magicPower)
        {

        }
        public Archmage(CharacterInitializer characterInitializer, int magicPower) : base(characterInitializer, magicPower)
        {

        }
        public override void PrintHealth()
        {
            Console.WriteLine("Archmage health: " + this.health + "\n");
        }
        public override void PrintMana()
        {
            Console.WriteLine("Archmage mana: " + this.mana + "\n");
        }
        public override void PrintAttack()
        {
            Console.WriteLine("Archmage attack: " + this.attack + "\n");
        }
        public override void TakeDamage(int attack)
        {
            base.TakeDamage(attack);
        }
        public override void Attack(Character character)
        {
            int[] arrayNumber = { Fireball(), IceLance(), ElementalPower() };
            Random random = new Random();
            int chooseNumber = random.Next(0, 3);
            int skill = arrayNumber[chooseNumber];
            if (ArcaneRune())
            {
                Console.WriteLine("Arcane rune activated!!");
                attackBoost = (this.attack + this.mana / 100) + 10;
                if (skill <= 4)
                {
                    Console.WriteLine("Archmage use fireball!!");
                    Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {attackBoost + 20} damage");
                    character.TakeDamage(attackBoost + 20);
                    elementarCounter++;
                }
                else if (skill > 4 && skill <= 8)
                {
                    Console.WriteLine("Archmage use icelance!!");
                    Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {attackBoost + 20} damage");
                    character.TakeDamage(attackBoost + 20);
                    elementarCounter++;
                }
                else
                {
                    Console.WriteLine("Archmage use elementarpower!!");
                    elementarCounter++;

                    Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {attackBoost * elementarCounter} damage");
                    character.TakeDamage(attackBoost * elementarCounter);
                    elementarCounter = 0;
                }
            }
            else
            {
                if (skill <= 4)
                {
                    Console.WriteLine("Archmage use fireball!!");

                    Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.attack + this.magicPower + 20} damage");
                    character.TakeDamage(this.attack + this.magicPower + 40);
                    elementarCounter++;
                }
                else if (skill > 4 && skill <= 8)
                {
                    Console.WriteLine("Archmage use icelance!!");
                    Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.attack + this.magicPower + 20} damage");
                    character.TakeDamage(this.attack + this.magicPower + 20);
                    elementarCounter++;
                }
                else
                {
                    Console.WriteLine("Archmage use elementarpower!!");
                    elementarCounter++;
                    Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.magicPower * elementarCounter + 50} damage");
                    character.TakeDamage(this.magicPower * elementarCounter + 50);
                    elementarCounter = 0;
                }
            }
        }

        private int Fireball()
        {
            Random random = new Random();
            int number = random.Next(0, 5);
            return number;
        }
        private int IceLance()
        {
            Random random = new Random();
            int number = random.Next(5, 10);
            return number;
        }

        private int ElementalPower()
        {
            Random random = new Random();
            int number = random.Next(10, 12);
            return number;
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
