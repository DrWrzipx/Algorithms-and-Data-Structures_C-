using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // First node in chain
            Node first = new Node { Value = 3 };
         
            // Second node in chain
            Node second = new Node { Value = 5 };

            // Third node in chain
            Node third = new Node { Value = 7 };

            first.Next = second;
            second.Next = third;

            PrintList(first);
        }

        private static void PrintList(Node node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}
