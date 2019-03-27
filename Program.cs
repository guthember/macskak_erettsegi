using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace macskak
{
    class Program
    {
        struct Macska
        {
            public string datum;
            public string szin;
            public int suly;
        }

        static Macska[] sz = new Macska[14];
        static Macska[] f = new Macska[14];

        static void Elso()
        {
            Console.WriteLine("1. feladat");
            string[] sorok = File.ReadAllLines("macskak.txt");
            int szurke = 0;
            int fekete = 0;
            foreach (var s in sorok)
            {
                string[] adatok = s.Split();
                if (adatok[1] == "fekete")
                {
                    f[fekete].datum = adatok[0];
                    f[fekete].szin = adatok[1];
                    f[fekete].suly = int.Parse(adatok[2]);
                    fekete++;
                }
                else
                {
                    sz[szurke].datum = adatok[0];
                    sz[szurke].szin = adatok[1];
                    sz[szurke].suly = int.Parse(adatok[2]);
                    szurke++;
                }
            }

            for (int i = 0; i < 14; i++)
            {
                Console.WriteLine("{0} --- szürke {1} fekete {2}",
                    sz[i].datum, sz[i].suly, f[i].suly);
            }
        }

        static void Main(string[] args)
        {
            Elso();

            Console.ReadKey();
        }
    }
}
