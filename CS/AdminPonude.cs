using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Zavrsni
{
    public partial class AdminPonude : Form
    {
        public AdminPonude()
        {
            InitializeComponent();

            napuni();

            Database db = new Database();
            string sql = "SELECT DISTINCT idAgent,naziv FROM AGENT";

            DataSet ds = db.izvrsi(sql, "Agenti");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbxAgent.Items.Add(dr["idAgent"].ToString() + " - " + dr["naziv"].ToString());
                cbxAgent2.Items.Add(dr["idAgent"].ToString() + " - " + dr["naziv"].ToString());
            }

            string sql2 = "SELECT DISTINCT vrstaOsiguranja FROM PONUDA";

            DataSet ds2 = db.izvrsi(sql2, "vrsteOsiguranja");
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                cbxVrstaFilter.Items.Add(dr["vrstaOsiguranja"].ToString());
                cbxVrsta.Items.Add(dr["vrstaOsiguranja"].ToString());
            }

            this.Width = Screen.FromControl(this).Bounds.Width;
            dataGridView1.Width = ClientSize.Width;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            button4.Location = new Point(ClientSize.Width / 2, button4.Location.Y);
            cbxAgent2.Location = new Point(ClientSize.Width / 2, cbxAgent2.Location.Y);
            cbxVrsta.Location = new Point(ClientSize.Width / 2, cbxVrsta.Location.Y);
            txtCena.Location = new Point(ClientSize.Width / 2, txtCena.Location.Y);
            txtLimit.Location = new Point(ClientSize.Width / 2, txtLimit.Location.Y);
            txtPopust.Location = new Point(ClientSize.Width / 2, txtPopust.Location.Y);
            label3.Location = new Point(cbxAgent2.Location.X - label3.Width, cbxAgent2.Location.Y);
            label8.Location = new Point(cbxVrsta.Location.X - label8.Width, cbxVrsta.Location.Y);
            label5.Location = new Point(txtCena.Location.X - label5.Width, txtCena.Location.Y);
            label9.Location = new Point(txtLimit.Location.X - label9.Width, txtLimit.Location.Y);
            label7.Location = new Point(txtPopust.Location.X - label7.Width, txtPopust.Location.Y);
            button2.Location = new Point(ClientSize.Width / 10, button2.Location.Y);
            button1.Location = new Point(button2.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
            button3.Location = new Point(button1.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
            button5.Location = new Point(button3.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
            button6.Location = new Point(button5.Location.X + button2.Width + button2.Width / 10, button2.Location.Y);
        }

        private void napuni()
        {
            Database db = new Database();
            string sql = "SELECT idPonuda as 'ID',CAST(PONUDA.idAgent as nvarchar)+' - '+naziv as 'Agent',vrstaOsiguranja as 'Vrsta osiguranja',cenaMesecno as 'Cena €'" +
                ",limitPokrica as 'Limit pokrića', isnull(popust,0) as 'Popust', statusPonuda as 'Status' FROM AGENT,PONUDA WHERE AGENT.idAgent=PONUDA.idAgent";

            DataSet ds = db.izvrsi(sql, "Ponude");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Ponude";
        }

        private void filtriraj()
        {
            if (cbxAgent.SelectedIndex==-1 && cbxVrstaFilter.SelectedIndex==-1)
            {
                napuni();
            }
            else if(cbxAgent.SelectedIndex==-1 && cbxVrstaFilter.SelectedIndex!=-1)
            {
                Database db = new Database();
                string sql = "SELECT idPonuda as 'ID',CAST(PONUDA.idAgent as nvarchar)+' - '+naziv as 'Agent',vrstaOsiguranja as 'Vrsta osiguranja',cenaMesecno as 'Cena €'" +
                    ",limitPokrica as 'Limit pokrića', isnull(popust,0) as 'Popust', statusPonuda as 'Status' FROM AGENT,PONUDA WHERE AGENT.idAgent=PONUDA.idAgent AND " +
                    "vrstaOsiguranja LIKE '"+cbxVrstaFilter.SelectedItem.ToString()+"%'";

                DataSet ds = db.izvrsi(sql, "Ponude");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Ponude";
            }
            else if (cbxAgent.SelectedIndex != -1 && cbxVrstaFilter.SelectedIndex == -1)
            {
                Database db = new Database();
                string sql = "SELECT idPonuda as 'ID',CAST(PONUDA.idAgent as nvarchar)+' - '+naziv as 'Agent',vrstaOsiguranja as 'Vrsta osiguranja',cenaMesecno as 'Cena €'" +
                    ",limitPokrica as 'Limit pokrića', isnull(popust,0) as 'Popust', statusPonuda as 'Status' FROM AGENT,PONUDA WHERE AGENT.idAgent=PONUDA.idAgent AND " +
                    "naziv LIKE '" + cbxAgent.SelectedItem.ToString().Split(' ')[2] + "%'";

                DataSet ds = db.izvrsi(sql, "Ponude");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Ponude";
            }
            else
            {
                Database db = new Database();
                string sql = "SELECT idPonuda as 'ID',CAST(PONUDA.idAgent as nvarchar)+' - '+naziv as 'Agent',vrstaOsiguranja as 'Vrsta osiguranja',cenaMesecno as 'Cena €'" +
                    ",limitPokrica as 'Limit pokrića', isnull(popust,0) as 'Popust', statusPonuda as 'Status' FROM AGENT,PONUDA WHERE AGENT.idAgent=PONUDA.idAgent AND " +
                    "naziv LIKE '" + cbxAgent.SelectedItem.ToString().Split(' ')[2] + "%' AND vrstaOsiguranja LIKE '"+cbxVrstaFilter.SelectedItem.ToString()+"%'";

                DataSet ds = db.izvrsi(sql, "Ponude");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Ponude";
            }
        }




        private void AdminPonude_Load(object sender, EventArgs e)
        {

        }

        private void cbxAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtriraj();
        }

        private void cbxVrstaFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtriraj();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cbxAgent.SelectedIndex = -1;
            cbxVrstaFilter.SelectedIndex = -1;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                cbxVrsta.SelectedIndex = cbxVrsta.FindStringExact(dr.Cells["Vrsta osiguranja"].Value.ToString());
                txtCena.Text = dr.Cells["Cena €"].Value.ToString();
                txtLimit.Text = dr.Cells["Limit pokrića"].Value.ToString();
                txtPopust.Text = dr.Cells["Popust"].Value.ToString();
                cbxAgent2.SelectedIndex = cbxAgent2.FindStringExact(dr.Cells["Agent"].Value.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                string id = dr.Cells["ID"].Value.ToString();
                string status = dr.Cells["Status"].Value.ToString();

                Database db = new Database();
                string sql = "";
                if (status=="Aktivan")
                {
                    sql = "UPDATE PONUDA SET statusPonuda='Neaktivan' WHERE idPonuda=" + id;
                }
                else
                {
                    sql = "UPDATE PONUDA SET statusPonuda='Aktivan' WHERE idPonuda=" + id;
                }

                int i = db.izvrsi_proceduru(sql);
                if (i > 0)
                {
                    MessageBox.Show("Uspešna izmena");
                }
                else
                {
                    MessageBox.Show("Greška pri izmeni");
                }

                filtriraj();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbxVrsta.SelectedIndex == -1 || cbxAgent2.SelectedIndex == -1 || txtCena.Text == "" || txtLimit.Text == "")
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
                        string sql = "INSERT INTO PONUDA(idAgent,vrstaOsiguranja,cenaMesecno,limitPokrica,popust,statusPonuda) " +
                            "VALUES(" + cbxAgent2.SelectedItem.ToString().Split(' ')[0] + ",'" + cbxVrsta.SelectedItem.ToString() + "'," + cena + "," + limit + "," + popust + ",'Aktivan')";

                        int i = db.izvrsi_proceduru(sql);
                        if (i > 0)
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
                        filtriraj();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                string id = dr.Cells["ID"].Value.ToString();

                if (cbxVrsta.SelectedIndex == -1 || cbxAgent2.SelectedIndex == -1 || txtCena.Text == "" || txtLimit.Text == "")
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
                            string sql = "UPDATE PONUDA SET idAgent="+cbxAgent2.SelectedItem.ToString().Split(' ')[0] +",vrstaOsiguranja='" + cbxVrsta.SelectedItem.ToString() + "',cenaMesecno=" + cena + "," +
                                "limitPokrica=" + limit + ",popust=" + popust + " WHERE idPonuda=" + id;

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
                            filtriraj();
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
                Database db = new Database();
                string sql = "EXEC sp_brisanje_ponude " + dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();

                int i = db.izvrsi_proceduru(sql);
                if (i > 0)
                {
                    MessageBox.Show("Uspešno obrisana ponuda");
                    filtriraj();
                }
                else
                {
                    MessageBox.Show("Ponuda se vodi na aktivnim ugovorima! Brisanje neuspešno");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idP = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
                AgentUsluge au = new AgentUsluge(idP);
                au.ShowDialog();
            }
        }
    }
}
