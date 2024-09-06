namespace cadeteria;
using cadete;
using pedidos;

public class Cadeteria{

    public string nombre{get; set;}
    public int telefono{get; set;}

    public List<Cadete> listaCadetes{get; set;} = new List<Cadete>();

    public Cadeteria(string nombre, int telefono){
        this.nombre = nombre;
        this.telefono = telefono;

    }
    



}
