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
    public partial class AgentArhiva : Form
    {
        public AgentArhiva()
        {
            InitializeComponent();

            Database db = new Database();
            string sql = "SELECT idAgent,naziv,adresa,mejl,telefon FROM AGENT_ARHIVA";

            DataSet ds = db.izvrsi(sql, "Agenti");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Agenti";

            this.Width = Screen.FromControl(this).Bounds.Width;
            dataGridView1.Width = ClientSize.Width;
            dataGridView1.Height = ClientSize.Height;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AgentArhiva_Load(object sender, EventArgs e)
        {

        }
    }
}
