///////////////////////////////////////////////////////////////////////////////
//
// Author: Travis Nagle, Naglet@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 2 - Sorting Algorithms
// Description: Sorts a jagged array using the merge sort algorithm and searches for values using binary search
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Reflection;

namespace SortingAlgorithms
{
    internal class Program
    {
        /// <summary>
        /// Sorts and displays a jagged array filled with CSV file values. Displays index of 256 in arrays.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[20][];
            string filePath = $"../../../ArrayValues/inputJagged.csv";

            ReadFile(filePath, jaggedArray);
            
            Console.WriteLine("Unsorted Array");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                SortArray(jaggedArray[i], 0, jaggedArray[i].Length - 1);
            }
            Console.WriteLine();
            Console.WriteLine("Sorted Array");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int index = BinarySearch(jaggedArray[i], 0, jaggedArray[i].Length - 1, 256);
                Console.WriteLine($"Row {i}: {index}");
            }
        }

        /// <summary>
        /// Reads in CSV file and fills in the jagged array with the CSV values
        /// </summary>
        /// <param name="filePath">Path to CSV file</param>
        /// <param name="jaggedArray">Created jagged array</param>
        /// <returns>Jagged array with CSV values</returns>
        public static int[][] ReadFile(string filePath, int[][] jaggedArray)
        {
            string text = "";
            int counter = 0;
            StreamReader reader = new StreamReader(filePath);

            while(reader.Peek() != -1)
            {
                text = reader.ReadLine();
                string[] fields = text.Split(",");

                jaggedArray[counter] = new int[fields.Length];
                for(int i = 0; i < jaggedArray[counter].Length; i++)
                {
                    jaggedArray[counter][i] = int.Parse(fields[i]);
                }
                counter++;
            }
            return jaggedArray;
        }

        public static void SortArray(int[] array, int startingIndex, int endingIndex)
        {
            int mid = (startingIndex + endingIndex) / 2;

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
            int leftSubArrayIndex = 0;
            int rightSubArrayIndex = 0;
            int sortedArrayIndex = startingIndex;

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
            
            if(endingIndex < startingIndex)
            {
                return -1;
            }

            if (array[middlePoint] < searchedValue)
            {
                return BinarySearch(array, middlePoint + 1, endingIndex, searchedValue);
            }
            else if (array[middlePoint] > searchedValue)
            {
                return BinarySearch(array, startingIndex, middlePoint - 1, searchedValue);
            }
            else
            {
                return middlePoint;
            }
        }
    }
}