using InventarioHTML.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventarioHTML.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        private Registro_TiendasEntities db = new Registro_TiendasEntities();
        public ActionResult Index()
        {
            return View(db.Categorias.ToList().OrderBy(c => c.nombre));
        }
        public ActionResult ModalCategoria()
        {
            return PartialView("_ModalCategoria");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModalCategoria(Categorias categorias)
        {
            if (ModelState.IsValid)
            {
                var verifica = db.Categorias.FirstOrDefault(c => c.nombre == categorias.nombre);
                if (verifica == null)
                {
                    db.Categorias.Add(categorias);
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
                Categorias categorias = db.Categorias.Find(id);
                return PartialView("_Edit", categorias);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Categorias categorias)
        {
            var verifica = db.Categorias.FirstOrDefault(c => c.nombre == categorias.nombre);
            if (verifica == null)
            {
                db.Entry(categorias).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Categorias categorias = db.Categorias.Find(id);
                db.Categorias.Remove(categorias);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public JsonResult VerificarCategoria(string categoria)
        {
            if (categoria != "")
            {
                var categorias = db.Categorias.FirstOrDefault(c => c.nombre == categoria);
                if (categorias != null)
                    return Json("La marca ya esta registrada",JsonRequestBehavior.AllowGet);
            }
            return Json("",JsonRequestBehavior.AllowGet);
        }
    }
}