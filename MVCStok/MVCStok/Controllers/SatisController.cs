using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entitiy;
namespace MVCStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        dbo_stokEntities db = new dbo_stokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(tbl_satislar p1)
        {
            db.tbl_satislar.Add(p1);
            db.SaveChanges();
            return View("Index");
        }

    }
}