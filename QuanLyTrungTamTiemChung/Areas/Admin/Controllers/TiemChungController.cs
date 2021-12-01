using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTrungTamTiemChung.Areas.Admin.Controllers
{
    public class TiemChungController : Controller
    {
        // GET: Admin/TiemChung
        public ActionResult Index()
        {
            return View();
        }
    }
}