namespace pedidos;
using cliente;

public class Pedidos{
    private int numeroPedido{get; set;}
    private string observaciones{get; set;}

    private  Cliente cliente;

    private  string estado{get; set;}
    
    

    public Pedidos(int numeroPedido, string observaciones, string estado, string nombre, string direccionCliente, int telefono){
        cliente = new Cliente(nombre, direccionCliente ,telefono);
        this.numeroPedido = numeroPedido;
        this.observaciones = observaciones;
        this.estado = estado;
    }
    public void verDireccionCliente(){
        Console.WriteLine("La direccion del cliente es: " + cliente.Direccion);
        
    }
    public void verDatosCliente(){
        Console.WriteLine("Nombre del cliente: " + cliente.Nombre + "Telefono del cliente: " + cliente.Telefono);

    }


}