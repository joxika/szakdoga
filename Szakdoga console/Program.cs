using System;
using System.Collections.Generic;

namespace Szakdoga_console
{
    class Program
    {
        List<Mezo> Palya = new List<Mezo>();
        public readonly int URESMEZO = 0;
        public readonly int GYALOG = 1;
        public readonly int BASTYA = 2;

        public static readonly string KEK = "kek";
        public static readonly string PIROS = "piros";
        public static readonly string URES = "ures";

        public static readonly bool NEMLEHETIDELEPNI = false;
        public static readonly bool LEHETIDELEPNI = true;

        public string kinekakore = PIROS;

        public int Kijeloltsor = 0;
        public int Kijeloltoszlop = 0;

        public int Hovasor = 2;
        public int Hovaoszlop = 2;

        static void Main(string[] args)
        {
            var program = new Program();

            program.Palyafeltoltes();
            while (true)
            {
                program.Palyakirajzolas();
                program.Babukijeloles();
                program.Hovalephet();
                program.Palyakirajzolas();
                program.Lepes();
            }
        }

        void Palyafeltoltes()
        {
            Urespalyafeltoltes();
            Babuhozzaad(0, 8, BASTYA, KEK, NEMLEHETIDELEPNI);
            Babuhozzaad(8, 16, GYALOG, KEK, NEMLEHETIDELEPNI);
            Babuhozzaad(48, 56, GYALOG, PIROS, NEMLEHETIDELEPNI);
            Babuhozzaad(56, 64, BASTYA, PIROS, NEMLEHETIDELEPNI);
        } 
        void Urespalyafeltoltes()
        {
            for (int i = 0; i < 64; i++)
            {
                Palya.Add(new Mezo(URESMEZO, URES, NEMLEHETIDELEPNI));
            }
        }
        void Babuhozzaad(int mettol, int meddig, int mit, string tulajdonos, bool idelepes)
        {
            for (int i = mettol; i < meddig; i++)
            {
                Palya[i].tipus = mit;
                Palya[i].tulajdonos = tulajdonos;
                Palya[i].idelepes = idelepes;
            }
        }

        void Palyakirajzolas()
        {
            Console.Clear();
            if(kinekakore == PIROS) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.WriteLine("{0} köre van", kinekakore);
            Console.WriteLine();

            for (int sor = 0; sor < 8; sor++)
                {
                for(int oszlop = 0; oszlop < 8; oszlop++)
                {
                    Mezo jelenlegimezo = Palya[sor * 8 + oszlop];
                    Szinbeallitas(jelenlegimezo.tulajdonos);

                    Console.Write(" ");
                    Kijeloleshatter(sor, oszlop);

                    Console.Write(jelenlegimezo.tipus);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
        }
        void Szinbeallitas(string tulajdonos)
        {
            if (tulajdonos == URES)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            if (tulajdonos == PIROS)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (tulajdonos == KEK)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
        }
        void Kijeloleshatter(int sor, int oszlop)
        {
            if (Kijeloltoszlop == oszlop && Kijeloltsor == sor)
            {
                Console.BackgroundColor = ConsoleColor.White;
            }
            else if (Palya[sor * 8 + oszlop].idelepes == LEHETIDELEPNI)
            { 
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
            
        }
        void Babukijeloles()
        {
            int kijeloltsor;
            int kijeloltoszlop;
            if (kinekakore == PIROS)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.WriteLine();
            Console.WriteLine("Bábukijelölés");
            Console.Write("     sor: ");
            kijeloltsor = Convert.ToInt32(Console.ReadLine()) -1;
            Console.Write("     oszlop: ");
            kijeloltoszlop = Convert.ToInt32(Console.ReadLine()) -1 ;
            if(Palya[kijeloltsor * 8 + kijeloltoszlop].tulajdonos == kinekakore) 
            {
                Kijeloltsor = kijeloltsor;
                Kijeloltoszlop = kijeloltoszlop;
            }
        }
        void Hovalephet()
        {
            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    if (Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos != URES)
                    {
                        if (Kijeloltoszlop == oszlop - 1 && Kijeloltsor == sor && Palya[Kijeloltsor * 8 + Kijeloltoszlop + 1].tulajdonos == URES ||
                            Kijeloltoszlop == oszlop - 1 && Kijeloltsor == sor + 1 && Palya[(Kijeloltsor - 1) * 8 + Kijeloltoszlop + 1].tulajdonos == URES ||
                            Kijeloltoszlop == oszlop - 1 && Kijeloltsor == sor - 1 && Palya[(Kijeloltsor + 1)* 8 + Kijeloltoszlop + 1].tulajdonos == URES ||
                            Kijeloltoszlop == oszlop && Kijeloltsor == sor - 1 && Palya[(Kijeloltsor + 1) * 8 + Kijeloltoszlop].tulajdonos == URES ||
                            Kijeloltoszlop == oszlop && Kijeloltsor == sor + 1 && Palya[(Kijeloltsor - 1) * 8 + Kijeloltoszlop].tulajdonos == URES ||
                            Kijeloltoszlop == oszlop + 1 && Kijeloltsor == sor - 1 && Palya[(Kijeloltsor + 1) * 8 + Kijeloltoszlop - 1].tulajdonos == URES ||
                            Kijeloltoszlop == oszlop + 1 && Kijeloltsor == sor && Palya[Kijeloltsor * 8 + Kijeloltoszlop - 1].tulajdonos == URES ||
                            Kijeloltoszlop == oszlop + 1 && Kijeloltsor == sor + 1 && Palya[(Kijeloltsor - 1) * 8 + Kijeloltoszlop - 1].tulajdonos == URES)
                        {

                            Palya[sor * 8 + oszlop].idelepes = LEHETIDELEPNI;
                        }
                    }
                }
            }
        }
        void Lepes()
        {
            if (Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos != URES)
            {
                Lepesbekeres();
                if (Palya[Hovasor * 8 + Hovaoszlop].idelepes == LEHETIDELEPNI)
                {
                    Palya[Hovasor * 8 + Hovaoszlop].tulajdonos = Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos;
                    Palya[Hovasor * 8 + Hovaoszlop].tipus = Palya[Kijeloltsor * 8 + Kijeloltoszlop].tipus;

                    Palya[Kijeloltsor * 8 + Kijeloltoszlop].tulajdonos = URES;
                    Palya[Kijeloltsor * 8 + Kijeloltoszlop].tipus = URESMEZO;

                    if(kinekakore == PIROS) 
                    {
                        kinekakore = KEK;
                    }
                    else 
                    {
                        kinekakore = PIROS;
                    }
                }
                for (int sor = 0; sor < 8; sor++)
                {
                    for (int oszlop = 0; oszlop < 8; oszlop++)
                    {
                        Palya[sor * 8 + oszlop].idelepes = NEMLEHETIDELEPNI;
                    }
                }
            }

        }
        void Lepesbekeres()
        {
            if (kinekakore == PIROS)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.WriteLine();
            Console.WriteLine("Lépés");
            Console.Write("     sor: ");
            Hovasor = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("     oszlop: ");
            Hovaoszlop = Convert.ToInt32(Console.ReadLine()) - 1;
        }
    }
}
