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
    public class PhieuNhapController : Controller
    {
        private ApplicationDbContext _context;

        public PhieuNhapController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/PhieuNhap
        public ActionResult Index(string searchTuTT = null, string searchDenTT = null, 
            string searchTuNgay = null, string searchDenNgay = null,
            string searchNSX = null, string searchNV = null)
        {
            ViewBag.nsx = _context.NHASANXUAT.ToList();
            ViewBag.nv = _context.NHANVIEN.ToList();
            ViewBag.pn = _context.PHIEUNHAP.ToList();

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

        public ActionResult Create()
        {

            var nsx = _context.NHASANXUAT.ToList();
            var nv = _context.NHANVIEN.ToList();

            var viewModel = new PHIEUNHAP
            {
                NHANVIENs = nv,
                NHASANXUATs = nsx
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var phieunhap = _context.PHIEUNHAP.SingleOrDefault(c => c.MAPN == id);
            if (phieunhap == null)
                return HttpNotFound();

            var nsx = _context.NHASANXUAT.ToList();
            var nv = _context.NHANVIEN.ToList();

            var viewModel = new PHIEUNHAP(phieunhap)
            {
                NHANVIENs = nv,
                NHASANXUATs = nsx
            };
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            var phieunhap = _context.PHIEUNHAP.SingleOrDefault(c => c.MAPN == id);

            var lovacxin = _context.LOVACXIN.ToList();

            if (phieunhap == null)
                return HttpNotFound();
            else
            {
                foreach(var item in lovacxin)
                {
                    if(item.MAPN==id)
                    {
                        _context.LOVACXIN.Remove(item);
                    }
                }
                _context.PHIEUNHAP.Remove(phieunhap);               
                _context.SaveChanges();
                return RedirectToAction("Index", "PhieuNhap");
            }
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

        public ActionResult IndexLoVX()
        {
            ViewBag.nsx = _context.NHASANXUAT.ToList();
            ViewBag.nv = _context.NHANVIEN.ToList();
            ViewBag.pn = _context.PHIEUNHAP.ToList();
            ViewBag.lovx = _context.LOVACXIN.ToList();
            ViewBag.vx = _context.VACXIN.ToList();

            double totalMoney = (double)_context.LOVACXIN.Sum(c => c.THANHTIEN);

            ViewBag.ToTal = totalMoney;

            //var lovx = _context.LOVACXIN.SingleOrDefault(c => c.MAPN == null);

            //return PartialView(lovx);
            IQueryable<LOVACXIN> phieunhapQuery = _context.LOVACXIN;

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

            SqlCommand.Append(" and lovx.MAPN is null ");

            var lst = _context.Database.SqlQuery<LOVACXIN>("" + SqlCommand)
                .ToList<LOVACXIN>();
            return PartialView(lst);
        }

        public ActionResult CreateLoVX()
        {
            var vx = _context.VACXIN.ToList();

            var viewModel = new LOVACXIN
            {
                VACXINs = vx
            };

            return View(viewModel);
        }

        public ActionResult EditLoVX(int id)
        {
            var lovx = _context.LOVACXIN.SingleOrDefault(c => c.MALO == id);
            if (lovx == null)
                return HttpNotFound();

            var vx = _context.VACXIN.ToList();

            var viewModel = new LOVACXIN(lovx)
            {
                VACXINs = vx
            };
            return View(viewModel);
        }

        public ActionResult DeleteLoVX(int id)
        {
            var lovx = _context.LOVACXIN.SingleOrDefault(c => c.MALO == id);
            if (lovx == null)
                return HttpNotFound();
            else
            {
                _context.LOVACXIN.Remove(lovx);
                _context.SaveChanges();
                return RedirectToAction("Create", "PhieuNhap");
            }
        }

        public ActionResult InfoLoVX(int id)
        {
            ViewBag.loaivx = _context.LOAIVACXIN.ToList();
            ViewBag.kho = _context.KHO.ToList();
            ViewBag.lovx = _context.LOVACXIN.ToList();
            ViewBag.pn = _context.PHIEUNHAP.ToList();
            ViewBag.vx = _context.VACXIN.ToList();
            ViewBag.lovxinfo = _context.LOVACXIN.SingleOrDefault(c => c.MALO == id);

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

        public ActionResult SaveLoVX(LOVACXIN lovx)
        {
            if (lovx.MALO == 0)
                _context.LOVACXIN.Add(lovx);
            else
            {
                var lovxInDb = _context.LOVACXIN.Single(c => c.MALO == lovx.MALO);
                lovxInDb.SOLUONG = lovx.SOLUONG;
                lovxInDb.DONGIA = lovx.DONGIA;
                lovxInDb.THANHTIEN = lovx.THANHTIEN;
                lovxInDb.MAVX = lovx.MAVX;
            }
            _context.SaveChanges();
            return RedirectToAction("Create", "PhieuNhap");
        }

        public ActionResult Save(PHIEUNHAP phieunhap)
        {
            if (phieunhap.MAPN == 0)
            {              
                _context.PHIEUNHAP.Add(phieunhap);
                _context.SaveChanges();
                int mapn = phieunhap.MAPN;

                var lovxInDb = _context.LOVACXIN.ToList();
                foreach (var item in lovxInDb)
                {
                    if (item.MAPN == null)
                    {
                        item.MAPN = mapn;
                        _context.SaveChanges();
                    }
                }

                double totalMoney = (double)_context.LOVACXIN.Where(c => c.MAPN == mapn).Sum(c => c.THANHTIEN);

                ViewBag.ToTal = totalMoney;

                var pnInDb = _context.PHIEUNHAP.Single(c => c.MAPN == mapn);
                pnInDb.TONGTIEN = (decimal?)totalMoney;
                _context.SaveChanges();
            }              
            else
            {
                var phieunhapInDb = _context.PHIEUNHAP.Single(c => c.MAPN == phieunhap.MAPN);
                phieunhapInDb.NGAYNHAP = phieunhap.NGAYNHAP;
                phieunhapInDb.TONGTIEN = phieunhap.TONGTIEN;
                phieunhapInDb.MANSX = phieunhap.MANSX;
                phieunhapInDb.MANV = phieunhap.MANV;
                _context.SaveChanges();
            }            
            return RedirectToAction("Index", "PhieuNhap");
        }
    }
}