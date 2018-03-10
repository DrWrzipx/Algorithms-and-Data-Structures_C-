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


    /// <summary>
    /// A node in the LinkedList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedListNode<T>
    {
        /// <summary>
        /// The node value
        /// </summary>
        public T Value { get; set; }
        
        /// <summary>
        /// The next node in the linked list (null if last node) 
        /// </summary>
        public LinkedListNode<T> Next { get; set; }

        /// <summary>
        /// Constructs a new node with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public LinkedListNode(T value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// A linked list collection capable of basic operations such as
    /// Add, Remove, Find and Enumerate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : System.Collections.Generic.ICollection<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public LinkedListNode<T> Head { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        public LinkedListNode<T> Tail { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        public void AddFirst(LinkedListNode<T> node)
        {
            // Save off the head node so we don't lose it
            LinkedListNode<T> temp = Head;

            // Point head to the new node
            Head = node;

            // Insert the rest of the list behind the head
            Head.Next = temp;

            Count++;

            if (Count == 1)
            {
                Tail = Head;
            }
        }

        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            Tail = node;

            Count++;
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                // Before: Head -> 3 -> 5
                // After: Head -----> 5

                Head = Head.Next;
                Count--;

                if (Count == 0)
                {
                    Tail = null;
                }
            }
        }

        public void RemoveLast()
        {
            // Before: Head -> 3 -> 5
            // After: Head -------> 5

            // Head -> 3 -> null
            // Head -------> null
            Head = Head.Next;
            Count--;

            if (Count == 0)
            {
                Tail = null;
            }
        }

        /// <summary>
        /// The number of items currently in the list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Adds the specified value to the front of the list
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            AddFirst(item);
        }

        /// <summary>
        /// Returns true if the list contains the specific item,
        /// false otherwise
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Copies the node values into the specified array.
        /// </summary>
        /// <param name="array">The array to copy the linked list values to</param>
        /// <param name="arrayIndex">The index in the array to start copying at</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// True if the collection is readonly, false otherwise
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = Head;

            // 1: Empty list - do nothing
            // 2: Single node: (previous is null)
            // Many nodes:
            //          a: node to remove is the first node
            //          b: node to remove is the middle or last

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    // it's a node in the middle or end
                    if (previous != null)
                    {
                        // Case 3b:

                        // Before: Head -> 3 -> 5 -> 7
                        // After:  Head -> 3 -----> 7
                        previous.Next = current.Next;

                        // it was the end - so update Tail
                        if (current.Next == null)
                        {
                            Tail = previous;
                        }

                        Count--;
                    }
                    else
                    {
                        // Case 2 or 3a
                        RemoveFirst();
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
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
