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
    public class KhoController : Controller
    {
        private ApplicationDbContext _context;

        public KhoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/Kho
        public ActionResult Index(string searchTenKho = null, string searchDiaChi = null, string searchCoSo = null)
        {

            ViewBag.cs = _context.COSO.ToList();
            ViewBag.k = _context.KHO.ToList(); 

            IQueryable<KHO> khoQuery = _context.KHO;           

            ViewBag.SearchTenKho = searchTenKho;
            ViewBag.SearchDiaChi = searchDiaChi;
            ViewBag.SearchCoSo = searchCoSo;

            bool TenKho = string.IsNullOrEmpty(searchTenKho);

            bool DiaChi = string.IsNullOrEmpty(searchDiaChi);

            bool sCoSo = string.IsNullOrEmpty(searchCoSo);

            StringBuilder SqlCommand = new StringBuilder();

            SqlCommand.Append(" SELECT ");
            SqlCommand.Append(" k.MAKHO MAKHO, ");
            SqlCommand.Append(" k.TENKHO TENKHO, ");
            SqlCommand.Append(" k.SDT SDT, ");
            SqlCommand.Append(" k.DIACHI DIACHI, ");
            SqlCommand.Append(" k.MACS MACS ");
            SqlCommand.Append(" FROM KHO k ");
            SqlCommand.Append(" WHERE 1=1 ");

            if (!TenKho)  //Ten kho
            {
                SqlCommand.Append(" and TENKHO like N'%" + searchTenKho + "%'");
            }

            if (!DiaChi)  //Dia chi
            {
                SqlCommand.Append(" and DIACHI like N'%" + searchDiaChi + "%'");
            }

            if (!sCoSo)  // tim theo co so
            {
                SqlCommand.Append(" and MACS = N'" + searchCoSo + "'" + "and k.MACS in(select MACS from COSO cs)");
            }

            var lst = _context.Database.SqlQuery<KHO>("" + SqlCommand)
                .ToList<KHO>();
            return View(lst);
        }

        public ActionResult Create()
        {
            var cs = _context.COSO.ToList();

            var viewModel = new KHO
            {
                COSOs = cs
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var kho = _context.KHO.SingleOrDefault(c => c.MAKHO == id);
            if (kho == null)
                return HttpNotFound();

            var cs = _context.COSO.ToList();

            var viewModel = new KHO(kho)
            {
                COSOs = cs
            };
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            var kho = _context.KHO.SingleOrDefault(c => c.MAKHO == id);
            if (kho == null)
                return HttpNotFound();
            else
            {
                _context.KHO.Remove(kho);
                _context.SaveChanges();
                return RedirectToAction("Index", "Kho");
            }
        }

        public ActionResult Info(int id, string searchTenLoaiVacXin = null)
        {
            ViewBag.cs = _context.COSO.ToList();
            ViewBag.loaivx = _context.LOAIVACXIN.ToList();
            ViewBag.kho = _context.KHO.ToList();
            ViewBag.khoinfo = _context.KHO.SingleOrDefault(c => c.MAKHO == id);

            IQueryable<LOAIVACXIN> loaivxQuery = _context.LOAIVACXIN;

            ViewBag.SearchTenLoaiVacXin = searchTenLoaiVacXin;

            bool TenLoaiVacXin = string.IsNullOrEmpty(searchTenLoaiVacXin);

            StringBuilder SqlCommand = new StringBuilder();

            SqlCommand.Append(" SELECT ");
            SqlCommand.Append(" loaivx.MALOAI MALOAI, ");
            SqlCommand.Append(" loaivx.TENLOAI TENLOAI, ");
            SqlCommand.Append(" loaivx.MAKHO MAKHO ");
            SqlCommand.Append(" FROM LOAIVACXIN loaivx");

            SqlCommand.Append(" WHERE 1=1 ");

            if (!TenLoaiVacXin)  //Ten loai vac xin
            {
                SqlCommand.Append(" and TENLOAI like N'%" + searchTenLoaiVacXin + "%'");
            }

            var lst = _context.Database.SqlQuery<LOAIVACXIN>("" + SqlCommand)
                .ToList<LOAIVACXIN>();
            return View(lst);
        }

        public ActionResult Save(KHO kho)
        {
            if (kho.MAKHO == 0)
                _context.KHO.Add(kho);
            else
            {
                var khoInDb = _context.KHO.Single(c => c.MAKHO == kho.MAKHO);
                khoInDb.TENKHO = kho.TENKHO;
                khoInDb.SDT = kho.SDT;
                khoInDb.DIACHI = kho.DIACHI;
                khoInDb.MACS = kho.MACS;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Kho");
        }
    }
}