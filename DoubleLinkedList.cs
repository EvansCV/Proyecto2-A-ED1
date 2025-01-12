using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

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

        // Función para agregar nodos a la lista, la cual es, la más importante en cuestión, según el 
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
        public void imprimirLista() { 
            Node current = head;
            while (current != null) {
                Console.Write($"({current.getNota()}, {current.getFigura()})  -> ");
                current = current.getNext();
            }
            Console.WriteLine("null");
        }
    }
}

