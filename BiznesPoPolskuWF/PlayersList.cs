using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiznesPoPolskuWF
{
    public class PlayersList:List<PlayerItem>
    {
        private int AktualnyGraczIndex { get;  set; }
        public PlayerItem AktualnyGracz { get { return this[AktualnyGraczIndex]; } }

        public int RzutKostka()
        {
            Kosc.CzyRzucano = true;
            return Kosc.RzutKoscia();
        }
        public void NastepnaTura()
        {
            if (Kosc.CzyRzucano)
            {
                Kosc.CzyRzucano = false;
                AktualnyGraczIndex++;
                if (AktualnyGraczIndex >= this.Count) AktualnyGraczIndex = 0;
                while (AktualnyGracz.StoiKolejek > 0)
                {
                    AktualnyGracz.StoiKolejek--;
                    AktualnyGraczIndex++;
                    if (AktualnyGraczIndex >= this.Count)AktualnyGraczIndex = 0;
                } 
            }
            else
                System.Windows.Forms.MessageBox.Show("Nim zakończysz turę musisz rzucić kostką");
        }
        public List<string> PrzejrzyjStatystyki(ref List<pole> pola, PlayerItem gracz)
        {
            List<string> temp = new List<string>();
            temp.Add(gracz.Nazwa);
            temp.Add(gracz.Saldo.ToString());
            for (int i = 0; i < pola.Count; i++)
                if (pola[i].czyje == gracz.Nazwa)
                    temp.Add(pola[i].nazwa_pola);
            return temp;
        }

        public void UtrataZawodu()
        {
            AktualnyGracz.PosiadanyZawod = -1;
        }
        public void PobierzOplateZaStart()
        {
            AktualnyGracz.Saldo += 300;
        }
        public void OglosBankructwoGracza()
        {
            if (AktualnyGracz.Saldo < 0)
            {
                System.Windows.Forms.MessageBox.Show("Zbankrutowałeś");
                AktualnyGracz.PictureBox.Dispose();
                this.Remove(AktualnyGracz);
            }

        }

        public void UstalKolejnoscGraczy()
        {
            var temp = this.OrderBy(a => Guid.NewGuid()).ToList();
            this.Clear();
            this.AddRange(temp);
            for (int i = 0; i < this.Count; i++)
            {
                this[i].PictureBox.BackColor= System.Drawing.Color.FromArgb(i*50,i*50,i*50);
            }
            PrzydzielSaldo();
        }
        public void ZaplacInnemuGraczowi(int kara, string czyjePole)
        {
            AktualnyGracz.Saldo -= kara;
            this[this.FindIndex(x => x.Nazwa.Equals(czyjePole))].Saldo+=kara;
            OglosBankructwoGracza();
        }
        public void PrzydzielSaldo(int kwota=20000)
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Saldo = kwota;
            }
        }
        public void Inwestuj(int kwota)
        {
            AktualnyGracz.Saldo -= kwota;
        }
        public void ZastosujSieDoInstrukcjiKarty(KartaItem karta)
        {
            AktualnyGracz.Saldo -= karta.Kwota;
            AktualnyGracz.StoiKolejek += karta.Kolejki;
            OglosBankructwoGracza();
        }
    }
    public class PlayerItem
    {
        public System.Windows.Forms.PictureBox PictureBox = new System.Windows.Forms.PictureBox();
        public string Nazwa { get; set; }
        public int RzutKoscia()
        {
            return Kosc.RzutKoscia();
        }
        public int PosiadanyZawod { get; set; }
        public int Saldo;
        public int StoiKolejek=0;
        public int Pozycja { get; set; } = 0;
    }
}
