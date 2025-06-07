using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zavrsni
{
    public partial class KlijentProfil : Form
    {
        public string idK;
        public string mejl;
        public string pass;
        public KlijentProfil(string id)
        {
            idK = id;
            InitializeComponent();

            Database db = new Database();
            string sql = "SELECT * FROM KLIJENT WHERE idKlijent=" + idK;

            DataSet ds = db.izvrsi(sql, "Klijent");
            string ime = ds.Tables[0].Rows[0]["ime"].ToString();
            string prezime = ds.Tables[0].Rows[0]["prezime"].ToString();
            lblIme.Text = ime + " " + prezime;
            lblJMBG.Text = ds.Tables[0].Rows[0]["jmbg"].ToString();
            lbldatum.Text = ((DateTime)ds.Tables[0].Rows[0]["datumRodjenja"]).ToString("dd/MM/yyyy");
            string pol = ds.Tables[0].Rows[0]["pol"].ToString();
            if (pol == "M")
                cbPol.SelectedIndex = 0;
            else if (pol == "Ž") 
                cbPol.SelectedIndex = 1;
            else 
                cbPol.SelectedIndex = 2;
            txtAdresa.Text = ds.Tables[0].Rows[0]["adresa"].ToString();
            txtMesto.Text = ds.Tables[0].Rows[0]["mesto"].ToString();
            txtTelefon.Text = ds.Tables[0].Rows[0]["telefon"].ToString();
            mejl = ds.Tables[0].Rows[0]["mejl"].ToString();
            txtMejl.Text = mejl;
            pass = ds.Tables[0].Rows[0]["sifra"].ToString();
        }

        private void KlijentProfil_Load(object sender, EventArgs e)
        {

        }

        private void izmena()
        {
            string pol = "M";
            if (cbPol.SelectedIndex == 1)
                pol = "Ž";
            else if (cbPol.SelectedIndex == 2)
                pol = "O";

            Database db = new Database();
            string sql = "UPDATE KLIJENT SET pol='" + pol + "',adresa='" + txtAdresa.Text + "'," +
                "mesto='" + txtMesto.Text + "',mejl='" + txtMejl.Text + "',telefon='" + txtTelefon.Text + "' WHERE idKlijent=" + idK;
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
            if (txtAdresa.Text=="" || txtMesto.Text=="" || txtTelefon.Text=="" || txtMejl.Text=="")
            {
                MessageBox.Show("Niste popunili sve podatke");
            }
            else
            {
                Database db = new Database();
                string sql1 = "SELECT mejl FROM KLIJENT WHERE mejl='" + txtMejl.Text + "'";
                string sql2 = "SELECT mejl FROM AGENT WHERE mejl='" + txtMejl.Text + "'";
                string sql3 = "SELECT mejl FROM ADMIN WHERE mejl='" + txtMejl.Text + "'";

                DataSet ds1 = db.izvrsi(sql1, "Klijent");
                DataSet ds2 = db.izvrsi(sql2, "Agent");
                DataSet ds3 = db.izvrsi(sql3, "Admin");
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0]["mejl"].ToString() != mejl)
                    {
                        MessageBox.Show("Uneti mejl je već u upotrebi");
                    }
                    else
                    {
                        izmena();
                    }
                }
                else if (ds2.Tables[0].Rows.Count > 0 || ds3.Tables[0].Rows.Count > 0)
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
            if (txtPass.Text=="" || txtnewPass.Text=="" || txtConfirm.Text=="")
            {
                MessageBox.Show("Niste uneli sve podatke");
            }
            else
            {
                if (Form1.GetHashString(txtPass.Text)!=pass)
                {
                    MessageBox.Show("Niste uneli ispravnu lozinku");
                }
                else if (txtnewPass.Text!=txtConfirm.Text)
                {
                    MessageBox.Show("Nova lozinka i potvrda se ne poklapaju");
                }
                else
                {
                    Database db = new Database();
                    string sql = "UPDATE KLIJENT SET sifra='" + Form1.GetHashString(txtnewPass.Text) + "' " +
                        "WHERE idKlijent=" + idK;
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
