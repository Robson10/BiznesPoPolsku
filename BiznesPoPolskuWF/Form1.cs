using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiznesPoPolskuWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PlayersList PlayerList = new PlayersList();
        List<pole> Pola = new List<pole>();

        private void Form1_Load(object sender, EventArgs e)
        {
            //tempMethod(PlayerList);
            CreatePlayers();
            StworzPlansze();
        }

        private void RzutKostkaBT_Click(object sender, EventArgs e)
        {
            RzutKostka();
        }

        private void NastepnaTuraBT_Click(object sender, EventArgs e)
        {
            NastepnaTura();
        }

        private void Gracz1Button_Click(object sender, EventArgs e)
        {
            Gracz13Info.Visible = true;
            Gracz13InfoCombo.Items.Clear();
            Gracz13InfoCombo.Text = PlayerList[0].Nazwa;
            Gracz13InfoCombo.Items.AddRange(PlayerList.PrzejrzyjStatystyki(ref Pola, PlayerList[0]).ToArray());
        }

        private void Gracz3Button_Click(object sender, EventArgs e)
        {
            Gracz13Info.Visible = true;
            Gracz13InfoCombo.Items.Clear();
            Gracz13InfoCombo.Text = PlayerList[2].Nazwa;
            Gracz13InfoCombo.Items.AddRange(PlayerList.PrzejrzyjStatystyki(ref Pola, PlayerList[2]).ToArray());
        }

        private void Gracz2Button_Click(object sender, EventArgs e)
        {
            Gracz24Info.Visible = true;
            Gracz24InfoCombo.Items.Clear();
            Gracz24InfoCombo.Text = PlayerList[1].Nazwa;
            Gracz24InfoCombo.Items.AddRange(PlayerList.PrzejrzyjStatystyki(ref Pola, PlayerList[1]).ToArray());
        }

        private void Gracz4Button_Click(object sender, EventArgs e)
        {
            Gracz24Info.Visible = true;
            Gracz24InfoCombo.Items.Clear();
            Gracz24InfoCombo.Text = PlayerList[3].Nazwa;
            Gracz24InfoCombo.Items.AddRange(PlayerList.PrzejrzyjStatystyki(ref Pola, PlayerList[3]).ToArray());
        }

        private void TakBT_Click(object sender, EventArgs e)
        {
            Inwestuj();
        }

        private void NieBT_Click(object sender, EventArgs e)
        {
            TakBT.Visible = false;
            NieBT.Visible = false;
        }
    }
}
