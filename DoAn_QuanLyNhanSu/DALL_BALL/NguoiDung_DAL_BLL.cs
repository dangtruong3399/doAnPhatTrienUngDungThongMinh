using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Library;
using System.Net.Mail;

namespace DALL_BALL
{
    public class NguoiDung_DAL_BLL
    {
        private QuanLyNhanSuDataContext db;
        private PhanNguoiDungVaoNhomQuyen_DAL_BLL _dataPvnq;

        public NguoiDung_DAL_BLL()
        {
            _dataPvnq = new PhanNguoiDungVaoNhomQuyen_DAL_BLL();
            db = new QuanLyNhanSuDataContext();
        }

      

        public NGUOIDUNG layNguoiDung(string uName)
        {
            return db.NGUOIDUNGs.FirstOrDefault(n => n.USERNAME.Equals(uName));
        }

        public List<NguoiDung_DTO> layTatCa()
        {
            List<NguoiDung_DTO> result = new List<NguoiDung_DTO>();
            foreach (NGUOIDUNG nv in db.NGUOIDUNGs)
                result.Add(new NguoiDung_DTO
                {
                    UserName = nv.USERNAME,
                    Pass = nv.PASS,
                    TenNguoiDung = nv.TENNGUOIDUNG,
                    Email = nv.EMAIL,
                    HoatDong = nv.HOATDONG
                });

            return result;
        }

        public IQueryable layNguoiDungTheoMaNhom(string maNhom)
        {
            var list = from nv in db.NGUOIDUNGs
                       join p in db.PHANNGUOIDUNG_VAONHOMQUYENs
                           on nv.USERNAME equals p.USERNAME
                       where p.MANHOM.Equals(maNhom)
                       select new { nv.USERNAME, nv.TENNGUOIDUNG, nv.EMAIL, p.GHICHU };

            return list;
        }

        

        public EStatus XoaNguoiDung(string username)
        {

            var nv = db.NGUOIDUNGs.SingleOrDefault(x => x.USERNAME.Equals(username));
            if (nv == null)
            {
                return EStatus.THAT_BAI;
            }

            var layNhomQuyen = _dataPvnq.layTheoMaUser(username);
            if (layNhomQuyen.Any())
            {
                if (!_dataPvnq.XoaNhieuNhomQuyen(layNhomQuyen))
                {
                    return EStatus.THAT_BAI;
                }
            }
            db.NGUOIDUNGs.DeleteOnSubmit(nv);

            return EStatus.THANH_CONG;

        }
        public void SaveChanged()
        {
            db.SubmitChanges();
        }
        public EStatus UpdateNguoiDung(NguoiDung_DTO nvDto)
        {
            var nv = db.NGUOIDUNGs.SingleOrDefault(x => x.USERNAME == nvDto.UserName);
            if (nv == null) return EStatus.LOI;
            nv.USERNAME = nvDto.UserName;
            nv.PASS = nvDto.Pass;
            nv.EMAIL = nvDto.Email;
            nv.HOATDONG = nvDto.HoatDong;
            nv.TENNGUOIDUNG = nvDto.TenNguoiDung;
            return EStatus.THANH_CONG;
        }
        public bool GetById(string username)
        {
            return db.NGUOIDUNGs.Any(x => x.USERNAME.Equals(username));
        }
        public bool EmailIsValid(string emailAddress)
        {
            try
            {
                var mailAddress = new MailAddress(emailAddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public EStatus AddNhanVien(NguoiDung_DTO nvDto)
        {
            try
            {

                db.NGUOIDUNGs.InsertOnSubmit(new NGUOIDUNG()
                {
                    EMAIL = nvDto.Email,
                    HOATDONG = nvDto.HoatDong,
                    PASS = nvDto.Pass,
                    TENNGUOIDUNG = nvDto.TenNguoiDung,
                    USERNAME = nvDto.UserName
                });
                return EStatus.THANH_CONG;
            }
            catch (Exception)
            {
                return EStatus.LOI;
            }
        }
    
    }
}
