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
    public partial class CreateUsers : Form
    {
        public CreateUsers(ref PlayersList PlayerList)
        {
            InitializeComponent();
            TempPlayerList = PlayerList;
        }
        PlayersList TempPlayerList;
        private void Play_Click(object sender, EventArgs e)
        {
            TempPlayerList.Add(new PlayerItem() { Nazwa = textBox1.Text });
            TempPlayerList.Add(new PlayerItem() { Nazwa = textBox2.Text });
            TempPlayerList.Add(new PlayerItem() { Nazwa = textBox3.Text });
            TempPlayerList.Add(new PlayerItem() { Nazwa = textBox4.Text });
            TempPlayerList.UstalKolejnoscGraczy();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}