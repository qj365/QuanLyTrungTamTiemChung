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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var phieunhap = _context.PHIEUNHAP.SingleOrDefault(c => c.MAPN == id);
            if (phieunhap == null)
                return HttpNotFound();
            return View(phieunhap);
        }

        public ActionResult Delete(int id)
        {
            var phieunhap = _context.PHIEUNHAP.SingleOrDefault(c => c.MAPN == id);
            if (phieunhap == null)
                return HttpNotFound();
            else
            {
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

            return View();
        }

        public ActionResult Save(PHIEUNHAP phieunhap)
        {
            if (phieunhap.MAPN == 0)
                _context.PHIEUNHAP.Add(phieunhap);
            else
            {
                var phieunhapInDb = _context.PHIEUNHAP.Single(c => c.MAPN == phieunhap.MAPN);
                phieunhapInDb.NGAYNHAP = phieunhap.NGAYNHAP;
                phieunhapInDb.TONGTIEN = phieunhap.TONGTIEN;
                phieunhapInDb.MANSX = phieunhap.MANSX;
                phieunhapInDb.MANV = phieunhap.MANV;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "PhieuNhap");
        }
    }
}