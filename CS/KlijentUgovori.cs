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
    public partial class KlijentUgovori : Form
    {
        public string idK;
        public KlijentUgovori(string id)
        {
            idK = id;
            InitializeComponent();

            Database db = new Database();
            string sql = "SELECT * FROM dbo.fun_prikazi_ugovor(" + idK + ")";

            DataSet ds = db.izvrsi(sql, "Ugovori");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Ugovori";

            this.Width = Screen.FromControl(this).Bounds.Width;
            dataGridView1.Width = ClientSize.Width;
            dataGridView1.Height = 3 * ClientSize.Height / 4;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            button2.Location = new Point(ClientSize.Width / 2 - button2.Width / 2, 7 * ClientSize.Height / 8 - button2.Height / 2);
        }

        private void KlijentUgovori_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                var id = dr.Cells["ID"].Value.ToString();

                PrijavaDogadjaja pd = new PrijavaDogadjaja(id);
                pd.ShowDialog();
            } 
        }
    }
}
