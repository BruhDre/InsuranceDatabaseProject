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
    public partial class Dogadjaji : Form
    {
        public string idP;
        public Dogadjaji(string id)
        {
            idP = id;
            InitializeComponent();

            Database db = new Database();
            string sql="SELECT * FROM dbo.fun_dogadjaji("+idP+")";

            DataSet ds = db.izvrsi(sql, "Dogadjaji");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Dogadjaji";

            string sql3 = "SELECT * FROM view_ponude WHERE [ID]=" + idP;
            DataSet ds2 = db.izvrsi(sql3, "Ponuda");
            lblAgent.Text = ds2.Tables[0].Rows[0]["Agent"].ToString();
            lblVrsta.Text = ds2.Tables[0].Rows[0]["Vrsta osiguranja"].ToString();
            lblCena.Text = ds2.Tables[0].Rows[0]["Cena €"].ToString();
            lblLimit.Text = ds2.Tables[0].Rows[0]["Limit pokrića"].ToString();
            lblPopust.Text = ds2.Tables[0].Rows[0]["Popust"].ToString();

            this.Width = Screen.FromControl(this).Bounds.Width;
            dataGridView1.Width = ClientSize.Width / 2;
            dataGridView1.Height = ClientSize.Height;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lblAgent.Location = new Point(3 * ClientSize.Width / 4, lblAgent.Location.Y);
            lblVrsta.Location = new Point(3 * ClientSize.Width / 4, lblVrsta.Location.Y);
            lblCena.Location = new Point(3 * ClientSize.Width / 4, lblCena.Location.Y);
            lblLimit.Location = new Point(3 * ClientSize.Width / 4, lblLimit.Location.Y);
            lblPopust.Location = new Point(3 * ClientSize.Width / 4, lblPopust.Location.Y);
            label1.Location = new Point(lblAgent.Location.X - label1.Width, label1.Location.Y);
            label2.Location = new Point(lblVrsta.Location.X - label2.Width, label2.Location.Y);
            label3.Location = new Point(lblCena.Location.X - label3.Width, label3.Location.Y);
            label4.Location = new Point(lblLimit.Location.X - label4.Width, label4.Location.Y);
            label5.Location = new Point(lblPopust.Location.X - label5.Width, label5.Location.Y);
            button2.Location = new Point(3 * ClientSize.Width / 4 - button2.Width / 2, button2.Location.Y);
        }

        private void Dogadjaji_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            string sql = "SELECT idAgent FROM PONUDA WHERE idPonuda=" + idP;

            DataSet ds = db.izvrsi(sql, "Agent");
            string ida = ds.Tables[0].Rows[0]["idAgent"].ToString();

            PrikazAgent pa = new PrikazAgent(ida);
            pa.ShowDialog();
        }
    }
}
