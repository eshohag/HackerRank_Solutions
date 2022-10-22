using HackerRank_Solutions;

namespace Solutions_Solutions
{
    public class Program
    {
        static void Main(string[] args)
        {

            //int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            Solutions.MinimumDistances(arr);

            //string s = Console.ReadLine();
            //var time=   Solutions.TimeConversion(s);
            //var median = Solutions.FindMedian(arr);
            //var result = Solutions.LonelyInteger(arr);


            //List<List<int>> arr = new List<List<int>>();
            //for (int i = 0; i < n; i++)
            //{
            //    arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            //}

            //int result = Solutions.DiagonalDifference(arr);
            //Console.WriteLine(result);

            //char[] arr = { 'g', 'e', 'e', 'k', 's', 'f', 'o', 'r', 'g', 'e', 'e', 'k', 's' };
            //Solutions.CountSortingChar(arr);
            //Console.Write("Sorted character array is ");
            //for (int i = 0; i < arr.Length; ++i)
            //    Console.Write(arr[i]);

            //int[] arr = { -5, -10, 0, -3, 8, 5, -1, 10 };
            //Solutions.CountSortingInt(arr);
            //Console.Write("Sorted character array is ");
            //for (int i = 0; i < arr.Length; ++i)
            //    Console.Write(arr[i]);

            //int[,] matrix = { { 2, -2 }, { -2, 2 } };
            //Console.Write(Solutions.MaxSum(matrix));

            Console.ReadKey();
        }
    }
}
