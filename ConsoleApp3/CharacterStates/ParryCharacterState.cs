﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.CharacterStates
{
    public class ParryCharacterState : CharacterStateBase
    {
        public override void ToState(Character character, ICharacterState targetState)
        {
            base.ToState(character, targetState);
        }

        public override void Update(Character character)
        {
            Console.WriteLine("Assassin has parrried your attack!");
        }
    }
}
