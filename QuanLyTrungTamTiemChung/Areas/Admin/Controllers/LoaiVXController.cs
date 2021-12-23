using QuanLyTrungTamTiemChung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTamTiemChung.Areas.Admin.Controllers
{
    public class LoaiVXController : Controller
    {
        private ApplicationDbContext _context;
        public LoaiVXController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Admin/LoaiVX
        public ActionResult Index()
        {
            var lvx = _context.LOAIVACXIN.SqlQuery("Select * from LOAIVACXIN").ToList();
            return View(lvx) ;
        }
        public ViewResult Create()
        {
            ViewBag.Kho = _context.KHO.SqlQuery("Select * from KHO").ToList();

            return View();
        }
        public ActionResult Edit(int id)
        {
            var lvx = _context.LOAIVACXIN.SqlQuery("Select * from LOAIVACXIN where MALOAI = {0}", new object[] { id }).SingleOrDefault();
            if (lvx == null)
                return HttpNotFound();
            ViewBag.Kho = _context.KHO.ToList();

            return View(lvx);
        }

        public ActionResult Delete(int id)
        {
            var lvx = _context.LOAIVACXIN.SqlQuery("Select * from LOAIVACXIN where MALOAI = {0}", new object[] { id }).SingleOrDefault();
            if (lvx == null)
                return HttpNotFound();
            else
            {
                _context.Database.ExecuteSqlCommand("delete from LOAIVACXIN WHERE MALOAI = {0}", new object[] { id });
                return RedirectToAction("Index", "LoaiVX");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(LOAIVACXIN lvx)
        {
            _context.Database.ExecuteSqlCommand("EXEC TAO_LOAIVX {0},{1},{2}", new object[] { lvx.MALOAI, lvx.TENLOAI, lvx.MAKHO });
            return RedirectToAction("Index", "LoaiVX");
        }
    }
}