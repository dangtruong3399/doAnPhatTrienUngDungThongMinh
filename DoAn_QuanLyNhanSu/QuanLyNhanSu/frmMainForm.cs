using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraTabbedMdi;
using System.Data;
namespace QuanLyNhanSu
{
    public partial class frmMainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string flag1 = "1";
        public delegate void Thoat();
        public Thoat thoat;
        DataTable dt = new DataTable();
        public frmMainForm()
        {
            InitializeComponent();
            InitSkinGallery();
        }
        //public frmMainForm(DataTable dt)
        //{
        //    InitializeComponent();
        //    InitSkinGallery();
        // //   this.dt = dt;
        //}

        private void loadSkin()
        {
            
        }

        void InitSkinGallery()
        {
       
        }
        #region Phân quyền
        public void phanquyen()
        {
            if (dt.Rows[0]["quyen"].ToString() == "0")
            {
                //bt_dmBophan.Enabled = false;
                //bt_dmChucvu.Enabled = false;
                //bt_dmLoaicong.Enabled = false;
                //bt_dmPhucap.Enabled = false;
                //bt_dmLoaica.Enabled = false;
                //bt_dmTinh.Enabled = false;
                //barbt_saoluu.Enabled = false;
                //barbt_phuchoi.Enabled = false;
                //barbt_taikhoan.Enabled = false;
                //navBarItem_DMTinh.Enabled = false;
                //navBarItem_DMbophan.Enabled = false;
                //navBarItem_DMChucvu.Enabled = false;
                //navBarItem_DMLoaicong.Enabled = false;
                //navBarItem_DMPhucap.Enabled = false;
                //navBarItem_taikhoan.Enabled = false;
                //navBarItem_phuchoi.Enabled = false;
                //navBarItem_Saoluu.Enabled = false;
            }
            else
            {
                //bt_dmBophan.Enabled = true;
                //bt_dmChucvu.Enabled = true;
                //bt_dmLoaicong.Enabled = true;
                //bt_dmPhucap.Enabled = true;
                //bt_dmLoaica.Enabled = true;
                //bt_dmTinh.Enabled = true;
                //barbt_saoluu.Enabled = true;
                //barbt_phuchoi.Enabled = true;
                //barbt_taikhoan.Enabled = true;
                //navBarItem_DMTinh.Enabled = true;
                //navBarItem_DMbophan.Enabled = true;
                //navBarItem_DMChucvu.Enabled = true;
                //navBarItem_DMLoaicong.Enabled = true;
                //navBarItem_DMPhucap.Enabled = true;
                //navBarItem_taikhoan.Enabled = true;
                //navBarItem_phuchoi.Enabled = true;
                //navBarItem_Saoluu.Enabled = true;
            }
        }
        #endregion
        

        private void btbaocaonhanvien_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        private void navBarItemQLSV_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

       
        private void btbaocaoluong_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        
        private void navBarItemQLSV_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void btQuanlynhanvien_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            
           
        }

        private void btquanlybaocao_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btbaocaoluong_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
        
        }

        private void barbt_nvchuakyhopdonglannao_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barbt_nvsaphethopdong_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barbt_nvdahethopdong_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barbt_nvdangconhieuluchopdong_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barbt_nvchuacobaohiemlannao_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barbt_nvdahethanbaohiem_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barbt_nvsaphethanbaohiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barbt_nvdangconhieulucbaohiem_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void nvnghiviec_bar_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void bt_baocaonhanvien_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void btBaocaoNVdenhanhopdong_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btThemcong_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
        private void btLoaicong_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void bt_NvVaolamtheongay_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void bt_NvNghiviectheongay_ItemClick(object sender, ItemClickEventArgs e)
        {
      
        }
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
        
        }

        private void navBarItemNhapxuatTufileExcel_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void navBarItem_BcNvVaolamNgay_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
         
        }

        private void navBarItem_BcNcDathoiviec_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
          
        }

        private void frmMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            thoat();
        }

        private void btPhucap_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void ribbon_Click_1(object sender, EventArgs e)
        {

        }

        private void btBangcong_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btNvTangca_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void btThemTangca_ItemClick(object sender, ItemClickEventArgs e)
        {
         
        }

        private void btNvUngluong_ItemClick(object sender, ItemClickEventArgs e)
        {
       
        }
        private void btNhanviennghiviec_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btKhautru_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btNvDitre_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bt_Bcbangcongthang_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void bt_nhap_excel_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void btChitietphucap_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btBar_DMLoaica_ItemClick(object sender, ItemClickEventArgs e)
        {
         
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
         
        }

        private void navBar_NvDenhanKyhopdong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void navBar_NvVaoLam_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void navBar_Congdoan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        
        }

        private void navBarItem_Bangcong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void navBarItemQLTangca_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
     
        }

        private void navBarItem_NvUngluong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void navBarItem_Khautru_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void navBarItem_Loaicong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void navBar_phucap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void barbt_saoluu_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barbt_phuchoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barbt_taikhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
         
        }

        private void bar_ThoatFRM_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bar_DangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            // mo lai frm dang nhap
        }

        private void bar_DoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string ngay = "Ngày: "+DateTime.Now.Day.ToString()+"/";
            ngay += DateTime.Now.Month.ToString() + "/";
            ngay += DateTime.Now.Year.ToString();
            string gio = "Giờ: " + DateTime.Now.Hour.ToString() + ":";
            gio += DateTime.Now.Minute.ToString() + ":";
            gio += DateTime.Now.Second.ToString();
          //  string nguoidung = "Đăng nhập dưới tên: " + dt.Rows[0]["ten"].ToString();
          
        }

        private void bt_dmNhanvien_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void bt_dmCongdoan_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void bt_dmBophan_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void bt_dmChucvu_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void bt_dmLoaicong_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void bt_dmPhucap_ItemClick(object sender, ItemClickEventArgs e)
        {
        
        }

        private void bt_dmLoaica_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void check_chucnang_CheckedChanged(object sender, ItemClickEventArgs e)
        {
        }

        private void bt_dmTinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void bt_dangxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bt_doimatkhau_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bt_thoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void navBarItem_QlDMLuong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void navBarItem_DMTinh_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void navBarItem_DMNhanvien_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
         
        }

        private void navBarItem_DMbophan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
         
        }

        private void navBarItem_DMChucvu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        
        }

        private void navBarItem_DMLoaicong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
          
        }

        private void navBarItem_DMPhucap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void bt_congdong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void navBarItem_taikhoan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
          
        }

        private void navBarItem_phuchoi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void navBarItem_Saoluu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        }

        private void rb_Skin_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
          
        }
    }
}