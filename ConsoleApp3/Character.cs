using ConsoleApp3.CharacterStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public abstract class Character
    {
        protected int health;
        protected int attack;
        protected int mana;
        //?
        public static ArcaneRuneCharacterState arcane;
        public static BurnCharacterState burning;
        public static ParryCharacterState parry;
        public static StunCharacterState stun;
        public static SleepCharacterState sleep;
        public static ImmortalCharacterState immortality;

        //?
        private ICharacterState state;

        public ICharacterState State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }
        public void Update()
        {
            this.State.Update(this);
        }

        //?

        public Character(int health, int attack, int mana)
        {
            this.health = health;
            this.attack = attack;
            this.mana = mana;
        }
        public Character(CharacterInitializer characterInitializer)
        {
            this.health = characterInitializer.Health;
            this.attack = characterInitializer.Attack;
            this.mana = characterInitializer.Mana;
        }

        public int GetAttack()
        {
            return this.attack;
        }
        
        public int GetHealth()
        {
            return this.health;
        }

        public int GetMana()
        {
            return this.mana;
        }

        public virtual void PrintHealth()
        {
            Console.WriteLine(this.health);
        }

        public virtual void PrintAttack()
        {
            Console.WriteLine(this.attack);
        }

        public virtual void PrintMana()
        {
            Console.WriteLine(this.mana);
        }

        public virtual void Attack(Character character)
        {            
            Console.WriteLine($"Character: {this.GetType()}, attacked character: {character.GetType()} for {this.attack} damage");
            character.TakeDamage(this.attack);
        }

        public virtual void TakeDamage(int attack)
        {
            this.health -= attack;
            Console.WriteLine($"Character: {this.GetType()}, got hurt for {attack} damage. Remaining health: {this.health} \n");
        }
        public virtual void Healing(int heal)
        {
            this.health += heal;
        }
    }    
}
