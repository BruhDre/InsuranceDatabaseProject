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
    public partial class AgentIzvestaji : Form
    {
        public AgentIzvestaji(string id)
        {
            InitializeComponent();

            Database db = new Database();
            string sql = "SELECT * FROM dbo.fun_prikaz_izvestaj_agent(" + id + ") ORDER BY [Datum] DESC";

            DataSet ds = db.izvrsi(sql, "Izvestaji");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Izvestaji";

            this.Width = Screen.FromControl(this).Bounds.Width;
            dataGridView1.Width = ClientSize.Width;
            dataGridView1.Height = ClientSize.Height;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AgentIzvestaji_Load(object sender, EventArgs e)
        {

        }
    }
}
