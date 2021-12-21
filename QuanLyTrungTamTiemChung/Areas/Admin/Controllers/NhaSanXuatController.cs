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
    public class NhaSanXuatController : Controller
    {
        private ApplicationDbContext _context;

        public NhaSanXuatController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/NhaSanXuat
        public ActionResult Index(string searchTenNSX = null, string searchDiaChi = null)
        {
            IQueryable<NHASANXUAT> khoQuery = _context.NHASANXUAT;

            ViewBag.cs = _context.COSO.ToList();

            ViewBag.SearchTenNSX = searchTenNSX;
            ViewBag.SearchDiaChi = searchDiaChi;

            bool TenNSX = string.IsNullOrEmpty(searchTenNSX);

            bool DiaChi = string.IsNullOrEmpty(searchDiaChi);

            StringBuilder SqlCommand = new StringBuilder();

            SqlCommand.Append(" SELECT ");
            SqlCommand.Append(" nsx.MANSX MANSX, ");
            SqlCommand.Append(" nsx.TENNSX TENNSX, ");
            SqlCommand.Append(" nsx.DIACHI DIACHI, ");
            SqlCommand.Append(" nsx.SDT SDT ");
            SqlCommand.Append(" FROM NHASANXUAT nsx ");
            SqlCommand.Append(" WHERE 1=1 ");

            if (!TenNSX)  //Ten nsx
            {
                SqlCommand.Append(" and TENNSX like N'%" + searchTenNSX + "%'");
            }

            if (!DiaChi)  //Dia chi
            {
                SqlCommand.Append(" and DIACHI like N'%" + searchDiaChi + "%'");
            }

            var lst = _context.Database.SqlQuery<NHASANXUAT>("" + SqlCommand)
                .ToList<NHASANXUAT>();
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var nhasanxuat = _context.NHASANXUAT.SingleOrDefault(c => c.MANSX == id);
            if (nhasanxuat == null)
                return HttpNotFound();
            return View(nhasanxuat);
        }

        public ActionResult Delete(int id)
        {
            var nhasanxuat = _context.NHASANXUAT.SingleOrDefault(c => c.MANSX == id);
            if (nhasanxuat == null)
                return HttpNotFound();
            else
            {
                _context.NHASANXUAT.Remove(nhasanxuat);
                _context.SaveChanges();
                return RedirectToAction("Index", "NhaSanXuat");
            }
        }

        public ActionResult Info(int id)
        {
            var nhasanxuat = _context.NHASANXUAT.SingleOrDefault(c => c.MANSX == id);
            if (nhasanxuat == null)
                return HttpNotFound();
            return View(nhasanxuat);
        }

        public ActionResult Save(NHASANXUAT nhasanxuat)
        {
            if (nhasanxuat.MANSX == 0)
                _context.NHASANXUAT.Add(nhasanxuat);
            else
            {
                var nhasanxuatInDb = _context.NHASANXUAT.Single(c => c.MANSX == nhasanxuat.MANSX);
                nhasanxuatInDb.TENNSX = nhasanxuat.TENNSX;
                nhasanxuatInDb.SDT = nhasanxuat.SDT;
                nhasanxuatInDb.DIACHI = nhasanxuat.DIACHI;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "NhaSanXuat");
        }
    }
}