namespace cadete;
using pedidos;
using System.Linq; // Para usar LINQ en el método GetPedidosEntregados

public class Cadete
{
    public int id { get; set; }
    public string nombre { get; set; }
    public string direccionCadete { get; private set; }
    public int telefono { get; private set; }

    private List<Pedido> pedidosAsignados { get; set; } = new List<Pedido>();

    public Cadete(int id, string nombre, string direccionCadete, int telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccionCadete = direccionCadete;
        this.telefono = telefono;
    }

    // Agrega un pedido a la lista de pedidos asignados
    public void AgregarPedido(Pedido pedido)
    {
        if (!pedidosAsignados.Contains(pedido))
        {
            pedidosAsignados.Add(pedido);
        }
    }

    // Elimina un pedido de la lista de pedidos asignados
    public void RemoverPedido(int numeroPedido)
    {
        var pedido = pedidosAsignados.FirstOrDefault(p => p.numeroPedido == numeroPedido);
        if (pedido != null)
        {
            pedidosAsignados.Remove(pedido);
        }
    }

    // Verifica si el cadete tiene un pedido específico
    public bool HasPedido(int numeroPedido)
    {
        return pedidosAsignados.Any(p => p.numeroPedido == numeroPedido);
    }

    // Cuenta la cantidad de pedidos entregados
    public int GetPedidosEntregados()
    {
        return pedidosAsignados.Count(p => p.Estado == EstadoPedido.Entregado);
    }

    // Método para mostrar información del cadete
    public override string ToString()
    {
        return $"ID: {id}, Nombre: {nombre}, Teléfono: {telefono}";
    }
}