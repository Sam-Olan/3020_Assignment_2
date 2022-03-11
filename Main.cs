using System;
using System.Collections;
using System.Collections.Generic;

namespace Project
{
    class Program
    {

        static void Main(string[] args)
        {

            List<Rope> allRopes = new List<Rope>();     // List of all ropes

            char userinput;


            Console.Write("Create Rope:\n>> ");     // Promts user to create string            
            allRopes.Add(new Rope(Console.ReadLine()));     // Add the string to be converted into a rope

            
            Console.WriteLine("\n\n\nCurrent number of ropes: " + allRopes.Count);          

            do      // Main loop which accepts user inputs until a sentinal value is reached
            {
                Console.WriteLine("Command List:");
                Console.WriteLine("C = Concatinate");
                Console.WriteLine("S = Split");
                Console.WriteLine("I = Insert");
                Console.WriteLine("D = Delete");
                Console.WriteLine("B = Return Substring");
                Console.WriteLine("A = Return Character at Specific Index");
                Console.WriteLine("F = Index of First Occurance of Specific Character");
                Console.WriteLine("R = Reverse String");
                Console.WriteLine("L = Find Length of String");
                Console.WriteLine("P = Print String");
                Console.Write("Enter a command >> ");
                userinput = Convert.ToChar(Console.ReadLine());        // assign user input to string userinput


                switch (char.ToUpper(userinput))        // Uses a switch statement to complete correct task bassed off user input
                {
                    case 'C':
                        
                        break;

                    case 'S':
                        break;

                    case 'I':
                        break;

                    case 'D':
                        break;

                    case 'B':
                        break;

                    case 'A':
                        break;

                    case 'F':
                        break;

                    case 'R':
                        break;

                    case 'L':
                        break;

                    case 'P':
                        break;

                    default:
                        Console.WriteLine("***Error. Must enter valid command code. ");     // Print error if User inpust incorrect command
                        break;

                }


            } while (char.ToUpper(userinput) != 'Q');       //Loop while user input does not = Sentinal value Q 
            
        }
    }


    
    class Rope
    {
        Node root;

        //creates an empty rope
        public Rope()
        {
            root = null;
        }

        //turns user given string into a rope
        public Rope(string S)
        {
            char[] stringArray = S.ToCharArray();
            char[] array;
     

            Array.Copy(stringArray, 0, array, 0, 10);   // Copies the first 10 characters into the array that is passed to the new node

            root = new Node(array, 0);      // Create new node with first 10 char's of the string

            //root = new Node(array[0].ToString().ToCharArray(), 1);
            Node oldRoot;

            //create an unbalenced rope
            for (int i = 1; i < array.Length; i++)
            {
                oldRoot = root;
                root = new Node(0);
                root.left = oldRoot;
                Array.Copy(stringArray, (i * 10 + 1), array, (i * 10 + 1), 10);     // Print the appropriate group of 10 char's to be inserted into the node
                root.right = new Node(array, 0);
            }

            //balance the rope
            BalanceFullRope();
        }
        /*  
         Rope Concatenate(Rope R1, Rope R2)
         {

         }

         void Split(int i, Rope R1,Rope R2)
         {

         }

         void Insert(String S, int i)
         {
             // This operation can be done by a Split() and two Concat() operations. 

         }

         void Delete(int i, int j)
         {

         }

         string Substring(int i, int j)
         {

         }

         char CharAt(int i)
         {

         }

         int IndexOf(char c)
         {

         }

         void Reverse()
         {

         }

         int Length()
         {
             Node current = root;
             int length = current.value;
             while (current.Right != null)
             {
                 current = current.Right;
                 length = length + current.value;
             }
             return length;
         }

         string ToString()
         {

         }

         void PrintRope()
         {

         }

         
        */

        //private int sizeOfLeft(Node current)        // currently O(n)
        //{
        //    //Node rootNode = new Node(0);

        //    if (current.left != null)
        //        sizeOfLeft(current.left);
        //    if (current.right != null)
        //        sizeOfLeft(current.right);


        //    if (current.left == null && current.right == null)       // if the current node is a leaf node
        //    {
        //        current.value = current.data.Length;
        //    }

        //    else if (current.left != null)      // Check if the nodes left sub tree is empty
        //    {
        //        current.value = current.left.value;
        //    }
        //    else
        //    {
        //        current.value = 0;     // Value = 0 if left sub tree is empty
        //    }
                

        //    return current.value;       // return the value (number of characters in left sub tree) of passed node
        //}





        //updates the value of the node provided as well as all nodes under it
        private void UpdateValues(Node current)
        {
            Node root = current;
            Node prev; 

            if (current.left != null)
                UpdateValues(current.left);
            if (current.right != null)
                UpdateValues(current.right);


            if (current.left == null && current.right == null)     // if the current node is a leaf node
            {
                current.value = current.data.Length;
            }

            else if (current.left != null)      // Check if the nodes left sub tree is empty
            {
                
            }
            else
            {
                current.value = 0;     // Value = 0 if left sub tree is empty
            }


            //return current.value;       // return the value (number of characters in left sub tree) of passed node








            ////make sure all values below current node are updated
            //if (current.left != null)
            //    UpdateValues(current.left);
            //if (current.right != null)
            //    UpdateValues(current.right);

            ////update the value of current
            //if (current.data == null)       // if the current node is not a leaf node
            //{
            //    //current.value = 0;
            //    if (current.left != null)      
            //    {
            //        current.value = sizeOfLeft(current);

            //        //Node secondNode = current.left;
            //        //current.value = secondNode.value;

            //        //while (secondNode.right != null)
            //        //{
            //        //    secondNode = secondNode.right;
            //        //    current.value = current.value + secondNode.value;
            //        //}

            //    }
            //    else        // if left sub tree is empty value = 0 since value represents size of left sub tree
            //        current.value = 0;
            //}
            ////else        // If the current node is a leaf node, value = size of the string in current leaf node (May want to change to 0 to represent empty sub trees but ass page shows length of string)
            ////    current.value = current.data.Length;

        }

        public void BalanceFullRope()
        {
            BalanceRope(root);
            UpdateValues(root);
        }

        private void BalanceRope(Node current)
        {
            if (!current.leafNode)
            {
                int leafNodesLeft = numberOfLeafNodes(current.left);
                int leafNodesRight = numberOfLeafNodes(current.right);
                while (Math.Abs(leafNodesLeft - leafNodesRight) > 1)
                {
                    if (leafNodesLeft > leafNodesRight)
                        rotateRight(current);
                    else
                        RotateLeft(current);

                    leafNodesLeft = numberOfLeafNodes(current.left);
                    leafNodesRight = numberOfLeafNodes(current.right);
                }

                BalanceRope(current.right);
                BalanceRope(current.left);
            }
        }

        private int numberOfLeafNodes(Node current)
        {
            if (!current.leafNode)
            {
                int leftNum;
                int rightNum;
                leftNum = numberOfLeafNodes(current.left);
                rightNum = numberOfLeafNodes(current.right);
                return leftNum + rightNum;
            }
            else
                return 1;
        }

        //used by Balance rope function for right rotations
        private void rotateRight(Node current)
        {
            Node newNode = new Node(0);
            newNode.right = current.right;
            current.right = newNode;

            if (current.left.right.leafNode)
            {
                newNode.left = current.left.right;
                current.left = current.left.left;
            }
            else
            {
                Node updateNode = current.left;
                while (updateNode.right.right.leafNode)
                    updateNode = updateNode.right;

                current.right.right = newNode.left;
                current.right = current.right.left;
            }
        }

        //used by Balance rope function for left rotations
        private void RotateLeft(Node current)
        {
            Node newNode = new Node(0);
            newNode.left = current.left;
            current.left = newNode;

            if (current.right.left.leafNode)
            {
                newNode.right = current.right.left;
                current.right = current.right.right;
            }
            else
            {
                Node updateNode = current.right;
                while (updateNode.left.left.leafNode)
                    updateNode = updateNode.left;

                current.left.left = newNode.right;
                current.left = current.left.right;
            }

        }

    }

    class Node
    {
        public char[] data;
        public int value;
        public bool leafNode;


        public Node left;
        public Node right;

        public Node(int v)
        {
            value = v;
            leafNode = false;
        }

        public Node(char[] d, int v)
        {
            data = d;
            value = v;
            leafNode = true;
        }
    }
}