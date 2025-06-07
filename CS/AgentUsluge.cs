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
    public partial class AgentUsluge : Form
    {
        public string idP;
        public AgentUsluge(string id)
        {
            idP = id;
            InitializeComponent();

            napuni("SELECT idDogadjaj as 'ID',opis as 'Opis',odsteta as 'Odšteta' FROM " +
                "DOGADJAJ WHERE idPonuda="+idP+" AND statusDogadjaj='Aktivan'");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void napuni(string sql)
        {
            Database db = new Database();

            DataSet ds = db.izvrsi(sql, "Usluge");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Usluge";
        }

        private void AgentUsluge_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                napuni("SELECT idDogadjaj as 'ID',opis as 'Opis',odsteta as 'Odšteta' FROM " +
                "DOGADJAJ WHERE idPonuda=" + idP + " AND statusDogadjaj='Aktivan'");
                button3.Text = "Ukloni uslugu";
            }
            else
            {
                napuni("SELECT idDogadjaj as 'ID',opis as 'Opis',odsteta as 'Odšteta' FROM " +
                "DOGADJAJ WHERE idPonuda=" + idP + " AND statusDogadjaj='Neaktivan'");
                button3.Text = "Aktiviraj uslugu";
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                txtOpis.Text = dr.Cells["Opis"].Value.ToString();
                txtOdsteta.Text = dr.Cells["Odšteta"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtOpis.Text=="" || txtOdsteta.Text=="")
            {
                MessageBox.Show("Niste uneli sve podatke");
            }
            else
            {
                if (float.TryParse(txtOdsteta.Text, out float odsteta))
                {
                    if (odsteta>0)
                    {
                        Database db = new Database();
                        string sql = "INSERT INTO DOGADJAJ(idPonuda,opis,odsteta,statusDogadjaj) " +
                            "VALUES(" + idP + ",'" + txtOpis.Text + "'," + odsteta + ",'Aktivan')";

                        int i = db.izvrsi_proceduru(sql);
                        if (i > 0)
                        {
                            MessageBox.Show("Uspešno dodata usluga");
                        }
                        else
                        {
                            MessageBox.Show("Greška pri dodavanju usluge");
                        }
                        txtOpis.Clear();
                        txtOdsteta.Clear();
                        checkBox1.Checked = true;
                        napuni("SELECT idDogadjaj as 'ID',opis as 'Opis',odsteta as 'Odšteta' FROM " +
                            "DOGADJAJ WHERE idPonuda=" + idP + " AND statusDogadjaj='Aktivan'");
                        button3.Text = "Ukloni uslugu";
                    }
                    else
                    {
                        MessageBox.Show("Odšteta mora biti pozitivna");
                    }
                }
                else
                {
                    MessageBox.Show("Odšteta mora biti broj");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                string id = dr.Cells["ID"].Value.ToString();

                if (txtOpis.Text == "" || txtOdsteta.Text == "")
                {
                    MessageBox.Show("Niste uneli sve podatke");
                }
                else
                {
                    if (float.TryParse(txtOdsteta.Text, out float odsteta))
                    {
                        if (odsteta > 0)
                        {
                            Database db = new Database();
                            string sql = "UPDATE DOGADJAJ SET opis='"+txtOpis.Text+"',odsteta="+odsteta+" " +
                                "WHERE idDogadjaj="+id;

                            int i = db.izvrsi_proceduru(sql);
                            if (i > 0)
                            {
                                MessageBox.Show("Uspešno izmenjena usluga");
                            }
                            else
                            {
                                MessageBox.Show("Greška pri izmeni usluge");
                            }
                            txtOpis.Clear();
                            txtOdsteta.Clear();
                            checkBox1.Checked = true;
                            napuni("SELECT idDogadjaj as 'ID',opis as 'Opis',odsteta as 'Odšteta' FROM " +
                                "DOGADJAJ WHERE idPonuda=" + idP + " AND statusDogadjaj='Aktivan'");
                            button3.Text = "Ukloni uslugu";
                        }
                        else
                        {
                            MessageBox.Show("Odšteta mora biti pozitivna");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Odšteta mora biti broj");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                string id = dr.Cells["ID"].Value.ToString();

                string sql;
                if (checkBox1.Checked)
                {
                    sql = "UPDATE DOGADJAJ SET statusDogadjaj='Neaktivan' WHERE idDogadjaj=" + id;
                }
                else
                {
                    sql = "UPDATE DOGADJAJ SET statusDogadjaj='Aktivan' WHERE idDogadjaj=" + id;
                }

                Database db = new Database();
                int i = db.izvrsi_proceduru(sql);
                if (i > 0)
                {
                    MessageBox.Show("Uspešna izmena");
                }
                else
                {
                    MessageBox.Show("Greška pri izmeni");
                }

                if (checkBox1.Checked)
                {
                    napuni("SELECT idDogadjaj as 'ID',opis as 'Opis',odsteta as 'Odšteta' FROM " +
                    "DOGADJAJ WHERE idPonuda=" + idP + " AND statusDogadjaj='Aktivan'");
                    button3.Text = "Ukloni uslugu";
                }
                else
                {
                    napuni("SELECT idDogadjaj as 'ID',opis as 'Opis',odsteta as 'Odšteta' FROM " +
                    "DOGADJAJ WHERE idPonuda=" + idP + " AND statusDogadjaj='Neaktivan'");
                    button3.Text = "Aktiviraj uslugu";
                }
            }
        }
    }
}
