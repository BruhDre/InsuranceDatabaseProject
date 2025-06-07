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
    public partial class PrikazKlijent : Form
    {
        public PrikazKlijent(string id)
        {
            InitializeComponent();

            Database db = new Database();
            string sql = "SELECT * FROM KLIJENT WHERE idKlijent=" + id;

            DataSet ds = new DataSet();
            ds = db.izvrsi(sql, "Klijent");
            string ime = ds.Tables[0].Rows[0]["ime"].ToString();
            string prezime = ds.Tables[0].Rows[0]["prezime"].ToString();
            txtIme.Text = ime + " " + prezime;
            txtJmbg.Text = ds.Tables[0].Rows[0]["jmbg"].ToString();
            txtDatum.Text= ds.Tables[0].Rows[0]["datumRodjenja"].ToString();
            string adresa= ds.Tables[0].Rows[0]["adresa"].ToString();
            string mesto= ds.Tables[0].Rows[0]["mesto"].ToString();
            txtAdresa.Text = adresa + ", " + mesto;
            txtTelefon.Text= ds.Tables[0].Rows[0]["telefon"].ToString();
            txtMejl.Text= ds.Tables[0].Rows[0]["mejl"].ToString();
            txtPol.Text= ds.Tables[0].Rows[0]["pol"].ToString();
        }

        private void PrikazKlijent_Load(object sender, EventArgs e)
        {

        }

        private void txtAdresa_Click(object sender, EventArgs e)
        {

        }
    }
}
