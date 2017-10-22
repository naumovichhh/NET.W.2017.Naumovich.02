using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Day2
{
    public static class InsertNumber
    {
        public static int Insert(int n1, int n2, int i, int j)
        {
            CheckParameters(i, j);

            int result = n1;
            for (int resultBitIndex = j; resultBitIndex >= i; --resultBitIndex)
            {
                int n2BitIndex = resultBitIndex - i;
                if (Has1(n2, n2BitIndex))
                {
                    InsertBit(ref result, 1, resultBitIndex);
                }
                else
                {
                    InsertBit(ref result, 0, resultBitIndex);
                }
            }
            return result;
        }

        private static void InsertBit(ref int dest, int bit, int position)
        {
            if (bit == 0)
            {
                dest &= ~Pow(2, position);
            }
            else
            {
                dest |= Pow(2, position);
            }
        }

        private static bool Has1(int num, int bitIndex)
        {
            int bit = Pow(2, bitIndex);
            if ((num & bit) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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

        private static void CheckParameters(int i, int j)
        {
            if (i > j)
            {
                throw new ArgumentException("bottom bound shouldn't be more than top bound");
            }
            if (i < 0 || i > 31)
            {
                throw new ArgumentOutOfRangeException("bound should be between 0 and 31");
            }
            if (j < 0 || j > 31)
            {
                throw new ArgumentOutOfRangeException("bound should be between 0 and 31");
            }
        }
    }
}
