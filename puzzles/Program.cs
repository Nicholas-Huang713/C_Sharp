using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            // RandomArray();
        //    System.Console.WriteLine(TossCoin()); 
            // TossMultipleCoins(10);
                
                Names();

        }

        public static void RandomArray(){
            int[] newArr = new int[10];
            int sum = 0;
            Random rand = new Random();
            for(var i = 0; i < newArr.Length; i++){
                newArr[i] = rand.Next(5, 25);
                System.Console.WriteLine(newArr[i]);
            }
            int min = newArr[0];
            int max = newArr[0];

            for(var i = 0; i < newArr.Length; i++){
                if(newArr[i] < min){
                    min = newArr[i];
                }
                if(newArr[i]>max){
                    max = newArr[i];
                }
                sum += newArr[i];
            }
            System.Console.WriteLine("Min: " + min + " Max: " + max);
            System.Console.WriteLine("Sum: " +sum);
            
        }

        public static string TossCoin(){
            System.Console.WriteLine("Tossing Coin!");
            string result = "heads";
            Random rand = new Random();
            int flip = rand.Next(10);
            if(flip % 2 == 0){
                result = "tails";
            } 
            return result; 
        }

        public static double TossMultipleCoins(int num){
            double ratio = 0;
            double heads = 0;
            double tails = 0;
            string side = "";
            for(var i = 0; i< num; i++){
                side = TossCoin();
                System.Console.WriteLine("Side: " + side);
                if(side == "heads"){
                    heads++;
                    System.Console.WriteLine("heads: " + heads);
                } else{
                    tails++;
                    System.Console.WriteLine("tails: "+ tails);
                }
            }
            if(tails == 0){
                    ratio = 1;
                } else{
                    ratio = heads/tails;
                }
                System.Console.WriteLine("Ratio: "+ ratio);
                return Math.Round(ratio,2);
        }

        public static List<string> Names(){
            List<string> nameList= new List<string>();
            nameList.Add("Todd");
            nameList.Add("Tiffany");
            nameList.Add("Charlie");
            nameList.Add("Geneva");
            nameList.Add("Sydney");

            List<string> newList = new List<string>();

            Random rand = new Random();
            int len = nameList.Count;
            while(len > 0){
                len--;
                int i = rand.Next(len);
                string temp = nameList[i];
                nameList[i] = nameList[len];
                nameList[len] = temp;
                Console.WriteLine(nameList[len]);
            }
            foreach(string j in nameList){
                 if(j.Length > 5){
                    newList.Add(j);
                    System.Console.WriteLine("Name: " + j);
                }
            }
            System.Console.WriteLine(newList);
            return newList;
           
        }
    }
}
