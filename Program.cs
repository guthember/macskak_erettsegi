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

        static void Masodik()
        {
            Console.WriteLine("\n2. feladat");
            Console.WriteLine("adatok kiírása");
            FileStream fileSz = new FileStream("szurke.txt", FileMode.Create);
            StreamWriter kiSz = new StreamWriter(fileSz);

            for (int i = 0; i < 14; i++)
			{
                kiSz.WriteLine("{0} {1}", sz[i].datum, sz[i].suly);
			}

            kiSz.Close();
            fileSz.Close();
            FileStream fileF = new FileStream("fekete.txt", FileMode.Create);
            StreamWriter kiF = new StreamWriter(fileF);

            for (int i = 0; i < 14; i++)
			{
                kiF.WriteLine("{0} {1}", f[i].datum, f[i].suly);
			}

            kiF.Close();
            fileF.Close();
        }

        static void Main(string[] args)
        {
            Elso();
            Masodik();
            Console.ReadKey();
        }
    }
}
