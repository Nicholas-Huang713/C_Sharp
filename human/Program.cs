using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Human myHuman = new Human ("Nick");
            System.Console.WriteLine(myHuman.Health);
            Human myEnemy = new Human ("Teng", 5, 5, 5, 50);
            myHuman.Attack(myEnemy);
        }
    }

    class Human{
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;

        public int Health
        {
            get{ return health; }
        }

        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }

        public Human(string name, int str, int intel, int dext, int life){
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dext;
            health = life;
        }
        
        public int Attack(Human target)
        {
            int dmg = this.Strength*5;
            target.health -= dmg; 
            System.Console.WriteLine(target.health);
            return target.health;
        }   
    }

}
