using QuanLyTrungTamTiemChung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTamTiemChung.Areas.Admin.Controllers
{
    [Authorize]
    public class PhieuNhapStatisticController : Controller
    {
        private ApplicationDbContext _context;

        public PhieuNhapStatisticController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/PhieuNhapStatistic
        public ActionResult Index(string searchTuTT = null, string searchDenTT = null,
            string searchTuNgay = null, string searchDenNgay = null,
            string searchNSX = null, string searchNV = null)
        {
            ViewBag.nsx = _context.NHASANXUAT.ToList();
            ViewBag.nv = _context.NHANVIEN.ToList();
            ViewBag.pn = _context.PHIEUNHAP.ToList();

            //Tinh tong so lo vac xin và số lượng vắc xin
            int countlovx = 0; // tong so lo vac xin
            int countsoluongvx = 0; // tong so luong vac xin

            ViewBag.lovx = _context.LOVACXIN.ToList();
            foreach(var item in ViewBag.lovx)
            {
                countlovx++;
                countsoluongvx = countsoluongvx + item.SOLUONG;
            }
            ViewBag.countlovx = countlovx;
            ViewBag.countsoluongvx = countsoluongvx;



            IQueryable<PHIEUNHAP> phieunhapQuery = _context.PHIEUNHAP;

            ViewBag.SearchTuTT = searchTuTT;
            ViewBag.SearchDenTT = searchDenTT;
            ViewBag.SearchTuNgay = searchTuNgay;
            ViewBag.SearchDenNgay = searchDenNgay;
            ViewBag.SearchNSX = searchNSX;
            ViewBag.SearchNV = searchNV;

            bool TuTT = string.IsNullOrEmpty(searchTuTT);

            bool DenTT = string.IsNullOrEmpty(searchDenTT);

            bool TuNgay = string.IsNullOrEmpty(searchTuNgay);

            bool DenNgay = string.IsNullOrEmpty(searchDenNgay);

            bool sNhaSanXuat = string.IsNullOrEmpty(searchNSX);

            bool sNhanVien = string.IsNullOrEmpty(searchNV);

            StringBuilder SqlCommand = new StringBuilder();

            SqlCommand.Append(" SELECT ");
            SqlCommand.Append(" pn.MAPN MAPN, ");
            SqlCommand.Append(" pn.NGAYNHAP NGAYNHAP, ");
            SqlCommand.Append(" pn.TONGTIEN TONGTIEN, ");
            SqlCommand.Append(" pn.MANSX MANSX, ");
            SqlCommand.Append(" pn.MANV MANV ");
            SqlCommand.Append(" FROM PHIEUNHAP pn ");
            SqlCommand.Append(" WHERE 1=1 ");

            //Tim kiem theo Tong tien
            if (!TuTT && DenTT)
            {
                float fTuTT = float.Parse(searchTuTT);
                SqlCommand.Append(" and TONGTIEN >= " + fTuTT);
            }
            if (!DenTT && TuTT)
            {
                float fDenTT = float.Parse(searchDenTT);
                SqlCommand.Append(" and TONGTIEN <= " + fDenTT);
            }
            if (!TuTT && !DenTT)
            {
                float fTuTT = float.Parse(searchTuTT);
                float fDenTT = float.Parse(searchDenTT);

                SqlCommand.Append(" and TONGTIEN >= " + fTuTT + " and TONGTIEN <= " + fDenTT);
            }

            //Tim kiem theo ngay nhap
            if (!TuNgay && DenNgay)
            {
                DateTime dtTuNgay = DateTime.Parse(searchTuNgay);
                string strTuNgay = dtTuNgay.ToString("yyyy/MM/dd");
                SqlCommand.Append(" and NGAYNHAP >= '" + strTuNgay + "'");
            }
            if (!DenNgay && TuNgay)
            {
                DateTime dtDenNgay = DateTime.Parse(searchDenNgay);
                string strDenNgay = dtDenNgay.ToString("yyyy/MM/dd");
                SqlCommand.Append(" and NGAYNHAP <= '" + strDenNgay + "'");
            }
            if (!TuNgay && !DenNgay)
            {
                DateTime dtTuNgay = DateTime.Parse(searchTuNgay);
                DateTime dtDenNgay = DateTime.Parse(searchDenNgay);

                string strTuNgay = dtTuNgay.ToString("yyyy/MM/dd");
                string strDenNgay = dtDenNgay.ToString("yyyy/MM/dd");
                SqlCommand.Append(" and NGAYNHAP >= '" + dtTuNgay + "'" + " and NGAYNHAP <= '" + dtDenNgay + "'");
            }

            if (!sNhaSanXuat)  // tim theo co so
            {
                SqlCommand.Append(" and MANSX = N'" + searchNSX + "'" + "and pn.MANSX in(select MANSX from NHASANXUAT nsx)");
            }

            if (!sNhanVien)  // tim theo co so
            {
                SqlCommand.Append(" and MANV = N'" + searchNV + "'" + "and pn.MANV in(select MANV from NHANVIEN nv)");
            }

            var lst = _context.Database.SqlQuery<PHIEUNHAP>("" + SqlCommand)
                .ToList<PHIEUNHAP>();
            return View(lst);
        }

        public ActionResult Info(int id)
        {
            ViewBag.loaivx = _context.LOAIVACXIN.ToList();
            ViewBag.kho = _context.KHO.ToList();
            ViewBag.lovx = _context.LOVACXIN.ToList();
            ViewBag.pn = _context.PHIEUNHAP.ToList();
            ViewBag.vx = _context.VACXIN.ToList();
            ViewBag.nv = _context.NHANVIEN.ToList();
            ViewBag.nsx = _context.NHASANXUAT.ToList();
            ViewBag.pninfo = _context.PHIEUNHAP.SingleOrDefault(c => c.MAPN == id);

            IQueryable<LOVACXIN> lovxQuery = _context.LOVACXIN;

            StringBuilder SqlCommand = new StringBuilder();

            SqlCommand.Append(" SELECT ");
            SqlCommand.Append(" lovx.MALO MALO, ");
            SqlCommand.Append(" lovx.SOLUONG SOLUONG, ");
            SqlCommand.Append(" lovx.DONGIA DONGIA, ");
            SqlCommand.Append(" lovx.THANHTIEN THANHTIEN, ");
            SqlCommand.Append(" lovx.MAPN MAPN, ");
            SqlCommand.Append(" lovx.MAVX MAVX ");
            SqlCommand.Append(" FROM LOVACXIN lovx");

            SqlCommand.Append(" WHERE 1=1 ");

            var lst = _context.Database.SqlQuery<LOVACXIN>("" + SqlCommand)
                .ToList<LOVACXIN>();
            return View(lst);
        }
    }
}