namespace DATN.PARKING.UIUX
{
    partial class frmMain
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            panel2 = new Panel();
            btnAuto = new RadioButton();
            button2 = new Button();
            label19 = new Label();
            label20 = new Label();
            label17 = new Label();
            label18 = new Label();
            label15 = new Label();
            label16 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            cbBike = new CheckBox();
            cbMotoBike = new CheckBox();
            cbCar = new CheckBox();
            label11 = new Label();
            label10 = new Label();
            panel3 = new Panel();
            textBox1 = new TextBox();
            button1 = new Button();
            label8 = new Label();
            label9 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            panel4 = new Panel();
            button3 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            cmtQueryInfo = new ToolStripMenuItem();
            cmtReport = new ToolStripMenuItem();
            cmtLogout = new ToolStripMenuItem();
            lbDateTime = new Label();
            label3 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1239, 797);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnAuto);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(label20);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(cbBike);
            panel2.Controls.Add(cbMotoBike);
            panel2.Controls.Add(cbCar);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 40);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(271, 757);
            panel2.TabIndex = 5;
            // 
            // btnAuto
            // 
            btnAuto.AutoSize = true;
            btnAuto.BackColor = Color.White;
            btnAuto.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAuto.ForeColor = Color.Red;
            btnAuto.Location = new Point(13, 399);
            btnAuto.Margin = new Padding(4, 3, 4, 3);
            btnAuto.Name = "btnAuto";
            btnAuto.Size = new Size(155, 24);
            btnAuto.TabIndex = 23;
            btnAuto.TabStop = true;
            btnAuto.Text = "Chế độ tự động ";
            btnAuto.UseVisualStyleBackColor = false;
            btnAuto.Click += btnAuto_CheckedChanged;
            // 
            // button2
            // 
            button2.Location = new Point(13, 706);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(238, 37);
            button2.TabIndex = 22;
            button2.Text = "SPACE";
            button2.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            label19.BackColor = Color.Silver;
            label19.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.FromArgb(192, 0, 0);
            label19.Location = new Point(100, 665);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(164, 36);
            label19.TabIndex = 21;
            label19.Text = "0,000 VNĐ";
            label19.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label20.Location = new Point(6, 672);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(72, 16);
            label20.TabIndex = 20;
            label20.Text = "T/G XE RA";
            // 
            // label17
            // 
            label17.BackColor = Color.Silver;
            label17.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.FromArgb(192, 0, 0);
            label17.Location = new Point(100, 615);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(164, 36);
            label17.TabIndex = 19;
            label17.Text = "0,000 VNĐ";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.Location = new Point(6, 622);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(81, 16);
            label18.TabIndex = 18;
            label18.Text = "T/G XE VÀO";
            // 
            // label15
            // 
            label15.BackColor = Color.Silver;
            label15.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.FromArgb(192, 0, 0);
            label15.Location = new Point(100, 565);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(164, 36);
            label15.TabIndex = 17;
            label15.Text = "0,000 VNĐ";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(6, 572);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(80, 16);
            label16.TabIndex = 16;
            label16.Text = "BIỂN SỐ ĐK";
            // 
            // label14
            // 
            label14.BackColor = Color.Silver;
            label14.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.FromArgb(192, 0, 0);
            label14.Location = new Point(100, 513);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(164, 36);
            label14.TabIndex = 15;
            label14.Text = "0,000 VNĐ";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(6, 520);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(56, 16);
            label13.TabIndex = 14;
            label13.Text = "CHỦ XE";
            // 
            // label12
            // 
            label12.BackColor = Color.Lime;
            label12.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(0, 462);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(271, 40);
            label12.TabIndex = 13;
            label12.Text = "THÔNG TIN NGƯỜI DÙNG";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbBike
            // 
            cbBike.AutoSize = true;
            cbBike.Location = new Point(180, 438);
            cbBike.Margin = new Padding(4, 3, 4, 3);
            cbBike.Name = "cbBike";
            cbBike.Size = new Size(62, 19);
            cbBike.TabIndex = 12;
            cbBike.Text = "Xe đạp";
            cbBike.UseVisualStyleBackColor = true;
            cbBike.Click += cbBike_CheckedChanged;
            // 
            // cbMotoBike
            // 
            cbMotoBike.AutoSize = true;
            cbMotoBike.Location = new Point(90, 438);
            cbMotoBike.Margin = new Padding(4, 3, 4, 3);
            cbMotoBike.Name = "cbMotoBike";
            cbMotoBike.Size = new Size(65, 19);
            cbMotoBike.TabIndex = 11;
            cbMotoBike.Text = "Xe máy";
            cbMotoBike.UseVisualStyleBackColor = true;
            cbMotoBike.Click += cbMotoBike_CheckedChanged;
            // 
            // cbCar
            // 
            cbCar.AutoSize = true;
            cbCar.Location = new Point(13, 438);
            cbCar.Margin = new Padding(4, 3, 4, 3);
            cbCar.Name = "cbCar";
            cbCar.Size = new Size(63, 19);
            cbCar.TabIndex = 10;
            cbCar.Text = "Xe ô tô";
            cbCar.UseVisualStyleBackColor = true;
            cbCar.Click += cbCar_CheckedChanged;
            // 
            // label11
            // 
            label11.BackColor = Color.Silver;
            label11.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(192, 0, 0);
            label11.Location = new Point(15, 351);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(240, 45);
            label11.TabIndex = 9;
            label11.Text = "0,000 VNĐ";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(4, 323);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(75, 16);
            label10.TabIndex = 8;
            label10.Text = "PHÍ GIỮ XE";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(button1);
            panel3.Location = new Point(14, 288);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(240, 31);
            panel3.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(92, 3);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(144, 23);
            textBox1.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(4, 3);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(82, 23);
            button1.TabIndex = 6;
            button1.Text = "Nhập biển";
            button1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.BackColor = Color.White;
            label8.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(0, 0, 192);
            label8.Location = new Point(14, 240);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(240, 45);
            label8.TabIndex = 5;
            label8.Text = "20B1-073.64";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(4, 222);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(82, 16);
            label9.TabIndex = 4;
            label9.Text = "BIỂN SỐ RA";
            // 
            // label7
            // 
            label7.BackColor = Color.White;
            label7.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(0, 0, 192);
            label7.Location = new Point(14, 170);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(240, 45);
            label7.TabIndex = 3;
            label7.Text = "20B1-073.64";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(4, 151);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(91, 16);
            label6.TabIndex = 2;
            label6.Text = "BIỂN SỐ VÀO";
            // 
            // label5
            // 
            label5.BackColor = Color.White;
            label5.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(14, 52);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(240, 87);
            label5.TabIndex = 1;
            label5.Text = "VÉ THÁNG: ĐÃ MỞ CỬA CHO XE RA";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.Lime;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(271, 40);
            label4.TabIndex = 0;
            label4.Text = "THÔNG TIN CẢNH BÁO";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.AutoSize = true;
            panel4.BackColor = Color.Navy;
            panel4.Controls.Add(button3);
            panel4.Controls.Add(lbDateTime);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(1239, 40);
            panel4.TabIndex = 4;
            // 
            // button3
            // 
            button3.BackColor = Color.Blue;
            button3.ContextMenuStrip = contextMenuStrip1;
            button3.Dock = DockStyle.Left;
            button3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Red;
            button3.Location = new Point(0, 0);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(222, 40);
            button3.TabIndex = 4;
            button3.Text = "DATN.PARKING";
            button3.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { cmtQueryInfo, cmtReport, cmtLogout });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(175, 70);
            // 
            // cmtQueryInfo
            // 
            cmtQueryInfo.Name = "cmtQueryInfo";
            cmtQueryInfo.Size = new Size(174, 22);
            cmtQueryInfo.Text = "Tra cứu thông tin ";
            cmtQueryInfo.Click += cmtQueryInfo_Click;
            // 
            // cmtReport
            // 
            cmtReport.Name = "cmtReport";
            cmtReport.Size = new Size(174, 22);
            cmtReport.Text = "Báo cáo doanh thu";
            cmtReport.Click += cmtReport_Click;
            // 
            // cmtLogout
            // 
            cmtLogout.Name = "cmtLogout";
            cmtLogout.Size = new Size(174, 22);
            cmtLogout.Text = "Đăng xuất";
            cmtLogout.Click += cmtLogout_Click;
            // 
            // lbDateTime
            // 
            lbDateTime.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbDateTime.ForeColor = Color.FromArgb(255, 128, 0);
            lbDateTime.Location = new Point(418, 12);
            lbDateTime.Margin = new Padding(4, 0, 4, 0);
            lbDateTime.Name = "lbDateTime";
            lbDateTime.Size = new Size(450, 28);
            lbDateTime.TabIndex = 3;
            lbDateTime.Text = "TIME";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(875, 12);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(91, 24);
            label3.TabIndex = 2;
            label3.Text = "CAMERA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(273, 10);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 24);
            label2.TabIndex = 1;
            label2.Text = "HÌNH ẢNH";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 797);
            Controls.Add(panel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Main";
            Load += frmMain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbBike;
        private System.Windows.Forms.CheckBox cbMotoBike;
        private System.Windows.Forms.CheckBox cbCar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbDateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton btnAuto;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmtQueryInfo;
        private System.Windows.Forms.ToolStripMenuItem cmtReport;
        private System.Windows.Forms.ToolStripMenuItem cmtLogout;
    }
}