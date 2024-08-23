using System.Dynamic;

namespace cliente;

public class Cliente
{
    private string nombre;


    private string direccion;

    private int telefono;

    public string Nombre { get => nombre; }
    public string Direccion { get => direccion;  }
    public int Telefono { get => telefono;  }


    public Cliente(string nombre, string direccion, int telefono)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }
}