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

            int[] array = new int[10];
            int middle = (array.Length) / 2;


            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

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
            int[] leftSubArray = new int[mid - left + 1];
            int[] rightSubArray = new int[right - mid];

            for (int i = left; i < leftSubArray.Length; i++)
            {
                leftSubArray[i] = startingArray[i];
            }
            for (int i = 0; i < rightSubArray.Length; i++)
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
                MergeSort(startingArray, left, mid);
                MergeSort(startingArray, mid + 1, right);
                //SortArrays(startingArray, left, mid, right);
            }
        }

        public static int[] SortArrays(int[] arrayToSort, int left, int mid, int right)
        {
            int firstIndex = 0;
            int secondIndex = 0;
            int sortedIndex = 0;
            int[] sortedArray = new int[mid];
            /*
            while((firstIndex != arrayToSort.Length - 1) || (secondIndex != mid - 1))
            {
                if (arrayToSort[firstIndex] < left])
                {
                    sortedArray[sortedIndex] = arrayToSort[firstIndex];
                    sortedIndex++;
                    firstIndex++;
                }
                else
                {
                    sortedArray[sortedIndex] = right];
                    sortedIndex++;
                    secondIndex++;
                } */
            return arrayToSort;
        }
    }
}