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
    public partial class PrikazAgent : Form
    {
        public string idA;
        public PrikazAgent(string id)
        {
            idA= id;
            InitializeComponent();

            Database db = new Database();
            string sql = "SELECT * FROM AGENT WHERE idAgent=" + idA;

            DataSet ds = db.izvrsi(sql, "Agent");
            lblNaziv.Text = ds.Tables[0].Rows[0]["naziv"].ToString();
            lblAdresa.Text = ds.Tables[0].Rows[0]["adresa"].ToString();
            lblMail.Text = ds.Tables[0].Rows[0]["mejl"].ToString();
            lblTelefon.Text = ds.Tables[0].Rows[0]["telefon"].ToString();
        }

        private void PrikazAgent_Load(object sender, EventArgs e)
        {

        }
    }
}
