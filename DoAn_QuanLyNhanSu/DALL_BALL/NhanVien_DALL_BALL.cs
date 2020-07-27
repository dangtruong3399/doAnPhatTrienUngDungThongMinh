using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL_BALL
{
  public  class NhanVien_DALL_BALL
    {
        QuanLyNhanSuDataContext data = new QuanLyNhanSuDataContext();
        TudongTang tt = new TudongTang();
        Kiemtrakhoacs kt = new Kiemtrakhoacs();
        public IQueryable loaddsnhanvien()
        {
            var result = from NhanViens in data.NhanViens
                         from ctChucVus in data.ctChucVus
                         where
                           ctChucVus.MaNhanVien == NhanViens.MaNhanVien
                         select new
                         {
                             NhanViens.MaNhanVien,
                             NhanViens.TenNV,
                             NhanViens.NgaySinh,
                             NhanViens.GioiTinh,
                             NhanViens.PhongBan.TenPB,
                             ctChucVus.ChucVu.TenCv,
                             ctChucVus.NgayBatDau,
                             NhanViens.SoCM,
                             NhanViens.DienThoai,
                             NhanViens.TrinhDoHV,
                             NhanViens.DiaChi,
                             NhanViens.Email,
                             NhanViens.TTHonNhan,                             
                             NhanViens.HeSoLuong,

                         };
            return result;


        }
        public bool xoanhanvien(string manv)
        {
            NhanVien nv = new NhanVien();

            if (!kt.kiemtrakhoanv(manv))
            {
                nv = data.NhanViens.Where(m => m.MaNhanVien == manv).FirstOrDefault();

                data.NhanViens.DeleteOnSubmit(nv);
                data.SubmitChanges();
                return true;
            }
            else
                return false;


        }
        public void them1nhanvien(string manv, string mapb, string mahd, string tennv,
            string gioitinh, DateTime ngaysinh, string socm, string dienthoai, string trinhdohv,
            string diachi,
            string email, string hinh, string tthonnhan, int hsl
            )
        {
            NhanVien nv = new NhanVien();
            nv.MaNhanVien = manv;
            nv.MaPB = mapb;
            nv.MaHD = mahd;
            nv.TenNV = tennv;
            nv.GioiTinh = gioitinh;
            nv.NgaySinh = ngaysinh;
            nv.SoCM = socm;
            nv.DienThoai = dienthoai;
            nv.TrinhDoHV = trinhdohv;
            nv.DiaChi = diachi;
            nv.Email = email;
            nv.Hinh = hinh;
            nv.HeSoLuong = hsl;
            nv.TTHonNhan = tthonnhan;

            data.NhanViens.InsertOnSubmit(nv);
            data.SubmitChanges();
        }


        public bool sua1nhanvien(string manv, string mapb, string tennv,
            string gioitinh, DateTime ngaysinh, string socm, string dienthoai, string trinhdohv,
            string diachi,
            string email, string hinh, string tthonnhan, int hsl)
        {


            NhanVien nv = new NhanVien();

            nv = data.NhanViens.Where(t => t.MaNhanVien == manv).FirstOrDefault();

            if (nv != null)
            {
                nv.MaPB = mapb;
                nv.TenNV = tennv;
                nv.GioiTinh = gioitinh;
                nv.NgaySinh = ngaysinh;
                nv.SoCM = socm;
                nv.DienThoai = dienthoai;
                nv.TrinhDoHV = trinhdohv;
                nv.DiaChi = diachi;
                nv.Email = email;
                nv.Hinh = hinh;
                nv.HeSoLuong = hsl;
                nv.TTHonNhan = tthonnhan;


                data.SubmitChanges();
                return true;
            }


            return false;
        }


        public string getMaNVauto()
        {
            string IDMAX = data.NhanViens.Max(w => w.MaNhanVien);
            return tt.laymatudongtang(IDMAX, "NV00");
        }

        public IQueryable loadcboHeSoLuong()
        {
            var cbo = from hsl in data.Luongs select new { hsl.HeSoLuong };
            return cbo;
        }

        //public bool them1nhanviennew(string manv, string tennv, string pBan, string cVu, string gTinh, string nSinh, string DChi, string soCM, string sdt, string TDo, string Email, string TTHNhan, string NVLam)
        //{
        //    NhanVien nv = new NhanVien();
        //    nv.MaNhanVien = manv;
        //    nv.TenNV = tennv;
        //    nv.p
        //}

    }
}
