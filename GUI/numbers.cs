using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.IO;

namespace Apk
{
    class numbers
    {
        public static void add()
        {
            String a, b;
            a = System.IO.File.ReadAllText("liczba_a.txt");
            b = System.IO.File.ReadAllText("liczba_b.txt");
            BigInteger aa = BigInteger.Parse(a);
            BigInteger bb = BigInteger.Parse(b);
            BigInteger cc;
            cc = BigInteger.Add(aa, bb);
            System.IO.File.WriteAllText(@"wynik.txt", cc.ToString());
            Console.Write(cc);
        }

        public static void minus()
        {
            String a, b;
            a = System.IO.File.ReadAllText("liczba_a.txt");
            b = System.IO.File.ReadAllText("liczba_b.txt");
            BigInteger aa = BigInteger.Parse(a);
            BigInteger bb = -BigInteger.Parse(b);
            BigInteger cc;
            cc = BigInteger.Add(aa, bb);
            System.IO.File.WriteAllText(@"wynik.txt", cc.ToString());
            Console.Write(cc);
        }

        public static void multiply()
        {
            String a, b;
            a = System.IO.File.ReadAllText("liczba_a.txt");
            b = System.IO.File.ReadAllText("liczba_b.txt");
            BigInteger aa = BigInteger.Parse(a);
            BigInteger bb = BigInteger.Parse(b);

            BigInteger cc;
            cc = BigInteger.Multiply(aa, bb);
            Console.WriteLine(cc.ToString());
            System.IO.File.WriteAllText(@"wynik.txt", cc.ToString());

        }

        public static void mod()
            {
            String a, b;
            a = System.IO.File.ReadAllText("liczba_a.txt");
            b = System.IO.File.ReadAllText("liczba_b.txt");
            BigInteger aa = BigInteger.Parse(a);
            BigInteger bb = BigInteger.Parse(b);
            BigInteger cc;
            cc = BigInteger.ModPow(aa, bb - 2, bb);
            Console.WriteLine(cc.ToString());
            System.IO.File.WriteAllText(@"wynik.txt", cc.ToString());

        }
        
    }
}
