using InventarioHTML.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventarioHTML.Controllers
{
    public class MarcaController : Controller
    {
        private Registro_TiendasEntities db = new Registro_TiendasEntities();
        // GET: Marca
        public ActionResult Index()
        {
            return View(db.Marca.ToList().OrderBy(m => m.nombre_marca));
        }
        public ActionResult ModalMarca()
        {
            return PartialView("_ModalMarca");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModalMarca(Marca marca)
        {
            if (ModelState.IsValid)
            {
                var verifica = db.Marca.FirstOrDefault(m => m.nombre_marca == marca.nombre_marca);
                if (verifica == null)
                {
                    db.Marca.Add(marca);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Marca marca = db.Marca.Find(id);
                return PartialView("_Edit", marca);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Marca marca)
        {
            var verifica = db.Marca.FirstOrDefault(m => m.nombre_marca == marca.nombre_marca);
            if (verifica == null)
            {
                db.Entry(marca).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Marca marca = db.Marca.Find(id);
                db.Marca.Remove(marca);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public JsonResult VerificarMarca(string marca)
        {
            if (marca != "")
            {
                var marcas = db.Marca.FirstOrDefault(m => m.nombre_marca == marca);
                if (marcas != null)
                    return Json("La marca ya esta registrada",JsonRequestBehavior.AllowGet);
            }
            return Json("",JsonRequestBehavior.AllowGet);
        }
    }
}