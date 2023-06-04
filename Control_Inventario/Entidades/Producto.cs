using System;
using System.Collections.Generic;

namespace Control_Inventario.Entidades;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Presentacion{ get; set; }

    public int Unidades { get; set; }

    public string LineaProducto { get; set; }

    public bool Activo { get; set; }
}

public enum Presentaciones
{
    jarabe,
    ampolla,
    tableta

}
public enum Linea_Producto
{
    Med_Nacional,
    Med_Extranjeros,
    Linea_Bebes,
    Devolutivo,
    Sin_Receta,

}
