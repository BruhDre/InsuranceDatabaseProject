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
    public partial class AgentUgovori : Form
    {
        public string idA;
        public AgentUgovori(string id)
        {
            idA = id;
            InitializeComponent();

            napuni("SELECT * FROM dbo.fun_prikazi_ugovor_agentA("+idA+")");

            this.Width = Screen.FromControl(this).Bounds.Width;
            dataGridView1.Width = ClientSize.Width;
            dataGridView1.Height = 3 * ClientSize.Height / 4;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            checkBox1.Location = new Point(checkBox1.Location.X, 7 * ClientSize.Height / 8);
            button2.Location = new Point(button2.Location.X, 7 * ClientSize.Height / 8);
            button4.Location = new Point(ClientSize.Width - button4.Width - button4.Width / 10, 7 * ClientSize.Height / 8);
        }

        private void napuni(string sql)
        {
            Database db = new Database();

            DataSet ds = db.izvrsi(sql, "Ugovori");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Ugovori";
        }

        private void AgentUgovori_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                napuni("SELECT * FROM dbo.fun_prikazi_ugovor_agentA(" + idA + ")");
                button2.Text = "Deaktiviraj ugovor";
            }
            else
            {
                napuni("SELECT * FROM dbo.fun_prikazi_ugovor_agentN(" + idA + ")");
                button2.Text = "Aktiviraj ugovor";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string id = row.Cells["ID"].Value.ToString();

                string sql;
                if (checkBox1.Checked)
                {
                    sql = "UPDATE UGOVOR SET statusUgovora='Neaktivan' WHERE idUgovor=" + id;
                }
                else
                {
                    sql = "UPDATE UGOVOR SET statusUgovora='Aktivan' WHERE idUgovor=" + id;
                }
                Database db=new Database();
                int i = db.izvrsi_proceduru(sql);
                if (i > 0)
                {
                    MessageBox.Show("Uspešna izmena");
                }
                else
                {
                    MessageBox.Show("Neuspešna izmena");
                }

                if (checkBox1.Checked)
                {
                    napuni("SELECT * FROM dbo.fun_prikazi_ugovor_agentA(" + idA + ")");
                    button2.Text = "Deaktiviraj ugovor";
                }
                else
                {
                    napuni("SELECT * FROM dbo.fun_prikazi_ugovor_agentN(" + idA + ")");
                    button2.Text = "Aktiviraj ugovor";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string id = row.Cells["ID"].Value.ToString();

                Database db=new Database();
                string sql = "SELECT idKlijent FROM UGOVOR WHERE idUgovor=" + id;

                DataSet ds = db.izvrsi(sql, "Klijent");
                string idk = ds.Tables[0].Rows[0]["idKlijent"].ToString();

                PrikazKlijent pk = new PrikazKlijent(idk);
                pk.ShowDialog();
            }
        }
    }
}
