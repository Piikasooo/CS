using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int x1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            Mnogennya(x1, x2);

            Console.ReadLine();
        }
        static void Mnogennya(int x1, int x2)
        {
            Int64 A = (Int64)x1 << 17,
                S = (Int64)(-x1) << 17,
                P = (x2 << 1) & 0b0000_0000_0000_0000_1111_1111_1111_1111_0;

            Console.WriteLine("Q):\t{0}\nA):\t{1}\n-A):\t{2}\n", IntToBin(P), IntToBin(A), IntToBin(S));
            for (int i = 1; i < 17; ++i)
            {
                Console.Write(i + ") ");
                switch (P & 0b11)
                {
                    case 0b01:
                        P += A;
                        Console.WriteLine("  Q + A:\t{0}", IntToBin(P));
                        break;
                    case 0b10:
                        P += S;
                        Console.WriteLine("  Q - A:\t{0}", IntToBin(P));
                        break;
                }
                P >>= 1;
                Console.WriteLine("\t>>:\t" + IntToBin(P));
            }
            P >>= 1;
            Console.WriteLine("\nВідповідь: {0} = {1}", IntToBin(P, true), P);
        }
        static string IntToBin(Int64 number, bool is_end_result = false)
        {
            const int mask = 1;
            var rez = string.Empty;
            for (int i = (is_end_result ? 1 : 0); i < 33; ++i)
            {
                rez = (i % 4 == 0 ? " " : "") + (number & mask) + rez;
                number >>= 1;
            }
            return rez;
        }
    }
}
