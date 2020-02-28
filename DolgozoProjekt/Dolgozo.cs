using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozoProjekt
{
    class Dolgozo
    {
        string VezetekNev, KeresztNev, Nem;
        int eletkor, fizetes;

        public Dolgozo(string vezetekNev, string keresztNev, string nem, int eletkor, int fizetes)
        {
            VezetekNev = vezetekNev;
            KeresztNev = keresztNev;
            Nem = nem;
            this.eletkor = eletkor;
            this.fizetes = fizetes;
        }

        public string VezetekNev1 { get => VezetekNev; set => VezetekNev = value; }
        public string KeresztNev1 { get => KeresztNev; set => KeresztNev = value; }
        public string Nem1 { get => Nem; set => Nem = value; }
        public int Eletkor { get => eletkor; set => eletkor = value; }
        public int Fizetes { get => fizetes; set => fizetes = value; }
    }
}
