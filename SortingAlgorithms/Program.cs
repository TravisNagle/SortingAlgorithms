using System;
using System.Reflection;

namespace SortingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[20][];
            string filePath = $"../../../ArrayValues/inputJagged.csv";
            ReadFile(filePath);

            int[] array = { 45, 12, 90, 3, 1009, 32 };
            int middle = (array.Length) / 2;


            

            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            MergeSort(array, 0, array.Length - 1);
            /* 
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }

            int[] newArray = new int[array.Length - middle];
            for(int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = array[middle];
                middle++;
            }

            Console.WriteLine();

            foreach(int i in newArray)
            {
                Console.WriteLine($"{i}");
            } */
        }

        public static void ReadFile(string path)
        {
            StreamReader sr = new StreamReader(path);
        }

        public static void MergeSort(int[] startingArray, int left, int right)
        {
            int mid = (right + left) / 2;
            int leftArrayLength = mid - left + 1;
            int rightArrayLength = right - mid;

            int[] leftSubArray = new int[leftArrayLength];
            int[] rightSubArray = new int[rightArrayLength];

            for (int i = 0; i < leftArrayLength; i++)
            {
                leftSubArray[i] = startingArray[i + left];
            }
            for (int i = 0; i < rightArrayLength; i++)
            {
                rightSubArray[i] = startingArray[mid + i + 1];
            }
            
            if(left < right)
            {
                Console.WriteLine("Left Array");
                foreach (int val in leftSubArray)
                {
                    Console.Write(val + " ");
                }
                Console.WriteLine();

                Console.WriteLine("Right Array");
                foreach (int val in rightSubArray)
                {
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }

            int leftSubArrayIndex = 0;
            int rightSubArrayIndex = 0;
            int newArrayIndex = 0;

            while(leftSubArrayIndex < leftArrayLength && rightSubArrayIndex < rightArrayLength)
            {
                if (leftSubArray[leftSubArrayIndex] < rightSubArray[rightSubArrayIndex])
                {
                    leftSubArray[leftSubArrayIndex] = startingArray[newArrayIndex];
                    leftSubArrayIndex++;
                    newArrayIndex++;
                }
                else
                {
                    rightSubArray[rightSubArrayIndex] = startingArray[newArrayIndex];
                    rightSubArrayIndex++;
                    newArrayIndex++;
                }
            }

            Console.WriteLine();
            foreach(int val in startingArray)
            {
                Console.Write(val + " ");
            }
        }
    }
}