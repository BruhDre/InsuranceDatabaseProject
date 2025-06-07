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
    public partial class PrijavaDogadjaja : Form
    {
        public string idU;
        public PrijavaDogadjaja(string id)
        {
            idU = id;
            InitializeComponent();

            Database db = new Database();
            string prvo = "SELECT idPonuda FROM UGOVOR WHERE idUgovor=" + idU;
            DataSet ds1 = db.izvrsi(prvo, "Ponuda");
            string idP = ds1.Tables[0].Rows[0]["idPonuda"].ToString();


            string sql = "SELECT idDogadjaj as 'ID',opis as 'Opis',odsteta as 'Odšteta'" +
                " FROM DOGADJAJ,PONUDA WHERE statusDogadjaj='Aktivan' AND " +
                "DOGADJAJ.idPonuda=PONUDA.idPonuda and PONUDA.idPonuda=" + idP;

            DataSet ds = db.izvrsi(sql, "Dogadjaji");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Dogadjaji";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void PrijavaDogadjaja_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                var id = dr.Cells["ID"].Value.ToString();

                Database db = new Database();
                string prvo = "SELECT COUNT(idIzvestaj) as 'K' FROM IZVESTAJ WHERE idUgovor=" + idU;
                DataSet ds = db.izvrsi(prvo, "pom");
                string pom = ds.Tables[0].Rows[0]["K"].ToString();

                string sql = "exec sp_novi_izvestaj " + idU + "," + id;

                int i = db.izvrsi_proceduru(sql);
                if (i > 0)
                {
                    DataSet ds2 = db.izvrsi(prvo, "pom2");
                    if (pom == ds2.Tables[0].Rows[0]["K"].ToString())
                    {
                        MessageBox.Show("Mesečni limit je prekoračen");
                    }
                    else
                        MessageBox.Show("Uspešno kreiran izveštaj");
                }
                else
                    MessageBox.Show("Greška pri kreiranju izveštaja");
            }
        }
    }
}
