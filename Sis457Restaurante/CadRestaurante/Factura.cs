
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CadRestaurante
{

using System;
    using System.Collections.Generic;
    
public partial class Factura
{

    public int id { get; set; }

    public int idCliente { get; set; }

    public int idEmpleado { get; set; }

    public int idComida { get; set; }

    public int idBebida { get; set; }

    public string usuarioRegistro { get; set; }

    public System.DateTime fechaRegistro { get; set; }

    public short estado { get; set; }



    public virtual Bebida Bebida { get; set; }

    public virtual Cliente Cliente { get; set; }

    public virtual Comida Comida { get; set; }

    public virtual Empleado Empleado { get; set; }

}

}
