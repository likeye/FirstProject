using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public abstract class CharacterStateBase
    {
        public virtual void ToState(Character character, ICharacterState targetState)
        {
            character.State = targetState;
        }
        public abstract void Update(Character character);
    }
}
