using System.ComponentModel.DataAnnotations;

public class ComprasDetalle
{
    [Key]
    public int CompraDetalleId { get; set; }

    public int CompraId { get; set; }
    public int ProductoId { get; set; }
    [Required(ErrorMessage = "La descripcion no puede estar vacia...")]
    public String? Descripcion { get; set; }
    public string NombreProducto { get; set; }
    [Required(ErrorMessage = "El importe no puede estar vacio...")]
    [Range(1, int.MaxValue, ErrorMessage = "El Precio debe estar en el rango de {1} y {2}.")]
    public double Importe { get; set; }
    [Required(ErrorMessage = "La Cantidad no puede estar vacia...")]
    [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe estar en el rango de {1} y {2}.")]
    public int Cantidad { get; set; }
    [Required(ErrorMessage = "El costo no puede estar vacio...")]
    [Range(1, int.MaxValue, ErrorMessage = "El costo debe estar en el rango de {1} y {2}.")]
    public double Costo { get; set; }
   public ComprasDetalle()
        {
            this.CompraDetalleId = 0;
            this.ProductoId = 0;
            this.Descripcion = "";
            this.Cantidad = 0;
            this.Importe = 0;
            this.Costo = 0;
        }

        public ComprasDetalle(String? descripcion, double costo, int cantidad, double importe)
        {
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.Cantidad = cantidad;
            this.Importe = importe;
        }
    
}
