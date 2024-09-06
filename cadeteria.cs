namespace cadeteria;
using cadete;
using pedidos;

public class Cadeteria{

    public string nombre{get; set;}
    public int telefono{get; set;}

    public List<Cadete> listaCadetes{get; set;} = new List<Cadete>();

    public List<Pedido> todosLosPedidos = new List<Pedido>();

    public Cadeteria(string nombre, int telefono){
        this.nombre = nombre;
        this.telefono = telefono;

    }
    public void JornalACobrar(int idCadete){
        int cantEnvios = 0;
        foreach(var pedido in todosLosPedidos){
            if(pedido.cadeteAsignado.id == idCadete){
                if(pedido.Estado == EstadoPedido.Entregado){
                    
                cantEnvios++;
                }
            }
        }
        foreach(var cadete in listaCadetes){
            if(cadete.id == idCadete){
                Console.WriteLine($"El jornal a cobrar de {cadete.nombre} es de {500*cantEnvios}");
            }
        }
        
    }
    public void  AsignarCadeteAPedido(int idCadete, int idPedido){
        foreach(var cadete in listaCadetes){
            if(cadete.id == idCadete){
                Cadete asignado = cadete;
                foreach(var pedido in todosLosPedidos){
                    if(pedido.numeroPedido == idPedido){
                        pedido.cadeteAsignado = asignado;
                        pedido.Estado = EstadoPedido.Entregado;
                    }
                }
            }
        }

    }
    public void reasignarPedido(int idCadete, int idPedido){
        
        foreach(var pedidos in todosLosPedidos){
            if(pedidos.numeroPedido == idPedido){
                pedidos.Estado = EstadoPedido.Pendiente;
            }
        }
        AsignarCadeteAPedido(idCadete, idPedido);

    }



}
