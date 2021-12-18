//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventarioHTML.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public string codigo_producto { get; set; }
        public int precio_compra { get; set; }
        public int precio_venta { get; set; }
        public string descripcion_producto { get; set; }
        public int id_marca { get; set; }
        public int id_tienda { get; set; }
        public int id_categoria { get; set; }
        public System.DateTime fecha_recepcion { get; set; }
    
        public virtual Categorias Categorias { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Tienda Tienda { get; set; }
    }
}
