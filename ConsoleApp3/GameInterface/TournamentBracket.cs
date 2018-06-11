using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.GameInterface
{
    public class TournamentBracket
    {
        public void branch(int seed, int level, int limit)
        {
            var levelSum = (int)Math.Pow(2, level) + 1;

            if (limit == level + 1)
            {
                Console.WriteLine("Seed {0} vs. Seed {1}", seed, levelSum - seed);
                return;
            }
            else if (seed % 2 == 1)
            {
                branch(seed, level + 1, limit);
                branch(levelSum - seed, level + 1, limit);
            }
            else
            {
                branch(levelSum - seed, level + 1, limit);
                branch(seed, level + 1, limit);
            }
        }
    }
}
