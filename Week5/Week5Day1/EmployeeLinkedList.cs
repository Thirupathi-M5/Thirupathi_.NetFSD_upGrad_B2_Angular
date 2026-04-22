using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5Handson1
{
    namespace EmployeeLinkedList
    {
        // Node class
        class Node
        {
            public int EmpId;
            public string Name;
            public Node Next;

            public Node(int id, string name)
            {
                EmpId = id;
                Name = name;
                Next = null;
            }
        }

        class LinkedList
        {
            Node head = null;

            // Insert at Beginning
            public void InsertAtBeginning(int id, string name)
            {
                Node newNode = new Node(id, name);

                newNode.Next = head;
                head = newNode;

                Console.WriteLine("Inserted at beginning.");
            }

            // Insert at End
            public void InsertAtEnd(int id, string name)
            {
                Node newNode = new Node(id, name);

                if (head == null)
                {
                    head = newNode;
                    return;
                }

                Node temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = newNode;
                Console.WriteLine("Inserted at end.");
            }

            // Delete by Employee ID
            public void Delete(int id)
            {
                if (head == null)
                {
                    Console.WriteLine("List is empty.");
                    return;
                }

                // If head is to be deleted
                if (head.EmpId == id)
                {
                    head = head.Next;
                    Console.WriteLine("Employee deleted.");
                    return;
                }

                Node temp = head;
                while (temp.Next != null && temp.Next.EmpId != id)
                {
                    temp = temp.Next;
                }

                if (temp.Next == null)
                {
                    Console.WriteLine("Employee not found.");
                    return;
                }

                temp.Next = temp.Next.Next;
                Console.WriteLine("Employee deleted.");
            }

            // Display List
            public void Display()
            {
                if (head == null)
                {
                    Console.WriteLine("List is empty.");
                    return;
                }

                Node temp = head;
                Console.WriteLine("\nEmployee List:");
                while (temp != null)
                {
                    Console.WriteLine(temp.EmpId + " - " + temp.Name);
                    temp = temp.Next;
                }
            }
        }

        class Program
        {
            static void Main()
            {
                LinkedList list = new LinkedList();

                while (true)
                {
                    Console.WriteLine("\n1. Insert at Beginning");
                    Console.WriteLine("2. Insert at End");
                    Console.WriteLine("3. Delete by ID");
                    Console.WriteLine("4. Display");
                    Console.WriteLine("5. Exit");

                    Console.Write("Enter choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter ID: ");
                            int id1 = int.Parse(Console.ReadLine());

                            Console.Write("Enter Name: ");
                            string name1 = Console.ReadLine();

                            list.InsertAtBeginning(id1, name1);
                            break;

                        case 2:
                            Console.Write("Enter ID: ");
                            int id2 = int.Parse(Console.ReadLine());

                            Console.Write("Enter Name: ");
                            string name2 = Console.ReadLine();

                            list.InsertAtEnd(id2, name2);
                            break;

                        case 3:
                            Console.Write("Enter ID to delete: ");
                            int delId = int.Parse(Console.ReadLine());

                            list.Delete(delId);
                            break;

                        case 4:
                            list.Display();
                            break;

                        case 5:
                            return;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
        }
    }
}
