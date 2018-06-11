using System;
using ConsoleApp3.GameInterface;
using ConsoleApp3.Characters;
using System.Collections.Generic;

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
            Character rouge = new Rouge(400, 70, 0, 65);
            Character mage = new Mage(300, 30, 3000, 10);
            Character ranger = new Ranger(400, 60, 300, 30);
            
            Paladin paladin = new Paladin(700, 70, 100, 30, 40);
            Berserker berserker = new Berserker(700, 70, 0, 45);
            Assassin assassin = new Assassin(600, 80, 0, 89);
            Gambler gambler = new Gambler(600, 50, 0, 40, 2);
            Archmage archmage = new Archmage(500, 30, 5000, 50);
            Bloodmage bloodmage = new Bloodmage(500, 30, 2000, 50);
            Sniper sniper = new Sniper(600, 80, 100, 60);
            BeastMaster beastMaster = new BeastMaster(700, 60, 500, 40); // wip

            
            Fighting fighting = new Fighting();
            List<Character> lista = new List<Character>
            {
                paladin,
                berserker,
                assassin,
                gambler,
                archmage,
                bloodmage,
                sniper,
                beastMaster
            };

            Start start = new Start();
            start.StartingInterface(lista);
            Console.ReadKey();
            

            Random random = new Random();
            int p1 = random.Next(0, 7);
            int p2 = random.Next(0, 7);


            var playerOneTurn = false;
            playerOneTurn = fighting.Starting(lista[p1],lista[p2]);

            //if (startingClass == 0)
            //{
            //    playerOneTurn = true;
            //    bloodmage.Attack(sniper);
            //}
            //else if (startingClass == 1)
            //{
            //    playerOneTurn = false;
            //    sniper.Attack(bloodmage);
            //}
            
            
            while (lista[p1].GetHealth() > 0 && lista[p2].GetHealth() > 0)
            {
                fighting.Fight(lista[p1], lista[p2], playerOneTurn = !playerOneTurn);
            }
          //  if (berserker.GetHealth() <= 0)
          //  {
          //      for (int i = berserker.ImmortalRage(); i > 0; i--)
          //      {
          //          Fight(berserker, assassin, playerOneTurn = !playerOneTurn);
          //      }
          //  }


            

            Console.ReadKey();
        }

        

        
    }
}
