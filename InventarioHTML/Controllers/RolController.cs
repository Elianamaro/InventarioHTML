using InventarioHTML.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventarioHTML.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        private Registro_TiendasEntities db = new Registro_TiendasEntities();

        public ActionResult Index()
        {
            return View(db.Rol.ToList().OrderBy(r => r.nombre_rol));
        }
        public ActionResult ModalRol()
        {
            return PartialView("_ModalRol");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModalRol(Rol rol)
        {
            if (ModelState.IsValid)
            {
                var verifica = db.Rol.FirstOrDefault(m => m.nombre_rol == rol.nombre_rol);
                if (verifica == null)
                {
                    db.Rol.Add(rol);
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
                Rol rol = db.Rol.Find(id);
                return PartialView("_Edit", rol);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Rol rol)
        {
            var verifica = db.Rol.FirstOrDefault(m => m.nombre_rol == rol.nombre_rol);
            if (verifica == null)
            {
                db.Entry(rol).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Rol rol = db.Rol.Find(id);
                db.Rol.Remove(rol);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public JsonResult VerificarRol(string rol)
        {
            if (rol != "")
            {
                var roles = db.Rol.FirstOrDefault(r => r.nombre_rol == rol);
                if (roles != null)
                    return Json("El rol ya esta registrada",JsonRequestBehavior.AllowGet);
            }
            return Json("",JsonRequestBehavior.AllowGet);
        }
    }
}