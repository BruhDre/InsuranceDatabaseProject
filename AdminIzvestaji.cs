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
    public partial class AdminIzvestaji : Form
    {
        public AdminIzvestaji()
        {
            InitializeComponent();

            napuni();

            Database db = new Database();
            string sql = "SELECT DISTINCT idKlijent,ime,prezime FROM KLIJENT";

            DataSet ds = db.izvrsi(sql, "Klijenti");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbxKlijentFilter.Items.Add(dr["idKlijent"].ToString() + " - " + dr["ime"].ToString() + " " + dr["prezime"].ToString());
            }

            string sql2 = "SELECT DISTINCT idAgent,naziv FROM AGENT";

            DataSet ds2 = db.izvrsi(sql2, "Agenti");
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                cbxAgentFilter.Items.Add(dr["idAgent"].ToString() + " - " + dr["naziv"].ToString());
            }

            string sql3 = "SELECT DISTINCT vrstaOsiguranja FROM PONUDA";

            DataSet ds3 = db.izvrsi(sql3, "Osiguranja");
            foreach (DataRow dr in ds3.Tables[0].Rows)
            {
                cbxVrstaFilter.Items.Add(dr["vrstaOsiguranja"].ToString());
            }

            this.Width = Screen.FromControl(this).Bounds.Width;
            dataGridView1.Width = ClientSize.Width;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            label2.Location = new Point(cbxKlijentFilter.Location.X + cbxKlijentFilter.Width + 20, label1.Location.Y);
            cbxAgentFilter.Location = new Point(label2.Location.X + label2.Width, cbxKlijentFilter.Location.Y);
            label3.Location = new Point(cbxAgentFilter.Location.X + cbxAgentFilter.Width + 20, label1.Location.Y);
            cbxVrstaFilter.Location = new Point(label3.Location.X + label3.Width, cbxKlijentFilter.Location.Y);
            button4.Location = new Point((label2.Width + cbxAgentFilter.Width) / 2 + label2.Location.X, label3.Location.Y + (button4.Height / 3) * 2);
            lblUkupno.Location = new Point(ClientSize.Width / 2, lblUkupno.Location.Y);
            label4.Location = new Point(lblUkupno.Location.X - label4.Width, lblUkupno.Location.Y);
            lblTrenutni.Location = new Point(ClientSize.Width / 2, lblTrenutni.Location.Y);
            label6.Location = new Point(lblUkupno.Location.X - label6.Width, lblTrenutni.Location.Y);
            lblProsli.Location = new Point(ClientSize.Width / 2, lblProsli.Location.Y);
            label8.Location = new Point(lblUkupno.Location.X - label8.Width, lblProsli.Location.Y);
            button1.Location = new Point(button4.Location.X, button1.Location.Y);
        }

        private void napuni()
        {
            Database db = new Database();
            string sql = "SELECT idIzvestaj as 'ID',IZVESTAJ.idUgovor as 'Ugovor',CAST(UGOVOR.idKlijent as nvarchar)+' - '+ime+' '+prezime as 'Klijent'," +
                "CAST(PONUDA.idPonuda as nvarchar) + ' - ' + naziv + ' - ' + vrstaOsiguranja as 'Osiguranje'," +
                "CAST(IZVESTAJ.idDogadjaj as nvarchar) + ' - ' + opis as 'Usluga',IZVESTAJ.datum as 'Datum'," +
                "ukupnaOdsteta as 'Ukupna odšteta' FROM IZVESTAJ, UGOVOR, PONUDA, AGENT, KLIJENT, DOGADJAJ" +
                " WHERE IZVESTAJ.idUgovor = UGOVOR.idUgovor AND IZVESTAJ.idDogadjaj = DOGADJAJ.idDogadjaj AND " +
                "UGOVOR.idPonuda = PONUDA.idPonuda AND PONUDA.idAgent = AGENT.idAgent AND UGOVOR.idKlijent = KLIJENT.idKlijent";

            DataSet ds = db.izvrsi(sql, "Izvestaji");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Izvestaji";

            racunaj();
        }

        private void racunaj()
        {
            int sum = 0;
            int thisM = 0;
            int lastM = 0;
            int thisMonth = DateTime.Now.Month;
            int thisYear = DateTime.Now.Year;
            int lastMonth;
            int lastYear;
            if (thisMonth == 1)
            {
                lastMonth = 12;
                lastYear = thisYear - 1;
            }
            else
            {
                lastMonth = thisMonth - 1;
                lastYear = thisYear;
            }

            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    string br = dr.Cells["Ukupna odšteta"].Value.ToString();
                    sum += int.Parse(br);
                    string mesec = dr.Cells["Datum"].Value.ToString();
                    DateTime pretvoreno = DateTime.Parse(mesec);
                    if (pretvoreno.Month == thisMonth && pretvoreno.Year == thisYear)
                    {
                        thisM += int.Parse(br);
                    }
                    if (pretvoreno.Month == lastMonth && pretvoreno.Year == lastYear)
                    {
                        lastM += int.Parse(br);
                    }
                }
            }

            lblUkupno.Text = "€" + sum.ToString() + ",00";
            lblTrenutni.Text = "€" + thisM.ToString() + ",00";
            lblProsli.Text = "€" + lastM.ToString() + ",00";
        }

        private void napuniDato(string sql)
        {
            Database db = new Database();

            DataSet ds = db.izvrsi(sql, "Izvestaji");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Izvestaji";
        }

        private void filtriraj()
        {
            string sql = "SELECT idIzvestaj as 'ID',IZVESTAJ.idUgovor as 'Ugovor',CAST(UGOVOR.idKlijent as nvarchar)+' - '+ime+' '+prezime as 'Klijent'," +
                "CAST(PONUDA.idPonuda as nvarchar) + ' - ' + naziv + ' - ' + vrstaOsiguranja as 'Osiguranje'," +
                "CAST(IZVESTAJ.idDogadjaj as nvarchar) + ' - ' + opis as 'Usluga',IZVESTAJ.datum as 'Datum'," +
                "ukupnaOdsteta as 'Ukupna odšteta' FROM IZVESTAJ, UGOVOR, PONUDA, AGENT, KLIJENT, DOGADJAJ" +
                " WHERE IZVESTAJ.idUgovor = UGOVOR.idUgovor AND IZVESTAJ.idDogadjaj = DOGADJAJ.idDogadjaj AND " +
                "UGOVOR.idPonuda = PONUDA.idPonuda AND PONUDA.idAgent = AGENT.idAgent AND UGOVOR.idKlijent = KLIJENT.idKlijent";

            if (cbxKlijentFilter.SelectedIndex != -1)
            {
                sql += " AND UGOVOR.idKlijent=" + cbxKlijentFilter.SelectedItem.ToString().Split(' ')[0];
            }
            if (cbxAgentFilter.SelectedIndex != -1)
            {
                sql += " AND AGENT.idAgent=" + cbxAgentFilter.SelectedItem.ToString().Split(' ')[0];
            }
            if (cbxVrstaFilter.SelectedIndex != -1)
            {
                sql += " AND vrstaOsiguranja='" + cbxVrstaFilter.SelectedItem.ToString() + "'";
            }

            napuniDato(sql);
            racunaj();
        }

        private void AdminIzvestaji_Load(object sender, EventArgs e)
        {

        }

        private void cbxKlijentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtriraj();
        }

        private void cbxOsiguranjeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtriraj();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cbxKlijentFilter.SelectedIndex = -1;
            cbxAgentFilter.SelectedIndex = -1;
            cbxVrstaFilter.SelectedIndex = -1;
        }

        private void cbxVrstaFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtriraj();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Database db = new Database();
                string sql = "DELETE FROM IZVESTAJ WHERE idIzvestaj=" + dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();

                int i = db.izvrsi_proceduru(sql);
                if (i > 0)
                {
                    MessageBox.Show("Uspešno obrisan izveštaj");
                    filtriraj();
                }
                else
                {
                    MessageBox.Show("Greška pri brisanju izveštaja");
                }
            }
        }
    }
}
