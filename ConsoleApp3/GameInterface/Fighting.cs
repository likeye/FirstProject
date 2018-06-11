using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.GameInterface
{
    public class Fighting
    {
        private bool playerOneTurn;

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
        public bool Starting(Character pOne, Character pTwo)
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
                Console.WriteLine("Wygrał P2: " + playerTwo.GetType());
                return playerTwo;
            }
            else
            {
                Console.WriteLine("Wygrał P1: " + playerOne.GetType());
                return playerOne;
            }
        }
        public List<Character> BestOfFour(List<Character> characters, List<int> randomList)
        {
            List<Character> listBestOfFour = new List<Character>();
            System.Threading.Thread.Sleep(3000);
            int p1 = 0;
            int p2 = 1;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("\n Walka: " + (i + 1) + "\n");
                var playerOneTurn = false;
                playerOneTurn = Starting(characters[randomList[p1]], characters[randomList[p2]]);
                while (characters[randomList[p1]].GetHealth() > 0 && characters[randomList[p2]].GetHealth() > 0)
                {
                    Fight(characters[randomList[p1]], characters[randomList[p2]], playerOneTurn = !playerOneTurn);
                }
                Console.WriteLine("P1: " + characters[randomList[p1]].GetType() + " " + characters[randomList[p1]].GetHealth() + " " + "P2: " + characters[randomList[p2]].GetType() + " " + characters[randomList[p2]].GetHealth());
                listBestOfFour.Add(WinOrLose(characters[randomList[p1]], characters[randomList[p2]]));
                p1 = p2 + 1;
                p2 += 2;
            }
            return listBestOfFour;
        }
        public List<Character> BestOfTwo(List<Character> listBestOfFour)
        {
            int p1 = 0;
            int p2 = 1;
            Console.WriteLine("Nacisnij klawisz aby rozpocząć walkę!");
            Console.ReadKey();
            List<Character> champions = new List<Character>();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("\n Walka: " + (i + 1) + "\n");
                var playerOneTurn = false;
                playerOneTurn = Starting(listBestOfFour[p1], listBestOfFour[p2]);
                while (listBestOfFour[p1].GetHealth() > 0 && listBestOfFour[p2].GetHealth() > 0)
                {
                    Fight(listBestOfFour[p1], listBestOfFour[p2], playerOneTurn = !playerOneTurn);
                }
                Console.WriteLine("P1: " + listBestOfFour[p1].GetType() + " " + listBestOfFour[p1].GetHealth() + " " + "P2: " + listBestOfFour[p2].GetType() + " " + listBestOfFour[p2].GetHealth());
                champions.Add(WinOrLose(listBestOfFour[p1], listBestOfFour[p2]));
                p1 = p2 + 1;
                p2 += 2;
            }
            return champions;
        }
        public void Finals(List<Character> champions)
        {
            System.Threading.Thread.Sleep(3000);
            var playerOneTurn = false;
            playerOneTurn = Starting(champions[0], champions[1]);
            while (champions[0].GetHealth() > 0 && champions[1].GetHealth() > 0)
            {
                Fight(champions[0], champions[1], playerOneTurn = !playerOneTurn);
            }
            Console.WriteLine("P1: " + champions[0].GetType() + " " + champions[0].GetHealth() + " " + "P2: " + champions[1].GetType() + " " + champions[1].GetHealth());
            WinOrLose(champions[0], champions[1]);
        }
    }
}
