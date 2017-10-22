using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    /// <summary>
    /// Contains function, which searches lowest from numbers bigger than given,
    /// which consist of the same set of digits
    /// </summary>
    public static class FindNextBiggerNumber
    {
        public static int? Find(int num)
        {
            CheckParameter(num);
            int pos, result = ExchgFind(num, out pos);
            if (result == -1)
            {
                return null;
            }
            result = FindMinBelowPos(result, pos);
            return result;
        }

        private static int FindMinBelowPos(int num, int pos)
        {
            int n = num % Pow(10, pos);
            int m = Sort(n);
            int delta = n - m;
            return num - delta;
        }
        
        private static int Sort(int num)
        {
            int size = 1, dec = 10;
            while (num / dec > 0)
            {
                ++size;
                dec *= 10;
            }
            byte[] array = new byte[size];
            for (int i = 0; i < size; ++i)
            {
                array[i] = (byte)(num / Pow(10, i) % Pow(10, i + 1));
            }
            int result = 0;
            for (int i = 0; i < size; ++i)
            {
                result += array[i] * Pow(10, i);
            }
            return result;
        }

        private static void SortByteArray(byte[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                int iMin = i;
                for (int j = i + 1; j < array.Length; ++j)
                {
                    if (array[j] < array[iMin])
                    {
                        iMin = j;
                    }
                }
                Swap(ref array[i], ref array[iMin]);
            }
        }

        private static void Swap(ref byte a, ref byte b)
        {
            byte temp = a;
            a = b;
            b = temp;
        }

        private static int ExchgFind(int num, out int pos)
        {
            pos = -1;
            int size = 0, dec = 10;
            bool succeed = false;
            while (num / dec > 0)
            {
                ++size;
                dec *= 10;
            }
            for (int i = 1; i <= size; ++i)
            {
                if (MinExchangeOnThatPos(ref num, i))
                {
                    pos = i;
                    succeed = true;
                    break;
                }
            }
            if (succeed)
            {
                return num;
            }
            else
            {
                return -1;
            }
        }

        private static bool MinExchangeOnThatPos(ref int num, int pos)
        {
            bool succeed = false;
            int min = int.MaxValue, temp;
            for (int i = 0; i < pos; ++i)
            {
                if ((temp = Exchange(num, i, pos)) > num)
                {
                    succeed = true;
                    if (temp < min)
                    {
                        min = temp;
                    }
                }
            }
            if (succeed)
            {
                num = min;
            }
            return succeed;
        }

        private static int Exchange(int num, int i, int j)
        {
            int digitI, digitJ;
            digitI = num / Pow(10, i) % Pow(10, i + 1);
            digitJ = num / Pow(10, j) % Pow(10, j + 1);
            int delta = digitI - digitJ;
            num = num - delta * Pow(10, i) + delta * Pow(10, j);
            return num;
        }

        private static int Pow(int x, int y)
        {
            int result = 1;
            for (int i = 1; i <= y; ++i)
            {
                result *= x;
            }
            return result;
        }

        private static void CheckParameter(int num)
        {
            if (num <= 0)
            {
                throw new ArgumentOutOfRangeException("Number must be above zero");
            }
        }
    }
}
