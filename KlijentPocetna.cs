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
    public partial class KlijentPocetna : Form
    {
        public string idK;
        public KlijentPocetna(string id)
        {
            idK = id;
            InitializeComponent();

            Database db = new Database();
            string sql = "SELECT ime,prezime FROM KLIJENT WHERE idKlijent=" + idK;

            DataSet ds = db.izvrsi(sql, "Klijent");
            string ime = ds.Tables[0].Rows[0]["ime"].ToString();
            string prezime = ds.Tables[0].Rows[0]["prezime"].ToString();
            lblIme.Text = ime + " " + prezime;

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

        private void KlijentPocetna_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            KlijentProfil kp=new KlijentProfil(idK); 
            kp.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PonudeKlijent pk = new PonudeKlijent(idK);
            pk.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KlijentUgovori ku = new KlijentUgovori(idK);
            ku.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KlijentIzvestaji ki = new KlijentIzvestaji(idK);
            ki.ShowDialog();
        }
    }
}
