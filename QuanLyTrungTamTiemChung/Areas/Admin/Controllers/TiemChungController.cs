using QuanLyTrungTamTiemChung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity;
using QuanLyTrungTamTiemChung.Areas.Admin.ViewModel;
using System.Globalization;

namespace QuanLyTrungTamTiemChung.Areas.Admin.Controllers
{
    public class TiemChungController : Controller
    {

        private ApplicationDbContext _context;

        public TiemChungController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Admin/TiemChung
        public ActionResult Index()
        {
            var list = _context.PHIEUDANGKY.Where(c => c.MACS == 1).Where(c => c.NGAYDANGKYTIEM >= DateTime.Today).OrderBy(c => c.NGAYDANGKYTIEM).ToList();
            return View(list);
        }

        public ActionResult Delete(int id)
        {
            var pdk = _context.PHIEUDANGKY.SingleOrDefault(c => c.MAPHIEUDK == id);
            if (pdk == null)
                return HttpNotFound();
            else
            {
                _context.PHIEUDANGKY.Remove(pdk);
                _context.SaveChanges();
                return RedirectToAction("Index", "TiemChung");

            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ReturnUrl = "~/Admin/TiemChung/Edit/" + id;

            
            var pdk = _context.PHIEUDANGKY.SingleOrDefault(c => c.MAPHIEUDK == id);
            if (pdk == null)
                return HttpNotFound();
            PHIEUKHAM pk = _context.Database.SqlQuery<PHIEUKHAM>("select * from PHIEUKHAM a, PHIEUDANGKY b where a.MAPHIEUDK = b.MAPHIEUDK and b.MAPHIEUDK = {0}", id).SingleOrDefault();
            PHIEUTIEM pt = _context.Database.SqlQuery<PHIEUTIEM>("select * from PHIEUKHAM a, PHIEUDANGKY b, PHIEUTIEM c where a.MAPHIEUDK = b.MAPHIEUDK and a.MAPHIEUKHAM = c.MAPHIEUKHAM and b.MAPHIEUDK = {0}", id).SingleOrDefault();
            KHACHHANG kh = _context.Database.SqlQuery<KHACHHANG>("select * from khachhang a, phieudangky b where a.makh = b.makh and b.MAPHIEUDK = {0}", id).SingleOrDefault();

            var viewModel = new PDKViewModel(pdk)
            {
                KHACHHANG = kh,
                PHIEUKHAM = pk,
                PHIEUTIEM = pt,
            };
            if (viewModel.PHIEUKHAM != null)
            {
                ViewBag.Diung = viewModel.PHIEUKHAM.DIUNG;
                DateTime nk = (DateTime)viewModel.PHIEUKHAM.NGAYKHAM;
                ViewBag.Nk = nk.ToString("dd-MM-yyyy", DateTimeFormatInfo.InvariantInfo);
            }
            else
            {
                ViewBag.Diung = "-1";
                ViewBag.Nk = "-1";
            }


            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LuuPhieuKham(int MAPHIEUDK, string diung, string diungtext, string nhietdo, string huyetap, string returnUrl)
        {
            var luudiung = "";
            if(diung == "0")
                luudiung = "Không có";
            else
                luudiung = diungtext;
            _context.Database.ExecuteSqlCommand("CapNhatPhieuKham @MAPHIEUDK = {0}, @Diung = {1}, @Nhietdo = {2}, @Huyetap = {3}, @Mabs = {4}", MAPHIEUDK, luudiung, nhietdo, huyetap, 1);
            return Redirect(returnUrl);
        }

    }
}