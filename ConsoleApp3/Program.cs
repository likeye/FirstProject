using System;
using ConsoleApp3.Characters;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Character character = new Warrior(100, 15, 1, 67);
            //character.PrintHealth(); //virtual zeby uzyc metod z warriora
            //character.PrintAttack(); //nie wirtual zeby uzyc z character
            //character.PrintMana();

            //Warrior warrior = new Warrior(100, 10, 5, 15);
            //warrior.PrintHealth(); //nawet bez wirtual uzyje character
            //warrior.PrintAttack();
            //warrior.PrintMana();

            Character warrior = new Warrior(500, 70, 0, 65);
            Character rouge = new Rouge(300, 70, 0, 65);

            Paladin paladin = new Paladin(500, 70, 100, 30, 40);
            Berserker berserker = new Berserker(600, 70, 0, 45);
            Assassin assassin = new Assassin(600, 80, 0, 99);
            Gambler gambler = new Gambler(700, 50, 0, 40, 2);

            var startingClass = CoinFlip();
            var playerOneTurn = false;

            if (startingClass == 0)
            {
                playerOneTurn = true;
                gambler.Attack(assassin);
            }
            else if (startingClass == 1)
            {
                playerOneTurn = false;
                assassin.Attack(gambler);
            }
            
            
            while (gambler.GetHealth() > 0 && assassin.GetHealth() > 0)
            {
                Fight(gambler, assassin, playerOneTurn = !playerOneTurn);
            }
          //  if (berserker.GetHealth() <= 0)
          //  {
          //      for (int i = berserker.ImmortalRage(); i > 0; i--)
          //      {
          //          Fight(berserker, assassin, playerOneTurn = !playerOneTurn);
          //      }
          //  }


            Console.WriteLine("Gambler: "+gambler.GetHealth() + " " +"Assassin: "+ assassin.GetHealth());

            Console.ReadKey();
        }

        private static int CoinFlip()
        {
            Random random = new Random();
            return random.Next(0, 1);
        }

        private static void Fight(Character playerOne, Character playerTwo, bool attackerTurn)
        {
            if (attackerTurn)
                playerOne.Attack(playerTwo);
            else
                playerTwo.Attack(playerOne);
        }
    }
}
