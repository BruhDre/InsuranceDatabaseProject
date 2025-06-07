using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace Zavrsni
{
    public partial class AgentPonude : Form
    {
        public string idA;
        public AgentPonude(string id)
        {
            idA = id;
            InitializeComponent();

            napuni("SELECT idPonuda AS 'ID',vrstaOsiguranja as 'Vrsta osiguranja', " +
                "cenaMesecno as 'Cena €',limitPokrica as 'Mesečni limit',ISNULL(popust,0) as 'Popust'" +
                " FROM PONUDA WHERE idAgent=" + idA + " AND statusPonuda='Aktivan'");

            Database db = new Database();
            string sql = "SELECT DISTINCT vrstaOsiguranja FROM PONUDA";

            DataSet ds = db.izvrsi(sql, "vrsteOsiguranja");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                comboBox1.Items.Add(dr["vrstaOsiguranja"].ToString());
            }

            this.Width = Screen.FromControl(this).Bounds.Width;
            dataGridView1.Width = ClientSize.Width / 2;
            dataGridView1.Height = ClientSize.Height;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            checkBox1.Location = new Point(3 * ClientSize.Width / 4 - label8.Width, checkBox1.Location.Y);
            comboBox1.Location = new Point(3 * ClientSize.Width / 4, comboBox1.Location.Y);
            txtCena.Location = new Point(3 * ClientSize.Width / 4, txtCena.Location.Y);
            txtLimit.Location = new Point(3 * ClientSize.Width / 4, txtLimit.Location.Y);
            txtPopust.Location = new Point(3 * ClientSize.Width / 4, txtPopust.Location.Y);
            label8.Location = new Point(comboBox1.Location.X - label8.Width, comboBox1.Location.Y);
            label9.Location = new Point(txtCena.Location.X - label9.Width, txtCena.Location.Y);
            label10.Location = new Point(txtLimit.Location.X - label10.Width, txtLimit.Location.Y);
            label11.Location = new Point(txtPopust.Location.X - label11.Width, txtPopust.Location.Y);
            label1.Location = new Point(txtPopust.Location.X + txtPopust.Width, txtPopust.Location.Y);
            button1.Location = new Point(3 * ClientSize.Width / 4 - button1.Width / 2, ClientSize.Height / 2);
            button2.Location = new Point(3 * ClientSize.Width / 4 - button1.Width / 2, button1.Location.Y + button1.Height + button1.Height / 4);
            button3.Location = new Point(3 * ClientSize.Width / 4 - button1.Width / 2, button2.Location.Y + button1.Height + button1.Height / 4);
            button4.Location = new Point(3 * ClientSize.Width / 4 - button1.Width / 2, button3.Location.Y + button1.Height + button1.Height / 4);
        }

        private void napuni(string sql)
        {
            Database db=new Database();

            DataSet ds = db.izvrsi(sql, "Ponude");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Ponude";
        }

        private void AgentPonude_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                napuni("SELECT idPonuda AS 'ID',vrstaOsiguranja as 'Vrsta osiguranja', " +
                "cenaMesecno as 'Cena €',limitPokrica as 'Mesečni limit',ISNULL(popust,0) as 'Popust'" +
                " FROM PONUDA WHERE idAgent=" + idA + " AND statusPonuda='Aktivan'");
                button3.Text = "Ukloni ponudu";
            }
            else
            {
                napuni("SELECT idPonuda AS 'ID',vrstaOsiguranja as 'Vrsta osiguranja', " +
                "cenaMesecno as 'Cena €',limitPokrica as 'Mesečni limit',ISNULL(popust,0) as 'Popust'" +
                " FROM PONUDA WHERE idAgent=" + idA + " AND statusPonuda='Neaktivan'");
                button3.Text = "Aktiviraj ponudu";
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
                comboBox1.SelectedIndex = comboBox1.FindStringExact(dr.Cells["Vrsta osiguranja"].Value.ToString());
                txtCena.Text = dr.Cells["Cena €"].Value.ToString();
                txtLimit.Text = dr.Cells["Mesečni limit"].Value.ToString();
                txtPopust.Text = dr.Cells["Popust"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || txtCena.Text=="" || txtLimit.Text=="")
            {
                MessageBox.Show("Niste uneli sve podatke");
            }
            else
            {
                if (float.TryParse(txtCena.Text, out float cena) && float.TryParse(txtLimit.Text, out float limit))
                {
                    if (int.TryParse(txtPopust.Text, out int popust) || txtPopust.Text=="")
                    {
                        if (txtPopust.Text == "")
                            popust = 0;

                        Database db = new Database();
                        string sql = "INSERT INTO PONUDA(idAgent,vrstaOsiguranja,cenaMesecno,limitPokrica,popust,statusPonuda) " +
                            "VALUES(" + idA + ",'" + comboBox1.SelectedItem.ToString() + "'," + cena + "," + limit + "," + popust + ",'Aktivan')";

                        int i=db.izvrsi_proceduru(sql);
                        if (i>0)
                        {
                            MessageBox.Show("Uspešno dodata ponuda");
                        }
                        else
                        {
                            MessageBox.Show("Greška pri dodavanju ponude");
                        }
                        
                        txtCena.Clear();
                        txtLimit.Clear();
                        txtPopust.Clear();
                        checkBox1.Checked = true;
                        napuni("SELECT idPonuda AS 'ID',vrstaOsiguranja as 'Vrsta osiguranja', " +
                            "cenaMesecno as 'Cena €',limitPokrica as 'Mesečni limit',ISNULL(popust,0) as 'Popust'" +
                            " FROM PONUDA WHERE idAgent=" + idA + " AND statusPonuda='Aktivan'");
                        button3.Text = "Ukloni ponudu";
                    }
                    else
                    {
                        MessageBox.Show("Popust mora biti broj");
                    }
                }
                else
                {
                    MessageBox.Show("Cena i limit moraju biti brojevi");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                string id = dr.Cells["ID"].Value.ToString();

                if (comboBox1.SelectedIndex == -1 || txtCena.Text == "" || txtLimit.Text == "")
                {
                    MessageBox.Show("Niste uneli sve podatke");
                }
                else
                {
                    if (float.TryParse(txtCena.Text, out float cena) && float.TryParse(txtLimit.Text, out float limit))
                    {
                        if (int.TryParse(txtPopust.Text, out int popust) || txtPopust.Text == "")
                        {
                            if (txtPopust.Text == "")
                                popust = 0;

                            Database db = new Database();
                            string sql = "UPDATE PONUDA SET vrstaOsiguranja='"+ comboBox1.SelectedItem.ToString() + "',cenaMesecno="+cena+"," +
                                "limitPokrica="+limit+",popust="+popust+" WHERE idPonuda="+id;

                            int i = db.izvrsi_proceduru(sql);
                            if (i > 0)
                            {
                                MessageBox.Show("Uspešno izmenjena ponuda");
                            }
                            else
                            {
                                MessageBox.Show("Greška pri izmeni ponude");
                            }
                            
                            txtCena.Clear();
                            txtLimit.Clear();
                            txtPopust.Clear();
                            checkBox1.Checked = true;
                            napuni("SELECT idPonuda AS 'ID',vrstaOsiguranja as 'Vrsta osiguranja', " +
                                "cenaMesecno as 'Cena €',limitPokrica as 'Mesečni limit',ISNULL(popust,0) as 'Popust'" +
                                " FROM PONUDA WHERE idAgent=" + idA + " AND statusPonuda='Aktivan'");
                            button3.Text = "Ukloni ponudu";
                        }
                        else
                        {
                            MessageBox.Show("Popust mora biti broj");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cena i limit moraju biti brojevi");
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
                    sql = "UPDATE PONUDA SET statusPonuda='Neaktivan' WHERE idPonuda=" + id;
                }
                else
                {
                    sql = "UPDATE PONUDA SET statusPonuda='Aktivan' WHERE idPonuda=" + id;
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
                    napuni("SELECT idPonuda AS 'ID',vrstaOsiguranja as 'Vrsta osiguranja', " +
                    "cenaMesecno as 'Cena €',limitPokrica as 'Mesečni limit',ISNULL(popust,0) as 'Popust'" +
                    " FROM PONUDA WHERE idAgent=" + idA + " AND statusPonuda='Aktivan'");
                    button3.Text = "Ukloni ponudu";
                }
                else
                {
                    napuni("SELECT idPonuda AS 'ID',vrstaOsiguranja as 'Vrsta osiguranja', " +
                    "cenaMesecno as 'Cena €',limitPokrica as 'Mesečni limit',ISNULL(popust,0) as 'Popust'" +
                    " FROM PONUDA WHERE idAgent=" + idA + " AND statusPonuda='Neaktivan'");
                    button3.Text = "Aktiviraj ponudu";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                string id = dr.Cells["ID"].Value.ToString();

                AgentUsluge au = new AgentUsluge(id);
                au.ShowDialog();
            }
        }
    }
}
