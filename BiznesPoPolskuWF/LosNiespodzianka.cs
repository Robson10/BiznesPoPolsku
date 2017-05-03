using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiznesPoPolskuWF
{
    class Los : List<KartaItem>
    {
        public Los()
        {
            this.Add(new KartaItem("Trzeba uregulować rachunek za prąd i gaz. Płacisz 300 zł.", -300,0));
            this.Add(new KartaItem("Kontrola skarbowa - Płacisz 200 zł kary i czekasz 1 kolejkę", -200, 1));
            this.Add(new KartaItem("Bank wypłaca ci odsetki - otrzymujesz 300 zł.", 300, 0));
            this.Add(new KartaItem("Oddałeś butelki do punktu skupu - Otrzymujes 20 zł.", 20, 0));
            this.Add(new KartaItem("Dostajesz prezent od wujka z Ameryki - 500 zł.", 500, 0));
            this.Add(new KartaItem("Okradli cię. Tracisz 500zł.", 500, 0));
            this.Add(new KartaItem("Ofiarowałeś 1000 zł na akcję charytatywną.", 1000, 0));
            this.Add(new KartaItem("Stoisz w ulicznym korku - czekasz 1 kolejkę.", 0, 1));
            this.Add(new KartaItem("Obchodzisz imieniny. Otrzymujesz w prezencie 600 zł.", 600, 0));
            this.Add(new KartaItem("Zakupy w hipermarkecie nieoczekiwanie wyniosły cię 400 zł.", 400, 0));
        }
    }
    class Niespodzianka : List<KartaItem>
    {
        public Niespodzianka()
        {
            this.Add(new KartaItem("Trzeba uregulować rachunek za prąd i gaz. Płacisz 300 zł.", -300, 0));
            this.Add(new KartaItem("Kontrola skarbowa - Płacisz 200 zł kary i czekasz 1 kolejkę", -200, 1));
            this.Add(new KartaItem("Bank wypłaca ci odsetki - otrzymujesz 300 zł.", 300, 0));
            this.Add(new KartaItem("Oddałeś butelki do punktu skupu - Otrzymujes 20 zł.", 20, 0));
            this.Add(new KartaItem("Dostajesz prezent od wujka z Ameryki - 500 zł.", 500, 0));
            this.Add(new KartaItem("Okradli cię. Tracisz 500zł.", 500, 0));
            this.Add(new KartaItem("Ofiarowałeś 1000 zł na akcję charytatywną.", 1000, 0));
            this.Add(new KartaItem("Stoisz w ulicznym korku - czekasz 1 kolejkę.", 0, 1));
            this.Add(new KartaItem("Obchodzisz imieniny. Otrzymujesz w prezencie 600 zł.", 600, 0));
            this.Add(new KartaItem("Zakupy w hipermarkecie nieoczekiwanie wyniosły cię 400 zł.", 400, 0));
        }
    }
    public class KartaItem
    {
        public KartaItem(string _Informacja, int _Kwota, int _Kolejki)
        {
            Informacja = _Informacja;
            Kwota = _Kwota;
            Kolejki = _Kolejki;
        }
        public string Informacja { get; set; }
        public int Kwota { get; set; }//500zł
        public int Kolejki { get; set; }//czekasz 2 kolejki
    }
}
