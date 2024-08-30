
namespace cadete;
using pedidos;
public class Cadete{
    private int id{get; set;}

    public string nombre{get; set;}

    public string direccionCadete{get; set;}

    private int telefono{get; set;}
    




    public Cadete(int id, string nombre, string direccionCadete, int telefono){
        this.id = id;
        this.nombre = nombre;
        this.direccionCadete = direccionCadete;
        this.telefono = telefono;
        

    }

}