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

            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            SortArray(array, 0, array.Length - 1);
            Console.WriteLine();
            foreach(int val in array)
            {
                Console.Write(val + " ");
            }
        }

        public static void ReadFile(string path)
        {
            StreamReader sr = new StreamReader(path);
        }

        public static void SortArray(int[] array, int left, int right)
        {
            int mid = (left + (right - 1)) / 2;

            if(left < right)
            {
                SortArray(array, left, mid);
                SortArray(array, mid + 1, right);

                MergeSort(array, left, mid, right);
            }
        }

        public static void MergeSort(int[] startingArray, int left, int mid, int right)
        {
            int leftSubArrayLength = mid - left + 1; 
            int rightSubArrayLength = right - mid; 

            int[] leftSubArray = new int[leftSubArrayLength]; 
            int[] rightSubArray = new int[rightSubArrayLength]; 

            for (int i = 0; i < leftSubArrayLength; i++)
            {
                leftSubArray[i] = startingArray[i + left];
            }
            for (int i = 0; i < rightSubArrayLength; i++)
            {
                rightSubArray[i] = startingArray[mid + i + 1];
            }
            
            int leftSubArrayIndex = 0;
            int rightSubArrayIndex = 0;
            int newArrayIndex = left;

            while(leftSubArrayIndex < leftSubArrayLength && rightSubArrayIndex < rightSubArrayLength)
            {
                if (leftSubArray[leftSubArrayIndex] <= rightSubArray[rightSubArrayIndex])
                {
                    startingArray[newArrayIndex] = leftSubArray[leftSubArrayIndex];
                    leftSubArrayIndex++;
                    newArrayIndex++;
                }
                else
                {
                    startingArray[newArrayIndex] = rightSubArray[rightSubArrayIndex];
                    rightSubArrayIndex++;
                    newArrayIndex++;
                }
            }

            while(leftSubArrayIndex < leftSubArrayLength)
            {
                startingArray[newArrayIndex] = leftSubArray[leftSubArrayIndex];
                leftSubArrayIndex++;
                newArrayIndex++;
            }
            while(rightSubArrayIndex < rightSubArrayLength)
            {
                startingArray[newArrayIndex] = rightSubArray[rightSubArrayIndex];
                rightSubArrayIndex++;
                newArrayIndex++;
            }
        }
    }
}