﻿namespace DATN.PARKING.UIUX
{
    partial class frmQueryReport
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
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            lookVehicleType = new DevExpress.XtraEditors.LookUpEdit();
            label3 = new Label();
            btnSearch = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dateEdit2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit2.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lookVehicleType.Properties).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(dateEdit2);
            panel1.Controls.Add(dateEdit1);
            panel1.Controls.Add(gridControl1);
            panel1.Controls.Add(lookVehicleType);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnSearch);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1011, 541);
            panel1.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(0, 0, 192);
            label7.Location = new Point(319, 9);
            label7.Name = "label7";
            label7.Size = new Size(199, 30);
            label7.TabIndex = 20;
            label7.Text = "Báo cáo doanh thu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 98);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 19;
            label6.Text = "Đến ngày";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 59);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 18;
            label4.Text = "Từ ngày";
            // 
            // dateEdit2
            // 
            dateEdit2.EditValue = null;
            dateEdit2.Location = new Point(104, 96);
            dateEdit2.Name = "dateEdit2";
            dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit2.Size = new Size(100, 20);
            dateEdit2.TabIndex = 17;
            // 
            // dateEdit1
            // 
            dateEdit1.EditValue = null;
            dateEdit1.Location = new Point(104, 56);
            dateEdit1.Name = "dateEdit1";
            dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit1.Size = new Size(100, 20);
            dateEdit1.TabIndex = 16;
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Bottom;
            gridControl1.Location = new Point(0, 237);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(1011, 304);
            gridControl1.TabIndex = 15;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn1, gridColumn2, gridColumn3, gridColumn4, gridColumn5, gridColumn6, gridColumn7 });
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsFilter.InHeaderSearchMode = DevExpress.XtraGrid.Views.Grid.GridInHeaderSearchMode.TextSearch;
            // 
            // gridColumn1
            // 
            gridColumn1.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gridColumn1.AppearanceHeader.Options.UseFont = true;
            gridColumn1.Caption = "Biển số xe";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            gridColumn2.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gridColumn2.AppearanceHeader.Options.UseFont = true;
            gridColumn2.Caption = "Họ và tên";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            gridColumn3.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gridColumn3.AppearanceHeader.Options.UseFont = true;
            gridColumn3.Caption = "CCCD";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            gridColumn4.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gridColumn4.AppearanceHeader.Options.UseFont = true;
            gridColumn4.Caption = "Địa chỉ";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            gridColumn5.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gridColumn5.AppearanceHeader.Options.UseFont = true;
            gridColumn5.Caption = "Loại xe ";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            gridColumn6.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gridColumn6.AppearanceHeader.Options.UseFont = true;
            gridColumn6.Caption = "Ngày xe vào";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            gridColumn7.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gridColumn7.AppearanceHeader.Options.UseFont = true;
            gridColumn7.Caption = "Ngày xe ra";
            gridColumn7.Name = "gridColumn7";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 6;
            // 
            // lookVehicleType
            // 
            lookVehicleType.Location = new Point(104, 133);
            lookVehicleType.Name = "lookVehicleType";
            lookVehicleType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lookVehicleType.Properties.NullText = "[Chọn phương tiện]";
            lookVehicleType.Size = new Size(119, 20);
            lookVehicleType.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 138);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 11;
            label3.Text = "Loại xe";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(302, 80);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(115, 50);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // frmQueryReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 541);
            Controls.Add(panel1);
            Name = "frmQueryReport";
            Text = "frmQueryReport";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dateEdit2.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lookVehicleType.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label7;
        private Label label6;
        private Label label4;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.LookUpEdit lookVehicleType;
        private Label label3;
        private Button btnSearch;
    }
}