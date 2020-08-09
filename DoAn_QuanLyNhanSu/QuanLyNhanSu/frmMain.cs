using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DALL_BALL;
using DevExpress.Skins;
using DevExpress.UserSkins;
namespace QuanLyNhanSu
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        XulyGiaodien tt = new XulyGiaodien();
        public frmMain()
        {
            InitializeComponent();
            DevExpress.LookAndFeel.DefaultLookAndFeel thems = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            thems.LookAndFeel.SkinName = "Xmas 2008 Blue";
        }

        public void Skins()
        {
            DevExpress.UserSkins.BonusSkins.Register();

            DevExpress.UserSkins.OfficeSkins.Register();

            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(SkinHT, true);
        }

        public void loadfrom(Form frm)
        {

            frm.Show();
        }

        private void barDockingMenuItem1_ListItemClick(object sender, ListItemClickEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            Skins();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {

          //  panelControl1.Controls.Clear();
            //PhongBan frm = new PhongBan();
            //frm.Show();
            //frm.Dock = DockStyle.Fill;
            //panelControl1.Controls.Add(frm);

            


        }

        private void navigationPane1_Click(object sender, EventArgs e)
        {
            
           // navigationPage1.Controls.Add(frm);
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            xtraTabControl1.TabPages.RemoveAt(xtraTabControl1.SelectedTabPageIndex);
        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem6_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Phòng Ban")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                tt.AddTab(xtraTabControl1, "", "Phòng Ban", new PhongBan());
            }
        }

        private void xtraTabControl1_Click_1(object sender, EventArgs e)
        {

        }

        private void barBtnItemNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {

            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Nhân Viên")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                tt.AddTab(xtraTabControl1, "", "Nhân Viên", new NhanVien1());
            }

        }

        private void barBtnItemChucVu_ItemClick(object sender, ItemClickEventArgs e)
        {



            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Chức Vụ")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                tt.AddTab(xtraTabControl1, "", "Chức Vụ", new Chucvu());
            }
        }

        private void barBtnItemKhenThuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "ThuongPhat")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                tt.AddTab(xtraTabControl1, "", "ThuongPhat", new ThuongPhat());
            }
        }

        private void barBtnItemChamCong_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "ChamCongg")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                tt.AddTab(xtraTabControl1, "", "ChamCongg", new ChamCongg());
            }
        }

        private void barBtnItemBangLuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "BangLuongg")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                tt.AddTab(xtraTabControl1, "", "BangLuongg", new BangLuongg());
            }
        }

        private void barBtnItemThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }


        private void barBtnItemQuanLyQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Quản Lý Quyền")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                tt.AddTab(xtraTabControl1, "", "Quản Lý Quyền", new QuanLyQuyen());
            }
        }

        private void barButtonItemPhanNhanVienVaoNhomQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Phân Nhân Viên Vào Nhóm Quyền")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                tt.AddTab(xtraTabControl1, "", "Phân Nhân Viên Vào Nhóm Quyền", new PhanNguoiDungVaoNhom());
            }
        }

        private void barBtnItemQuanLyNhomQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Quản Lý Nhóm Quyền")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                tt.AddTab(xtraTabControl1, "", "Quản Lý Nhóm Quyền", new QuanLyNhomQuyen());
            }
        }

        private void barButtonItemPhanQuyenChoNhom_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Phân Quyền Cho Nhóm")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                tt.AddTab(xtraTabControl1, "", "Phân Quyền Cho Nhóm", new PhanQuyenChoNhom());
            }
        }

        private void bbarBtnItemDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            dangXuat();
        }
        public void dangXuat()
        {
            DialogResult res =hienThiCauHoiYesNo("Xác nhận đăng xuất?");
            if (res != DialogResult.Yes)
                return;
            Hide();
            frmlogin frm = new frmlogin();
            frm.ShowDialog();
            Close();
        }
        public static DialogResult hienThiCauHoiYesNo(string mess)
        {
            return MessageBox.Show(mess, "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void barBtnItemTaoTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Tạo Tài Khoản")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                tt.AddTab(xtraTabControl1, "", "Tạo Tài Khoản", new QLNguoiDung());
            }
        }

        private void barBtnItemBaoHiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Bảo Hiểm")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                tt.AddTab(xtraTabControl1, "", "Bảo Hiểm", new BaoHiem());
            }
        }
    }
}