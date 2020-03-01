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
        public readonly int LEPHET = 3;

        public static readonly string FEKETE = "fekete";
        public static readonly string FEHER = "feher";
        public static readonly string URES = "ures";

        public string kinekakore = FEHER;

        public int Sor = 5;
        public int Oszlop = 1;
        

        static void Main(string[] args)
        {
            var program = new Program();

            while (true)
            {
                program.Palyafeltoltes();
                program.Palyakirajzolas();
                program.Babukijeloles();
                Console.Clear();
            }
        }
        
        void Palyafeltoltes() 
        {
            Urespalyafeltoltes();
            Babuhozzaad(0, 8, BASTYA, FEKETE);
            Babuhozzaad(8, 16, GYALOG, FEKETE);
            Babuhozzaad(48, 56, GYALOG, FEHER);
            Babuhozzaad(56, 64, BASTYA, FEHER);
        }
        void Urespalyafeltoltes() 
        {
            for (int i = 0; i < 64; i++)
            {
                Palya.Add(new Mezo(URESMEZO,URES));
            }
        }
        void Babuhozzaad(int mettol, int meddig, int mit, string tulajdonos) 
        {
            for (int i = mettol; i < meddig; i++)
            {
                Palya[i].tipus = mit;
                Palya[i].tulajdonos = tulajdonos;
                
            }
        }
       
        void Palyakirajzolas() 
        {
            Console.WriteLine("{0}-nek a köre van",kinekakore);
            Console.WriteLine();

             for (int sor = 0; sor < 8; sor++)
                {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    Mezo jelenlegimezo = Palya[oszlop + sor *8];
                    Szinbeallitas(jelenlegimezo.tulajdonos);

                    Console.Write(" ");
                    Hatterszin(sor, oszlop);
                    
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
            if (tulajdonos == FEKETE)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (tulajdonos == FEHER)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
        }
        void Hatterszin(int sor, int oszlop) 
        {
            if (Oszlop == oszlop && Sor == sor)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
            }
            if (Oszlop == oszlop - 1 && Sor == sor || Oszlop == oszlop - 1 && Sor == sor + 1 || Oszlop == oszlop - 1 && Sor == sor - 1 || Oszlop == oszlop && Sor == sor - 1 || Oszlop == oszlop && Sor == sor + 1 || Oszlop == oszlop + 1 && Sor == sor - 1 || Oszlop == oszlop + 1 && Sor == sor || Oszlop == oszlop + 1 && Sor == sor + 1)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
            }
        }
        void Babukijeloles()
        {
            Console.WriteLine("sor:");
            Sor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("oszlop");
            Oszlop = Convert.ToInt32(Console.ReadLine());
        }

        
    }
}
