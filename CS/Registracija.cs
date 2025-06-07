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
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();

            this.Width = Screen.FromControl(this).Bounds.Width;
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
            txtPass.Location = new Point(ClientSize.Width / 2, txtPass.Location.Y);
            label12.Location = new Point(label3.Location.X, txtPass.Location.Y);
            txtConfirm.Location = new Point(ClientSize.Width / 2, txtConfirm.Location.Y);
            label14.Location = new Point(label3.Location.X, txtConfirm.Location.Y);
            button2.Location = new Point(ClientSize.Width / 2, button2.Location.Y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtIme.Text != "" && txtPrezime.Text != "" && txtJmbg.Text != "" &&
                txtAdresa.Text != "" && txtMejl.Text != "" && txtMesto.Text != "" &&
                txtTelefon.Text != "" && comboBox1.SelectedIndex > -1 && txtPass.Text != "" &&
                txtConfirm.Text != "")
            {
                if (txtPass.Text == txtConfirm.Text)
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
                            "'" + Form1.GetHashString(txtPass.Text) + "')";

                        int i = db.izvrsi_proceduru(sql);
                        if (i > 0)
                        {
                            MessageBox.Show("Uspešno dodat klijent");
                            txtIme.Clear();
                            txtPrezime.Clear();
                            txtJmbg.Clear();
                            txtAdresa.Clear();
                            txtMesto.Clear();
                            txtMejl.Clear();
                            txtTelefon.Clear();
                            txtPass.Clear();
                            txtConfirm.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Neuspešno dodavanje klijenta");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Potvrda lozinke neuspešna");
                }
            }
            else
            {
                MessageBox.Show("Niste uneli sve podatke");
            }
        }
    }
}
