using System;
using System.Collections.Generic;

namespace WebRestaurante.Models;

public partial class Factura
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public int IdEmpleado { get; set; }

    public int IdComida { get; set; }

    public int IdBebida { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual Bebidum IdBebidaNavigation { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Comidum IdComidaNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
