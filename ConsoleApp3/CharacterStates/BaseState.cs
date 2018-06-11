using System;
using ConsoleApp3.Characters;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.CharacterStates
{
    public class BaseState : CharacterStateBase
    {
        public override void ToState(Character character, ICharacterState targetState)
        {
            base.ToState(character, targetState);
        }
        public override void Update(Character character)
        {
            Console.WriteLine("State base returned");
        }
        public void StatAttack(Character character)
        {
            int attack = character.GetAttack();
        }
    }
}
