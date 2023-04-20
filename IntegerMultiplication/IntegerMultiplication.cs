using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // ***************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // ***************
    public static class IntegerMultiplication
    {
        #region YOUR CODE IS HERE

        
        static public byte[] IntegerMultiply(byte[] X, byte[] Y, int N)
        {
            if (N <= 32)
            {
                return NaiveMult(N, X, Y); 
            }
           
            int half = N / 2;
            int end = N - half;

            byte[] A = new byte[half];
            byte[] B = new byte[end];
            byte[] C = new byte[half];
            byte[] D = new byte[end];

            for (int i = 0; i < half; i++)
            {
                A[i] = X[i];
                C[i] = Y[i];
            }

            for (int i = half; i < N; i++)
            {
                B[i - half] = X[i];
                D[i - half] = Y[i];
            }

            byte[] AC = IntegerMultiply(A, C, half);
            byte[] BD = IntegerMultiply(B, D, end);
            byte[] addition1 = Add(A, B);
            byte[] addition2 = Add(C, D);

            if (addition1.Length != addition2.Length)
            {
                if (addition1.Length > addition2.Length)
                    Array.Resize(ref addition2, addition1.Length);
                else
                    Array.Resize(ref addition1, addition2.Length);
            }


            byte[] ABCD = IntegerMultiply(addition2, addition1, addition2.Length);
            ABCD = Subtract(ABCD, Add(AC, BD));



            byte[] newArr2 = new byte[(half * 2) + BD.Length]; 
            for (int i = 0; i < BD.Length; i++)
            {
                newArr2[(half*2) + i] = BD[i];
            }
            byte[] newArr = new byte[half + ABCD.Length];
            for (int i = 0; i < ABCD.Length; i++)
            {
                newArr[half + i] = ABCD[i];
            }
            byte[] result = Add(newArr2, Add(newArr, AC));
            return result;
           

        }

        public static byte[] Add(byte[] a, byte[] b)

        {
            if (a.Length != b.Length)
            {
                int maxLength = Math.Max(a.Length, b.Length);
                a = (a.Length < maxLength) ? ResizeArray(a, maxLength) : a;
                b = (b.Length < maxLength) ? ResizeArray(b, maxLength) : b;

            }
            int sum;
            int carry = 0;
            byte[] final = new byte[a.Length + 1];
            for (int i = 0; i < a.Length; i++)
            {
                sum = (b[i] + a[i] + carry);
                final[i] = (byte)(sum % 10);
                carry = sum / 10;
            }
            final[a.Length] = (carry != 0) ? (byte)carry : final[a.Length];
            int idx = final.Length - 1;
            while (idx > 0 && final[idx] == 0)
            {
                idx--;
            }
            if (idx < 0)
            {
                idx = 0;
            }
            final = ResizeArray(final, idx + 1);
            return final;
        }
        private static byte[] ResizeArray(byte[] array, int newSize)
        {
            byte[] newArray = new byte[newSize];
            Array.Copy(array, newArray, Math.Min(array.Length, newSize));
            return newArray;
        }
        static public byte[] Subtract(byte[] a, byte[] b)
        {
            int n = a.Length;
            int m = b.Length;
            byte[] result = new byte[n];
            int carry = 0;
            for (int i = 0; i < n; i++)
            {
                int sub = a[i];
                if (i < m)
                {
                    sub -= b[i];
                }
                sub -= carry;
                if (sub < 0)
                {
                    sub += 10;
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }
                result[i] = (byte)sub;
            }
            return (result);
        }

        static public byte[] NaiveMult(int N , byte[] X , byte[] Y) {

            byte[] result = new byte[2 * N];
            int carry = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int prod = X[i] * Y[j] + carry + result[i + j];
                    result[i + j] = (byte)(prod % 10);
                    carry = prod / 10;
                }
                result[i + N] += (byte)carry;
                carry = 0;
            }
            return result;

        }
        #endregion
    }
}
