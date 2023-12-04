using System;
using System.Collections.Generic;

namespace WebRestaurante.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string CedulaIdentidad { get; set; } = null!;

    public DateTime FechaReserva { get; set; }

    public int NumPersonas { get; set; }

    public string Solicitud { get; set; } = null!;

    public string UsuarioRegistro { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public short Estado { get; set; }
}
