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
    public class KategoriController : Controller
    {
        // GET: Kategori
        dbo_stokEntities db = new dbo_stokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //   var degerler = db.tbl_kategoriler.ToList();
            var degerler = db.tbl_kategoriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(tbl_kategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.tbl_kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.tbl_kategoriler.Find(id);
            db.tbl_kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tbl_kategoriler.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(tbl_kategoriler p1) {
            var ktg = db.tbl_kategoriler.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
   
}