namespace SortingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[20][];
            string filePath = $"../../../ArrayValues/inputJagged.csv";
            ReadFile(filePath);
        }

        public static void ReadFile(string path)
        {
            StreamReader sr = new StreamReader(path);
        }
    }
}