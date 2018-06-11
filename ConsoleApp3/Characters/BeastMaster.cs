using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Characters
{
    public class BeastMaster : Ranger
    {
        public BeastMaster(int health, int attack, int mana, int dexterity) : base(health, attack, mana, dexterity)
        {

        }
        public BeastMaster(CharacterInitializer characterInitializer, int dexterity) : base(characterInitializer, dexterity)
        {

        }
        public override void PrintHealth()
        {
            base.PrintHealth();
        }
        public override void PrintAttack()
        {
            base.PrintAttack();
        }
        public override void PrintMana()
        {
            base.PrintMana();
        }
        public override void TakeDamage(int attack)
        {
            base.TakeDamage(attack);
        }
        public override void Attack(Character character)
        {
            base.Attack(character);
        }
    }
}
