namespace cadeteria;
using cadete;


public class Cadeteria{

    private string nombre{get; set;}
    private int telefono{get; set;}

    private List<Cadete> listaCadetes{get; set;}

    public Cadeteria(string nombre, int telefono, List<Cadete> lista){
        this.nombre = nombre;
        this.telefono = telefono;
        listaCadetes = lista;

    }



}