using ConsoleApp3.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.CharacterStates
{
    public class ArcaneRuneCharacterState : CharacterStateBase
    {
        public void ArcaneRune(Mage mage, bool Arcane)
        {
            if (Arcane == true)
            {
                int mana = mage.GetMana();
                mage.magicPower += (mana / 60);
            }
        }
    

        public override void ToState(Character character, ICharacterState targetState)
        {
            base.ToState(character, targetState);
        }

        public override void Update(Character character)
        {
            Console.WriteLine("Mage got ArcaneRune!!! \n");
        }
    }  
}
