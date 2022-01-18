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
            var  gvx = _context.GOIVACXIN.ToList();
            var ctgvx = _context.CT_GOIVX.ToList();
            var mapk = pk == null ? 0:pk.MAPHIEUKHAM ;
            int magvx;
            if (_context.PHIEUKHAM.Where(c => c.MAPHIEUKHAM == mapk).FirstOrDefault() == null)
                magvx = 0;
            else
                magvx = _context.PHIEUKHAM.Where(c => c.MAPHIEUKHAM == pk.MAPHIEUKHAM).SingleOrDefault().MAPHIEUKHAM;
            ViewBag.Magvx =  magvx;
            var viewModel = new PDKViewModel(pdk)
            {
                KHACHHANG = kh,
                PHIEUKHAM = pk,
                PHIEUTIEM = pt,
                GOIVACXIN = gvx,
                CT_GOIVX = ctgvx,
                MAGOIVX = magvx,
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LuuPhieuTiem(int MAPHIEUDK, string options, int MAGOIVX, string returnUrl)
        {
            if(options == "0")
            {
                _context.Database.ExecuteSqlCommand("CapNhatPhieuTiem @MAPHIEUDK = {0}, @mabs = {1}, @magoivx = {2}", MAPHIEUDK, 1, MAGOIVX);//chú
                List<CT_GOIVX> ct = _context.Database.SqlQuery<CT_GOIVX>("select * from CT_GOIVX where magoivx = {0}", MAGOIVX).ToList();
                foreach (var item in ct)
                {
                    _context.Database.ExecuteSqlCommand("CapNhatCTPhieuTiem @MAPHIEUDK = {0}, @MAVX = {1}, @LIEULUONG = {2}, @SOLUONG = {3},@DONGIA = {4}, @THANHTIEN =  {5}", MAPHIEUDK, item.MAVX, item.LIEULUONG, item.SOLUONG, item.DONGIA, item.THANHTIEN);
                }

            }
            else if (options == "1"){
                _context.Database.ExecuteSqlCommand("CapNhatPhieuTiem @MAPHIEUDK = {0}, @mabs = {1}, @magoivx = {2}", MAPHIEUDK, 1, DBNull.Value);
            }

            return Redirect(returnUrl);
        }

    }
}