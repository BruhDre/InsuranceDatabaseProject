using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Zavrsni
{
    public partial class PonudeKlijent : Form
    {
        public string idK;
        public PonudeKlijent(string id)
        {
            idK = id;
            InitializeComponent();

            napuni();
            statistika();

            Database db = new Database();
            string sql = "SELECT DISTINCT vrstaOsiguranja FROM PONUDA";

            DataSet ds = db.izvrsi(sql, "vrsteOsiguranja");
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                comboBox1.Items.Add(dr["vrstaOsiguranja"].ToString());
            }

            this.Width = Screen.FromControl(this).Bounds.Width;
            dataGridView1.Width = ClientSize.Width;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            button1.Location = new Point(ClientSize.Width / 2 - button1.Width / 5 - button1.Width, 7 * ClientSize.Height / 8 - button1.Height / 2);
            button2.Location = new Point(ClientSize.Width / 2 + button1.Width / 5, 7 * ClientSize.Height / 8 - button1.Height / 2);
            dataGridView1.Height = ClientSize.Height / 2 - dataGridView1.Location.Y;
            chart1.Location=new Point(dataGridView1.Location.X, dataGridView1.Location.Y + dataGridView1.Height + chart1.Height / 5);
        }

        private void napuni()
        {
            Database db=new Database();
            string sql = "SELECT * FROM dbo.fun_prikaz_ponuda("+idK+")";

            DataSet ds = db.izvrsi(sql, "Ponude");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Ponude";
        }

        private void statistika()
        {
            chart1.Series.Clear();
            chart1.Legends.Clear();

            chart1.Legends.Add("Agenti");
            chart1.Legends[0].LegendStyle = LegendStyle.Table;
            chart1.Legends[0].Docking = Docking.Bottom;
            chart1.Legends[0].Alignment = StringAlignment.Center;
            chart1.Legends[0].Title = "Ugovori po agentima";
            chart1.Legends[0].BorderColor = Color.Black;

            chart1.Series.Add("Agenti");
            chart1.Series["Agenti"].ChartType = SeriesChartType.Pie;

            Database db = new Database();
            string sql = "SELECT naziv, COUNT(idUgovor) as 'BROJ' FROM AGENT,PONUDA,UGOVOR " +
                "WHERE AGENT.idAgent=PONUDA.idAgent AND Ponuda.idPonuda=UGOVOR.idPonuda " +
                "GROUP BY naziv";

            DataSet ds = db.izvrsi(sql, "UgovoriPoAgentima");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                chart1.Series["Agenti"].Points.AddXY(dr["naziv"].ToString(), int.Parse(dr["BROJ"].ToString()));
            }
        }

        private void PonudeKlijent_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Database db = new Database();
            string sql = "SELECT * FROM dbo.fun_filter_ponude('" + comboBox1.SelectedItem.ToString() + "',"+idK+")";

            DataSet ds = db.izvrsi(sql, "Ponude");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Ponude";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                var id = dr.Cells["ID"].Value.ToString();

                Dogadjaji dg = new Dogadjaji(id);
                dg.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                var id = dr.Cells["ID"].Value.ToString();

                Database db = new Database();
                string sql = "exec sp_sklopi_ugovor " + idK + "," + id;

                int i = db.izvrsi_proceduru(sql);
                if (i > 0)
                    MessageBox.Show("Uspešno sklopljen ugovor");
                else
                    MessageBox.Show("Greška pri sklapanju ugovora");

                napuni();
            }
        }
    }
}
