using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Zavrsni
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Width = Screen.FromControl(this).Bounds.Width;
            txtMejl.Location = new Point(ClientSize.Width / 2 - label1.Width, txtMejl.Location.Y);
            txtPass.Location = new Point(txtMejl.Location.X, txtPass.Location.Y + txtPass.Height);
            label1.Location = new Point(txtMejl.Location.X - label1.Width, txtMejl.Location.Y);
            label2.Location = new Point(txtPass.Location.X - label2.Width, txtPass.Location.Y);
            button1.Location = new Point(label1.Location.X, button1.Location.Y + txtPass.Height * 2);
            button2.Location = new Point(button1.Location.X + button1.Width + button2.Width / 4, button1.Location.Y);
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mejl = txtMejl.Text;
            string pass = txtPass.Text;

            Database db = new Database();
            string sql = "SELECT * FROM KLIJENT WHERE mejl='" + mejl + "' AND sifra='" + GetHashString(pass)+"'";

            DataSet ds = db.izvrsi(sql, "Klijenti");
            if (ds.Tables[0].Rows.Count == 0)
            {
                string sql2 = "SELECT * FROM AGENT WHERE mejl='" + mejl + "' AND sifra='" + GetHashString(pass) + "'";

                DataSet ds2 = db.izvrsi(sql2, "Agenti");
                if (ds2.Tables[0].Rows.Count == 0) 
                {
                    string sql3 = "SELECT * FROM ADMIN WHERE mejl='" + mejl + "' AND sifra='" + GetHashString(pass) + "'";

                    DataSet ds3 = db.izvrsi(sql3, "Admini");
                    if (ds3.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Niste uneli ispravne podatke!");
                        txtPass.Clear();
                    }
                    else
                    {
                        string id = ds3.Tables[0].Rows[0]["idAdmin"].ToString();
                        AdminPocetna kp=new AdminPocetna(id);
                        kp.ShowDialog();
                        txtPass.Clear();
                    }
                }
                else
                {
                    string id = ds2.Tables[0].Rows[0]["idAgent"].ToString();
                    AgentPocetna kp = new AgentPocetna(id);
                    kp.ShowDialog();
                    txtPass.Clear();
                }
            }
            else
            {
                string id = ds.Tables[0].Rows[0]["idKlijent"].ToString();
                KlijentPocetna kp = new KlijentPocetna(id);
                kp.ShowDialog();
                txtPass.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Registracija rg = new Registracija();
            rg.ShowDialog();
        }
    }
}
