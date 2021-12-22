using QuanLyTrungTamTiemChung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTamTiemChung.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            ViewBag.Bs = _context.Database.SqlQuery<int>("select count(*) from BACSI a, COSO b where a.MACS = b.MACS and b.MACS = 1").FirstOrDefault();

            ViewBag.Nv = _context.Database.SqlQuery<int>("select count(*) from NHANVIEN a, COSO b where a.MACS = b.MACS and b.MACS = 1").FirstOrDefault();

            ViewBag.Vx = _context.Database.SqlQuery<int>("select sum(SOLUONG) from COSO a, KHO b, LOAIVACXIN c, VACXIN d where a.MACS = b.MACS and b.MAKHO = c.MAKHO and d.MALOAI = c.MALOAI and  b.MACS = 1");

            ViewBag.Pt = _context.Database.SqlQuery<int>("select count(*) from COSO a, PHIEUDANGKY b, PHIEUKHAM c, PHIEUTIEM d where a.MACS = b.MACS and b.MAPHIEUDK = c.MAPHIEUDK and c.MAPHIEUKHAM = d.MAPHIEUKHAM and a.MACS = 1 and MONTH(NGAYTIEM) = MONTH(GETDATE())").FirstOrDefault();
            return View();
        }
    }
}