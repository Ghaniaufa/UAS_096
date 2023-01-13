using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_096
{
    class node
    {
        /*Node class represents the node of doubly linked list.
         *It consists of the information part and links to
         *Its succeeding and preceeding nodes
         In terms of nest and previous nodes.*/
        public int Idbarang;
        public string namaBrg;
        public string jenisBrg;
        public string hargaBrg;
        public node next;/*points to the succeeding node*/
        public node prev;/*points to the precceeding node*/

    }

    class DoubleLinkedlisT
    {
        node START;
        public DoubleLinkedlisT()
        {
            START = null;
        }
        public void addNode()/*Adds a new node*/
        {
            int Idbrng;
            string nmBrg;
            string jnBrg;
            string hrgBrg;
            Console.Write("\nMasukkan Id Barang : ");
            Idbrng = Convert.ToInt32(System.Console.ReadLine());
            Console.Write("\nMasukan Nama Barang : ");
            nmBrg = Console.ReadLine();
            Console.Write("\nMasukkan jenis Barang : ");
            jnBrg = Console.ReadLine();
            Console.Write("\nMasukkan Harga Barang : ");
            hrgBrg = Console.ReadLine();
            node newnode = new node();
            newnode.Idbarang = Idbrng;
            newnode.namaBrg = nmBrg;
            newnode.jenisBrg = jnBrg;
            newnode.hargaBrg = hrgBrg;
            /*Checks if the list is empty*/
            if (START == null || Idbrng <= START.Idbarang)
            {
                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;

            }
            node previous, current;
            for (current = previous = START; current != null &&
                Idbrng >= current.Idbarang; previous = current, current = current.next)
            {
                if (Idbrng == current.Idbarang)
                {
                    Console.WriteLine("\nData Terduplikasi");
                    return;
                }
            }
            /*On the execution of the above of the above for loop, prev and
             *current will point to those nodes
             between which the new node is to be inserted.*/
            newnode.next = current;
            newnode.prev = previous;

            /*If the node is to be inserted at the end of the list*/
            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }

        /*Checks whether the specified node is present*/
        public bool Search(string nm, ref node previous, ref node current)
        {
            for (previous = current = START;
                current != null && nm != current.namaBrg; 
                previous = current, current = current.next)
            { }
            /*The above for loop traverses the list. If the specified node
             is found then the function returns true, otherwise false.*/
            return (current != null);
        }
        public void traverse()/*Traverses the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nData Kosong");
            else
            {
                Console.WriteLine("\nUrutan Jenis Data Barang terBaru" +
                    "sebagai berikut : \n");
                node currentnode;
                for (currentnode = START;
                    currentnode != null;
                    currentnode = currentnode.next)
                    Console.Write(currentnode.Idbarang + " " + currentnode.namaBrg + " " + currentnode.jenisBrg + " " + currentnode.hargaBrg + "\n");
            }
        }
        /*traverses the list in the reverse direction*/
        public void revtraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nData Kosong");
            else
            {
                Console.WriteLine("\nUrutan Jenis Data Barang TerLama" +
                    "sebagai berikut :\n");
                node currentnode;
                for (currentnode = START;
                    currentnode.next != null;
                    currentnode = currentnode.next)
                {
                }
                while (currentnode != null)
                {
                    Console.Write(currentnode.Idbarang + " " + currentnode.namaBrg + " " + currentnode.jenisBrg + " " + currentnode.hargaBrg + "\n");
                    currentnode = currentnode.prev;
                }
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            DoubleLinkedlisT obj = new DoubleLinkedlisT();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n Menu" +
                        "\n 1. Masukkan Data Barang "+
                        "\n 2. Melihat Data Barang TerBaru" +
                        "\n 3. Melihat Data Barang TerLama" +
                        "\n 4. Menampilkan Data Jenis Barang" +
                        "\n 5. Exit \n" +
                        "\n Enter your choice (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;

                        case '2':
                            {
                                obj.revtraverse();
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                node prev, curr;
                                prev = curr = null;
                                Console.Write("\nMasukan Data Barang " + "yang ingin anda cari: ");
                                string id = Console.ReadLine();
                                if (obj.Search(id, ref prev, ref curr) == false)
                                    Console.WriteLine("\nBarang Belum Terdaftar");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nId Barang : " + curr.Idbarang);
                                    Console.WriteLine("\nNama Barang :" + curr.namaBrg);
                                    Console.WriteLine("\nJenis Barang :" + curr.jenisBrg);
                                    Console.WriteLine("\nHarga Barang :" + curr.hargaBrg);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Check for the values entered.");
                }
            }
        }
    }

}

/* 2. Menggunakan Algoritma Double LinkedList, karena mudah digunakan untuk pendataan pencarian(search)
 *    menambahkan nama barang(add Node), jenis barang(add Node), dan harga. Lalu bisa menampilkan semua data
 *    barang yang sudah di input oleh Indri.
 * 3. -Untuk array itu bisa menambahkan element tetapi hanya untuk posisi index. 
 *     apapun caranya ketika sudah mendapatkan akhirnya, array tidak bisa memulai
 *     memasukan element apapun itu.
 *    -Untuk Linked List itu bisa menambahkan juga elemet tetapi jika data kosong pun
 *    untuk Linked List data bisa di tampilkan.
   4. Rear dan Front
   5. A. dari 16 siblings 53
         dari 46 siblings 55
         dari 63 siblings 70
         dari 62 siblings 64
      B.Metode InOrder 
        41,16,25,53,46,42,55,60,74,65,63,62,70,64
 */