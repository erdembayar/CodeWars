using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace CodeWars
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(ReverseLetter("ultr53o?n"));
            Console.WriteLine(IQTest("2 4 7 8 10"));
            Console.WriteLine(IQTest("1 2 1 1"));
            Console.WriteLine(IQTest("1 2"));
            Console.WriteLine(IQTest("1 1"));
            Console.WriteLine(IQTest("1 2 1"));



            #region SeriusSum

            Console.WriteLine(SeriesSum(0));
            Console.WriteLine(SeriesSum(1));
            Console.WriteLine(SeriesSum(5));
            for (int i = 6; i < 30; i++)
            {
                Console.WriteLine(SeriesSum(i));
            }

            #endregion

            var result = OpenOrSenior(new int[][] { new int[] { 18, 20 }, new int[] { 45, 2 }, new int[] { 61, 12 }, new int[] { 37, 6 }, new int[] { 21, 21 }, new int[] { 78, 9 } });
            foreach (var v in result)
            {
                Console.WriteLine(v);
            }

            foreach (var v in ArrayDiff(new int[] { 1, 2 }, new int[] { 1 }))
            {
                Console.WriteLine(v);
            }


            Console.WriteLine(Narcissistic(5));
            Console.WriteLine(Narcissistic(371));

            Console.WriteLine(PigIt("Pig latin is cool"));
            Console.WriteLine(PigIt("Hello world !"));

            Console.WriteLine(GoodVsEvil("1 1 1 1 1 1", "1 1 1 1 1 1 1"));
            Console.WriteLine(GoodVsEvil("0 0 0 0 0 10", "0 1 1 1 1 0 0"));
            Console.WriteLine(GoodVsEvil("1 0 0 0 0 0", "1 0 0 0 0 0 0"));

            foreach (var v in sqInRect(5, 3))
            {
                Console.WriteLine(v);
            }

            foreach (var v in sqInRect(5, 5))
            {
                Console.WriteLine(v);
            }

            Console.WriteLine(perimeter(5));
            Console.WriteLine(perimeter(7));

            Console.WriteLine(TrailingZeros(12));
            Console.WriteLine(TrailingZeros(25));

            //            Console.WriteLine(NextSmaller(111));
            //            Console.WriteLine(NextSmaller(21));
            //            Console.WriteLine(NextSmaller(531));
            //            Console.WriteLine(NextSmaller(2071));
            //            Console.WriteLine(NextSmaller(907));
            //            Console.WriteLine(NextSmaller(123456798));
            //            Console.WriteLine(NextSmaller(29009));
            Console.ReadKey();
        }


        public static int TrailingZeros(int n)
        {
            var sum = 0;
            while (n > 0)
            {
                sum += n / 5;
                n /= 5;
            }
            return sum;
        }

        public static BigInteger perimeter(BigInteger n)
        {
            BigInteger sum = 0;

            BigInteger a = 1;
            BigInteger b = 1;
            sum += a;
            sum += b;

            if (n == 0)
                return a * 4;
            if (n == 1)
                return sum * 4;

            BigInteger fib = a;
            for (int i = 2; i <= n; i++)
            {
                fib = a + b;
                sum += fib;
                a = b;
                b = fib;
            }

            return sum * 4;
        }

        public static string SpinWords(string sentence)
        {
            var result = new StringBuilder();
            var words = sentence.Split(' ');
            foreach (var word in words)
            {
                if (word.Length >= 5)
                {
                    var chars = word.ToCharArray();
                    Array.Reverse(chars);
                    result.Append((new string(chars)) + " ");
                }
                else
                {
                    result.Append(word + " ");
                }
            }

            return result.ToString()
                .Trim();
        }

        public static List<int> sqInRect(int lng, int wdth)
        {
            var result = new List<int>();
            //Simple greeedy algorithm
            if (lng == wdth)
                return null;
            while (lng > 0 && wdth > 0)
            {

                if (lng > wdth)
                {
                    result.Add(wdth);
                    lng -= wdth;
                }
                else
                {
                    result.Add(lng);
                    wdth -= lng;
                }
            }

            return result;
        }

        public static string GoodVsEvil(string good, string evil)
        {
            var goods = good.Split(' ');
            var evils = evil.Split(' ');
            var goodSide = 0;
            var goodWeight = new int[] { 1, 2, 3, 3, 4, 10 };
            var evilWeight = new int[] { 1, 2, 2, 2, 3, 5, 10 };
            for (int i = 0; i < 6; i++)
            {
                goodSide += int.Parse(goods[i]) * goodWeight[i];
            }

            var evilSide = 0;
            for (int i = 0; i < 7; i++)
            {
                evilSide += int.Parse(evils[i]) * evilWeight[i];
            }

            var result = "Battle Result: ";
            if (goodSide > evilSide)
            {
                return result + "Good triumphs over Evil";
            }
            else if (goodSide < evilSide)
            {
                return result + "Evil eradicates all trace of Good";
            }
            else
            {
                return result + "No victor on this battle field";
            }
        }
        public static string PigIt(string str)
        {
            var words = str.Split(' ');
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var word in words)
            {
                char c = word[0];
                if (char.IsPunctuation(c))
                {
                    stringBuilder.Append(c + " ");
                    continue;
                }
                stringBuilder.Append(word.Substring(1) + c + "ay ");
            }

            return stringBuilder.ToString().Trim();
        }
        public static bool Narcissistic(int value)
        {
            int temp = value;
            List<int> digits = new List<int>();
            while (temp > 0)
            {
                var digit = temp % 10;
                digits.Add(digit);
                temp = temp / 10;
            }

            int[] digitsArray = digits.ToArray();
            int[] digitsPower = digits.ToArray();
            int sum = digits.Sum();
            while (sum < value)
            {
                sum = 0;
                for (int i = 0; i < digitsArray.Length; i++)
                {
                    digitsPower[i] *= digitsArray[i];
                    sum += digitsPower[i];
                }
            }

            return sum == value;
        }

        public static int[] ArrayDiff(int[] a, int[] b)
        {
            // Your brilliant solution goes here
            // It's possible to pass random tests in about a second ;)
            HashSet<int> bHashSet = new HashSet<int>(b);
            return a.Where(v => !bHashSet.Contains(v))
                .ToArray();

        }

        public static IEnumerable<string> OpenOrSenior(int[][] data)
        {
            var result = new List<string>();
            //your code here
            foreach (var row in data)
            {
                if (row[0] >= 55 && row[1] > 7)
                {
                    result.Add("Senior");
                }
                else
                {
                    result.Add("Open");
                }

            }

            return result;
        }

        //        Simple Fun #176: Reverse Letter
        static string ReverseLetter(string str)
        {
            //coding and coding..
            char[] arr = str.ToCharArray();
            arr = Array.FindAll(arr, (c => char.IsLetter(c)));
            Array.Reverse(arr);

            return new string(arr);
        }

        static int IQTest(string numbers)
        {
            var intNumbers = numbers.Split(' ').Select(n => int.Parse(n)).ToList();
            int countEven = 0, countOdd = 0;
            int evenLocation = 0, oddLocation = 0; //Only first encounter matters.
            bool? searchOdd = null;
            for (int i = 0; i < intNumbers.Count(); i++)
            {
                var odd = intNumbers[i] % 2 == 1;
                if (odd && searchOdd == true)
                {
                    return i + 1;
                }
                else if (!odd && searchOdd == false)
                {
                    return i + 1;
                }

                if (searchOdd == null)
                {
                    if (odd)
                    {
                        countOdd++;
                        oddLocation = i + 1;
                    }
                    else
                    {
                        countEven++;
                        evenLocation = i + 1;
                    }

                    if (countOdd > 1 && odd)
                    {
                        searchOdd = false;
                    }
                    if (countEven > 1 && !odd)
                    {
                        searchOdd = true;
                    }
                }

            }


            return searchOdd == true ? oddLocation : evenLocation;
        }

        private static string SeriesSum(int n)
        {
            if (n == 0)
                return "0.00";
            decimal sum = (decimal)1;
            int divider = 1;
            for (int i = 2; i <= n; i++)
            {
                divider += 3;
                decimal d = ((decimal)1 / (decimal)divider);
                sum += d;
            }
            sum = sum / 1.00M;
            return string.Format("${0:f2}", sum);

        }
    }
}
