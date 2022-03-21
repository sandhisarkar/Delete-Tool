namespace Deleting_Tool
{
    partial class DeedParameter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxDeed = new System.Windows.Forms.TextBox();
            this.textBoxVol = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.comboBoxBook = new System.Windows.Forms.ComboBox();
            this.comboBoxRO = new System.Windows.Forms.ComboBox();
            this.comboBoxDis = new System.Windows.Forms.ComboBox();
            this.labelDeed = new System.Windows.Forms.Label();
            this.labelVol = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelBook = new System.Windows.Forms.Label();
            this.labelRO = new System.Windows.Forms.Label();
            this.labelDis = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 443);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.textBoxDeed);
            this.panel1.Controls.Add(this.textBoxVol);
            this.panel1.Controls.Add(this.textBoxYear);
            this.panel1.Controls.Add(this.comboBoxBook);
            this.panel1.Controls.Add(this.comboBoxRO);
            this.panel1.Controls.Add(this.comboBoxDis);
            this.panel1.Controls.Add(this.labelDeed);
            this.panel1.Controls.Add(this.labelVol);
            this.panel1.Controls.Add(this.labelYear);
            this.panel1.Controls.Add(this.labelBook);
            this.panel1.Controls.Add(this.labelRO);
            this.panel1.Controls.Add(this.labelDis);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 422);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(271, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 32);
            this.button1.TabIndex = 13;
            this.button1.Text = "&Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonDelete.Location = new System.Drawing.Point(116, 346);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(112, 32);
            this.buttonDelete.TabIndex = 12;
            this.buttonDelete.Text = "&Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxDeed
            // 
            this.textBoxDeed.Location = new System.Drawing.Point(217, 266);
            this.textBoxDeed.MaxLength = 5;
            this.textBoxDeed.Name = "textBoxDeed";
            this.textBoxDeed.Size = new System.Drawing.Size(221, 22);
            this.textBoxDeed.TabIndex = 11;
            this.textBoxDeed.Enter += new System.EventHandler(this.textBoxDeed_Enter);
            this.textBoxDeed.Leave += new System.EventHandler(this.textBoxDeed_Leave);
            // 
            // textBoxVol
            // 
            this.textBoxVol.Location = new System.Drawing.Point(217, 220);
            this.textBoxVol.Name = "textBoxVol";
            this.textBoxVol.Size = new System.Drawing.Size(221, 22);
            this.textBoxVol.TabIndex = 10;
            this.textBoxVol.Enter += new System.EventHandler(this.textBoxVol_Enter);
            this.textBoxVol.Leave += new System.EventHandler(this.textBoxVol_Leave);
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(216, 172);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(222, 22);
            this.textBoxYear.TabIndex = 9;
            this.textBoxYear.Enter += new System.EventHandler(this.textBoxYear_Enter);
            this.textBoxYear.Leave += new System.EventHandler(this.textBoxYear_Leave);
            // 
            // comboBoxBook
            // 
            this.comboBoxBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBook.FormattingEnabled = true;
            this.comboBoxBook.Location = new System.Drawing.Point(217, 121);
            this.comboBoxBook.Name = "comboBoxBook";
            this.comboBoxBook.Size = new System.Drawing.Size(220, 24);
            this.comboBoxBook.TabIndex = 8;
            // 
            // comboBoxRO
            // 
            this.comboBoxRO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRO.FormattingEnabled = true;
            this.comboBoxRO.Location = new System.Drawing.Point(217, 74);
            this.comboBoxRO.Name = "comboBoxRO";
            this.comboBoxRO.Size = new System.Drawing.Size(220, 24);
            this.comboBoxRO.TabIndex = 7;
            // 
            // comboBoxDis
            // 
            this.comboBoxDis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDis.Enabled = false;
            this.comboBoxDis.FormattingEnabled = true;
            this.comboBoxDis.Location = new System.Drawing.Point(217, 32);
            this.comboBoxDis.Name = "comboBoxDis";
            this.comboBoxDis.Size = new System.Drawing.Size(220, 24);
            this.comboBoxDis.TabIndex = 6;
            // 
            // labelDeed
            // 
            this.labelDeed.AutoSize = true;
            this.labelDeed.Location = new System.Drawing.Point(139, 271);
            this.labelDeed.Name = "labelDeed";
            this.labelDeed.Size = new System.Drawing.Size(54, 16);
            this.labelDeed.TabIndex = 5;
            this.labelDeed.Text = "Deed :";
            // 
            // labelVol
            // 
            this.labelVol.AutoSize = true;
            this.labelVol.Location = new System.Drawing.Point(67, 226);
            this.labelVol.Name = "labelVol";
            this.labelVol.Size = new System.Drawing.Size(126, 16);
            this.labelVol.TabIndex = 4;
            this.labelVol.Text = "Volume Number :";
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(144, 175);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(49, 16);
            this.labelYear.TabIndex = 3;
            this.labelYear.Text = "Year :";
            // 
            // labelBook
            // 
            this.labelBook.AutoSize = true;
            this.labelBook.Location = new System.Drawing.Point(142, 127);
            this.labelBook.Name = "labelBook";
            this.labelBook.Size = new System.Drawing.Size(52, 16);
            this.labelBook.TabIndex = 2;
            this.labelBook.Text = "Book :";
            // 
            // labelRO
            // 
            this.labelRO.AutoSize = true;
            this.labelRO.Location = new System.Drawing.Point(53, 78);
            this.labelRO.Name = "labelRO";
            this.labelRO.Size = new System.Drawing.Size(142, 16);
            this.labelRO.TabIndex = 1;
            this.labelRO.Text = "Where Registered :";
            // 
            // labelDis
            // 
            this.labelDis.AutoSize = true;
            this.labelDis.Location = new System.Drawing.Point(131, 38);
            this.labelDis.Name = "labelDis";
            this.labelDis.Size = new System.Drawing.Size(64, 16);
            this.labelDis.TabIndex = 0;
            this.labelDis.Text = "District :";
            // 
            // DeedParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 467);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeedParameter";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeedParameter";
            this.Load += new System.EventHandler(this.DeedParameter_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeedParameter_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DeedParameter_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DeedParameter_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDeed;
        private System.Windows.Forms.Label labelVol;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelBook;
        private System.Windows.Forms.Label labelRO;
        private System.Windows.Forms.Label labelDis;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxDeed;
        private System.Windows.Forms.TextBox textBoxVol;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.ComboBox comboBoxBook;
        private System.Windows.Forms.ComboBox comboBoxRO;
        private System.Windows.Forms.ComboBox comboBoxDis;
        private System.Windows.Forms.Button button1;
    }
}