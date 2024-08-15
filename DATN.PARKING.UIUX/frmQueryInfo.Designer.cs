namespace DATN.PARKING.UIUX
{
    partial class frmQueryInfo
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
            panel1 = new Panel();
            label6 = new Label();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            btnSearch = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label7 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(btnSearch);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(882, 499);
            panel1.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 98);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 19;
            label6.Text = "Ngày xe ra";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 59);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 18;
            label4.Text = "Ngày xe vào";
            // 
            // dateEdit2
            // 
            // 
            // dateEdit1
            // 
            // 
            // gridControl1
            // 
            // 
            // gridView1
            // 
            // 
            // lookVehicleType
            // 
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(253, 143);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 13;
            label5.Text = "Biển số xe";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(462, 98);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 11;
            label3.Text = "Loại xe";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(253, 98);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 10;
            label2.Text = "Họ và tên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(253, 59);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 9;
            label1.Text = "CCCD";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(319, 135);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(118, 23);
            textBox5.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(319, 90);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(118, 23);
            textBox4.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(319, 51);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(118, 23);
            textBox3.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(720, 75);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(115, 50);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(0, 0, 192);
            label7.Location = new Point(319, 9);
            label7.Name = "label7";
            label7.Size = new Size(209, 30);
            label7.TabIndex = 20;
            label7.Text = "Tìm kiếm thông tin ";
            // 
            // gridColumn1
            // 
            // 
            // gridColumn2
            // 
            // 
            // gridColumn3
            // 
            // 
            // gridColumn4
            // 
            // 
            // gridColumn5
            // 
            // 
            // gridColumn6
            // 
            // 
            // gridColumn7
            // 
            // 
            // frmQueryInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 499);
            Controls.Add(panel1);
            Name = "frmQueryInfo";
            Text = "frmQueryInfo";
            Load += frmQueryInfo_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
        private Label label4;
        private Label label7;
    }
}