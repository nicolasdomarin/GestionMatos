﻿namespace gestionMatos
{
    partial class Form1
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
            this.tabControl1Onglets = new System.Windows.Forms.TabControl();
            this.onglet_accueil = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.titre_accueil = new System.Windows.Forms.Label();
            this.groupBoxAccueilIntervention = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.onglet_clients = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id_client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Denomination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onglet_interventions = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materiel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateprevue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateRealise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.onglet_materiels = new System.Windows.Forms.TabPage();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1Onglets.SuspendLayout();
            this.onglet_accueil.SuspendLayout();
            this.groupBoxAccueilIntervention.SuspendLayout();
            this.onglet_clients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.onglet_interventions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1Onglets
            // 
            this.tabControl1Onglets.Controls.Add(this.onglet_accueil);
            this.tabControl1Onglets.Controls.Add(this.onglet_clients);
            this.tabControl1Onglets.Controls.Add(this.onglet_interventions);
            this.tabControl1Onglets.Controls.Add(this.onglet_materiels);
            this.tabControl1Onglets.Location = new System.Drawing.Point(12, 12);
            this.tabControl1Onglets.Name = "tabControl1Onglets";
            this.tabControl1Onglets.SelectedIndex = 0;
            this.tabControl1Onglets.Size = new System.Drawing.Size(807, 509);
            this.tabControl1Onglets.TabIndex = 0;
            // 
            // onglet_accueil
            // 
            this.onglet_accueil.Controls.Add(this.label4);
            this.onglet_accueil.Controls.Add(this.label3);
            this.onglet_accueil.Controls.Add(this.dateTimePicker1);
            this.onglet_accueil.Controls.Add(this.titre_accueil);
            this.onglet_accueil.Controls.Add(this.groupBoxAccueilIntervention);
            this.onglet_accueil.Location = new System.Drawing.Point(4, 22);
            this.onglet_accueil.Name = "onglet_accueil";
            this.onglet_accueil.Padding = new System.Windows.Forms.Padding(3);
            this.onglet_accueil.Size = new System.Drawing.Size(799, 483);
            this.onglet_accueil.TabIndex = 0;
            this.onglet_accueil.Text = "Accueil";
            this.onglet_accueil.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(680, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(553, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Interventions retardées :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(569, 430);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // titre_accueil
            // 
            this.titre_accueil.AutoSize = true;
            this.titre_accueil.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titre_accueil.Location = new System.Drawing.Point(280, 31);
            this.titre_accueil.Name = "titre_accueil";
            this.titre_accueil.Size = new System.Drawing.Size(214, 37);
            this.titre_accueil.TabIndex = 0;
            this.titre_accueil.Text = "GestionMatos";
            // 
            // groupBoxAccueilIntervention
            // 
            this.groupBoxAccueilIntervention.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAccueilIntervention.Controls.Add(this.label2);
            this.groupBoxAccueilIntervention.Controls.Add(this.label1);
            this.groupBoxAccueilIntervention.Controls.Add(this.linkLabel2);
            this.groupBoxAccueilIntervention.Controls.Add(this.listBox1);
            this.groupBoxAccueilIntervention.Controls.Add(this.linkLabel1);
            this.groupBoxAccueilIntervention.Controls.Add(this.listBox2);
            this.groupBoxAccueilIntervention.Location = new System.Drawing.Point(23, 111);
            this.groupBoxAccueilIntervention.Name = "groupBoxAccueilIntervention";
            this.groupBoxAccueilIntervention.Size = new System.Drawing.Size(507, 302);
            this.groupBoxAccueilIntervention.TabIndex = 5;
            this.groupBoxAccueilIntervention.TabStop = false;
            this.groupBoxAccueilIntervention.Text = "Interventions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Les cinq prochaines interventions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Les cinq dernières interventions";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(305, 274);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(55, 13);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "linkLabel2";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(45, 87);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(153, 173);
            this.listBox1.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(100, 274);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(264, 87);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(148, 173);
            this.listBox2.TabIndex = 2;
            // 
            // onglet_clients
            // 
            this.onglet_clients.Controls.Add(this.label6);
            this.onglet_clients.Controls.Add(this.textBox1);
            this.onglet_clients.Controls.Add(this.label5);
            this.onglet_clients.Controls.Add(this.dataGridView1);
            this.onglet_clients.Location = new System.Drawing.Point(4, 22);
            this.onglet_clients.Name = "onglet_clients";
            this.onglet_clients.Padding = new System.Windows.Forms.Padding(3);
            this.onglet_clients.Size = new System.Drawing.Size(799, 483);
            this.onglet_clients.TabIndex = 1;
            this.onglet_clients.Text = "Clients";
            this.onglet_clients.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Dénomination :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(470, 92);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(166, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Clients";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_client,
            this.Denomination});
            this.dataGridView1.Location = new System.Drawing.Point(6, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(245, 237);
            this.dataGridView1.TabIndex = 0;
            // 
            // id_client
            // 
            this.id_client.HeaderText = "ID";
            this.id_client.Name = "id_client";
            this.id_client.ReadOnly = true;
            // 
            // Denomination
            // 
            this.Denomination.HeaderText = "Dénomination";
            this.Denomination.Name = "Denomination";
            this.Denomination.ReadOnly = true;
            // 
            // onglet_interventions
            // 
            this.onglet_interventions.Controls.Add(this.button3);
            this.onglet_interventions.Controls.Add(this.button2);
            this.onglet_interventions.Controls.Add(this.button1);
            this.onglet_interventions.Controls.Add(this.dataGridView2);
            this.onglet_interventions.Controls.Add(this.radioButton2);
            this.onglet_interventions.Controls.Add(this.radioButton1);
            this.onglet_interventions.Controls.Add(this.label7);
            this.onglet_interventions.Controls.Add(this.groupBox1);
            this.onglet_interventions.Location = new System.Drawing.Point(4, 22);
            this.onglet_interventions.Name = "onglet_interventions";
            this.onglet_interventions.Padding = new System.Windows.Forms.Padding(3);
            this.onglet_interventions.Size = new System.Drawing.Size(799, 483);
            this.onglet_interventions.TabIndex = 2;
            this.onglet_interventions.Text = "Interventions";
            this.onglet_interventions.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(639, 251);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Supprimer";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(639, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Modifier";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(639, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Ajouter";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.client,
            this.materiel,
            this.dateprevue,
            this.dateRealise});
            this.dataGridView2.Location = new System.Drawing.Point(6, 107);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(544, 182);
            this.dataGridView2.TabIndex = 3;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // client
            // 
            this.client.HeaderText = "Client";
            this.client.Name = "client";
            this.client.ReadOnly = true;
            // 
            // materiel
            // 
            this.materiel.HeaderText = "Matériels";
            this.materiel.Name = "materiel";
            this.materiel.ReadOnly = true;
            // 
            // dateprevue
            // 
            this.dateprevue.HeaderText = "Date prévue";
            this.dateprevue.Name = "dateprevue";
            this.dateprevue.ReadOnly = true;
            // 
            // dateRealise
            // 
            this.dateRealise.HeaderText = "Date Réalisée";
            this.dateRealise.Name = "dateRealise";
            this.dateRealise.ReadOnly = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(267, 84);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(63, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "prévues";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(98, 84);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(66, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "réalisées";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(329, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Interventions";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(6, 295);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 182);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(301, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Date Réalisée :";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(399, 25);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 14;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(151, 128);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 13;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(151, 78);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Date Réalisé :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(68, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Matériel :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(79, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Client :";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(151, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(378, 121);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Valider";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // onglet_materiels
            // 
            this.onglet_materiels.Location = new System.Drawing.Point(4, 22);
            this.onglet_materiels.Name = "onglet_materiels";
            this.onglet_materiels.Padding = new System.Windows.Forms.Padding(3);
            this.onglet_materiels.Size = new System.Drawing.Size(799, 483);
            this.onglet_materiels.TabIndex = 3;
            this.onglet_materiels.Text = "Matériels";
            this.onglet_materiels.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 523);
            this.Controls.Add(this.tabControl1Onglets);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1Onglets.ResumeLayout(false);
            this.onglet_accueil.ResumeLayout(false);
            this.onglet_accueil.PerformLayout();
            this.groupBoxAccueilIntervention.ResumeLayout(false);
            this.groupBoxAccueilIntervention.PerformLayout();
            this.onglet_clients.ResumeLayout(false);
            this.onglet_clients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.onglet_interventions.ResumeLayout(false);
            this.onglet_interventions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1Onglets;
        private System.Windows.Forms.TabPage onglet_accueil;
        private System.Windows.Forms.Label titre_accueil;
        private System.Windows.Forms.GroupBox groupBoxAccueilIntervention;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TabPage onglet_interventions;
        private System.Windows.Forms.TabPage onglet_materiels;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TabPage onglet_clients;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_client;
        private System.Windows.Forms.DataGridViewTextBoxColumn Denomination;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn client;
        private System.Windows.Forms.DataGridViewTextBoxColumn materiel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateprevue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateRealise;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
    }
}
