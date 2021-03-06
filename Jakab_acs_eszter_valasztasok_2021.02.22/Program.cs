﻿using System;
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
            const int szav_jogosultak = 12345;
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
                /*if (db[4] == "-")
                {
                    adatok[n].part = "Független";
                }
                else
                {*/
                    adatok[n].part = db[4];
                //}              
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

            //4.feladat
            double osszesen = 0;
            for (int i = 0;i<n;i++)
            {
                osszesen += adatok[i].szavazatszam;
            }
            double szazalek = osszesen / szav_jogosultak * 100;
            Console.WriteLine($"A választáson {osszesen} állampolgár, a jogosultak {szazalek.ToString("0.00")}%-a vett részt.");

            //5.feladat
            string[] Partok = { "ZEP", "HEP", "TISZ", "GYEP", "-" };
            double osszes = 0;
            Console.WriteLine("5.feladat");
            for (int j = 0;j<Partok.Length;j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (adatok[i].part == Partok[j])
                    {
                        osszes += adatok[i].szavazatszam;
                    }

                }
                if (Partok[j] == "-")
                {
                    Console.WriteLine($"Független jelöltek={(osszes / szav_jogosultak * 100).ToString("0.00")}%");
                }
                else
                {
                    Console.WriteLine($"{Partok[j]}={(osszes / szav_jogosultak * 100).ToString("0.00")}%");
                }              
                osszes = 0;
            }

            //6.feladat
            int leg = 0;
            Console.WriteLine("6.feladat");
            for (int i = 0;i<n;i++)
            {
                if (adatok[i].szavazatszam > leg)
                {
                    leg = adatok[i].szavazatszam;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (adatok[i].szavazatszam == leg)
                {
                    if (adatok[i].part == "-")
                    {
                        Console.WriteLine($"{adatok[i].nev} független");
                    }
                    else
                    {
                        Console.WriteLine($"{adatok[i].nev} {adatok[i].part}");
                    }                  
                }
            }

            //7.feladat
            StreamWriter ir = new StreamWriter(@"E:\OneDrive - Kisvárdai SZC Móricz Zsigmond Szakgimnáziuma és Szakközépiskolája\Oktatas\Programozas\Jakab_Acs_Eszter\Erettsegi_feladatok\2013-majus\kepviselok.txt");
            int nagy = 0;
            int p = 0;
            for (int j = 1;j<=8;j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (adatok[i].szavazatszam>nagy && adatok[i].v_sorszam == j)
                    {
                        nagy = adatok[i].szavazatszam;
                        p = i;
                    }                                    
                }
                if (adatok[p].part == "-")
                {
                    ir.WriteLine($"{j}.választókerületben győztes: {adatok[p].nev} pártja: független");
                }
                else
                {
                    ir.WriteLine($"{j}.választókerületben győztes: {adatok[p].nev} pártja: {adatok[p].part}");
                }                
                nagy = 0;
            }
            ir.Close();
            Console.ReadKey();
        }
    }
}
