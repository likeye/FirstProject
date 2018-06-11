using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Characters
{
    public class Bloodmage : Mage
    {
        int magicOfBlood = 0;
        public Bloodmage(int health, int attack, int mana, int magicPower) : base(health, attack, mana, magicPower)
        {
            this.health = this.health + this.mana;
            this.mana = 0;
        }
        public Bloodmage(CharacterInitializer characterInitializer, int magicPower): base( characterInitializer, magicPower)
        {
            this.health = this.health + this.mana;
            this.mana = 0;
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
            if (BloodRain())
            {
                magicOfBlood = this.magicPower * VampiricTouch() * 2;
                Console.WriteLine("Bloodmage use Bloodrain!!!");
                Console.ReadKey();
                Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.magicPower + magicOfBlood} damage");
                character.TakeDamage(this.magicPower + magicOfBlood);
                Console.WriteLine("Bloodmage health decreased for: " + (this.attack + this.magicPower) * 5);
                this.health -= (this.attack + this.magicPower) * 5;
                magicOfBlood = 0;
            }
            else if (VampiricAttack())
            {
                this.health += (this.magicPower * VampiricTouch())/2;
                magicOfBlood = (this.magicPower * VampiricTouch());
                this.magicPower += magicOfBlood;
                Console.WriteLine("Bloodmage healed for: "+ (this.magicPower * VampiricTouch())/2);
                base.Attack(character);
                this.health -= (this.attack + this.magicPower)*2;
                Console.WriteLine("Bloodmage health decreased for: "+ (this.attack + this.magicPower) * 2);
                this.magicPower -= magicOfBlood;
                magicOfBlood = 0;
            }
            else
            {
                magicOfBlood = (this.magicPower * VampiricTouch());
                this.magicPower += magicOfBlood;
                base.Attack(character);
                this.health -= (this.attack + this.magicPower)*2;
                Console.WriteLine("Bloodmage health decreased for: " + (this.attack + this.magicPower) * 2);
                this.magicPower -= magicOfBlood;
                magicOfBlood = 0;
            }
        }
        private void BloodControl()
        {
            // nie moze atakowac przez 2 tury
        }
        private bool VampiricAttack()
        {
            Random random = new Random();
            int number = random.Next(0, 2);
            if (number == 1)
                return true;
            else
                return false;
        }
        private int VampiricTouch()
        {
            Random random = new Random();
            int number = random.Next(0, 5);
            return number;
        }
        private bool BloodRain()
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            if (number <= this.magicPower)
                return true;
            else
                return false;
        }
    }
}
