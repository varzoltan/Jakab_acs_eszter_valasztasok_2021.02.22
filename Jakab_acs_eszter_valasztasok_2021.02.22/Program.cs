using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jakab_acs_eszter_valasztasok_2021._02._22
{
    class Program
    {
        struct Adat
        {
            public int v_sorszam;
            public int szavazatszam;
            public string nev;
            public string part;
        }
        static void Main(string[] args)
        { 
            Adat[] adatok = new Adat[100];
            StreamReader beolvas = new StreamReader(@"E:\OneDrive - Kisvárdai SZC Móricz Zsigmond Szakgimnáziuma és Szakközépiskolája\Oktatas\Programozas\Jakab_Acs_Eszter\Erettsegi_feladatok\2013-majus\szavazatok.txt");
            int n = 0;
            while (!beolvas.EndOfStream)
            {
                string sor = beolvas.ReadLine();
                string[] db = sor.Split();
                adatok[n].v_sorszam = int.Parse(db[0]);
                adatok[n].szavazatszam = int.Parse(db[1]);
                adatok[n].nev = db[2] + " " + db[3];
                adatok[n].part = db[4];
                n++;
            }
            Console.WriteLine("1.feladat\nBeolvasás kész!");

            //2.feladat
            Console.WriteLine($"2.feladat\nA helyhatósági választáson {n} képviselőjelölt indult.");

            //3.feladat
            Console.Write("Kérem adja meg a képviselőjelölt nevét: ");
            string jelolt =  Console.ReadLine();
            bool volt = true;
            for (int i = 0; i<n ;i++)
            {
                if (jelolt == adatok[i].nev)
                {
                    Console.WriteLine($"{adatok[i].nev} {adatok[i].szavazatszam} szavazatot kapott.");
                    volt = false;
                }
            }
            if (volt == true)
            {
                Console.WriteLine("Ilyen  nevű  képviselőjelölt  nem  szerepel  a nyilvántartásban!");
            }

            //4.feladat//
            Console.ReadKey();
        }
    }
}
