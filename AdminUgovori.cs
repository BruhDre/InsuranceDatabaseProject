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
    public partial class AdminUgovori : Form
    {
        public AdminUgovori()
        {
            InitializeComponent();

            napuni();

            Database db = new Database();
            string sql = "SELECT DISTINCT idKlijent,ime,prezime FROM KLIJENT";

            DataSet ds = db.izvrsi(sql, "Klijenti");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbxKlijentFilter.Items.Add(dr["idKlijent"].ToString() + " - " + dr["ime"].ToString() + " " + dr["prezime"].ToString());
                cbxKlijent.Items.Add(dr["idKlijent"].ToString() + " - " + dr["ime"].ToString() + " " + dr["prezime"].ToString());
            }

            string sql2 = "SELECT DISTINCT idPonuda,naziv,vrstaOsiguranja FROM AGENT,PONUDA WHERE AGENT.idAgent=PONUDA.idAgent";

            DataSet ds2 = db.izvrsi(sql2, "Osiguranja");
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                cbxPonudaFilter.Items.Add(dr["idPonuda"].ToString() + " - " + dr["naziv"].ToString() + " - " + dr["vrstaOsiguranja"].ToString());
                cbxPonuda.Items.Add(dr["idPonuda"].ToString() + " - " + dr["naziv"].ToString() + " - " + dr["vrstaOsiguranja"].ToString());
            }

            this.Width = Screen.FromControl(this).Bounds.Width;
            dataGridView1.Width = ClientSize.Width;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            button4.Location = new Point(ClientSize.Width / 2, button4.Location.Y);
            cbxKlijent.Location = new Point(ClientSize.Width / 2, cbxKlijent.Location.Y);
            cbxPonuda.Location = new Point(ClientSize.Width / 2, cbxPonuda.Location.Y);
            label3.Location = new Point(cbxKlijent.Location.X - label3.Width, cbxKlijent.Location.Y);
            label8.Location = new Point(cbxPonuda.Location.X - label8.Width, cbxPonuda.Location.Y);
            button2.Location = new Point(ClientSize.Width / 10, button2.Location.Y);
            button1.Location = new Point(button2.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
            button3.Location = new Point(button1.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
            button5.Location = new Point(button3.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
            button6.Location = new Point(button5.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
        }

        private void napuni()
        {
            Database db = new Database();
            string sql = "SELECT idUgovor as 'ID',CAST(UGOVOR.idKlijent as nvarchar)+' - '+ime+' '+prezime as 'Klijent'," +
                "CAST(PONUDA.idPonuda as nvarchar)+' - '+naziv+' - '+vrstaOsiguranja as 'Osiguranje'," +
                "ROUND(cenaMesecno-(popust*cenaMesecno/100),2) as 'Cena €',limitPokrica as 'Limit pokrića',datum as 'Datum',statusUgovora as 'Status'" +
                "FROM UGOVOR, AGENT, PONUDA, KLIJENT WHERE KLIJENT.idKlijent=UGOVOR.idKlijent AND UGOVOR.idPonuda = PONUDA.idPonuda AND " +
                "PONUDA.idAgent = AGENT.idAgent";

            DataSet ds = db.izvrsi(sql, "Ugovori");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Ugovori";
        }

        private void napuniDato(string sql)
        {
            Database db = new Database();

            DataSet ds = db.izvrsi(sql, "Ugovori");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Ugovori";
        }

        private void filtriraj()
        {
            string sql = "SELECT idUgovor as 'ID',CAST(UGOVOR.idKlijent as nvarchar)+' - '+ime+' '+prezime as 'Klijent'," +
                "CAST(PONUDA.idPonuda as nvarchar)+' - '+naziv+' - '+vrstaOsiguranja as 'Osiguranje'," +
                "ROUND(cenaMesecno-(popust*cenaMesecno/100),2) as 'Cena €',limitPokrica as 'Limit pokrića',datum as 'Datum',statusUgovora as 'Status'" +
                "FROM UGOVOR, AGENT, PONUDA, KLIJENT WHERE KLIJENT.idKlijent=UGOVOR.idKlijent AND UGOVOR.idPonuda = PONUDA.idPonuda AND " +
                "PONUDA.idAgent = AGENT.idAgent";

            if (cbxKlijentFilter.SelectedIndex != -1)
            {
                sql += " AND UGOVOR.idKlijent=" + cbxKlijentFilter.SelectedItem.ToString().Split(' ')[0];
            }
            if (cbxPonudaFilter.SelectedIndex != -1)
            {
                sql += " AND PONUDA.idPonuda=" + cbxPonudaFilter.SelectedItem.ToString().Split(' ')[0];
            }

            napuniDato(sql);
        }

        private void AdminUgovori_Load(object sender, EventArgs e)
        {

        }

        private void cbxKlijentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtriraj();
        }

        private void cbxPonudaFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtriraj();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cbxPonudaFilter.SelectedIndex = -1;
            cbxKlijentFilter.SelectedIndex = -1;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                cbxKlijent.SelectedIndex = cbxKlijent.FindStringExact(dr.Cells["Klijent"].Value.ToString());
                cbxPonuda.SelectedIndex = cbxPonuda.FindStringExact(dr.Cells["Osiguranje"].Value.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                string id = dr.Cells["ID"].Value.ToString();
                string status = dr.Cells["Status"].Value.ToString();

                Database db = new Database();
                string sql = "";
                if (status == "Aktivan")
                {
                    sql = "UPDATE UGOVOR SET statusUgovora='Neaktivan' WHERE idUgovor=" + id;
                }
                else
                {
                    sql = "UPDATE UGOVOR SET statusUgovora='Aktivan' WHERE idUgovor=" + id;
                }

                int i = db.izvrsi_proceduru(sql);
                if (i > 0)
                {
                    MessageBox.Show("Uspešna izmena");
                }
                else
                {
                    MessageBox.Show("Greška pri izmeni");
                }

                filtriraj();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbxKlijent.SelectedIndex == -1 || cbxPonuda.SelectedIndex == -1)
            {
                MessageBox.Show("Niste izabrali sve podatke");
            }
            else
            {
                string idk = cbxKlijent.SelectedItem.ToString().Split(' ')[0];
                string idp = cbxPonuda.SelectedItem.ToString().Split(' ')[0];

                Database db = new Database();
                string sql = "EXEC sp_sklopi_ugovor " + idk + ", " + idp;

                int i = db.izvrsi_proceduru(sql);
                if (i>0)
                {
                    MessageBox.Show("Uspešno sklopljen ugovor");
                    filtriraj();
                }
                else
                {
                    MessageBox.Show("Greška pri sklapanju ugovora");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (cbxKlijent.SelectedIndex == -1 || cbxPonuda.SelectedIndex == -1)
                {
                    MessageBox.Show("Niste izabrali sve podatke");
                }
                else
                {
                    string idk = cbxKlijent.SelectedItem.ToString().Split(' ')[0];
                    string idp = cbxPonuda.SelectedItem.ToString().Split(' ')[0];
                    string id = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();

                    Database db = new Database();
                    string sql = "UPDATE UGOVOR SET idKlijent=" + idk + ",idPonuda=" + idp + " WHERE idUgovor=" + id;

                    int i = db.izvrsi_proceduru(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("Uspešno izmenjen ugovor");
                        filtriraj();
                    }
                    else
                    {
                        MessageBox.Show("Greška pri izmeni ugovora");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Database db = new Database();
                string sql = "DELETE FROM UGOVOR WHERE idUgovor=" + dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();

                int i = db.izvrsi_proceduru(sql);
                if (i > 0)
                {
                    MessageBox.Show("Uspešno obrisan ugovor");
                    filtriraj();
                }
                else
                {
                    MessageBox.Show("Greška pri brisanju ugovora");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idU = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
                PrijavaDogadjaja pd = new PrijavaDogadjaja(idU);
                pd.ShowDialog();
            }
        }
    }
}
