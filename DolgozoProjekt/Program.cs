using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DolgozoProjekt
{
    class Program
    {
        public string fajlnev;
        static public List<Dolgozo> dolgozok;
        static public void beolvas()
        {
            dolgozok = new List<Dolgozo>();
            using (var olv = new StreamReader("adatok.txt"))
            {
                while (!olv.EndOfStream)
                {
                    string[] sor = olv.ReadLine().Split(' ');
                    string vezetekNev = sor[0];
                    string Keresztnev = sor[1];
                    string nem = sor[2];
                    int eletkor = Convert.ToInt32(sor[3]);
                    int fizetes = Convert.ToInt32(sor[4]);
                    var dolgozik = new Dolgozo(vezetekNev, Keresztnev, nem, eletkor, fizetes);
                    dolgozok.Add(dolgozik);
                }
            }
        }

        static void Main(string[] args)
        {
            beolvas();
            harmadikFeladat();
            negyedikFeladat();
            otodikFeladat();
            hatodikFeladat();
            hetedikFeladat();
            Console.ReadLine();
        }

        static public void harmadikFeladat()
        {
            int count = dolgozok.Count;
            Console.WriteLine("3. feladat: Dolgozók száma: {0}", count);
        }

        static public void negyedikFeladat()
        {
            int fiatal = 0;
            int osszFizu = 0;
            foreach (var item in dolgozok)
            {
                if (item.Eletkor < 25)
                {
                    fiatal++;
                    osszFizu += item.Fizetes;
                }
            }
            Console.WriteLine("4. feladat: 25 év alattiak összfizetése: {0} Ft", osszFizu);
        }

        static public void otodikFeladat()
        {
            int legnagyobbFizu = 0;
            string vezetekNev = "";
            string keresztnev = "";
            string nem = "";
            int eletkor = 0;
            foreach (var item in dolgozok)
            {
                if (item.Fizetes > legnagyobbFizu)
                {
                    legnagyobbFizu = item.Fizetes;
                    vezetekNev = item.VezetekNev1;
                    keresztnev = item.KeresztNev1;
                    nem = item.Nem1;
                    eletkor = item.Eletkor;
                }
            }
            Console.WriteLine("5. feladat: A legnagyobb fizetésű dolgozó adatai: \nA dolgozó neve: {0} {1} \nNeme: {2} \nÉletkora: {3} \nFizetése: {4} Ft ", vezetekNev, keresztnev, nem, eletkor, legnagyobbFizu);
        }

        static public void hatodikFeladat()
        {
            Console.Write("Kérem adjon meg egy összeget: ");
            int bekert = Convert.ToInt32(Console.ReadLine());

            bool vanOlyan = false;
            foreach (var item in dolgozok)
            {
                if (item.Fizetes > bekert)
                {
                    vanOlyan = true;
                }
            }
            if (vanOlyan)
            {
                Console.WriteLine(" Van olyan dolgozó, akinek a fizetése {0} Ft felett van ", bekert);
            }
            else
            {
                Console.WriteLine(" Nincs olyan dolgozó, akinek a fizetése {0} Ft felett van ", bekert);
            }
        }

        static public void hetedikFeladat()
        {
            using (var ir = new StreamWriter("diakok.txt"))
            {
                foreach (var item in dolgozok)
                {
                    if (item.Eletkor < 25)
                    {
                        string vezetekNev = item.VezetekNev1;
                        string Keresztnev = item.KeresztNev1;
                        string nem = item.Nem1;
                        int eletkor = item.Eletkor;
                        int fizetes = item.Fizetes;
                        ir.WriteLine("{0} {1} {2} {3} {4} Ft", vezetekNev, Keresztnev, nem, eletkor, fizetes);
                    }
                }
            }
        }
    }
}
