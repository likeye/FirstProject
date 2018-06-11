using System;
using ConsoleApp3.CharacterStates;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Characters
{
    public class Mage : Character
    {
        public int magicPower;
        
        private int attackBoost;
        
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
            Console.WriteLine("Mage health: " + this.health + "\n");
        }
        public override void PrintAttack()
        {
            Console.WriteLine("Mage attack: " + this.attack + "\n");
        }
        public override void PrintMana()
        {
            Console.WriteLine("Mage mana: " + this.mana + "\n");
        }
        public override void TakeDamage(int attack)
        {
            base.TakeDamage(attack);
        }
        public override void Attack(Character character)
        {
            if (ArcaneRune())
            {
                Console.WriteLine("Arcane rune activated!!");
                attackBoost = (this.attack + this.mana / 100) + 10;
                Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {attackBoost} damage");
                character.TakeDamage(attackBoost);
            }
            else
            {
                Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.attack + this.magicPower} damage");
                character.TakeDamage(this.attack + this.magicPower);
            }
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
