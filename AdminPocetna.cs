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
    public partial class AdminPocetna : Form
    {
        public AdminPocetna(string id)
        {
            string idA = id;
            InitializeComponent();

            Database db = new Database();
            string sql = "SELECT ime FROM ADMIN WHERE idAdmin=" + idA;

            DataSet ds = db.izvrsi(sql, "Admin");
            lblIme.Text = ds.Tables[0].Rows[0]["ime"].ToString();

            this.Width = Screen.FromControl(this).Bounds.Width;
            pictureBox1.Width = ClientSize.Width / 2;
            pictureBox1.Height = ClientSize.Height;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Location = new Point(ClientSize.Width / 2, 0);
            button1.Width = ClientSize.Width / 2 - button1.Width / 5;
            button2.Width = ClientSize.Width / 2 - button2.Width / 5;
            button3.Width = ClientSize.Width / 2 - button3.Width / 5;
            button4.Width = ClientSize.Width / 2 - button4.Width / 5;
            button5.Width = ClientSize.Width / 2 - button5.Width / 5;
        }

        private void AdminPocetna_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminKlijenti ak = new AdminKlijenti();
            ak.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminAgenti ag = new AdminAgenti();
            ag.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPonude ap = new AdminPonude();
            ap.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminUgovori au = new AdminUgovori();
            au.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminDogadjaji ad = new AdminDogadjaji();
            ad.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminIzvestaji ai = new AdminIzvestaji();
            ai.ShowDialog();
        }
    }
}
