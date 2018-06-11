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
            Console.WriteLine("Arena Mistrzów to szybki symulator walk w systemie turniejowym pomiędzy utworzonymi wcześniej bohaterami");
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
                Console.WriteLine("\n Wybrałeś/łaś: {0}", number);
                switch (number)
                {
                    case 1:
                        Fighting fighting = new Fighting();
                        Console.WriteLine("Losuje pary: ");
                        List<int> randomList = RandomListOfEight(); //losowanie drabinki
                        List<Character> listBestOfFour = fighting.BestOfFour(characters, randomList); //bestOfFour
                        Console.WriteLine("\n Bohaterowie, którzy wygrali:\n" + listBestOfFour[0] + ",\n" + listBestOfFour[1] + ",\n" + listBestOfFour[2] + ",\n" + listBestOfFour[3]);
                        Console.WriteLine("Nacisnij dowolny przycisk aby kontynuować");
                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine("\n Rozpoczynam półfinały! \n");
                        Console.WriteLine("~ Przywracanie zdrowia bohaterów [///////---] ~ ");
                        Healing(1000, listBestOfFour);  //heal championów za 1k

                        List<Character> champions = fighting.BestOfTwo(listBestOfFour); //bestoftwo
                        Console.WriteLine("\n Bohaterowie, którzy wygrali:\n" + champions[0] + ",\n" + champions[1]);
                        Console.WriteLine("Nacisnij dowolny przycisk aby kontynuować");
                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine("\n Rozpoczynam finały! \n");
                        Console.WriteLine("~ Przywracanie zdrowia bohaterów [///////---] ~ ");
                        Healing(2000, champions);   //heal championów za 2k

                        Console.WriteLine("\n FINAŁ! :\n ");
                        fighting.Finals(champions); // finał                      
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Przykro mi ale nic tu jeszcze nie ma :(( ");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Do zobaczenia!! c:");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                number = -1;
                Console.WriteLine("\n To nie była cyfra z wymienionych :(");
            }

        }
        private void Healing(int heal, List<Character> characters)
        {
            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].GetHealth();
                characters[i].Healing(heal);
            }
        }
        private List<int> RandomListOfEight()
        {
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
            return randomList;
        }

    }
}
