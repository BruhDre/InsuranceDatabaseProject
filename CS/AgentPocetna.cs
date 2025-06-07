using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zavrsni
{
    public partial class AgentPocetna : Form
    {
        public string idA;
        public AgentPocetna(string id)
        {
            idA = id;
            InitializeComponent();

            Database db = new Database();
            string sql = "SELECT naziv FROM AGENT WHERE idAgent=" + idA;

            DataSet ds = db.izvrsi(sql, "Agent");
            lblIme.Text = ds.Tables[0].Rows[0]["naziv"].ToString();

            this.Width = Screen.FromControl(this).Bounds.Width;
            pictureBox1.Width = ClientSize.Width / 2;
            pictureBox1.Height = ClientSize.Height;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Location = new Point(ClientSize.Width / 2, 0);
            button1.Width = ClientSize.Width / 2 - button1.Width / 5;
            button2.Width = ClientSize.Width / 2 - button2.Width / 5;
            button3.Width = ClientSize.Width / 2 - button3.Width / 5;
            button4.Width = ClientSize.Width / 2 - button4.Width / 5;
        }

        private void AgentPocetna_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgentProfil ap = new AgentProfil(idA);
            ap.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AgentPonude ap = new AgentPonude(idA);
            ap.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AgentUgovori au=new AgentUgovori(idA); 
            au.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AgentIzvestaji ai=new AgentIzvestaji(idA);
            ai.ShowDialog();
        }
    }
}
