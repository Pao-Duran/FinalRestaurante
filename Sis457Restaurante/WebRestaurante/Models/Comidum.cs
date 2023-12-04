using System;
using System.Collections.Generic;

namespace WebRestaurante.Models;

public partial class Comidum
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual ICollection<Factura1> Factura1s { get; set; } = new List<Factura1>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
