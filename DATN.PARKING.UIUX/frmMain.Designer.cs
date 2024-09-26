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
            tableLayoutPanel1 = new TableLayoutPanel();
            picGateIn = new PictureBox();
            picGateOut = new PictureBox();
            videoGateIn = new PictureBox();
            videoGateOut = new PictureBox();
            panel2 = new Panel();
            btnAuto = new RadioButton();
            btnOpenGate = new Button();
            dtGateOut = new Label();
            label20 = new Label();
            dtGateIn = new Label();
            label18 = new Label();
            txtBienSo = new Label();
            label16 = new Label();
            txtVehicleOwner = new Label();
            label13 = new Label();
            label12 = new Label();
            txtAmount = new Label();
            label10 = new Label();
            panel3 = new Panel();
            txtNhapBienSo = new TextBox();
            btnNhapBien = new Button();
            txtBienSoRa = new Label();
            label9 = new Label();
            txtBienSoVao = new Label();
            label6 = new Label();
            txtStatus = new Label();
            label4 = new Label();
            panel4 = new Panel();
            button3 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            cmtQueryInfo = new ToolStripMenuItem();
            cmtReport = new ToolStripMenuItem();
            cmtAreaParkingMap = new ToolStripMenuItem();
            cmtLogout = new ToolStripMenuItem();
            lbDateTime = new Label();
            label3 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picGateIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picGateOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)videoGateIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)videoGateOut).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1239, 797);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(picGateIn, 0, 0);
            tableLayoutPanel1.Controls.Add(picGateOut, 0, 1);
            tableLayoutPanel1.Controls.Add(videoGateIn, 1, 0);
            tableLayoutPanel1.Controls.Add(videoGateOut, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(271, 40);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(968, 757);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // picGateIn
            // 
            picGateIn.Dock = DockStyle.Fill;
            picGateIn.Location = new Point(3, 3);
            picGateIn.Name = "picGateIn";
            picGateIn.Size = new Size(478, 372);
            picGateIn.TabIndex = 0;
            picGateIn.TabStop = false;
            // 
            // picGateOut
            // 
            picGateOut.Dock = DockStyle.Fill;
            picGateOut.Location = new Point(3, 381);
            picGateOut.Name = "picGateOut";
            picGateOut.Size = new Size(478, 373);
            picGateOut.TabIndex = 1;
            picGateOut.TabStop = false;
            // 
            // videoGateIn
            // 
            videoGateIn.Dock = DockStyle.Fill;
            videoGateIn.Location = new Point(487, 3);
            videoGateIn.Name = "videoGateIn";
            videoGateIn.Size = new Size(478, 372);
            videoGateIn.TabIndex = 2;
            videoGateIn.TabStop = false;
            // 
            // videoGateOut
            // 
            videoGateOut.Dock = DockStyle.Fill;
            videoGateOut.Location = new Point(487, 381);
            videoGateOut.Name = "videoGateOut";
            videoGateOut.Size = new Size(478, 373);
            videoGateOut.TabIndex = 3;
            videoGateOut.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnAuto);
            panel2.Controls.Add(btnOpenGate);
            panel2.Controls.Add(dtGateOut);
            panel2.Controls.Add(label20);
            panel2.Controls.Add(dtGateIn);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(txtBienSo);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(txtVehicleOwner);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(txtAmount);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(txtBienSoRa);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txtBienSoVao);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txtStatus);
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
            btnAuto.Location = new Point(15, 416);
            btnAuto.Margin = new Padding(4, 3, 4, 3);
            btnAuto.Name = "btnAuto";
            btnAuto.Size = new Size(155, 24);
            btnAuto.TabIndex = 23;
            btnAuto.TabStop = true;
            btnAuto.Text = "Chế độ tự động ";
            btnAuto.UseVisualStyleBackColor = false;
            // 
            // btnOpenGate
            // 
            btnOpenGate.Location = new Point(13, 706);
            btnOpenGate.Margin = new Padding(4, 3, 4, 3);
            btnOpenGate.Name = "btnOpenGate";
            btnOpenGate.Size = new Size(238, 37);
            btnOpenGate.TabIndex = 22;
            btnOpenGate.Text = "SPACE";
            btnOpenGate.UseVisualStyleBackColor = true;
            // 
            // dtGateOut
            // 
            dtGateOut.BackColor = Color.Silver;
            dtGateOut.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtGateOut.ForeColor = Color.FromArgb(192, 0, 0);
            dtGateOut.Location = new Point(100, 665);
            dtGateOut.Margin = new Padding(4, 0, 4, 0);
            dtGateOut.Name = "dtGateOut";
            dtGateOut.Size = new Size(164, 36);
            dtGateOut.TabIndex = 21;
            dtGateOut.Text = "0,000 VNĐ";
            dtGateOut.TextAlign = ContentAlignment.MiddleCenter;
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
            // dtGateIn
            // 
            dtGateIn.BackColor = Color.Silver;
            dtGateIn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtGateIn.ForeColor = Color.FromArgb(192, 0, 0);
            dtGateIn.Location = new Point(100, 615);
            dtGateIn.Margin = new Padding(4, 0, 4, 0);
            dtGateIn.Name = "dtGateIn";
            dtGateIn.Size = new Size(164, 36);
            dtGateIn.TabIndex = 19;
            dtGateIn.Text = "0,000 VNĐ";
            dtGateIn.TextAlign = ContentAlignment.MiddleCenter;
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
            // txtBienSo
            // 
            txtBienSo.BackColor = Color.Silver;
            txtBienSo.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBienSo.ForeColor = Color.FromArgb(192, 0, 0);
            txtBienSo.Location = new Point(100, 565);
            txtBienSo.Margin = new Padding(4, 0, 4, 0);
            txtBienSo.Name = "txtBienSo";
            txtBienSo.Size = new Size(164, 36);
            txtBienSo.TabIndex = 17;
            txtBienSo.Text = "0,000 VNĐ";
            txtBienSo.TextAlign = ContentAlignment.MiddleCenter;
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
            // txtVehicleOwner
            // 
            txtVehicleOwner.BackColor = Color.Silver;
            txtVehicleOwner.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtVehicleOwner.ForeColor = Color.FromArgb(192, 0, 0);
            txtVehicleOwner.Location = new Point(100, 513);
            txtVehicleOwner.Margin = new Padding(4, 0, 4, 0);
            txtVehicleOwner.Name = "txtVehicleOwner";
            txtVehicleOwner.Size = new Size(164, 36);
            txtVehicleOwner.TabIndex = 15;
            txtVehicleOwner.Text = "0,000 VNĐ";
            txtVehicleOwner.TextAlign = ContentAlignment.MiddleCenter;
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
            // txtAmount
            // 
            txtAmount.BackColor = Color.Silver;
            txtAmount.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAmount.ForeColor = Color.FromArgb(192, 0, 0);
            txtAmount.Location = new Point(15, 351);
            txtAmount.Margin = new Padding(4, 0, 4, 0);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(240, 45);
            txtAmount.TabIndex = 9;
            txtAmount.Text = "0,000 VNĐ";
            txtAmount.TextAlign = ContentAlignment.MiddleCenter;
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
            panel3.Controls.Add(txtNhapBienSo);
            panel3.Controls.Add(btnNhapBien);
            panel3.Location = new Point(14, 288);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(240, 31);
            panel3.TabIndex = 7;
            // 
            // txtNhapBienSo
            // 
            txtNhapBienSo.Location = new Point(92, 3);
            txtNhapBienSo.Margin = new Padding(4, 3, 4, 3);
            txtNhapBienSo.Name = "txtNhapBienSo";
            txtNhapBienSo.Size = new Size(144, 23);
            txtNhapBienSo.TabIndex = 7;
            // 
            // btnNhapBien
            // 
            btnNhapBien.Location = new Point(4, 3);
            btnNhapBien.Margin = new Padding(4, 3, 4, 3);
            btnNhapBien.Name = "btnNhapBien";
            btnNhapBien.Size = new Size(82, 23);
            btnNhapBien.TabIndex = 6;
            btnNhapBien.Text = "Nhập biển";
            btnNhapBien.UseVisualStyleBackColor = true;
            // 
            // txtBienSoRa
            // 
            txtBienSoRa.BackColor = Color.White;
            txtBienSoRa.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBienSoRa.ForeColor = Color.FromArgb(0, 0, 192);
            txtBienSoRa.Location = new Point(14, 240);
            txtBienSoRa.Margin = new Padding(4, 0, 4, 0);
            txtBienSoRa.Name = "txtBienSoRa";
            txtBienSoRa.Size = new Size(240, 45);
            txtBienSoRa.TabIndex = 5;
            txtBienSoRa.Text = "20B1-073.64";
            txtBienSoRa.TextAlign = ContentAlignment.MiddleCenter;
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
            // txtBienSoVao
            // 
            txtBienSoVao.BackColor = Color.White;
            txtBienSoVao.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBienSoVao.ForeColor = Color.FromArgb(0, 0, 192);
            txtBienSoVao.Location = new Point(14, 170);
            txtBienSoVao.Margin = new Padding(4, 0, 4, 0);
            txtBienSoVao.Name = "txtBienSoVao";
            txtBienSoVao.Size = new Size(240, 45);
            txtBienSoVao.TabIndex = 3;
            txtBienSoVao.Text = "20B1-073.64";
            txtBienSoVao.TextAlign = ContentAlignment.MiddleCenter;
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
            // txtStatus
            // 
            txtStatus.BackColor = Color.White;
            txtStatus.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStatus.ForeColor = Color.Red;
            txtStatus.Location = new Point(14, 52);
            txtStatus.Margin = new Padding(4, 0, 4, 0);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(240, 87);
            txtStatus.TabIndex = 1;
            txtStatus.Text = "VÉ THÁNG: ĐÃ MỞ CỬA CHO XE RA";
            txtStatus.TextAlign = ContentAlignment.MiddleCenter;
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
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { cmtQueryInfo, cmtReport, cmtAreaParkingMap, cmtLogout });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(175, 92);
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
            // cmtAreaParkingMap
            // 
            cmtAreaParkingMap.Name = "cmtAreaParkingMap";
            cmtAreaParkingMap.Size = new Size(174, 22);
            cmtAreaParkingMap.Text = "Sơ đồ bãi giữ xe";
            cmtAreaParkingMap.Click += cmtAreaParkingMap_Click;
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
            lbDateTime.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbDateTime.ForeColor = Color.FromArgb(255, 128, 0);
            lbDateTime.Location = new Point(519, 0);
            lbDateTime.Margin = new Padding(4, 0, 4, 0);
            lbDateTime.Name = "lbDateTime";
            lbDateTime.Size = new Size(349, 40);
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
            timer1.Tick += timer1_Tick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 797);
            Controls.Add(panel1);
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Main";
            Load += frmMain_Load;
            KeyDown += frmMain_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picGateIn).EndInit();
            ((System.ComponentModel.ISupportInitialize)picGateOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)videoGateIn).EndInit();
            ((System.ComponentModel.ISupportInitialize)videoGateOut).EndInit();
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
        private System.Windows.Forms.Label dtGateOut;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label dtGateIn;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label txtBienSo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label txtVehicleOwner;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label txtAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtNhapBienSo;
        private System.Windows.Forms.Button btnNhapBien;
        private System.Windows.Forms.Label txtBienSoRa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtBienSoVao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbDateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnOpenGate;
        private System.Windows.Forms.RadioButton btnAuto;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmtQueryInfo;
        private System.Windows.Forms.ToolStripMenuItem cmtReport;
        private System.Windows.Forms.ToolStripMenuItem cmtLogout;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox picGateIn;
        private PictureBox picGateOut;
        private PictureBox videoGateIn;
        private PictureBox videoGateOut;
        private ToolStripMenuItem cmtAreaParkingMap;
    }
}