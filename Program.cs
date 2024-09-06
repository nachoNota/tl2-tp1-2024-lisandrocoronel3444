// See https://aka.ms/new-console-template for more information
using cadeteria;
using cadete;
using pedidos;
using cliente;
using System.Data.Common;


/*TP1 A)Una empresa de cadetería necesita implementar un sistema para asignar pedidos a sus
cadetes y poder luego saber cuántos pedidos despachó cada uno para poder así pagarles su
correspondiente jornal ($500 por cada pedido Entregado)
Tenga en cuenta que: Cada Pedido tiene un Cliente y cada Cadete puede tener uno o
más pedidos. Si se elimina un pedido entonces el cliente tiene que eliminarse también. Un pedido
puede reasignarse a otro Cadete. Es necesario generar informes sobre la actividad de la
cadetería.
2.a A partir del siguiente diseño de clases incompleto, responda las preguntas planteadas
a continuación en el archivo Readme.md:*/
/*TP1 2.b Implemente el sistema de cadetería solicitado utilizando como base el diseño de
clases sugerido, tenga en cuenta que:
A) Debe agregar los métodos faltantes a las clases en función de sus respuestas del
punto anterior.
B) Los datos de la cadetería y de sus cadetes deberán ser cargados
automáticamente a partir de 2 archivos csv, uno por cada entidad.
C) El sistema posee una interfaz de consola para gestión de pedidos para realizar las
siguientes operaciones:
a) dar de alta pedidos
b) asignarlos a cadetes
c) cambiarlos de estado
d) reasignar el pedido a otro cadete.
D) Mostrar un informe de pedidos al finalizar la jornada que incluya el monto ganado
y la cantidad de envíos de cada cadete y el total. Muestre también la cantidad de
envíos promedio por cadete*/

string archivoCadeteria = "cadeteria.csv";
Cadeteria nuevaCadeteria = null;

string[] lines = File.ReadAllLines(archivoCadeteria);
if (lines.Length > 0)
{
    string[] valores = lines[0].Split(";");
    string nombreCadeteria = valores[0];
    int telefonoCadeteria;
    Int32.TryParse(valores[1], out telefonoCadeteria);

    // Crear la instancia de Cadeteria (sin lista de cadetes aún)
    nuevaCadeteria = new Cadeteria(nombreCadeteria, telefonoCadeteria);
}
string archivoCadete = "cadetes.csv";
List<Cadete> cadeteLista = new List<Cadete>();
List<Pedido> pedidosNOAsignados = new List<Pedido>();
string[] lineaCadetes = File.ReadAllLines(archivoCadete);
foreach (var lineaDatos in lineaCadetes)
{
    var valores2 = lineaDatos.Split(',');

    int id;
    Int32.TryParse(valores2[0], out id);
    int numero;
    Int32.TryParse(valores2[3], out numero);

    Cadete cadete = new Cadete(id, valores2[1], valores2[2], numero);
    cadeteLista.Add(cadete);
}


nuevaCadeteria.listaCadetes = cadeteLista;


while (true)
{
    Console.WriteLine("Sistema de Gestión de Pedidos");
    Console.WriteLine("1. Dar de alta pedidos");
    Console.WriteLine("2. Asignar pedidos a cadetes");
    Console.WriteLine("3. Cambiar estado de pedidos");
    Console.WriteLine("4. Reasignar pedidos a otro cadete");
    Console.WriteLine("5. Mostrar informe de la jornada");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Pedido nuevoPedido = CrearPedido();
            pedidosNOAsignados.Add(nuevoPedido);
            Console.WriteLine("Pedido creado exitosamente.");
            break;
        case "2":
            AsignarPedidoACadete(pedidosNOAsignados, nuevaCadeteria.listaCadetes);
            break;
        case "3":
            CambiarEstadoPedido(pedidosNOAsignados);
            break;
        case "4":
            ReasignarPedidoACadete(pedidosNOAsignados, nuevaCadeteria.listaCadetes);
            break;
        case "5":
            MostrarInforme(nuevaCadeteria.listaCadetes);
            break;
        case "6":
            return; // Salir del programa
        default:
            Console.WriteLine("Opción inválida. Intente nuevamente.");
            break;
    }
    
}


static Pedido CrearPedido()
{
    Console.WriteLine("Ingrese el número del pedido:");
    int numeroPedido;
    Int32.TryParse(Console.ReadLine(), out numeroPedido);

    Console.WriteLine("Ingrese las observaciones del pedido:");
    string observaciones = Console.ReadLine();

    Console.WriteLine("Ingrese el nombre del cliente:");
    string nombreCliente = Console.ReadLine();

    Console.WriteLine("Ingrese la dirección del cliente:");
    string direccionCliente = Console.ReadLine();

    Console.WriteLine("Ingrese el teléfono del cliente:");
    int telefonoCliente;
    Int32.TryParse(Console.ReadLine(), out telefonoCliente);

    // Crear un nuevo pedido
    return new Pedido(numeroPedido, observaciones, nombreCliente, direccionCliente, telefonoCliente);
}
static void AsignarPedidoACadete(List<Pedido> pedidosLista, List<Cadete> cadetesLista)
{
    Console.WriteLine("Seleccione el número del pedido a asignar:");

    // Mostrar los pedidos disponibles
    foreach (var pedido in pedidosLista)
    {
        Console.WriteLine($"Número de pedido: {pedido.numeroPedido}");
    }

    // Leer el número de pedido del usuario
    int numeroAsignacion;
    if (!Int32.TryParse(Console.ReadLine(), out numeroAsignacion))
    {
        Console.WriteLine("Número de pedido inválido.");
        return;
    }

    // Buscar el pedido seleccionado
    Pedido pedidoSeleccionado = null;
    foreach (var pedido in pedidosLista)
    {
        if (pedido.numeroPedido == numeroAsignacion)
        {
            pedidoSeleccionado = pedido;
            break;
        }
    }

    if (pedidoSeleccionado == null)
    {
        Console.WriteLine("Pedido no encontrado.");
        return;
    }

    Console.WriteLine("Seleccione el ID del cadete al que asignar el pedido:");

    // Mostrar los cadetes disponibles
    foreach (var cadete in cadetesLista)
    {
        Console.WriteLine($"ID Cadete: {cadete.id} - Nombre: {cadete.nombre}");
    }

    // Leer el ID del cadete del usuario
    int idCadete;
    if (!Int32.TryParse(Console.ReadLine(), out idCadete))
    {
        Console.WriteLine("ID de cadete inválido.");
        return;
    }

    // Buscar el cadete seleccionado
    Cadete cadeteSeleccionado = null;
    foreach (var cadete in cadetesLista)
    {
        if (cadete.id == idCadete)
        {
            cadeteSeleccionado = cadete;
            break;
        }
    }

    if (cadeteSeleccionado == null)
    {
        Console.WriteLine("Cadete no encontrado.");
        return;
    }

    // Asignar el pedido al cadete
    cadeteSeleccionado.AgregarPedido(pedidoSeleccionado);

    // Opcional: Eliminar el pedido de la lista de pedidos
    pedidosLista.Remove(pedidoSeleccionado);

    Console.WriteLine("Pedido asignado exitosamente.");
}
static void CambiarEstadoPedido(List<Pedido> pedidosLista)
{
    Console.WriteLine("Seleccione el número del pedido cuyo estado desea cambiar:");

    // Mostrar los pedidos disponibles
    foreach (var pedido in pedidosLista)
    {
        Console.WriteLine($"Número de pedido: {pedido.numeroPedido} - Estado: {pedido.Estado}");
    }

    // Leer el número de pedido del usuario
    int numeroPedido;
    if (!Int32.TryParse(Console.ReadLine(), out numeroPedido))
    {
        Console.WriteLine("Número de pedido inválido.");
        return;
    }

    // Buscar el pedido seleccionado
    Pedido pedidoSeleccionado = null;
    foreach (var pedido in pedidosLista)
    {
        if (pedido.numeroPedido == numeroPedido)
        {
            pedidoSeleccionado = pedido;
            break;
        }
    }

    if (pedidoSeleccionado == null)
    {
        Console.WriteLine("Pedido no encontrado.");
        return;
    }

    // Mostrar opciones para el nuevo estado
    Console.WriteLine("Seleccione el nuevo estado del pedido:");
    Console.WriteLine("1. Pendiente");
    Console.WriteLine("2. En Proceso");
    Console.WriteLine("3. Entregado");

    int nuevaOpcionEstado;
    if (!Int32.TryParse(Console.ReadLine(), out nuevaOpcionEstado) || nuevaOpcionEstado < 1 || nuevaOpcionEstado > 3)
    {
        Console.WriteLine("Opción de estado inválida.");
        return;
    }

    // Asignar el nuevo estado al pedido
    pedidoSeleccionado.Estado = (EstadoPedido)(nuevaOpcionEstado - 1);

    Console.WriteLine("Estado del pedido actualizado exitosamente.");
}
static void ReasignarPedidoACadete(List<Pedido> pedidosLista, List<Cadete> cadetesLista)
{
    Console.WriteLine("Seleccione el número del pedido a reasignar:");

    // Mostrar los pedidos disponibles
    foreach (var pedido in pedidosLista)
    {
        Console.WriteLine($"Número de pedido: {pedido.numeroPedido}");
    }

    // Leer el número de pedido del usuario
    int numeroPedido;
    if (!Int32.TryParse(Console.ReadLine(), out numeroPedido))
    {
        Console.WriteLine("Número de pedido inválido.");
        return;
    }

    // Buscar el pedido seleccionado
    Pedido pedidoSeleccionado = null;
    foreach (var pedido in pedidosLista)
    {
        if (pedido.numeroPedido == numeroPedido)
        {
            pedidoSeleccionado = pedido;
            break;
        }
    }

    if (pedidoSeleccionado == null)
    {
        Console.WriteLine("Pedido no encontrado.");
        return;
    }

    Console.WriteLine("Seleccione el ID del nuevo cadete al que reasignar el pedido:");

    // Mostrar los cadetes disponibles
    foreach (var cadete in cadetesLista)
    {
        Console.WriteLine($"ID Cadete: {cadete.id} - Nombre: {cadete.nombre}");
    }

    // Leer el ID del nuevo cadete del usuario
    int idCadete;
    if (!Int32.TryParse(Console.ReadLine(), out idCadete))
    {
        Console.WriteLine("ID de cadete inválido.");
        return;
    }

    // Buscar el nuevo cadete seleccionado
    Cadete nuevoCadete = null;
    foreach (var cadete in cadetesLista)
    {
        if (cadete.id == idCadete)
        {
            nuevoCadete = cadete;
            break;
        }
    }

    if (nuevoCadete == null)
    {
        Console.WriteLine("Cadete no encontrado.");
        return;
    }

    // Reasignar el pedido al nuevo cadete
    // Primero, eliminar el pedido del cadete actual (si es necesario)
    // Nota: Asumiendo que el Pedido ya está asignado a un Cadete y el Cadete tiene una lista de Pedidos.
    foreach (var cadete in cadetesLista)
    {
        if (cadete.HasPedido(pedidoSeleccionado.numeroPedido))
        {
            cadete.RemoverPedido(pedidoSeleccionado.numeroPedido);
            break;
        }
    }

    // Asignar el pedido al nuevo cadete
    nuevoCadete.AgregarPedido(pedidoSeleccionado);

    Console.WriteLine("Pedido reasignado exitosamente.");
}
static void MostrarInforme(List<Cadete> cadetesLista)
{
    int totalPedidosEntregados = 0;
    double totalMontoGanado = 0;

    foreach (var cadete in cadetesLista)
    {
        int pedidosEntregados = cadete.GetPedidosEntregados();
        totalPedidosEntregados += pedidosEntregados;
        totalMontoGanado += pedidosEntregados * 500;

        Console.WriteLine($"Cadete ID: {cadete.id} - Nombre: {cadete.nombre} - Pedidos Entregados: {pedidosEntregados}");
    }

    double promedioEnvios = cadetesLista.Count > 0 ? (double)totalPedidosEntregados / cadetesLista.Count : 0;

    Console.WriteLine($"Total de Pedidos Entregados: {totalPedidosEntregados}");
    Console.WriteLine($"Total Monto Ganado: ${totalMontoGanado}");
    Console.WriteLine($"Promedio de Envíos por Cadete: {promedioEnvios:F2}");
}