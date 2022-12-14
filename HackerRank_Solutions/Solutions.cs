using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank_Solutions
{
    public class Solutions
    {
        public static String Reshape(int n, String str)
        {
            var array = str.Replace(" ", "").ToCharArray();
            var test = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (test != "" && (i % n == 0 || n == i))
                {
                    test += System.Environment.NewLine;
                }
                test += array[i].ToString();
            }
            return test;
        }
        public static int BeautifulTriplets(int d, List<int> arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                int j = arr[i];
                if (arr.Contains(j + d) && arr.Contains(j + 2 * d))
                {
                    count++;
                }
            }
            return count;
        }
        public static void CountSortingChar(char[] arr)
        {
            int n = arr.Length;
            char[] output = new char[n];
            int[] count = new int[256];

            for (int i = 0; i < 256; ++i)
                count[i] = 0;

            for (int i = 0; i < n; ++i)
                ++count[arr[i]];

            for (int i = 1; i <= 255; ++i)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[arr[i]] - 1] = arr[i];
                --count[arr[i]];
            }

            for (int i = 0; i < n; ++i)
                arr[i] = output[i];
        }
        public static void CountSortingInt(int[] arr)
        {
            int max = arr.Max();
            int min = arr.Min();
            int range = max - min + 1;
            int[] count = new int[range];
            int[] output = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i] - min]++;
            }
            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                output[count[arr[i] - min] - 1] = arr[i];
                count[arr[i] - min]--;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = output[i];
            }
        }
        public static List<int> countingSort(List<int> arr)
        {
            int n = arr.Count();
            List<int> arr1 = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                arr1.Add(0);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (arr[i] == j)
                        arr1[j]++;
                }
            }
            return arr1;
        }
        public static int DiagonalDifference(List<List<int>> arr)
        {
            var right = 0;
            var left = 0;
            var result = 0;
            var rowCount = arr.Count - 1;
            var listCount = arr[0].Count;

            for (var j = 0; j < listCount; j++)
            {
                right += arr[j][j];
                left += arr[rowCount - j][j];
            }
            result = Math.Abs(right - left);

            return result;
        }
        public static int FindMedian(List<int> arr)
        {
            arr = arr.OrderBy(a => a).ToList();
            var medianIndex = arr.Count / 2;
            return arr[medianIndex];
        }
        #region Flipping Matrix 2D
        public static int FlippingMatrix(List<List<int>> matrix)
        {
            var sum = 0;
            var n = matrix.Count / 2;
            for (var row = 0; row < n; row++)
            {
                for (var col = 0; col < n; col++)
                {
                    sum += getMaxPossibleFor(matrix, row, col);
                }
            }

            return sum;
        }
        public static int getMaxPossibleFor(List<List<int>> matrix, int row, int col)
        {
            var n2 = matrix.Count - 1;
            return Math.Max(
                Math.Max(
                    matrix[row][col],
                    matrix[n2 - row][col]),

                Math.Max(
                    matrix[row][n2 - col],
                    matrix[n2 - row][n2 - col])
            );
        }
        #endregion
        public static void PlusMinus(List<int> arr)
        {
            var length = Convert.ToDecimal(arr.Count);
            var positiveNoCount = 0;
            var negativeNoCount = 0;
            var zeroNoCount = 0;
            foreach (var i in arr)
            {
                if (i > 0)
                    positiveNoCount++;
                if (i < 0)
                    negativeNoCount++;
                if (i == 0)
                    zeroNoCount++;
            }

            var positiveRatio = Convert.ToDecimal(positiveNoCount / length);
            var negativeRatio = Convert.ToDecimal(negativeNoCount / length);
            var zeroRatio = Convert.ToDecimal(zeroNoCount / length);
            Console.WriteLine(positiveRatio.ToString("0.000000"));
            Console.WriteLine(negativeRatio.ToString("0.000000"));
            Console.WriteLine(zeroRatio.ToString("0.000000"));
        }
        public static void MiniMaxSum(List<int> arr)
        {
            arr = arr.OrderBy(a => a).ToList();
            Int64 sumEveryting = 0;
            List<Int64> sumList = new List<Int64>();
            for (int i = 0; i < arr.Count; i++)
            {
                var skip = arr.Select((value, index) => new { value, index }).Where(a => a.index != i).Select(a => a.value).ToList();
                for (var s = 0; s < skip.Count; s++)
                {
                    sumEveryting += skip[s];
                }
                sumList.Add(sumEveryting);
                sumEveryting = 0;
            }

            Console.WriteLine(sumList.Min());
            Console.WriteLine(sumList.Max());
        }
        public static string TimeConversion(string s)
        {
            var time = Convert.ToDateTime(s);
            return time.ToString("HH:mm:ss");
        }
        public static int LonelyInteger(List<int> a)
        {
            IDictionary<int, string> intgerList = new Dictionary<int, string>();
            a = a.OrderBy(a => a).ToList();

            for (int i = 0; i < a.Count(); i++)
            {
                var itemKey = a[i];
                if (!intgerList.ContainsKey(itemKey))
                {
                    var valueCount = a.Count(a => a == itemKey);
                    intgerList.Add(itemKey, valueCount.ToString());
                }
            }
            var alone = intgerList.FirstOrDefault(a => a.Value == intgerList.Min(a => a.Value));
            return alone.Key;
        }
        public static int MaxSum(int[,] matrix)
        {
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            int sum = 0;
            int mini = int.MaxValue;
            int count = 0;

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    int k = matrix[i, j];
                    mini = Math.Min(mini, Math.Abs(k));
                    if (k < 0)
                        count++;
                    sum += Math.Abs(k);
                }
            }
            if (count % 2 == 0)
            {
                return sum;
            }
            else
            {
                return (sum - 2 * mini);
            }
        }
        public static int MinimumDistances(List<int> a)
        {
            var minimumDist = -1;
            var numberMap = new Dictionary<int, int>();
            for (var i = 0; i < a.Count; i++)
            {
                if (numberMap.ContainsKey(a[i]))
                {
                    if (minimumDist == -1)
                    {
                        minimumDist = i - numberMap[a[i]];
                        continue;
                    }

                    if (i - numberMap[a[i]] < minimumDist)
                    {
                        minimumDist = i - numberMap[a[i]];
                    }
                }
                else
                    numberMap.Add(a[i], i);
            }
            return minimumDist;
        }
        public void findZigZagSequence(List<int> a, int n)
        {
            a = a.OrderBy(a => a).ToList();
            int mid = (n - 1) / 2;
            swap(a[mid], a[n - 1]);

            int st = mid + 1;
            int ed = n - 2;
            while (st <= ed)
            {
                swap(a[st], a[ed]);
                st = st + 1;
                ed = ed - 1;
            }
            for (int i = 0; i < n; i++)
            {
                if (i > 0) cout << " ";
                cout << a[i];
            }
            cout << endl;
        }
    }
}
