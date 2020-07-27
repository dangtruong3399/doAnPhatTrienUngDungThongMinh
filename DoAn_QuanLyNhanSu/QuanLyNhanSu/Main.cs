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
namespace QuanLyNhanSu
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        XulyGiaodien tt = new XulyGiaodien();
        public Main()
        {
            InitializeComponent();
            DevExpress.LookAndFeel.DefaultLookAndFeel thems = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            thems.LookAndFeel.SkinName = "Xmas 2008 Blue";


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
                if (tab.Text == "NhanVien")
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
                tt.AddTab(xtraTabControl1, "", "NhanVien", new NhanVien());
            }

        }

        private void barBtnItemChucVu_ItemClick(object sender, ItemClickEventArgs e)
        {



            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "ChucVu")
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
                tt.AddTab(xtraTabControl1, "", "ChucVu", new Chucvu());
            }
        }
    }
}