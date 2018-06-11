using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Characters
{
    public class Gambler : Rouge
    {
        private int luck;
        public Gambler(int health, int attack, int mana, int agility, int luck) : base(health, attack, mana, agility)
        {
            this.luck = luck;
        }
        public Gambler(CharacterInitializer characterInitializer, int agility, int luck) : base(characterInitializer, agility)
        {
            this.luck = luck;
        }
        public override void PrintHealth()
        {
            Console.WriteLine("Gambler health: " + this.health + "\n");
        }
        public override void PrintAttack()
        {
            Console.WriteLine("Gambler attack: " + this.attack + "\n");
        }
        public override void PrintMana()
        {
            Console.WriteLine("Gambler mana: " + this.mana + "\n");
        }
        public override void TakeDamage(int attack)
        {
            int numberOfDiece = Roll_a_Diece();
            Console.WriteLine($"Character: {this.GetType()}, has choosen number: {numberOfDiece} ");
            this.health -= attack*numberOfDiece;
            Console.WriteLine($"Character: {this.GetType()}, got hurt for {attack*numberOfDiece} damage. Remaining health: {this.health} \n");
        }
        public override void Attack(Character character)
        {
            Pick_a_Card();
            int poker = Poker();
            Console.WriteLine($"Character: {this.GetType()}, has choosen poker: {poker}");
            int pairOfAces = PairOfAces();
            Console.WriteLine($"Character: {this.GetType()}, has choosen aces number: { pairOfAces}");

            if (poker > 10)
            {
                Console.WriteLine("Poker higher than 10!");
                Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.attack + this.agility} damage");
                character.TakeDamage(this.attack + this.agility);
            }

            if (IfAces())
            {
                Console.WriteLine("Aces have been picked!!!");
                Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.attack * pairOfAces} damage");
                character.TakeDamage(this.attack * pairOfAces);
                return;
            }
            else
            {
                Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.attack} damage");
                character.TakeDamage(this.attack);
            }
        }

        private void Pick_a_Card() // wybierz karte
        {
            Random random = new Random();
            int card = random.Next(1, 5);
            switch (card)
            {
                case 1: //serce
                    this.health += this.agility;
                    Console.WriteLine("Picked Hearths ");
                    break;
                case 2: //dzwonek
                    this.attack += this.agility / 10;
                    Console.WriteLine("Picked Diamonds ");
                    break;
                case 3: //wino
                    Console.WriteLine("Picked Spades ");
                    this.luck += this.agility / 50;
                    break;
                case 4: //żołądź
                    Console.WriteLine("Picked Clubs ");
                    this.health -= this.agility / 7;
                    break;
            }
        }
        private int Poker() // poker
        {
            Random random = new Random();
            int pokerStrenght = random.Next(1+this.luck, 15);
            return pokerStrenght;
        }
        private bool IfAces() // wylosował asy lub nie
        {
            Random random = new Random();
            if (random.Next(0,2) < 1)
                return false;
            else
                return true;
        } 
        private int PairOfAces() // para asów
        {
            Random random = new Random();
            int pairOfAces = random.Next(1, 15-this.luck);
            if (pairOfAces < 3)
                return 0;
            else if (pairOfAces < 7 && pairOfAces >= 3)
                return 1;
            else if (pairOfAces < 13-this.luck && pairOfAces >= 7)
                return 2;
            else
                return 3;
        }
        private int Roll_a_Diece() //rzut magiczną kostką
        {
            Random random = new Random();
            int dieceNumber = random.Next(1, 7);
            switch (dieceNumber)
            {
                case 1:
                    return 0;
                case 2:
                case 4:
                    return 1;
                case 3:
                case 5:
                    return (1 + 1/2);
                case 6:
                    return 2;
                default:
                    return 1;
            }
            
        }
        private void SmokeAndMirrors() // zmiana wizerunkuuu na 2 tury 
        {

        }
    }
}
