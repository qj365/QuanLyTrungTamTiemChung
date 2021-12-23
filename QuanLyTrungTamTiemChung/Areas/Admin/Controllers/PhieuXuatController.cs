using QuanLyTrungTamTiemChung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyTrungTamTiemChung.Areas.Admin.ViewModel;

namespace QuanLyTrungTamTiemChung.Areas.Admin.Controllers
{
    public class PhieuXuatController : Controller
    {
        private ApplicationDbContext _context;
        public PhieuXuatController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Admin/PhieuXuat
        public ActionResult Index()
        {
            ViewBag.CT = _context.CT_PHIEUXUAT.ToList();
            var px = _context.PHIEUXUAT.ToList();
            return View(px);
        }

        public ViewResult Create()
        {
            ViewBag.CT = _context.CT_PHIEUXUAT.SqlQuery("select * from CT_PHIEUXUAT where MAPHIEUXUAT = 0").ToList();
            ViewBag.Kho1 = _context.KHO.ToList();
            ViewBag.Kho2 = _context.KHO.ToList();
            ViewBag.VX = _context.VACXIN.ToList();
            return View();
        }
        public ActionResult Edit(int id)
        {
            ViewBag.CT = _context.CT_PHIEUXUAT.SqlQuery("select * from CT_PHIEUXUAT where MAPHIEUXUAT = {0}", new object[] { id}).ToList();
            ViewBag.Kho1 = _context.KHO.ToList();
            ViewBag.Kho2 = _context.KHO.ToList();
            ViewBag.VX = _context.VACXIN.ToList();
            var px = _context.Database.SqlQuery<PXViewModel>("Select MAPHIEUXUAT, MAKHODICH, MAKHONGUON, TONGTIEN from PHIEUXUAT where MAPHIEUXUAT = {0}", new object[] { id }).SingleOrDefault();
            if (px == null)
                return HttpNotFound();
            return View(px);
        }

        public ActionResult Delete(int id)
        {
            var px = _context.Database.SqlQuery<PXViewModel>("Select MAPHIEUXUAT, MAKHODICH, MAKHONGUON, TONGTIEN from PHIEUXUAT where MAPHIEUXUAT = {0}", new object[] { id }).SingleOrDefault();
            if (px == null)
                return HttpNotFound();
            else
            {
                _context.Database.ExecuteSqlCommand("exec DEL_PX {0}", new object[] { id });
                return RedirectToAction("Index", "PhieuXuat");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PXViewModel px)
        {
            string url = "~/Admin/PhieuXuat/Edit";
            if (px.MAPHIEUXUAT == 0)
            {
                int mpx = _context.Database.SqlQuery<int>("SELECT DBO.TAOMAPX()").FirstOrDefault();
                _context.Database.ExecuteSqlCommand("EXEC PROC_PHIEUXUAT {0},{1},{2},{3},{4},{5}", new object[] { mpx, px.MAKHONGUON, px.MAKHODICH, 1, px.MAVX, px.SOLUONG });
                string returnurl = url + "/" + mpx.ToString();
                return Redirect(returnurl);
            }
            else
            {
                _context.Database.ExecuteSqlCommand("EXEC PROC_PHIEUXUAT {0},{1},{2},{3},{4},{5}", new object[] { px.MAPHIEUXUAT, px.MAKHONGUON, px.MAKHODICH, 1, px.MAVX, px.SOLUONG });
                string returnurl = url + "/" + px.MAPHIEUXUAT.ToString();
                return Redirect(returnurl);
            }
            
        }
    }
        
    
}