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
    public partial class AgentProfil : Form
    {
        public string idA;
        public string mejl;
        public string pass;
        public AgentProfil(string id)
        {
            idA = id;
            InitializeComponent();

            Database db = new Database();
            string sql = "SELECT * FROM AGENT WHERE idAgent=" + idA;

            DataSet ds = db.izvrsi(sql, "Agent");
            txtNaziv.Text = ds.Tables[0].Rows[0]["naziv"].ToString();
            txtAdresa.Text = ds.Tables[0].Rows[0]["adresa"].ToString();
            txtTelefon.Text = ds.Tables[0].Rows[0]["telefon"].ToString();
            mejl = ds.Tables[0].Rows[0]["mejl"].ToString();
            txtMejl.Text = mejl;
            pass = ds.Tables[0].Rows[0]["sifra"].ToString();
        }

        private void izmena()
        {
            Database db = new Database();
            string sql = "UPDATE AGENT SET adresa='" + txtAdresa.Text + "'," +
                "naziv='" + txtNaziv.Text + "',mejl='" + txtMejl.Text + "',telefon='" + txtTelefon.Text + "' WHERE idAgent=" + idA;
            int p = db.izvrsi_proceduru(sql);
            if (p > 0)
            {
                MessageBox.Show("Uspesno izmenjeni podaci");
            }
            else
            {
                MessageBox.Show("Greska prilikom izmene podataka");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAdresa.Text == "" || txtNaziv.Text == "" || txtTelefon.Text == "" || txtMejl.Text == "")
            {
                MessageBox.Show("Niste popunili sve podatke");
            }
            else
            {
                Database db = new Database();
                string sql1 = "SELECT mejl FROM KLIJENT WHERE mejl='" + txtMejl.Text + "'";
                string sql2 = "SELECT mejl FROM AGENT WHERE mejl='" + txtMejl.Text + "'";
                string sql3 = "SELECT mejl FROM ADMIN WHERE mejl='"+txtMejl.Text + "'";

                DataSet ds1 = db.izvrsi(sql1, "Klijent");
                DataSet ds2 = db.izvrsi(sql2, "Agent");
                DataSet ds3 = db.izvrsi(sql3, "Admin");
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    if (ds2.Tables[0].Rows[0]["mejl"].ToString() != mejl)
                    {
                        MessageBox.Show("Uneti mejl je već u upotrebi");
                    }
                    else
                    {
                        izmena();
                    }
                }
                else if (ds1.Tables[0].Rows.Count > 0 || ds3.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Uneti mejl je već u upotrebi");
                }
                else
                {
                    izmena();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == "" || txtnewPass.Text == "" || txtConfirm.Text == "")
            {
                MessageBox.Show("Niste uneli sve podatke");
            }
            else
            {
                if (Form1.GetHashString(txtPass.Text) != pass)
                {
                    MessageBox.Show("Niste uneli ispravnu lozinku");
                }
                else if (txtnewPass.Text != txtConfirm.Text)
                {
                    MessageBox.Show("Nova lozinka i potvrda se ne poklapaju");
                }
                else
                {
                    Database db = new Database();
                    string sql = "UPDATE AGENT SET sifra='" + Form1.GetHashString(txtnewPass.Text) + "' " +
                        "WHERE idAgent=" + idA;
                    int p = db.izvrsi_proceduru(sql);
                    if (p > 0)
                    {
                        MessageBox.Show("Uspesno izmenjena lozinka");
                    }
                    else
                    {
                        MessageBox.Show("Greska prilikom izmene lozinke");
                    }
                }
            }
            txtPass.Clear();
            txtnewPass.Clear();
            txtConfirm.Clear();
        }
    }
}
