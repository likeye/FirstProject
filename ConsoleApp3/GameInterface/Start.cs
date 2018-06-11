using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp3.Characters;
using System.Threading.Tasks;


namespace ConsoleApp3.GameInterface
{
    public class Start
    {
        public void StartingInterface(List<Character> characters)
        {

            Console.WriteLine("Witamy na Arenie Mistrzów!");
            Console.WriteLine("Arena Mistrzów to szybki symulator walk w systemie turniejowym z pomiędzy utworzonymi wcześniej bohaterami");
            Console.WriteLine("Nacisnij dowolny przycisk aby kontynuować");
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
            Console.WriteLine("! ARENA MISTRZÓW ! \n");
            Console.WriteLine("--> Losuj pary [1]");
            Console.WriteLine("--> Zobacz bohaterów (niedostępne)[2]");
            Console.WriteLine("--> Wyjście[3] \n");

            Console.WriteLine("Co chcesz zrobić? : ");
            var UserInput = Console.ReadKey();
            int number;
            if (char.IsDigit(UserInput.KeyChar))
            {
                number = int.Parse(UserInput.KeyChar.ToString());
                Console.WriteLine("\n Wybrałeś/łaś : {0}", number);
                switch (number)
                {
                    case 1:
                        Fighting fighting = new Fighting();
                       

                        Console.WriteLine("Losuje pary: ");
                        
                        Random random = new Random();

                        List<int> randomList = new List<int>();
                        int MyNumber = 0;

                        while (randomList.Count < 8)
                        {
                            MyNumber = random.Next(0, 8);
                            if (!randomList.Contains(MyNumber))
                            {
                                randomList.Add(MyNumber);
                            }
                        }

                        List<Character> listBestOfFour = new List<Character>();
                        System.Threading.Thread.Sleep(3000);
                        int p1 = 0;
                        int p2 = 1;
                        for (int i = 0; i < 4; i++)
                        {
                            Console.WriteLine("\n Walka: " + (i + 1) + "\n");
                            var playerOneTurn = false;
                            playerOneTurn = fighting.Starting(characters[randomList[p1]], characters[randomList[p2]]);
                            while (characters[randomList[p1]].GetHealth() > 0 && characters[randomList[p2]].GetHealth() > 0)
                            {
                                fighting.Fight(characters[randomList[p1]], characters[randomList[p2]], playerOneTurn = !playerOneTurn);
                            }
                            Console.WriteLine("P1: " + characters[randomList[p1]].GetType() + " " + characters[randomList[p1]].GetHealth() + " " + "P2: " + characters[randomList[p2]].GetType() + " " + characters[randomList[p2]].GetHealth());
                            listBestOfFour.Add(fighting.WinOrLose(characters[randomList[p1]], characters[randomList[p2]]));
                            p1 = p2 + 1;
                            p2 += 2;
                        }
                        Console.WriteLine("\n Bohaterowie, którzy wygrali:\n" + listBestOfFour[0] +",\n"+ listBestOfFour[1] + ",\n"+ listBestOfFour[2] + ",\n"+ listBestOfFour[3]);
                        Console.WriteLine("Nacisnij dowolny przycisk aby kontynuować");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("\n Rozpoczynam półfinały! \n");
                        Console.WriteLine("~ Przywracanie zdrowia bohaterów [///////---] ~ ");

                        p1 = 0;
                        p2 = 1;
                        for (int i = 0; i < listBestOfFour.Count; i++)
                        {
                            listBestOfFour[i].GetHealth();
                            listBestOfFour[i].Healing(1000);
                        }
                        Console.WriteLine("Nacisnij klawisz aby rozpocząć walkę!");
                        Console.ReadKey();
                        List<Character> champions = new List<Character>();

                        for (int i = 0; i < 2; i++)
                        {
                            Console.WriteLine("\n Walka: " + (i + 1) + "\n");
                            var playerOneTurn = false;
                            playerOneTurn = fighting.Starting(listBestOfFour[p1], listBestOfFour[p2]);
                            while (listBestOfFour[p1].GetHealth() > 0 && listBestOfFour[p2].GetHealth() > 0)
                            {
                                fighting.Fight(listBestOfFour[p1], listBestOfFour[p2], playerOneTurn = !playerOneTurn);
                            }
                            Console.WriteLine("P1: " + listBestOfFour[p1].GetType() + " " + listBestOfFour[p1].GetHealth() + " " + "P2: " + listBestOfFour[p2].GetType() + " " + listBestOfFour[p2].GetHealth());
                            champions.Add(fighting.WinOrLose(listBestOfFour[p1], listBestOfFour[p2]));
                            p1 = p2 + 1;
                            p2 += 2;
                        }

                        Console.WriteLine("\n Bohaterowie, którzy wygrali:\n" + champions[0] + ",\n" + champions[1]);
                        Console.WriteLine("Nacisnij dowolny przycisk aby kontynuować");
                        Console.ReadKey();
                        Console.Clear();
                        //Console.WriteLine("\n Druga walka:\n ");
                        //System.Threading.Thread.Sleep(3000);

                        //playerOneTurn = false;
                        //playerOneTurn = fighting.Starting(characters[randomList[3]], characters[randomList[4]]);
                        //while (characters[randomList[3]].GetHealth() > 0 && characters[randomList[4]].GetHealth() > 0)
                        //{
                        //    fighting.Fight(characters[randomList[3]], characters[randomList[4]], playerOneTurn = !playerOneTurn);
                        //}
                        //Console.WriteLine("P1: " + characters[randomList[3]].GetType() + " " + characters[randomList[3]].GetHealth() + " " + "P2: " + characters[randomList[4]].GetType() + " " + characters[randomList[4]].GetHealth());
                        //whoWon = fighting.WinOrLose(characters[randomList[3]], characters[randomList[4]]);
                        break;

                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
            else
            {
                number = -1;
                Console.WriteLine("\n To nie była licza :(");
            }

        }

    }
}
