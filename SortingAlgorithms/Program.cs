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

            int count = 1;

            int[] array = new int[10];
            int middle = (array.Length) / 2;


            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            int index = BinarySearch(array, 9, 0, array.Length - 1);
            Console.WriteLine(index);
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

        public static int[] MergeSort(int[] arr1, int[] arr2)
        {
            //Check if array has one element
            //
            //
            //Split the array
            //int left = 0;
            //int right = array.Length - 1;
            //int middle = (right + left) / 2;

            //Create sub arrays from left and right
            //left array needs to be 0 - middle
            //right array needs to be middle + 1 - array.Length - 1

            int[] sortedArray = new int[arr1.Length];
            return sortedArray;
        }

        public static int BinarySearch(int[] arr, int search, int startPoint, int endPoint)
        {
            //Start at the array's middle value. If this value is the target, stop here
            int middle = (arr.Length) / 2;

            //If the middle value is greater than the target value, check the left (lesser) half of the
            //array.If it is less, check the right(greater) half.
            if (arr[middle] == search)
            {
                return middle;
            }
            else
            {
                if (search > arr[middle]) //Shared code
                {
                    //Drop left half of array and search again
                    //middle - array.length - 1
                    int[] rightArray = new int[arr.Length - middle];
                    startPoint = middle;
                    endPoint = arr.Length - 1;

                    return BinarySearch(rightArray, search, startPoint, endPoint);
                }
                /*else
                {
                    //Drop right half of array and search again
                    int[] leftArray = new int[arr.Length - middle];
                    for (int i = 0; i < leftArray.Length; i++)
                    {
                        leftArray[i] = arr[i];
                    }
                    Console.WriteLine();
                    foreach (int i in leftArray)
                    {
                        Console.Write(i + " ");
                    }
                    Console.WriteLine();
                    return BinarySearch(leftArray, search);
            } */
                return -1;
            }

        //Repeat steps 1 and 2 until you find the value or identify where the value should be.

        //Return the value’s index, or a -1 if the value is missing from the array
        }
    }
}