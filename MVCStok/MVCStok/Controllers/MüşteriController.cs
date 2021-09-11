using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entitiy;
using PagedList;
using PagedList.Mvc;

namespace MVCStok.Controllers
{
    public class MüşteriController : Controller
    {
        // GET: Müşteri
        dbo_stokEntities db = new dbo_stokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //    var degerler = db.tbl_musteriler.ToList();
            var degerler = db.tbl_musteriler.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(tbl_musteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.tbl_musteriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.tbl_musteriler.Find(id);
            db.tbl_musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.tbl_musteriler.Find(id);
            return View("MusteriGetir",mus);
        }
        public ActionResult Guncelle(tbl_musteriler p1)
        {
            var mus = db.tbl_musteriler.Find(p1.MUSTERIID);
            mus.MUSTERIAD = p1.MUSTERIAD;
            mus.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}