using System;
using System.Collections.Generic;

namespace WebRestaurante.Models;

public partial class Factura1
{
    public int Id { get; set; }

    public int NombreCliente { get; set; }

    public int NombreEmpleado { get; set; }

    public int IdComida { get; set; }

    public int IdBebida { get; set; }

    public virtual Bebidum IdBebidaNavigation { get; set; } = null!;

    public virtual Comidum IdComidaNavigation { get; set; } = null!;

    public virtual Cliente NombreClienteNavigation { get; set; } = null!;

    public virtual Empleado NombreEmpleadoNavigation { get; set; } = null!;
}
