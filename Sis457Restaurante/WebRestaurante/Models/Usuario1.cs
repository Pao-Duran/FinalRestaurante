using System;
using System.Collections.Generic;

namespace WebRestaurante.Models;

public partial class Usuario1
{
    public int Id { get; set; }

    public string Usuario { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public int IdEmpleado { get; set; }

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
