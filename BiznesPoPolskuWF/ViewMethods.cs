using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace BiznesPoPolskuWF
{
    public partial class Form1 
    {
        private void CreatePlayers()
        {
            CreateUsers CreateUsersWindow = new CreateUsers(ref PlayerList);
            if (CreateUsersWindow.ShowDialog() == DialogResult.OK) { }
        }
        public static void tempMethod(PlayersList PlayerList)
        {
            PlayerList.Add(new PlayerItem() { Nazwa = "gracz1" });
            PlayerList.Add(new PlayerItem() { Nazwa = "gracz2" });
            //PlayerList.Add(new PlayerItem() { Nazwa = "gracz3" });
            //PlayerList.Add(new PlayerItem() { Nazwa = "gracz4" });
            PlayerList.UstalKolejnoscGraczy();

        }
        private void StworzPlansze()
        {
            this.WindowState = FormWindowState.Maximized;
            for (int i = 0; i < 40; i++) Pola.Add(new pole(i));
            WypelnijPaneleGraczy();
            WypelnijPanelPlanszy(PlanszaPanel);
            UserActionPanel.Location = new Point(PlanszaPanel.Width / 2 - UserActionPanel.Width / 2, PlanszaPanel.Height / 2 - UserActionPanel.Height / 2);
            DodajPionkiGraczy();
        }
        private void WypelnijPaneleGraczy()
        {
            try
            {
                Gracz1Label.Text = PlayerList[0].Nazwa;
                Gracz2Label.Text = PlayerList[1].Nazwa;
                Gracz3Label.Text = PlayerList[2].Nazwa;
                Gracz4Label.Text = PlayerList[3].Nazwa;
            }
            catch
            {
                if (PlayerList.Count < 4) { Gracz4Panel.Visible = false; }
                if (PlayerList.Count < 3) { Gracz3Panel.Visible = false; }
                if (PlayerList.Count < 2) { Gracz2Panel.Visible = false; }
            }
        }
        private void WypelnijPanelPlanszy(Panel panel)
        {
            for (int i = 0; i < Pola.Count; i++) panel.Controls.Add(Pola[i].Pole);
            int szer = (panel.Width) / 14;
            int wys = panel.Height / 12;
            int pX = 0;
            int pY = 0;
            for (int i = 0; i <= 11; i++)
            {//21->32
                Pola[i].Pole.Location = new Point(pX, 0);
                Pola[31 - i].Pole.Location = new Point(pX, wys * 10);
                if (i == 0 || i == 11)
                {
                    Pola[i].Pole.Size = new Size(szer * 2, wys * 2);
                    Pola[31 - i].Pole.Size = new Size(szer * 2, wys * 2);
                    pX += 2 * szer;
                }
                else
                {
                    Pola[i].Pole.Size = new Size(szer, wys * 2);
                    Pola[31 - i].Pole.Size = new Size(szer, wys * 2);
                    pX += szer;
                }
            }
            pY += wys * 2;
            for (int i = 12; i <= 19; i++)
            {//33->40
                Pola[i].Pole.Location = new Point(szer * 12, pY);
                Pola[39 + 12 - i].Pole.Location = new Point(0, pY);

                Pola[i].Pole.Size = new Size(szer * 2, wys);
                Pola[39 + 12 - i].Pole.Size = new Size(szer * 2, wys);
                pY += wys;
            }
        }
        private void DodajPionkiGraczy()
        {
            for (int i = 0; i < PlayerList.Count; i++)
            {
                Pola[PlayerList[i].Pozycja].Pole.Controls.Add(PlayerList[i].PictureBox);
            }
        }
    }
}
