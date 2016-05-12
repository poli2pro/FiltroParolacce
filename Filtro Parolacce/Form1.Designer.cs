namespace Filtro_Parolacce
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnPubblica = new System.Windows.Forms.Button();
            this.txtTesto = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(793, 558);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnPubblica);
            this.tabPage1.Controls.Add(this.txtTesto);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(785, 532);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Posta qualcosa!";
            // 
            // btnPubblica
            // 
            this.btnPubblica.Location = new System.Drawing.Point(662, 489);
            this.btnPubblica.Name = "btnPubblica";
            this.btnPubblica.Size = new System.Drawing.Size(117, 37);
            this.btnPubblica.TabIndex = 1;
            this.btnPubblica.Text = "Pubblica";
            this.btnPubblica.UseVisualStyleBackColor = true;
            this.btnPubblica.Click += new System.EventHandler(this.btnPubblica_Click);
            // 
            // txtTesto
            // 
            this.txtTesto.Location = new System.Drawing.Point(17, 79);
            this.txtTesto.Name = "txtTesto";
            this.txtTesto.Size = new System.Drawing.Size(752, 404);
            this.txtTesto.TabIndex = 0;
            this.txtTesto.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(785, 532);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Blog page";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "aggiorna il tuo BLOG";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 584);
            this.Controls.Add(this.tabControl1);
            this.Enabled = false;
            this.Name = "Form1";
            this.Text = "progetto";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnPubblica;
        private System.Windows.Forms.RichTextBox txtTesto;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
    }
}

