// See https://aka.ms/new-console-template for more information
using cadeteria;
using cadete;


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

/*TP2
Refactorización del Sistema para una Cadeteria
El cliente presentó como nuevo requisito que los pedidos puedan no estar asignados a
algún cadete. Esto evidenció una falla en el diseño de clases del sistema, por lo que se decidió
realizar una refactorización del mismo.
Para poder cumplir con dicho requisito se propuso las siguientes modificaciones:
● Quitar el ListadoPedidos de la clase Cadete
● Agregar una referencia a Cadete dentro de la clase Pedido
● Agregar ListadoPedidos en la clase Cadeteria que contenga todo los pedidos que
se vayan generando.
● Agregar el método JornalACobrar en la clase Cadeteria que recibe como
parámetro el id del cadete y devuelve el monto a cobrar para dicho cadete
● Agregar el método AsignarCadeteAPedido en la clase Cadeteria que recibe como
parámetro el id del cadete y el id del Pedido
i) Implemente las modificaciones sugeridas más todas aquellas que crea necesarias
para cumplir con los requerimientos.
ii) Modifique la interfaz de usuario para cumplir con los nuevos requerimientos.*/
string archivoCadeteria = "cadeteria.csv";

string[] lines = File.ReadAllLines(archivoCadeteria);
foreach(var linea in lines){
    string[] valores = linea.Split(";");
    foreach(string columna in valores){
        Cadeteria nuevaCadeteria = new Cadeteria();
    }

}
string archivoCadete = "cadetes.csv";
List<Cadete> cadeteLista = new List<Cadete>();
string[] archivoNombres = File.ReadAllLines(archivoCadete);
foreach(var lineaNomb in archivoNombres){
       var valores2 = lineaNomb.Split(',');
   
        int id;
        Int32.TryParse(valores2[0], out id);
        int numero;
        Int32.TryParse(valores2[3], out numero);

        Cadete cadete = new Cadete(id, valores2[1], valores2[2], numero);
        cadeteLista.Add(cadete);
    }


