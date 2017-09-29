using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiznesPoPolskuWF
{
    public partial class Form1
    {
        
        private void NastepnaTura()
        {
            //metoda Nr 2
            PlayerList.NastepnaTura();
            Gracz13Info.Visible = false;
            Gracz24Info.Visible = false;
            TakBT.Visible = false;
            NieBT.Visible = false;
            Gracz13Info.Visible = false;
            Gracz24Info.Visible = false; 
            PrzebiegGryTB.Text = "Teraz tura gracza: " + PlayerList.AktualnyGracz.Nazwa+Environment.NewLine;
        }
                
        private void RzutKostka()
        {
            // metoda Nr 1
            if (!Kosc.CzyRzucano)
            {
                int wyrzuconaWartosc = PlayerList.RzutKostka();
                PrzebiegGryTB.Text += "Wyrzuciłeś: " + wyrzuconaWartosc + Environment.NewLine;
                PrzesunNaPole(wyrzuconaWartosc);
            }
            else
                PrzebiegGryTB.Text += "Już rzucałeś kostką" + Environment.NewLine;
        }
                
        private void PrzesunNaPole(int value)
        {
            //metoda nr 5
            Pola[PlayerList.AktualnyGracz.Pozycja].Pole.Controls.Remove(PlayerList.AktualnyGracz.PictureBox);
            PlayerList.AktualnyGracz.Pozycja += value;
            if (PlayerList.AktualnyGracz.Pozycja > 39)
            {
                PlayerList.AktualnyGracz.Pozycja -= 39;
                PlayerList.PobierzOplateZaStart();
            }
            Pola[PlayerList.AktualnyGracz.Pozycja].Pole.Controls.Add(PlayerList.AktualnyGracz.PictureBox);

            if (Pola[PlayerList.AktualnyGracz.Pozycja].dochod > 0)
            {
                PodejmijZawod();
            }
            else if(PlayerList.AktualnyGracz.Pozycja==2 || PlayerList.AktualnyGracz.Pozycja==11)
            { PlayerList.AktualnyGracz.StoiKolejek += 1; }
            else if (PlayerList.AktualnyGracz.Pozycja==23)
            { PlayerList.AktualnyGracz.StoiKolejek += 2; }
            else if(Pola[PlayerList.AktualnyGracz.Pozycja].czyje == null && Pola[PlayerList.AktualnyGracz.Pozycja].cena>0)//kupno
            {
                if (Pola[PlayerList.AktualnyGracz.Pozycja].cena <= PlayerList.AktualnyGracz.Saldo)
                {
                    PrzebiegGryTB.Text += "Stanąłeś na polu: " + Pola[PlayerList.AktualnyGracz.Pozycja].nazwa_pola + Environment.NewLine + "Możesz je kupić" + Environment.NewLine;
                    TakBT.Visible = true;
                    NieBT.Visible = true;
                }
            }
            else if (Pola[PlayerList.AktualnyGracz.Pozycja].czyje != null)
            { 
             if (Pola[PlayerList.AktualnyGracz.Pozycja].czyje.Equals(PlayerList.AktualnyGracz.Nazwa))//ulepszanie
                {
                    if (Pola[PlayerList.AktualnyGracz.Pozycja].upgrade_lv >= 5)
                    {
                        PrzebiegGryTB.Text += "Stanąłeś na polu: " + Pola[PlayerList.AktualnyGracz.Pozycja].nazwa_pola + Environment.NewLine + "Niestety osiągnęło ono maksymalny poziom" + Environment.NewLine;
                    }
                    else
                    {
                        if (Pola[PlayerList.AktualnyGracz.Pozycja].upgrade_cena <= PlayerList.AktualnyGracz.Saldo)
                        {
                            PrzebiegGryTB.Text += "Stanąłeś na polu: " + Pola[PlayerList.AktualnyGracz.Pozycja].nazwa_pola + Environment.NewLine + "Możesz je ulepszyć na poziom: " + (Pola[PlayerList.AktualnyGracz.Pozycja].upgrade_lv + 1) + Environment.NewLine;
                            TakBT.Visible = true;
                            NieBT.Visible = true;
                        }
                    }
                }
                else if (!Pola[PlayerList.AktualnyGracz.Pozycja].czyje.Equals(PlayerList.AktualnyGracz.Nazwa))//kara
                {
                    ZaplacInnemuGraczowi();
                }
                else if (Pola[PlayerList.AktualnyGracz.Pozycja].nazwa_pola.Equals("Niespodzianka"))//niespodzianka
                {
                    WybierzKarteLosuLubNiespodzianki("Niespodzianka");
                }
                else if (Pola[PlayerList.AktualnyGracz.Pozycja].nazwa_pola.Equals("Los"))//los
                {
                    WybierzKarteLosuLubNiespodzianki("Los");
                }
            }
        }
                
        private void Inwestuj() //Sprawdzenie w btn TAK
        {
            //metoda nr 6
            if (Pola[PlayerList.AktualnyGracz.Pozycja].czyje == null)
            {
                Pola[PlayerList.AktualnyGracz.Pozycja].czyje = PlayerList.AktualnyGracz.Nazwa;
                PlayerList.Inwestuj(Pola[PlayerList.AktualnyGracz.Pozycja].cena);
            }
            else
            {
                Pola[PlayerList.AktualnyGracz.Pozycja].upgrade_lv++;
                PlayerList.Inwestuj(Pola[PlayerList.AktualnyGracz.Pozycja].upgrade_cena);
            }
            TakBT.Visible = false;
            NieBT.Visible = false;
        }

        private void ZaplacInnemuGraczowi()
        {
            PrzebiegGryTB.Text += "Stanąłeś na polu: " + Pola[PlayerList.AktualnyGracz.Pozycja].nazwa_pola + Environment.NewLine +
                    "Nalezy ono do gracza: " + Pola[PlayerList.AktualnyGracz.Pozycja].czyje + Environment.NewLine +
                    "Musisz zaplacić: " + Pola[PlayerList.AktualnyGracz.Pozycja].kara + Environment.NewLine;
            PlayerList.ZaplacInnemuGraczowi(Pola[PlayerList.AktualnyGracz.Pozycja].kara, Pola[PlayerList.AktualnyGracz.Pozycja].czyje);
            if (PlayerList.OglosBankructwoGracza())
            {
                NastepnaTura();
            }
        }

        Los los = new Los();
        Niespodzianka niespodzianka = new Niespodzianka();
        
        private void Rezygnacja()
        {
            //metoda nr 14
            PlayerList.Rezygnacja();
            NastepnaTura();
        }
        
        private void WybierzKarteLosuLubNiespodzianki(string wariant)
        {
            //metoda nr 8
            if (wariant.Equals("Niespodzianka"))
            {
                int NrKarty = new Random().Next(0,niespodzianka.Count);
                System.Windows.Forms.MessageBox.Show(niespodzianka[NrKarty].Informacja);
                PlayerList.ZastosujSieDoInstrukcjiKarty(niespodzianka[NrKarty]);
                if (PlayerList.OglosBankructwoGracza())
                {
                    NastepnaTura();
                }
            }
            else if (wariant.Equals("Los"))
            {
                int NrKarty = new Random().Next(0, los.Count);
                System.Windows.Forms.MessageBox.Show(los[NrKarty].Informacja);
                PlayerList.ZastosujSieDoInstrukcjiKarty(los[NrKarty]);
                if (PlayerList.OglosBankructwoGracza())
                {
                    NastepnaTura();
                }
            }
        }

        public void PodejmijZawod()
        {
            //metoda nr 15
            if (Pola[PlayerList.AktualnyGracz.Pozycja].cena==0)//cena 0 to zawod -1 to np START
            {
                if (Pola[PlayerList.AktualnyGracz.Pozycja].czyje == null)
                {
                    PrzebiegGryTB.Text += "Stanąłeś na polu: " + Pola[PlayerList.AktualnyGracz.Pozycja].nazwa_pola + Environment.NewLine + "Czy chcesz podjąć ten zawód?" + Environment.NewLine;
                    TakBT.Visible = true;
                    NieBT.Visible = true;
                }
                else if (Pola[PlayerList.AktualnyGracz.Pozycja].czyje.Equals(PlayerList.AktualnyGracz.Nazwa))
                {
                    PrzebiegGryTB.Text += "Stanąłeś na polu: " + Pola[PlayerList.AktualnyGracz.Pozycja].nazwa_pola + Environment.NewLine +
                       "Otrzymujesz pensje: " + Pola[PlayerList.AktualnyGracz.Pozycja].dochod + Environment.NewLine;
                    PlayerList.AktualnyGracz.Saldo += Pola[PlayerList.AktualnyGracz.Pozycja].dochod;
                }
                else
                {
                    PrzebiegGryTB.Text += "Stanąłeś na polu: " + Pola[PlayerList.AktualnyGracz.Pozycja].nazwa_pola + Environment.NewLine +
                        "Należy ono do gracza: "+ Pola[PlayerList.AktualnyGracz.Pozycja].czyje+Environment.NewLine+
                           "Musisz zapłacić: " + Pola[PlayerList.AktualnyGracz.Pozycja].kara + Environment.NewLine;
                    PlayerList.ZaplacInnemuGraczowi(Pola[PlayerList.AktualnyGracz.Pozycja].kara, Pola[PlayerList.AktualnyGracz.Pozycja].czyje);
                    if (PlayerList.OglosBankructwoGracza())
                    {
                        NastepnaTura();
                    }
                }
            }
        }
    }
}
