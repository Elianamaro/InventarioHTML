using InventarioHTML.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventarioHTML.Controllers
{
    public class TiendaController : Controller
    {
        // GET: Tienda
        private Registro_TiendasEntities db = new Registro_TiendasEntities();
        public ActionResult Index()
        {
            return View(db.Tienda.ToList());
        }
        public ActionResult ModalTienda(int? id)
        {
            if (id != null)
            {
                Tienda tienda = db.Tienda.Find(id);
                ViewBag.id_encargado = new SelectList(db.Encargado, "id_encargado", "nombre", tienda.id_encargado);
                return PartialView("_ModalTienda", tienda);
            }
            ViewBag.id_encargado = new SelectList(db.Encargado, "id_encargado", "nombre");
            return PartialView("_ModalTienda");
        }
        [HttpPost]
        public ActionResult SaveTienda(Tienda tienda)
        {
            if (tienda.id_tienda == 0)
                db.Tienda.Add(tienda);
            else
                db.Entry(tienda).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Tienda tienda = db.Tienda.Find(id);
                db.Tienda.Remove(tienda);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public JsonResult GetTiendaByEncargado(int? id)
        {
            if (id != null)
            {
                var tienda = (from t in db.Tienda
                              where t.id_encargado == id
                              select new
                              {
                                  t.id_tienda,
                                  t.nombre,
                                  t.ubicacion,
                                  t.telefono,
                                  t.correo
                              });
                return Json(tienda.ToList(), JsonRequestBehavior.AllowGet);
            }
            return Json("");
        }
    }
}
