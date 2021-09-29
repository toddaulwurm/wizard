using System;
using System.Collections.Generic;

namespace wizard
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard harry = new Wizard("Harry");
            Ninja todd = new Ninja("Todd");
            Samurai dave = new Samurai("Dave");
            todd.Steal(harry);
            dave.Attack(harry);
            harry.Heal(harry);
            harry.Attack(todd);
            todd.Attack(harry);
            todd.Attack(dave);
            dave.Meditate();
            todd.GetInfo();
            harry.GetInfo();
            dave.GetInfo();
        }
    }
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;
        
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
        
        public Human(string name, int str, int intel, int dex, int hp)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;
        }
        
        public virtual int Attack(Human target)
        {
            int dmg = Strength * 3;
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Intelligence: {Intelligence}");
            Console.WriteLine($"Dexterity: {Dexterity}");
            Console.WriteLine($"Health: {Health}");
        }
    }
    class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            Intelligence = 25;
            health = 50;
        }
        public override int Attack(Human target)
        {   
            int dmg = Intelligence*3;
            target.Health -= dmg;
            Health += dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            Console.WriteLine($"{Name} healed themselves for {dmg}! Their health is now {Health}!");
            return target.Health;
        }
        public int Heal(Human target)
        {
            int heal = Intelligence*10;
            target.Health += heal;
            Console.WriteLine($"{Name} healed {target.Name} for {heal} points!");
            return target.Health;
        }
    }




    class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 175;
        }
        public override int Attack(Human target)
        {   
            Random rand = new Random();
            if(rand.Next(10)==9)
            {
                int crit = 10;
                int dmg = Dexterity*3;
                Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");  
                Console.WriteLine($"{Name} crit for an additional 10 damage!");
                target.Health -= dmg+crit;
            }
            else
            {
                int crit =0;            
                int dmg = Dexterity*3;
                Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");  
                target.Health -= dmg+crit;
            }
            return target.Health;
        }
        public int Steal(Human target)
        {
            target.Health -= 5;
            Health += 5;
            Console.WriteLine($"{Name} stole 5 of {target.Name}'s health!");
            return target.Health;
        }
    }



    class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            health = 200;
        }
        public override int Attack(Human target)
        {   
            base.Attack(target);
            if(target.Health<50)
            {
                target.Health=0;
                Console.WriteLine($"Samurai {Name} made a finishing blow! {target.Name} is dead!");
            }
            return target.Health;
        }
        public void Meditate()
        {
            Health = 200;
            Console.WriteLine($"Samurai {Name} meditated and is now at full health!");
        }
    }
}
