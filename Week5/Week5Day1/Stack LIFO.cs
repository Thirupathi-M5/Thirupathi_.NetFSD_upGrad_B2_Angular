using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5Handson1
{
    internal class Stack_LIFO
    {
        static void Main()
        {
            string[] stack = new string[10]; // Array for stack
            int top = -1; // Stack is empty

            // Perform operations
            Push(stack, ref top, "Type A");
            Push(stack, ref top, "Type B");
            Push(stack, ref top, "Type C");

            Pop(stack, ref top); // Undo
            Pop(stack, ref top); // Undo

            Console.WriteLine("\nFinal State:");
            Display(stack, top);
        }

        // Push Operation
        static void Push(string[] stack, ref int top, string action)
        {
            if (top == stack.Length - 1)
            {
                Console.WriteLine("Stack Overflow!");
                return;
            }

            top++;
            stack[top] = action;

            Console.WriteLine("After Push: " + action);
            Display(stack, top);
        }

        // Pop Operation (Undo)
        static void Pop(string[] stack, ref int top)
        {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow! Nothing to undo.");
                return;
            }

            Console.WriteLine("Undo: " + stack[top]);
            top--;

            Display(stack, top);
        }

        // Display Current State
        static void Display(string[] stack, int top)
        {
            if (top == -1)
            {
                Console.WriteLine("Current State: Empty");
                return;
            }

            Console.Write("Current State: ");
            for (int i = 0; i <= top; i++)
            {
                Console.Write(stack[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
