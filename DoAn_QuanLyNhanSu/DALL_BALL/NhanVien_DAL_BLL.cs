using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DALL_BALL
{
    public class NhanVien_DAL_BLL
    {
        QuanLyNhanSuDataContext data = new QuanLyNhanSuDataContext();
        TudongTang tt = new TudongTang();
        Kiemtrakhoacs kt = new Kiemtrakhoacs();
        public List<NhanVien> dsnhanvien()
        {
            return data.NhanViens.ToList();
        }
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

            //if (!kt.kiemtrakhoanv(manv))
            //{
                nv = data.NhanViens.Where(m => m.MaNhanVien == manv).FirstOrDefault();

                data.NhanViens.DeleteOnSubmit(nv);
                data.SubmitChanges();
                return true;
            //}
            //else
            //    return false;


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



        public void xoatinhluong(string manv)
        {
            TinhLuong tl = new TinhLuong();
            tl = data.TinhLuongs.Where(t => t.MaNhanVien == manv).FirstOrDefault();
            if (tl != null)
            {
                data.TinhLuongs.DeleteOnSubmit(tl);
                data.SubmitChanges();
            }
        }

        public void xoathuongphat(string manv)
        {
            ThuongPhat tp = new ThuongPhat();
            tp = data.ThuongPhats.Where(t => t.MaNhanVien == manv).FirstOrDefault();

            if (tp != null)
            {
                data.ThuongPhats.DeleteOnSubmit(tp);
                data.SubmitChanges();
            }
        }
        public void xoachamcong(string manv)
        {
            ChamCong chamCong = new ChamCong();
            chamCong = data.ChamCongs.Where(t => t.MaNhanVien == manv).FirstOrDefault();

            if (chamCong != null)
            {
                data.ChamCongs.DeleteOnSubmit(chamCong);
                data.SubmitChanges();
            }
        }

    }
}
