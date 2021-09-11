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
    public class ÜrünController : Controller
    {
        // GET: Ürün
        dbo_stokEntities db = new dbo_stokEntities();
        public ActionResult Index(int sayfa=1)
        {
          //  var degerler = db.tbl_urunler.ToList();
              var degerler = db.tbl_urunler.ToList().ToPagedList(sayfa,5);
              return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.tbl_kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(tbl_urunler p1)
        {
          
            var ktg = db.tbl_kategoriler.Where(m => m.KATEGORIID == p1.tbl_kategoriler.KATEGORIID).FirstOrDefault();
            p1.tbl_kategoriler = ktg;
            db.tbl_urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.tbl_urunler.Find(id);
            db.tbl_urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.tbl_urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.tbl_kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            
            return View("UrunGetir",urun);
        }
        public ActionResult Guncelle(tbl_urunler p1)
        {
            var ürün = db.tbl_urunler.Find(p1.URUNID);
            ürün.URUNAD = p1.URUNAD;
            //    ürün.URUNKATEGORI = p1.URUNKATEGORI;
            var ktg = db.tbl_kategoriler.Where(m => m.KATEGORIID == p1.tbl_kategoriler.KATEGORIID).FirstOrDefault();
            ürün.URUNKATEGORI = ktg.KATEGORIID;
            ürün.FIYAT = p1.FIYAT; 
            ürün.MARKA = p1.MARKA;
            ürün.STOK = p1.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}