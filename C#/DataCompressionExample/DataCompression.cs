using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/// <summary>
/// 1. Analyze the frequency of each character from the text file
/// 2. Put them in a Dictionary -> (Char, Frequency)
/// 3. Made nodes
/// 4. Build Huffman Tree
/// </summary>



namespace HuffmanCode
{
    class Node
    {
        public int frequency;
        public string data;
        public Node leftChild, rightChild;

        public Node(string data, int frequency)
        {
            this.data = data;
            this.frequency = frequency;
        }

        public Node(Node leftChild, Node rightChild)
        {
            this.leftChild = leftChild;
            this.rightChild = rightChild;

            this.data = leftChild.data + ":" + rightChild.data;
            this.frequency = leftChild.frequency + rightChild.frequency;
        }
    }


    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            huffman_code();
            Console.ReadKey();
        }

        /// <summary>
        /// Its main role is to do the following:
        /// 1. "read the given text file"
        /// 2. "Make Dictionary(pairs) for each character and its frequency"
        /// </summary>
        public static Dictionary<string, string> trey = new Dictionary<string, string>();
        public static void huffman_code()
        {
            List<char> list = new List<char>();
            // 1. read each line
            // 2. add new line at the end of the each line for decoding
            // 3. repeat until all the lines are scanned
            using (StreamReader sr = File.OpenText(@"C:\Users\student\Desktop\eg-ch1.txt"))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    foreach (char s1 in s)
                    {
                        list.Add(s1);
                    }
                    // this is how new line is stored as a "Char", not a string
                    list.Add(char.Parse("\n"));
                }
            }




            // DEBUGGING CODE
            // print list just to CHECK
            foreach (char c in list)
            {
                Console.Write(c);
            }
            Console.WriteLine();

            // DEBUGGING CODE
            // there is a new line at the end of the sentence
            Console.WriteLine(list[12]);

            // Convert from List to HashSet not to repeat same characters
            // it stores list's elements in list's order
            // So, list and hashSet have parallel indice
            var hashSet = new HashSet<char>(list);

            // DEBUG CODE
            // there are 61 different kinds of characters
            Console.WriteLine(hashSet.Count);
            foreach (char c1 in hashSet)
            {
                Console.Write(c1);
            }

            Console.WriteLine();
            Console.WriteLine("*******************************");

            // Count frequency

            var characterCount = new Dictionary<char, int>();
            Dictionary<string, int> dictionary = characterCount.ToDictionary(k => k.Key.ToString(), k => k.Value);

            var result = list.Select(c => c.ToString()).ToList();

           

            foreach (string c in result)
            {
                if (dictionary.ContainsKey(c))
                    dictionary[c]++;
                else
                    dictionary[c] = 1;
            }

            foreach (var pair in characterCount)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
            Console.WriteLine();
            Console.WriteLine("*******************************");

            // Sort the dictionary orders by its value
            var myList = dictionary.ToList();
            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            ///>>>>>>>>>>>>>>>>>>>>>>>>>>NODE LIST<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            IList<Node> node_list = new List<Node>();

            foreach (var c2 in myList)
            {
                node_list.Add(new Node(c2.Key, c2.Value));
                Console.WriteLine(c2);
            }

            Console.WriteLine();
            Console.WriteLine("*******************************");
            foreach (var c3 in node_list)
            {
                Console.WriteLine(c3.frequency);
            }

            Stack<Node> stack = GetSortedStack(node_list);

            while (stack.Count > 1)
            {
                Node leftChild = stack.Pop();
                Node rightChild = stack.Pop();

                Node parentNode = new Node(leftChild, rightChild);

                stack.Push(parentNode);

                stack = GetSortedStack(stack.ToList<Node>());
            }

            Node parentNode1 = stack.Pop();

            GenerateCode(parentNode1, "");

            Console.WriteLine("###############################");
            Console.WriteLine("*******************************");
            Console.WriteLine(list_of_binary_codes(parentNode1, ""));


            for (int i = 0; i < list_of_binary_codes(parentNode1, "").Count; i++)
            {

                string a = list_of_binary_codes(parentNode1, "")[i];
                DecodeData(parentNode1, parentNode1, 0, a);

            }
            foreach (var a1 in list_of_binary_codes(parentNode1, ""))
            {
                Console.WriteLine(a1);
                DecodeData(parentNode1, parentNode1, 0, a1);
            }

            Console.WriteLine("*******************************");
            Console.WriteLine("*******************************");

            foreach (var a in trey)
            {
                Console.WriteLine(">>> " + a + " <<<");
            }

            // PRINT
            foreach (var a in result)
            {
                foreach (var a1 in trey)
                {
                    if (a == a1.Key) {
                        Console.Write(a1.Value);
                    }

                }
            }
                
        }

        public static Stack<Node> GetSortedStack(IList<Node> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i].frequency > list[j].frequency)
                    {
                        Node tempNode = list[j];
                        list[j] = list[i];
                        list[i] = tempNode;
                    }
                }
            }

            Stack<Node> stack = new Stack<Node>();

            for (int j = 0; j < list.Count; j++)
                stack.Push(list[j]);

            return stack;
        }

        public static void GenerateCode(Node parentNode, string code)
        {
            List<string> binary_code = new List<string>();
            if (parentNode != null)
            {
                GenerateCode(parentNode.leftChild, code + "0");

                if (parentNode.leftChild == null && parentNode.rightChild == null)
                {

                    binary_code.Add(code);
                    trey.Add(parentNode.data, code);
                    Console.WriteLine();
                    Console.WriteLine(parentNode.data + "{" + code + "}");
                }

                GenerateCode(parentNode.rightChild, code + "1");
            }
            

            
        }

        public static List<string> list_of_binary_codes(Node parentNode, string code)
        {
            List<string> binary_code = new List<string>();
            if (parentNode != null)
            {
                list_of_binary_codes(parentNode.leftChild, code + "0");

                if (parentNode.leftChild == null && parentNode.rightChild == null)
                {
                    binary_code.Add(code);
                }

                list_of_binary_codes(parentNode.rightChild, code + "1kk");
            }
            return binary_code;
        }




        public static void DecodeData(Node parentNode, Node currentNode, int pointer, string input)
        {
            if (input.Length == pointer)
            {
                if (currentNode.leftChild == null && currentNode.rightChild == null)
                {
                    Console.Write(currentNode.data);
                }

                return;
            }
            else
            {
                if (currentNode.leftChild == null && currentNode.rightChild == null)
                {
                    Console.Write(currentNode.data);
                    DecodeData(parentNode, parentNode, pointer, input);
                }
                else
                {
                    if (input.Substring(pointer, 1) == "0")
                    {
                        DecodeData(parentNode, currentNode.leftChild, ++pointer, input);
                    }
                    else
                    {
                        DecodeData(parentNode, currentNode.rightChild, ++pointer, input);
                    }
                }
            }
        }
    }

}






