namespace QuanLyNhanSu
{
    partial class PhongBan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControlPhongBan = new DevExpress.XtraEditors.GroupControl();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.txtTenPb = new DevExpress.XtraEditors.TextEdit();
            this.txtMapb = new DevExpress.XtraEditors.TextEdit();
            this.lbSoNV = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dsphongban = new DevExpress.XtraGrid.GridControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlPhongBan)).BeginInit();
            this.groupControlPhongBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenPb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMapb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsphongban)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupControlPhongBan);
            this.panel1.Location = new System.Drawing.Point(11, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 262);
            this.panel1.TabIndex = 0;
            // 
            // groupControlPhongBan
            // 
            this.groupControlPhongBan.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControlPhongBan.Appearance.Options.UseBackColor = true;
            this.groupControlPhongBan.Controls.Add(this.btnXoa);
            this.groupControlPhongBan.Controls.Add(this.btnLuu);
            this.groupControlPhongBan.Controls.Add(this.btnSua);
            this.groupControlPhongBan.Controls.Add(this.btnThem);
            this.groupControlPhongBan.Controls.Add(this.txtTenPb);
            this.groupControlPhongBan.Controls.Add(this.txtMapb);
            this.groupControlPhongBan.Controls.Add(this.lbSoNV);
            this.groupControlPhongBan.Controls.Add(this.labelControl4);
            this.groupControlPhongBan.Controls.Add(this.labelControl3);
            this.groupControlPhongBan.Controls.Add(this.labelControl2);
            this.groupControlPhongBan.Controls.Add(this.labelControl1);
            this.groupControlPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlPhongBan.Location = new System.Drawing.Point(0, 0);
            this.groupControlPhongBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControlPhongBan.Name = "groupControlPhongBan";
            this.groupControlPhongBan.Size = new System.Drawing.Size(1032, 262);
            this.groupControlPhongBan.TabIndex = 0;
            this.groupControlPhongBan.Text = "PHÒNG BAN";
            this.groupControlPhongBan.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(660, 195);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(81, 24);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xoa";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(478, 195);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(81, 24);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Luu";
            this.btnLuu.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(294, 195);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(81, 24);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sua";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(113, 195);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(81, 24);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Them";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTenPb
            // 
            this.txtTenPb.Location = new System.Drawing.Point(207, 119);
            this.txtTenPb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenPb.Name = "txtTenPb";
            this.txtTenPb.Size = new System.Drawing.Size(240, 20);
            this.txtTenPb.TabIndex = 1;
            // 
            // txtMapb
            // 
            this.txtMapb.Location = new System.Drawing.Point(207, 75);
            this.txtMapb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMapb.Name = "txtMapb";
            this.txtMapb.Size = new System.Drawing.Size(240, 20);
            this.txtMapb.TabIndex = 1;
            // 
            // lbSoNV
            // 
            this.lbSoNV.Location = new System.Drawing.Point(660, 80);
            this.lbSoNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbSoNV.Name = "lbSoNV";
            this.lbSoNV.Size = new System.Drawing.Size(63, 13);
            this.lbSoNV.TabIndex = 0;
            this.lbSoNV.Text = "labelControl1";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(542, 80);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(63, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Số Nhân Viên";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(60, 77);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Mã phòng ban";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(60, 122);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "labelControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(365, 38);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(0, 13);
            this.labelControl1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.dsphongban);
            this.panelControl1.Location = new System.Drawing.Point(11, 292);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1037, 322);
            this.panelControl1.TabIndex = 1;
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 284;
            this.gridView1.GridControl = this.dsphongban;
            this.gridView1.Name = "gridView1";
            // 
            // dsphongban
            // 
            this.dsphongban.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dsphongban.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dsphongban.Location = new System.Drawing.Point(2, 2);
            this.dsphongban.MainView = this.gridView1;
            this.dsphongban.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dsphongban.Name = "dsphongban";
            this.dsphongban.Size = new System.Drawing.Size(1033, 318);
            this.dsphongban.TabIndex = 0;
            this.dsphongban.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // PhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PhongBan";
            this.Size = new System.Drawing.Size(1238, 785);
            this.Load += new System.EventHandler(this.PhongBan_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlPhongBan)).EndInit();
            this.groupControlPhongBan.ResumeLayout(false);
            this.groupControlPhongBan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenPb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMapb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsphongban)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.GroupControl groupControlPhongBan;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtTenPb;
        private DevExpress.XtraEditors.TextEdit txtMapb;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.LabelControl lbSoNV;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.GridControl dsphongban;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}
