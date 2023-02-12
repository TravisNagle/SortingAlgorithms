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

            Console.WriteLine();
            int index = BinarySearch(array, 0, array.Length - 1, 1009);
            Console.WriteLine("Found Index");
            Console.WriteLine(index);
        }

        public static void ReadFile(string path)
        {
            StreamReader sr = new StreamReader(path);
        }

        public static void SortArray(int[] array, int startingIndex, int endingIndex)
        {
            int mid = (startingIndex + (endingIndex - 1)) / 2;

            if(startingIndex < endingIndex)
            {
                SortArray(array, startingIndex, mid);
                SortArray(array, mid + 1, endingIndex);

                MergeSort(array, startingIndex, mid, endingIndex);
            }
        }

        public static void MergeSort(int[] startingArray, int startingIndex, int middlePoint, int endingIndex)
        {
            int leftSubArrayLength = middlePoint - startingIndex + 1; 
            int rightSubArrayLength = endingIndex - middlePoint; 

            int[] leftSubArray = new int[leftSubArrayLength]; 
            int[] rightSubArray = new int[rightSubArrayLength]; 

            for (int i = 0; i < leftSubArrayLength; i++)
            {
                leftSubArray[i] = startingArray[i + startingIndex];
            }
            for (int i = 0; i < rightSubArrayLength; i++)
            {
                rightSubArray[i] = startingArray[middlePoint + i + 1];
            }
            
            int leftSubArrayIndex = 0;
            int rightSubArrayIndex = 0;
            int sortedArrayIndex = startingIndex;

            while(leftSubArrayIndex < leftSubArrayLength && rightSubArrayIndex < rightSubArrayLength)
            {
                if (leftSubArray[leftSubArrayIndex] <= rightSubArray[rightSubArrayIndex])
                {
                    startingArray[sortedArrayIndex] = leftSubArray[leftSubArrayIndex];
                    leftSubArrayIndex++;
                    sortedArrayIndex++;
                }
                else
                {
                    startingArray[sortedArrayIndex] = rightSubArray[rightSubArrayIndex];
                    rightSubArrayIndex++;
                    sortedArrayIndex++;
                }
            }

            while(leftSubArrayIndex < leftSubArrayLength)
            {
                startingArray[sortedArrayIndex] = leftSubArray[leftSubArrayIndex];
                leftSubArrayIndex++;
                sortedArrayIndex++;
            }
            while(rightSubArrayIndex < rightSubArrayLength)
            {
                startingArray[sortedArrayIndex] = rightSubArray[rightSubArrayIndex];
                rightSubArrayIndex++;
                sortedArrayIndex++;
            }
        }

        public static int BinarySearch(int[] array, int startingIndex, int endingIndex, int searchedValue)
        { 
            int middlePoint = (endingIndex + startingIndex) / 2;

            if (array[middlePoint] == searchedValue)
            {
                return middlePoint;
            }
            else if (array[middlePoint] > searchedValue)
            {
                return BinarySearch(array, startingIndex, middlePoint, searchedValue);
            }
            else
            {
                return BinarySearch(array, middlePoint + 1, endingIndex, searchedValue);
            }
        }
    }
}