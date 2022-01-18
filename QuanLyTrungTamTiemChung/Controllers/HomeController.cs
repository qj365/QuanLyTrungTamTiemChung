using QuanLyTrungTamTiemChung.Models;
using QuanLyTrungTamTiemChung.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTamTiemChung.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DangKy()
        {
            var dscs = _context.COSO.ToList();
            var viewModel = new ThemPDKViewModel()
            {
                DSCOSO = dscs
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LuuPhieuDK(int MACS, DateTime ngay)
        {

            ViewBag.Cs = _context.COSO.ToList();
            _context.Database.ExecuteSqlCommand("INSERT INTO PHIEUDANGKY VALUES (GETDATE(), {0}, {1}, {2})",ngay,MACS,1);//chú

            return View("TC");
        }
    }
}