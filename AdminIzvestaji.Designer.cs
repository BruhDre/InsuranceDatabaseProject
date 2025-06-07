namespace Zavrsni
{
    partial class AdminIzvestaji
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbxAgentFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxKlijentFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.cbxVrstaFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTrenutni = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblProsli = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(134)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(12, 179);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(776, 357);
            this.dataGridView1.TabIndex = 96;
            // 
            // cbxAgentFilter
            // 
            this.cbxAgentFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this.cbxAgentFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAgentFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(134)))));
            this.cbxAgentFilter.FormattingEnabled = true;
            this.cbxAgentFilter.Location = new System.Drawing.Point(488, 29);
            this.cbxAgentFilter.Name = "cbxAgentFilter";
            this.cbxAgentFilter.Size = new System.Drawing.Size(211, 24);
            this.cbxAgentFilter.TabIndex = 103;
            this.cbxAgentFilter.SelectedIndexChanged += new System.EventHandler(this.cbxOsiguranjeFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(134)))));
            this.label2.Location = new System.Drawing.Point(383, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 31);
            this.label2.TabIndex = 102;
            this.label2.Text = "Agent:";
            // 
            // cbxKlijentFilter
            // 
            this.cbxKlijentFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this.cbxKlijentFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxKlijentFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(134)))));
            this.cbxKlijentFilter.FormattingEnabled = true;
            this.cbxKlijentFilter.Location = new System.Drawing.Point(127, 29);
            this.cbxKlijentFilter.Name = "cbxKlijentFilter";
            this.cbxKlijentFilter.Size = new System.Drawing.Size(211, 24);
            this.cbxKlijentFilter.TabIndex = 101;
            this.cbxKlijentFilter.SelectedIndexChanged += new System.EventHandler(this.cbxKlijentFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(134)))));
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 31);
            this.label1.TabIndex = 100;
            this.label1.Text = "Klijent:";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(59)))), ((int)(((byte)(167)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(138)))), ((int)(((byte)(232)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Georgia", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this.button4.Location = new System.Drawing.Point(318, 568);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(258, 77);
            this.button4.TabIndex = 104;
            this.button4.Text = "Resetuj filter";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbxVrstaFilter
            // 
            this.cbxVrstaFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this.cbxVrstaFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxVrstaFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(134)))));
            this.cbxVrstaFilter.FormattingEnabled = true;
            this.cbxVrstaFilter.Location = new System.Drawing.Point(374, 101);
            this.cbxVrstaFilter.Name = "cbxVrstaFilter";
            this.cbxVrstaFilter.Size = new System.Drawing.Size(211, 24);
            this.cbxVrstaFilter.TabIndex = 106;
            this.cbxVrstaFilter.SelectedIndexChanged += new System.EventHandler(this.cbxVrstaFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(134)))));
            this.label3.Location = new System.Drawing.Point(121, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 31);
            this.label3.TabIndex = 105;
            this.label3.Text = "Vrsta osiguranja:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(134)))));
            this.label4.Location = new System.Drawing.Point(226, 711);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 31);
            this.label4.TabIndex = 107;
            this.label4.Text = "Ukupna odšteta:";
            // 
            // lblUkupno
            // 
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUkupno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(134)))));
            this.lblUkupno.Location = new System.Drawing.Point(460, 711);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(0, 31);
            this.lblUkupno.TabIndex = 108;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(134)))));
            this.label6.Location = new System.Drawing.Point(253, 762);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 31);
            this.label6.TabIndex = 109;
            this.label6.Text = "Ovog meseca:";
            // 
            // lblTrenutni
            // 
            this.lblTrenutni.AutoSize = true;
            this.lblTrenutni.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrenutni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(134)))));
            this.lblTrenutni.Location = new System.Drawing.Point(448, 762);
            this.lblTrenutni.Name = "lblTrenutni";
            this.lblTrenutni.Size = new System.Drawing.Size(0, 31);
            this.lblTrenutni.TabIndex = 110;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(134)))));
            this.label8.Location = new System.Drawing.Point(223, 816);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(238, 31);
            this.label8.TabIndex = 111;
            this.label8.Text = "Prošlog meseca:";
            // 
            // lblProsli
            // 
            this.lblProsli.AutoSize = true;
            this.lblProsli.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProsli.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(134)))));
            this.lblProsli.Location = new System.Drawing.Point(448, 816);
            this.lblProsli.Name = "lblProsli";
            this.lblProsli.Size = new System.Drawing.Size(0, 31);
            this.lblProsli.TabIndex = 112;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(59)))), ((int)(((byte)(167)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(138)))), ((int)(((byte)(232)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Georgia", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            this.button1.Location = new System.Drawing.Point(12, 568);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 77);
            this.button1.TabIndex = 113;
            this.button1.Text = "Obriši";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminIzvestaji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1047, 871);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblProsli);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTrenutni);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblUkupno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxVrstaFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cbxAgentFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxKlijentFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(134)))));
            this.Name = "AdminIzvestaji";
            this.Text = "AdminIzvestaji";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminIzvestaji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbxAgentFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxKlijentFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cbxVrstaFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUkupno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTrenutni;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblProsli;
        private System.Windows.Forms.Button button1;
    }
}