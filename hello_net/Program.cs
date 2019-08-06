using System;
using System.Collections.Generic;

namespace hello_net
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] newArr= {1,2,3,4,5,6};
            int[] numArr = {1,2,3,4,5,6};
            int[] maxArr = {1,5,3,7,9};
            int[] negArr = {1,-1,2,-2,4,-4};
            // Console.WriteLine(sigma(5));
            // Console.WriteLine(avg(newArr));
            // printNums();
            // printSum();
            // loopArray(numArr);
            // Console.WriteLine(findMax(maxArr));
            // getAvg(newArr);

        //    List<int> oddList = oddArr(numArr); 
        //    for(int i = 0; i<oddList.Count; i++){
        //        Console.WriteLine(oddList[i]);
        //    }
            
            // System.Console.WriteLine(greaterThanY(newArr, 1)); 
            // sqVals(newArr);
            // eliminateNegs(negArr);
            // minMaxAvg(newArr);
            // ShiftValues(newArr);
            foreach (var val in NumToString(negArr)){
                Console.WriteLine(val);
            }
        }

        public static int sigma(int num){
            int sum = 0;
            for(int i = 0; i <=num; i++){
                sum += i;
            }
            return sum;
        }

        public static double avg(int[] arr){
            double avg = 0;
            int sum = 0;
            for(int i = 0; i<arr.Length; i++){
                sum += arr[i];
            }
            avg = sum/arr.Length;
            return avg;
        }

        public static void printNums(){
            for(int i =1; i< 256; i++){
                Console.WriteLine(i);
            }
        }

        public static void printSum(){
            int sum=0;
            for(int i =1; i<256;i++){
                sum += i;
                Console.WriteLine("New Number: "+ i + " Sum: "+ sum);
            }
        }

        public static void loopArray(int[] numbers){
            for(int i = 0; i< numbers.Length; i++){
                Console.WriteLine(numbers[i]);
            }
        }

        public static int findMax(int[] numbers){
            int max = numbers[0];
            for(int i = 1; i< numbers.Length; i++){
                if(numbers[i] > max){
                    max = numbers[i];
                }
            }
            return max;
        }

        public static void getAvg(int[] numbers){
            int sum = 0;
            for(int i = 0; i < numbers.Length;i++){
                sum += numbers[i];
            }
            double avg = sum/numbers.Length;
            System.Console.WriteLine(avg);
        }

        public static List<int> oddArr(int[] numbers){
            List<int> oddList = new List<int>();
            for(int i = 0; i < numbers.Length; i++){
                if(numbers[i] % 2 != 0){
                    oddList.Add(numbers[i]);
                }
            }
            return oddList;
        }

        public static int greaterThanY(int[] numbers, int y){
            int count = 0;
            for (int i = 0; i < numbers.Length; i++){
                if(numbers[i]> y){
                    count ++;
                }
            }
            return count;
        }

        public static void sqVals(int[] numbers){
            for(int i = 0; i < numbers.Length; i++){
                numbers[i] *= numbers[i];
                Console.WriteLine(numbers[i]);
            }
        }

        public static void eliminateNegs(int[] numbers){
            for(int i = 0; i< numbers.Length; i++){
                if(numbers[i] < 0){
                    numbers[i] = 0;
                }
                Console.WriteLine(numbers[i]);
            }
        }

        public static void minMaxAvg(int[] numbers){
            int sum = 0;
            int min = numbers[0];
            int max = numbers[0];
            for(int i = 0; i < numbers.Length; i++){
                if(numbers[i] < min){
                    min = numbers[i];
                }
                if(numbers[i] > max){
                    max = numbers[i];
                }
                sum += numbers[i];
            }
            double avg = sum/numbers.Length;
            Console.WriteLine("Min:{0} Max:{1} Avg:{2}", min, max, avg);
        }

        public static void ShiftValues(int[] numbers){
            for(int i = 0; i < numbers.Length - 1; i ++){
                numbers[i]= numbers[i+1];
                Console.WriteLine(numbers[i]);
            }
            numbers[numbers.Length - 1] = 0;
            Console.WriteLine(numbers[numbers.Length - 1]);
        }

        public static object[] NumToString(int[] numbers){
            string[] newNumbers = new string[numbers.Length];
            for (int i = 0; i< numbers.Length; i++){
                if(numbers[i] < 0){
                    newNumbers[i] = "Dojo";
                } else{
                    newNumbers[i]= numbers[i].ToString();
                }
            }
            return newNumbers;
        }
    }
}



//    List<object> data = new List<object>();

        //    data.Add(7);
        //    data.Add(28);
        //    data.Add(-1);
        //    data.Add(true);
        //    data.Add("chair");

        //    object sum= 0;
        //    foreach (object i in data){
        //        if(data[i] is int){
        //            sum += data[i];
        //        }
        //    }
        //    Console.WriteLine(sum);