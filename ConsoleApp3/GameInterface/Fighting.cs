using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.GameInterface
{
    public class Fighting
    {
        private bool playerOneTurn = false;

        public void Fight(Character playerOne, Character playerTwo, bool attackerTurn)
        {
            if (attackerTurn)
                playerOne.Attack(playerTwo);
            else
                playerTwo.Attack(playerOne);
        }

        private int CoinFlip()
        {
            Random random = new Random();
            return random.Next(0, 2);
        }
        public bool Starting (Character pOne, Character pTwo)
        {
            var startingClass = CoinFlip();
            if (startingClass == 0)
            {
                pOne.Attack(pTwo);
                return playerOneTurn = true;
            }
            else
            {
                pTwo.Attack(pOne);
                return playerOneTurn = false;
            }
        }
        public Character WinOrLose(Character playerOne, Character playerTwo)
        {
            if (playerOne.GetHealth() < playerTwo.GetHealth())
            {
                Console.WriteLine("Wygrał P2: "+ playerTwo.GetType());
                return playerTwo;
            }
            else
            {
                Console.WriteLine("Wygrał P1: " + playerOne.GetType());
                return playerOne;
            }
        }
    }
}
