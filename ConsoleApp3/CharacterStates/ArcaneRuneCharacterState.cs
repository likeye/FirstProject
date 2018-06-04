using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.CharacterStates
{
    public class ArcaneRuneCharacterState : CharacterStateBase
    {
        public void ArcaneRune (Character character)
        {
            
        }
        public override void ToState(Character character, ICharacterState targetState)
        {
            Console.WriteLine("Mage got ArcaneRune!!! \n");
            base.ToState(character, targetState);
        }
        public override void Update(Character character)
        {
            throw new NotImplementedException();
        }
    }  
}
