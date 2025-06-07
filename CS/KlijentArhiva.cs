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
    public partial class KlijentArhiva : Form
    {
        public KlijentArhiva()
        {
            InitializeComponent();

            Database db = new Database();
            string sql = "SELECT idKlijent,ime,prezime,jmbg,datumRodjenja,pol,adresa,mesto,mejl,telefon FROM KLIJENT_ARHIVA";

            DataSet ds = db.izvrsi(sql, "Klijenti");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Klijenti";

            this.Width = Screen.FromControl(this).Bounds.Width;
            dataGridView1.Width = ClientSize.Width;
            dataGridView1.Height = ClientSize.Height;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void KlijentArhiva_Load(object sender, EventArgs e)
        {

        }
    }
}
