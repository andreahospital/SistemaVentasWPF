//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaVentasWPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleFactura
    {
        public int Id { get; set; }
        public int factura_id { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public Nullable<int> Articulo { get; set; }
        public Nullable<double> Precio { get; set; }
    }
}
