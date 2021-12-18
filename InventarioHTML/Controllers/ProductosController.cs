using InventarioHTML.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventarioHTML.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        private Registro_TiendasEntities db = new Registro_TiendasEntities();
        public ActionResult Index()
        {
            return View(db.Producto.ToList());
        }
        public ActionResult ModalProductos(int? id)
        {
            if (id != null)
            {
                Producto producto = db.Producto.Find(id);
                ViewBag.id_categoria = new SelectList(db.Categorias, "id_categoria", "nombre", producto.id_categoria);
                ViewBag.id_marca = new SelectList(db.Marca, "id_marca", "nombre_marca", producto.id_marca);
                ViewBag.id_tienda = new SelectList(db.Tienda, "id_tienda", "nombre", producto.id_tienda);
                return PartialView("_ModalProductos", producto);
            }
            ViewBag.id_categoria = new SelectList(db.Categorias, "id_categoria", "nombre");
            ViewBag.id_marca = new SelectList(db.Marca, "id_marca", "nombre_marca");
            ViewBag.id_tienda = new SelectList(db.Tienda, "id_tienda", "nombre");
            return PartialView("_ModalProductos");
        }
        [HttpPost]
        public ActionResult SaveProducto(Producto producto)
        {
            if (producto.id_producto == 0)
                db.Producto.Add(producto);
            else
                db.Entry(producto).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Producto producto = db.Producto.Find(id);
                db.Producto.Remove(producto);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public JsonResult GetProductoByCategoria(int? id)
        {
            if (id != null)
            {
                var encargado = (from p in db.Producto
                                 where p.id_categoria == id
                                 select new
                                 {
                                     p.id_producto,
                                     p.nombre_producto,
                                     p.precio_compra,
                                     p.precio_venta,
                                     p.codigo_producto,
                                     p.descripcion_producto
                                 });
                return Json(encargado.ToList(), JsonRequestBehavior.AllowGet);
            }
            return Json("");
        }
        public JsonResult GetProductoByTienda(int? id)
        {
            if (id != null)
            {
                var encargado = (from p in db.Producto
                                 where p.id_tienda == id
                                 select new
                                 {
                                     p.id_producto,
                                     p.nombre_producto,
                                     p.precio_compra,
                                     p.precio_venta,
                                     p.codigo_producto,
                                     p.descripcion_producto
                                 });
                return Json(encargado.ToList(), JsonRequestBehavior.AllowGet);
            }
            return Json("");
        }
        public JsonResult GetProductoByMarca(int? id)
        {
            if (id != null)
            {
                var encargado = (from p in db.Producto
                                 where p.id_marca == id
                                 select new
                                 {
                                     p.id_producto,
                                     p.nombre_producto,
                                     p.precio_compra,
                                     p.precio_venta,
                                     p.codigo_producto,
                                     p.descripcion_producto
                                 });
                return Json(encargado.ToList(), JsonRequestBehavior.AllowGet);
            }
            return Json("");
        }
        public JsonResult VerificarCodigo(string codigo)
        {
            if (codigo != "")
            {
                var productos = db.Producto.FirstOrDefault(p => p.codigo_producto == codigo);
                if (productos != null)
                    return Json("El codigo ya existe en el sistema", JsonRequestBehavior.AllowGet);
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}