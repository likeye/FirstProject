using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public interface ICharacterState
    {
        void ToState(Character character, ICharacterState targetState);
        void Update(Character character);
        void ArcaneRuneCharacterState();
    }
}
