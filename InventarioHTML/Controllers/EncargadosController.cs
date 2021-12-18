using InventarioHTML.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventarioHTML.Controllers
{
    public class EncargadosController : Controller
    {
        // GET: Encargados
        private Registro_TiendasEntities db = new Registro_TiendasEntities();
        public ActionResult Index()
        {
            return View(db.Encargado.ToList());
        }
        public ActionResult ModalEncargado(int? id)
        {
            if (id != null)
            {
                Encargado encargado = db.Encargado.Find(id);
                ViewBag.id_rol = new SelectList(db.Rol, "id_rol", "nombre_rol", encargado.id_rol);
                return PartialView("_ModalEncargado", encargado);
            }
            ViewBag.id_rol = new SelectList(db.Rol, "id_rol", "nombre_rol");
            return PartialView("_ModalEncargado");
        }
        [HttpPost]
        public ActionResult SaveEncargado(Encargado encargado)
        {
            if (encargado.id_encargado == 0)
                db.Encargado.Add(encargado);
            else
                db.Entry(encargado).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Encargado encargado = db.Encargado.Find(id);
                db.Encargado.Remove(encargado);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public JsonResult GetEncargadoByRol(int? id)
        {
            if (id != null)
            {
                var encargado = (from e in db.Encargado
                                 where e.id_rol == id
                                 select new
                                 {
                                     e.id_encargado,
                                     e.nombre,
                                     e.apellido,
                                     e.rut,
                                     e.telefono,
                                     e.correo,
                                     e.contraseña
                                 });
                return Json(encargado.ToList(), JsonRequestBehavior.AllowGet);
            }
            return Json("");
        }
        public JsonResult VerificarRut(string rut)
        {
            if (rut != "")
            {
                var encargados = db.Encargado.FirstOrDefault(e => e.rut == rut);
                if (encargados != null)
                    return Json("El rut ya existe en el sistema", JsonRequestBehavior.AllowGet);
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}