
namespace cadete;
using pedidos;
public class Cadete{
    private int id;

    public string nombre;

    private string direccionCadete;

    private int telefono;

    private List<Pedidos> pedidos;



    public Cadete(int id, string nombre, string direccionCadete, int telefono, List<Pedidos> pedidos){
        this.id = id;
        this.nombre = nombre;
        this.direccionCadete = direccionCadete;
        this.telefono = telefono;
        this.pedidos = pedidos;

    }

}