
namespace Proyecto2 {
    public class Node {
        // variable que almacena el dato del nodo.
        // el dato se almacenará como un string, ya que es lo que se recibe en el input.
        private string nota;
        private string figura;
        public Node next;
        public Node prev;

        public Node(string nota, string figura) {
            this.nota = nota;
            this.figura = figura;
            next = null;
            prev = null;
        }

        public string getNota() {
            return nota;
        }

        public string getFigura() {
            return figura;
        }


        // Método para obtener el siguiente nodo.
        public Node getNext() {
            return next;
        }


        // Método para setear el siguiente nodo.
        public void setNext(Node node) {
            next = node;
        }

        // Método para obtener el nodo anterior. 
        public Node getPrev() {
            return prev;
        }


        // Método para setear el nodo anterior.
        public void setPrev(Node node) {
            prev = node;
        }
    }


    public class DoubleLinkedList{
        private Node head;
        private Node tail; // De momento no se usa la cola.
        private int size;


        // Constructor.
        public DoubleLinkedList() {
            tail = null;
            head = null;
            size = 0;
        }
        
        // Las siguientes funciones realmente las veo como opcionales porque su funcionalidad realmente
        // no la voy a implementar pero de momento las dejaré para que la clase tenga un toque más de
        // carnita.

        // Función para limpiar la lista.
        public void clear() {
            tail = null;
            head = null;
            size = 0;
        }

        // Función para saber si la lista se encuentra vacía.
        public bool isEmpty() {
            return size == 0;
        }

        // Función para agregar nodos a la lista, la cual es, la más importante en cuestión, según el 
        // proyecto que se está realizando.
        public void agregar(string nota, string figura) {
            Node newnode = new Node(nota, figura);
            if (head == null) {
                head = newnode;
                tail = newnode;
            } else {
                Node current = head;
                while (current.next != null) {
                    current = current.next;
                }
                current.next = newnode;
                tail = newnode;
                newnode.prev = current;
            }
            size++;
        }

        // Función que toca la melodía guardada en la lista de forma normal.
        public void listaDerecha(int baseDuration, Reproductor reproductor) { 
            Node current = head;
            while (current != null) {
                if (Notas.Frecuencias.TryGetValue(current.getNota(),out double frecuencia) &&
                Figuras.Multiplicadores.TryGetValue(current.getFigura(), out double Multiplicador)){
                     int duracion = (int)(baseDuration * Multiplicador);
                    Console.WriteLine($"Tocando {current.getNota()} ({frecuencia} Hz)");
                    reproductor.ReproducirSonido((int)frecuencia, duracion, 75);
                    Thread.Sleep(100);
                } else{
                    Console.WriteLine($"Error: Nota o figura musical no encontrada");
                }
                current = current.getNext();
            }
        }

        // Función que toca la melodía guardada en la lista al revés.
        public void listaReversa(int baseDuration, Reproductor reproductor) {
            Node current = tail;
            while (current != null) {
                if (Notas.Frecuencias.TryGetValue(current.getNota(),out double frecuencia) &&
                Figuras.Multiplicadores.TryGetValue(current.getFigura(), out double Multiplicador)){
                     int duracion = (int)(baseDuration * Multiplicador);
                    Console.WriteLine($"Tocando {current.getNota()} ({frecuencia} Hz)");
                    reproductor.ReproducirSonido((int)frecuencia, duracion, 75);
                    Thread.Sleep(100);
                } else{
                    Console.WriteLine($"Error: Nota o figura musical no encontrada");
                }
                current = current.getPrev();
            }
            Console.WriteLine();
        }
        public void imprimirLista() {
            Console.Write("null <= ");
            Node current = head;
            while (current != null) {
                Console.Write($"({current.getNota()}, {current.getFigura()}) ");
                if (current.getNext() == null) {
                    Console.Write("=> ");
                } else {
                    Console.Write("<=> ");
                }
                current = current.getNext();
            }
            Console.WriteLine("null");
        }
    }
}

