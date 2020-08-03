using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Library;

namespace DALL_BALL
{
    public class PhanNguoiDungVaoNhomQuyen_DAL_BLL
    {
        private QuanLyNhanSuDataContext db;
        public PhanNguoiDungVaoNhomQuyen_DAL_BLL()
        {
            db = new QuanLyNhanSuDataContext();
        }

       

        public List<PHANNGUOIDUNG_VAONHOMQUYEN> layTheoUserName(string uName)
        {
            return db.PHANNGUOIDUNG_VAONHOMQUYENs.Where(n => n.USERNAME.Equals(uName)).ToList();
        }

        public PhanNguoiDungVaoNhomQuyen_DTO layTheoKhoaChinh(string uName, string maNhom)
        {
            PHANNGUOIDUNG_VAONHOMQUYEN p = db.PHANNGUOIDUNG_VAONHOMQUYENs.FirstOrDefault(n => n.USERNAME.Equals(uName) && n.MANHOM.Equals(maNhom));
            return p == null ?
                null :
                new PhanNguoiDungVaoNhomQuyen_DTO
                {
                    UserName = p.USERNAME,
                    MaNhom = p.MANHOM,
                    GhiChu = p.GHICHU
                };
        }

        public EStatus them(PhanNguoiDungVaoNhomQuyen_DTO pNV_NQ)
        {
            PhanNguoiDungVaoNhomQuyen_DTO pTim = layTheoKhoaChinh(pNV_NQ.UserName, pNV_NQ.MaNhom);
            if (pTim != null)
                return EStatus.TRUNG_KHOA;

            if (pNV_NQ == null ||
                string.IsNullOrEmpty(pNV_NQ.UserName) ||
                string.IsNullOrEmpty(pNV_NQ.MaNhom))
                return EStatus.SAI_CAU_TRUC;
            db.PHANNGUOIDUNG_VAONHOMQUYENs.InsertOnSubmit(new PHANNGUOIDUNG_VAONHOMQUYEN
            {
                USERNAME = pNV_NQ.UserName,
                MANHOM = pNV_NQ.MaNhom,
                GHICHU = pNV_NQ.GhiChu
            });

            db.SubmitChanges();
            return EStatus.THANH_CONG;
        }

        public EStatus xoa(string uName, string maNhom)
        {
            PHANNGUOIDUNG_VAONHOMQUYEN p = db.PHANNGUOIDUNG_VAONHOMQUYENs.FirstOrDefault(n => n.USERNAME.Equals(uName) && n.MANHOM.Equals(maNhom));
            if (p == null)
                return EStatus.LOI;
            db.PHANNGUOIDUNG_VAONHOMQUYENs.DeleteOnSubmit(p);
            db.SubmitChanges();
            return EStatus.THANH_CONG;
        }

       

        public List<PHANNGUOIDUNG_VAONHOMQUYEN> layTheoMaUser(string uName)
        {
            return db.PHANNGUOIDUNG_VAONHOMQUYENs.Where(n => n.USERNAME.Equals(uName)).ToList();
        }
        public bool XoaNhieuNhomQuyen(List<PHANNGUOIDUNG_VAONHOMQUYEN> lst)
        {
            try
            {
                db.PHANNGUOIDUNG_VAONHOMQUYENs.DeleteAllOnSubmit(lst);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                string tmp = e.Message;
                return false;
            }
        }
    }
}