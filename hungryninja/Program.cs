using System;
using System.Collections.Generic;

namespace hungryninja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet buf = new Buffet();
            Ninja nick = new Ninja();

            nick.Eat(buf.Serve());
            System.Console.WriteLine(nick.isFull);

            nick.Eat(buf.Serve());
            System.Console.WriteLine(nick.isFull);

            nick.Eat(buf.Serve());
            System.Console.WriteLine(nick.isFull);

            foreach (var i in nick.FoodHistory){
                System.Console.WriteLine(i.Name);
            }

            // for (int i= 0 ; i < buf.Menu.Count; i++){
            //     System.Console.WriteLine(buf.Menu[i]);
            // }

            // nick.Eat(buf.Serve());
            // System.Console.WriteLine(nick.isFull);

            // System.Console.WriteLine(nick.calorieIntake);
        }
    }

    class Food
    {
        public string Name;
        public int Calories;
        public bool IsSpicy; 
        public bool IsSweet; 

        public Food(string name, int cal, bool spicy, bool sweet)
        {
            Name = name;
            Calories = cal;
            IsSpicy = spicy;
            IsSweet = sweet;
        }
    }

    class Buffet
    {
        public List<Food> Menu;
        
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Eggs", 1000, false, false),
                new Food("Bacon", 2000, false, false),
                new Food("Hot Wings", 2000, true, false),
                new Food("Waffles", 1000, false, true),
                new Food("Fries", 3000, false, false),
                new Food("Cake", 1000, false, true),
            };
        }
        
        public Food Serve()
        {
            Random rand = new Random();
            return  Menu[rand.Next(6)];
        }
    }

    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        public Ninja(){
            this.calorieIntake = 0;
            this.FoodHistory = new List<Food>();
        }

        public bool isFull{
            get{
                if(this.calorieIntake > 1200){
                    System.Console.WriteLine(this.calorieIntake);
                    return true;
                }
                System.Console.WriteLine(this.calorieIntake);
                return false;
            }

        }
        public void Eat(Food item)
        {
            if(this.calorieIntake >= 1200){
                System.Console.WriteLine("Can't eat");
            } else{
                this.calorieIntake += item.Calories;
                FoodHistory.Add(item);
            }
            

        }
    }
}
