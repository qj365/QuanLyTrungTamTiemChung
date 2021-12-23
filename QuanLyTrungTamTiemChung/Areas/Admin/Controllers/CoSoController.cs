using QuanLyTrungTamTiemChung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTamTiemChung.Areas.Admin.Controllers
{
    public class CoSoController : Controller
    {
        private ApplicationDbContext _context;
        public CoSoController()
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
            var cs = _context.COSO.SqlQuery("Select * from COSO").ToList();
            return View(cs);
        }
        public ViewResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var cs = _context.COSO.SqlQuery("Select * from COSO where MACS = {0}", new object[] { id }).SingleOrDefault();
            if (cs == null)
                return HttpNotFound();

            return View(cs);
        }

        public ActionResult Delete(int id)
        {
            var cs = _context.COSO.SqlQuery("Select * from COSO where MACS = {0}", new object[] { id }).SingleOrDefault();
            if (cs == null)
                return HttpNotFound();
            else
            {
                _context.Database.ExecuteSqlCommand("delete from COSO WHERE MACS = {0}", new object[] { id });
                return RedirectToAction("Index", "CoSo");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(COSO cs)
        {
            _context.Database.ExecuteSqlCommand("EXEC TAO_CS {0},{1},{2},{3}", new object[] { cs.MACS, cs.TENCS, cs.SDT, cs.DIACHI });
            return RedirectToAction("Index", "CoSo");
        }
    }
}