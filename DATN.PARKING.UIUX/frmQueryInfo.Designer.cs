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
            gridData = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            lookVehicleType = new DevExpress.XtraEditors.GridLookUpEdit();
            gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            dtGateOut = new DevExpress.XtraEditors.DateEdit();
            dtGateIn = new DevExpress.XtraEditors.DateEdit();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtBienSoXe = new TextBox();
            txtName = new TextBox();
            txtCCCD = new TextBox();
            btnSearch = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookVehicleType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridLookUpEdit1View).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtGateOut.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtGateOut.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtGateIn.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtGateIn.Properties.CalendarTimeProperties).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(gridData);
            panel1.Controls.Add(lookVehicleType);
            panel1.Controls.Add(dtGateOut);
            panel1.Controls.Add(dtGateIn);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtBienSoXe);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(txtCCCD);
            panel1.Controls.Add(btnSearch);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(882, 499);
            panel1.TabIndex = 0;
            // 
            // gridData
            // 
            gridData.Dock = DockStyle.Bottom;
            gridData.Location = new Point(0, 201);
            gridData.MainView = gridView1;
            gridData.Name = "gridData";
            gridData.Size = new Size(882, 298);
            gridData.TabIndex = 24;
            gridData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn1, gridColumn2, gridColumn3, gridColumn4, gridColumn5, gridColumn6, gridColumn7, gridColumn8, gridColumn9, gridColumn10, gridColumn11, gridColumn12 });
            gridView1.GridControl = gridData;
            gridView1.Name = "gridView1";
            // 
            // lookVehicleType
            // 
            lookVehicleType.Location = new Point(512, 96);
            lookVehicleType.Name = "lookVehicleType";
            lookVehicleType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookVehicleType.Properties.NullText = "[Chọn loại xe]";
            lookVehicleType.Properties.PopupView = gridLookUpEdit1View;
            lookVehicleType.Size = new Size(111, 20);
            lookVehicleType.TabIndex = 23;
            // 
            // gridLookUpEdit1View
            // 
            gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // dtGateOut
            // 
            dtGateOut.EditValue = null;
            dtGateOut.Location = new Point(104, 95);
            dtGateOut.Name = "dtGateOut";
            dtGateOut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtGateOut.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtGateOut.Size = new Size(129, 20);
            dtGateOut.TabIndex = 22;
            // 
            // dtGateIn
            // 
            dtGateIn.EditValue = null;
            dtGateIn.Location = new Point(104, 57);
            dtGateIn.Name = "dtGateIn";
            dtGateIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtGateIn.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtGateIn.Size = new Size(129, 20);
            dtGateIn.TabIndex = 21;
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
            // txtBienSoXe
            // 
            txtBienSoXe.Location = new Point(319, 135);
            txtBienSoXe.Name = "txtBienSoXe";
            txtBienSoXe.Size = new Size(118, 23);
            txtBienSoXe.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.Location = new Point(319, 90);
            txtName.Name = "txtName";
            txtName.Size = new Size(118, 23);
            txtName.TabIndex = 5;
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(319, 51);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(118, 23);
            txtCCCD.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(720, 75);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(115, 50);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // gridColumn1
            // 
            gridColumn1.Caption = "Họ Và Tên";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            gridColumn2.Caption = "CCCD";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            gridColumn3.Caption = "Biển Số Xe";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            gridColumn4.Caption = "Loại Xe";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            gridColumn5.Caption = "Phương Thức Thanh Toán";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            gridColumn6.Caption = "Ngày Ra";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            gridColumn7.Caption = "Ngày Vào";
            gridColumn7.Name = "gridColumn7";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            gridColumn8.Caption = "Số Điện Thoại";
            gridColumn8.Name = "gridColumn8";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            gridColumn9.Caption = "Địa Chỉ";
            gridColumn9.Name = "gridColumn9";
            gridColumn9.Visible = true;
            gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            gridColumn10.Caption = "Email";
            gridColumn10.Name = "gridColumn10";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            gridColumn11.Caption = "Điểm";
            gridColumn11.Name = "gridColumn11";
            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 10;
            // 
            // gridColumn12
            // 
            gridColumn12.Caption = "Loại Thành Viên";
            gridColumn12.Name = "gridColumn12";
            gridColumn12.Visible = true;
            gridColumn12.VisibleIndex = 11;
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
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookVehicleType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridLookUpEdit1View).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtGateOut.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtGateOut.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtGateIn.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtGateIn.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox txtBienSoXe;
        private TextBox txtName;
        private TextBox txtCCCD;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
        private Label label4;
        private Label label7;
        private DevExpress.XtraGrid.GridControl gridData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GridLookUpEdit lookVehicleType;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.DateEdit dtGateOut;
        private DevExpress.XtraEditors.DateEdit dtGateIn;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
    }
}