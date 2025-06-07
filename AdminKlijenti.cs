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

namespace Zavrsni
{
    public partial class AdminKlijenti : Form
    {
        public string mejl="";
        public string id;
        public AdminKlijenti()
        {
            InitializeComponent();

            napuni();

            this.Width = Screen.FromControl(this).Bounds.Width;
            dataGridView1.Width = ClientSize.Width;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dateTimePicker1.Location = new Point(ClientSize.Width / 2, dateTimePicker1.Location.Y);
            label3.Location = new Point(dateTimePicker1.Location.X - label3.Width, dateTimePicker1.Location.Y);
            txtIme.Location = new Point(ClientSize.Width / 2, txtIme.Location.Y);
            label8.Location = new Point(label3.Location.X, txtIme.Location.Y);
            txtPrezime.Location = new Point(ClientSize.Width / 2, txtPrezime.Location.Y);
            label1.Location = new Point(label3.Location.X, txtPrezime.Location.Y);
            comboBox1.Location = new Point(ClientSize.Width / 2, comboBox1.Location.Y);
            label4.Location = new Point(label3.Location.X, comboBox1.Location.Y);
            txtJmbg.Location = new Point(ClientSize.Width / 2, txtJmbg.Location.Y);
            label2.Location = new Point(label3.Location.X, txtJmbg.Location.Y);
            txtAdresa.Location = new Point(ClientSize.Width / 2, txtAdresa.Location.Y);
            label5.Location = new Point(label3.Location.X, txtAdresa.Location.Y);
            txtMesto.Location = new Point(ClientSize.Width / 2, txtMesto.Location.Y);
            label6.Location = new Point(label3.Location.X, txtMesto.Location.Y);
            txtMejl.Location = new Point(ClientSize.Width / 2, txtMejl.Location.Y);
            label9.Location = new Point(label3.Location.X, txtMejl.Location.Y);
            txtTelefon.Location = new Point(ClientSize.Width / 2, txtTelefon.Location.Y);
            label7.Location = new Point(label3.Location.X, txtTelefon.Location.Y);
            button2.Location = new Point(ClientSize.Width / 8, button2.Location.Y);
            button1.Location = new Point(button2.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
            button3.Location = new Point(button1.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
            button4.Location = new Point(button3.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
            button5.Location = new Point(button4.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
        }

        private void napuni()
        {
            Database db = new Database();
            string sql = "SELECT idKlijent,ime,prezime,jmbg,datumRodjenja,pol,adresa,mesto,mejl," +
                "telefon FROM KLIJENT";

            DataSet ds = db.izvrsi(sql, "Klijenti");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Klijenti";
        }

        private void AdminKlijenti_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text =="")
            {
                napuni();
            }
            else
            {
                Database db=new Database();
                string sql = "SELECT * FROM fun_filter_klijenti('" + textBox1.Text + "')";

                DataSet ds = db.izvrsi(sql, "Klijenti");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Klijenti";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                txtIme.Text = dr.Cells["ime"].Value.ToString();
                txtPrezime.Text = dr.Cells["prezime"].Value.ToString();
                txtJmbg.Text = dr.Cells["jmbg"].Value.ToString();
                txtAdresa.Text = dr.Cells["adresa"].Value.ToString();
                txtMesto.Text = dr.Cells["mesto"].Value.ToString();
                txtMejl.Text = dr.Cells["mejl"].Value.ToString();
                mejl=txtMejl.Text;
                id = dr.Cells["idKlijent"].Value.ToString();
                txtTelefon.Text = dr.Cells["telefon"].Value.ToString();
                comboBox1.SelectedIndex = comboBox1.FindStringExact(dr.Cells["pol"].Value.ToString());
                dateTimePicker1.Value = DateTime.Parse(dr.Cells["datumRodjenja"].Value.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                string idk = dr.Cells["idKlijent"].Value.ToString();
                string ime = dr.Cells["ime"].Value.ToString();

                Database db = new Database();
                string sql = "UPDATE KLIJENT SET sifra='" + Form1.GetHashString(ime + "123") + "' " +
                    "WHERE idKlijent=" + idk;

                int i = db.izvrsi_proceduru(sql);
                if (i > 0)
                {
                    MessageBox.Show("Uspešno! Nova lozinka: " + ime + "123");
                }
                else
                {
                    MessageBox.Show("Neuspešno resetovanje lozinke");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtIme.Text!="" && txtPrezime.Text!="" && txtJmbg.Text!="" &&
                txtAdresa.Text!="" && txtMejl.Text!="" && txtMesto.Text!="" &&
                txtTelefon.Text!="" && comboBox1.SelectedIndex > -1)
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
                    string sql = "INSERT INTO KLIJENT(ime,prezime,jmbg,datumRodjenja,adresa," +
                        "mesto,mejl,telefon,pol,sifra) VALUES('" + txtIme.Text + "','" + txtPrezime.Text + "'," +
                        "'" + txtJmbg.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                        "'" + txtAdresa.Text + "','" + txtMesto.Text + "','" + txtMejl.Text + "'," +
                        "'" + txtTelefon.Text + "','" + comboBox1.SelectedItem.ToString() + "'," +
                        "'" + Form1.GetHashString(txtIme.Text + "123") + "')";

                    int i = db.izvrsi_proceduru(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("Uspešno dodat klijent");
                        napuni();
                    }
                    else
                    {
                        MessageBox.Show("Neuspešno dodavanje klijenta");
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
            if (txtIme.Text != "" && txtPrezime.Text != "" && txtJmbg.Text != "" &&
                txtAdresa.Text != "" && txtMejl.Text != "" && txtMesto.Text != "" &&
                txtTelefon.Text != "" && comboBox1.SelectedIndex > -1)
            {
                Database db = new Database();
                string sql1 = "SELECT mejl FROM KLIJENT WHERE mejl='" + txtMejl.Text + "'";
                string sql2 = "SELECT mejl FROM AGENT WHERE mejl='" + txtMejl.Text + "'";
                string sql3 = "SELECT mejl FROM ADMIN WHERE mejl='" + txtMejl.Text + "'";

                DataSet ds1 = db.izvrsi(sql1, "Klijent");
                DataSet ds2 = db.izvrsi(sql2, "Agent");
                DataSet ds3 = db.izvrsi(sql3, "Admin");
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0]["mejl"].ToString() != mejl)
                    {
                        MessageBox.Show("Uneti mejl je već u upotrebi");
                    }
                    else
                    {
                        izmena();
                    }
                }
                else if (ds2.Tables[0].Rows.Count > 0 || ds3.Tables[0].Rows.Count > 0)
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
            string sql = "UPDATE KLIJENT SET ime='" + txtIme.Text + "',prezime='" + txtPrezime.Text + "'," +
                "jmbg='" + txtJmbg.Text + "',datumRodjenja='" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                "adresa='" + txtAdresa.Text + "',mesto='" + txtMesto.Text + "',mejl='" + txtMejl.Text + "'," +
                "telefon='" + txtTelefon.Text + "',pol='" + comboBox1.SelectedItem.ToString() + "' WHERE idKlijent=" + id;


            int i = db.izvrsi_proceduru(sql);
            if (i > 0)
            {
                MessageBox.Show("Uspešno izmenjen klijent");
                napuni();
            }
            else
            {
                MessageBox.Show("Neuspešna izmena klijenta");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Database db= new Database();
                string sql = "EXEC sp_brisanje_klijenta " + id;

                int i = db.izvrsi_proceduru(sql);
                if (i > 0)
                {
                    MessageBox.Show("Uspešno obrisan klijent");
                    napuni();
                }
                else
                {
                    MessageBox.Show("Klijent ima aktivne ugovore! Brisanje neuspešno");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KlijentArhiva ka=new KlijentArhiva();
            ka.ShowDialog();
        }
    }
}
