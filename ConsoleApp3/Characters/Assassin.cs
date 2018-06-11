using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Characters
{
    public class Assassin : Rouge
    {
        private int boostAttack = 0;
        public Assassin(int health, int attack, int mana, int agility) : base(health, attack, mana, agility)
        {
        }
        public Assassin(CharacterInitializer characterInitializer, int agility) : base(characterInitializer, agility)
        {
        }
        public override void PrintHealth()
        {
            Console.WriteLine("Assassin health: " + this.health + "\n");
        }
        public override void PrintAttack()
        {
            Console.WriteLine("Assassin health: " + this.attack + "\n");
        }
        public override void PrintMana()
        {
            Console.WriteLine("Assassin health: " + this.mana + "\n");
        }
        public override void TakeDamage(int attack)
        {
            
            if (Parry())
            {
                boostAttack = this.attack + attack;
                Console.WriteLine("Assassin has parried your attack!!!");
            }
            else
            {
                base.TakeDamage(attack);
            }
        }

        public override void Attack(Character character)
        {

            if (Assasinerino())
            {
                Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {character.GetHealth()} damage");
                character.TakeDamage(character.GetHealth());
            }
            else if(boostAttack != 0)
            {
                Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {boostAttack} damage");
                character.TakeDamage(boostAttack);
                boostAttack = 0;
            }
            else
                base.Attack(character);
        }

        private bool Parry()
        {
            Random random = new Random();
            if (random.Next(1, 300) <= this.agility)
                return true;
            else
                return false;
        }

        private bool Assasinerino()
        {
            Random random = new Random();
            if (random.Next(1, 100) == this.agility)
                return true;
            else
                return false;
        }
        private void Stealth()
        {
            // znika na jedna ture w nast ataku zadaje *2 obrazen 
        }
    }
}
