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
    }


    public class DoubleLinkedList{
        private Node head;
        private int size;


        // Constructor.
        public DoubleLinkedList() {
            head = null;
            size = 0;
        }
        
        // Las siguientes funciones realmente las veo como opcionales porque su funcionalidad realmente
        // no la voy a implementar pero de momento las dejaré para que la clase tenga un toque más de
        // carnita.

        // Función para limpiar la lista.
        public void clear() {
            head = null;
            size = 0;
        }

        // Función para saber si la lista se encuentra vacía.
        public bool isEmpty() {
            return size == 0;
        }

        // Función para agregar nodos a la lista, la cual es, la más importante en cuestión según el 
        // proyecto que se está realizando.
        public void agregar(string nota, string figura) {
            Node newnode = new Node(nota, figura);
            if (head == null) {
                head = newnode;
            } else {
                Node current = this.head;
                while (current.next != null) {
                    current = current.next;
                }
                current.next = newnode;
                newnode.prev = current;
            }
            size++;
        }
    }
}