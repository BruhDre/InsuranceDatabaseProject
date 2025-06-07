using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Zavrsni
{
    public partial class AdminAgenti : Form
    {
        public string mejl;
        public string id;
        public AdminAgenti()
        {
            InitializeComponent();

            napuni();

            this.Width = Screen.FromControl(this).Bounds.Width;
            dataGridView1.Width = ClientSize.Width;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int duzina1 = (label8.Width + txtNaziv.Width) / 2;
            label8.Location = new Point(ClientSize.Width / 2 - duzina1, label8.Location.Y);
            txtNaziv.Location = new Point(label8.Location.X + label8.Width, label8.Location.Y);
            txtAdresa.Location = new Point(txtNaziv.Location.X, txtAdresa.Location.Y);
            label5.Location = new Point(txtAdresa.Location.X - label5.Width, txtAdresa.Location.Y);
            txtMejl.Location = new Point(txtNaziv.Location.X, txtMejl.Location.Y);
            label9.Location = new Point(txtMejl.Location.X - label9.Width, txtMejl.Location.Y);
            txtTelefon.Location = new Point(txtNaziv.Location.X, txtTelefon.Location.Y);
            label7.Location = new Point(txtTelefon.Location.X - label7.Width, txtTelefon.Location.Y);
            button2.Location = new Point(ClientSize.Width / 8, button2.Location.Y);
            button1.Location = new Point(button2.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
            button3.Location = new Point(button1.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
            button4.Location = new Point(button3.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
            button5.Location = new Point(button4.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
        }

        private void napuni()
        {
            Database db = new Database();
            string sql = "SELECT idAgent,naziv,adresa,mejl,telefon FROM AGENT";

            DataSet ds = db.izvrsi(sql, "Agenti");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Agenti";
        }

        private void AdminAgenti_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                napuni();
            }
            else
            {
                Database db = new Database();
                string sql = "SELECT * FROM fun_filter_agenti('" + textBox1.Text + "')";

                DataSet ds = db.izvrsi(sql, "Agenti");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Agenti";
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                txtNaziv.Text = dr.Cells["naziv"].Value.ToString();
                txtAdresa.Text = dr.Cells["adresa"].Value.ToString();
                txtMejl.Text = dr.Cells["mejl"].Value.ToString();
                txtTelefon.Text = dr.Cells["telefon"].Value.ToString();
                mejl = txtMejl.Text;
                id = dr.Cells["idAgent"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                string ida = dr.Cells["idAgent"].Value.ToString();
                string naziv = dr.Cells["naziv"].Value.ToString();

                Database db = new Database();
                string sql = "UPDATE AGENT SET sifra='" + Form1.GetHashString(naziv.Replace(" ","") + "123") + "' " +
                    "WHERE idAgent=" + ida;

                int i = db.izvrsi_proceduru(sql);
                if (i > 0)
                {
                    MessageBox.Show("Uspešno! Nova lozinka: " + naziv.Replace(" ","") + "123");
                }
                else
                {
                    MessageBox.Show("Neuspešno resetovanje lozinke");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNaziv.Text!="" && txtAdresa.Text!="" && txtMejl.Text!="" && txtTelefon.Text!="")
            {
                Database db = new Database();
                string sql1 = "SELECT mejl FROM KLIJENT WHERE mejl='" + txtMejl.Text + "'";
                string sql2 = "SELECT mejl FROM AGENT WHERE mejl='" + txtMejl.Text + "'";
                string sql3 = "SELECT mejl FROM ADMIN WHERE mejl='" + txtMejl.Text + "'";

                DataSet ds1 = db.izvrsi(sql1, "Klijent");
                DataSet ds2 = db.izvrsi(sql2, "Agent");
                DataSet ds3 = db.izvrsi(sql3, "Admin");
                if (ds1.Tables[0].Rows.Count > 0 || ds2.Tables[0].Rows.Count > 0 || ds3.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Uneti mejl je već u upotrebi");
                }
                else
                {
                    string sql = "INSERT INTO AGENT(naziv,adresa,mejl,telefon,sifra) VALUES('" + txtNaziv.Text + 
                        "','" + txtAdresa.Text + "','" + txtMejl.Text + "','" + txtTelefon.Text + "','" +
                        Form1.GetHashString(txtNaziv.Text.Replace(" ","") + "123") + "')";

                    int i = db.izvrsi_proceduru(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("Uspešno dodat agent");
                        napuni();
                    }
                    else
                    {
                        MessageBox.Show("Neuspešno dodavanje agenta");
                    }
                }
            }
            else
            {
                MessageBox.Show("Niste uneli sve podatke");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNaziv.Text != "" && txtAdresa.Text != "" && txtMejl.Text != "" && txtTelefon.Text != "")
            {
                Database db = new Database();
                string sql1 = "SELECT mejl FROM KLIJENT WHERE mejl='" + txtMejl.Text + "'";
                string sql2 = "SELECT mejl FROM AGENT WHERE mejl='" + txtMejl.Text + "'";
                string sql3 = "SELECT mejl FROM ADMIN WHERE mejl='" + txtMejl.Text + "'";

                DataSet ds1 = db.izvrsi(sql1, "Klijent");
                DataSet ds2 = db.izvrsi(sql2, "Agent");
                DataSet ds3 = db.izvrsi(sql3, "Admin");
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    if (ds2.Tables[0].Rows[0]["mejl"].ToString() != mejl)
                    {
                        MessageBox.Show("Uneti mejl je već u upotrebi");
                    }
                    else
                    {
                        izmena();
                    }
                }
                else if (ds1.Tables[0].Rows.Count > 0 || ds3.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Uneti mejl je već u upotrebi");
                }
                else
                {
                    izmena();
                }
            }
            else
            {
                MessageBox.Show("Niste uneli sve podatke");
            }
        }

        private void izmena()
        {
            Database db = new Database();
            string sql = "UPDATE AGENT SET naziv='" + txtNaziv.Text + "',adresa='" + txtAdresa.Text + "',mejl='" + txtMejl.Text + "'," +
                "telefon='" + txtTelefon.Text + "' WHERE idAgent=" + id;


            int i = db.izvrsi_proceduru(sql);
            if (i > 0)
            {
                MessageBox.Show("Uspešno izmenjen agent");
                napuni();
            }
            else
            {
                MessageBox.Show("Neuspešna izmena agenta");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Database db = new Database();
                string sql = "EXEC sp_brisanje_agenta " + id;

                int i = db.izvrsi_proceduru(sql);
                if (i > 0)
                {
                    MessageBox.Show("Uspešno obrisan agent");
                    napuni();
                }
                else
                {
                    MessageBox.Show("Agent ima aktivne ponude! Brisanje neuspešno");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AgentArhiva aa = new AgentArhiva();
            aa.ShowDialog();
        }
    }
}
