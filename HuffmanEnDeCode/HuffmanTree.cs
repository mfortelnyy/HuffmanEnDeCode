using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEnDeCode
{
    public class Node
    {
       
        public char s { get; set; }//symbol or character
        public int f { get; set; }//freq
        public String? c { get; set; }//code 0 or 1 or null by default with ? the root node will not have code left child - 0 right -1 
        public Node? left { get; set; }//reference to the left and right nodes resp
        public Node? right { get; set; }
        public Node? parent { get; set; }    


    }
    /* public class Print//used for printing table
     {
         public char s { get; set; }//same
         public int f { get; set; }
         public String c { get; set; }//code in binary after tree traversal
         public int tB { get; set; }//total bits for the code
     }*/
    class HuffmanTree
    {

        public Node root { get; set; }
        List<Node>? charnodes = new List<Node>();
        List<Node>? copy = new List<Node>();
        //List<Node> treeNodes = new List<Node>();
        public List<Node> getCharNodes()
        {
            return charnodes;
        }
        /* public List<Node> getTreeNodes()
         {
             return treeNodes;
         }*/
        // public Dictionary<char, String> dic { get; set; }


        public void create()
        {
            List<Node> Ns = new List<Node> { copy[0], copy[1] };
            copy.RemoveRange(0, 2);
            Node p = new Node();
            p.f = Ns[0].f + Ns[1].f;
            p.left = Ns[0];
            p.right = Ns[1];
            //int insindex = binaryInsertion(copy, p);
            //Console.WriteLine(insindex);

            int ind = SearchInsert(copy, p);
            copy.Insert(ind, p);
            if (copy.Count == 1)
            { return; }

            create();
        }
        public void build(String s)
        {
            var charcount = new Dictionary<char, int>();
            foreach (var c in s)//iterate through char in the input string and store char with respective frequencies
            {
                if (charcount.ContainsKey(c))
                    charcount[c]++;
                else
                    charcount[c] = 1;
            }

            foreach (KeyValuePair<char, int> kvp in charcount)// dicts can not be sorted without LINQ so we can store List of Nodes(char,freq,left and right child)
                                                              // and sort that list of nodes by freq using the quicksort
            {
                Node node = new Node();
                node.s = kvp.Key;
                node.f = kvp.Value;

                charnodes.Add(node);
                copy.Add(node);
            }

            QuickSort(charnodes, 0, charnodes.Count - 1);
            create();
            root = copy[0];

        }
        public int SearchInsert(List<Node> nodes, Node x)
        {
            int pos = nodes.Count;
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                if (nodes[i].f > x.f)
                {
                    pos--;
                }
                if (nodes[i].f == x.f)
                {
                    return i + 1;
                }
                if (nodes[i].f < x.f)
                {
                    return i + 1;
                }
            }
            return 0;
        }
        private int binaryInsertion(List<Node> nodes, Node x)
        {
            if (nodes.Count < 1)
            {
                return 0;
            }
            int l = 0;
            int r = nodes.Count - 1;
            int m = 0;
            int pos = -1;
            while (l <= r)
            {
                m = l + (r - l) / 2;
                if (nodes[m].f == x.f)
                    return m;

                if (nodes[m].f > x.f)
                {
                    r = m - 1;
                    pos = m;
                }
                else
                {
                    l = m + 1;
                    pos = m + 1;
                }
            }
            return pos;

        }
        public Node HuffmanTreeFromString(string s)
        {
            var charcount = new Dictionary<char, int>();
            foreach (var c in s)//iterate through char in the input string and store char with respective frequencies
            {
                if (charcount.ContainsKey(c))
                    charcount[c]++;
                else
                    charcount[c] = 1;
            }

            foreach (KeyValuePair<char, int> kvp in charcount)// dicts can not be sorted without LINQ so we can store List of Nodes(char,freq,left and right child)
                                                              // and sort that list of nodes by freq using the quicksort
            {
                Node node = new Node();
                node.s = kvp.Key;
                node.f = kvp.Value;
                charnodes.Add(node);
            }


            QuickSort(charnodes, 0, charnodes.Count - 1);

            //After the List of Nodes are sorted We can start Building the Tree
            Node n1 = new Node();// input string does not matter - the first two sorted nodes always will form the parent node with the sum of its frequencies
            n1.f = charnodes[0].f + charnodes[1].f;
            n1.s = '\0';// there is no char representation of the node, only leaf nodes will contain the char 

            n1.left = charnodes[0];//first least elemnt by convention will be the left child and second - right
            n1.right = charnodes[1];
            charnodes[0].parent = charnodes[1].parent = n1;
            root = n1;//the new root is the parent root with the sum of least freq characters 

            root.left.c = "0";
            root.right.c = "1";

            for (int i = 2; i < charnodes.Count; i++)//go through each node in list of nodes and finish a tree 
            {
                if (i < charnodes.Count - 1)//the next if-statmnt below contains i+1 -> avoid index out of range
                {
                    bool islast = true;
                    if (root.f > charnodes[i].f && root.f > charnodes[i + 1].f)// we need to connect sets with min freqs (root is counted as one of the nodes)
                    // if root is bigger than the next two elements form the minimum set among all nodes availbale in the list of nodes
                    // we can not proceed with the regular routine -  take those two elements create a parent node for them and then add that parent node freq with current root freq 
                    {
                        if (i == charnodes.Count - 2) islast = false;
                        Node p = new Node();//parent node for the next two elements
                        Node r = new Node();//future root node which will hold sum of freq of the current root and parent node for those two merged elements
                                            //these nodes does not have any char so char is empty but by default they will 
                                            // p.s = r.s = '\0';

                        p.f = charnodes[i].f + charnodes[i + 1].f;

                        p.left = charnodes[i];
                        p.right = charnodes[i + 1];

                        r.f = p.f + root.f;

                        r.left = root;
                        r.right = p;
                        root = r;// no need to change r's code int bc root should not have code amd if there will be next root the current root will be recursively set to corresponding 0/1 if it's left/right child
                        root.left.c = "0";
                        root.right.c = "1";
                        p.left.c = "0";
                        p.right.c = "1";
                        //
                        charnodes[i].parent = charnodes[i + 1].parent = p;
                        p.parent = root;
                        root.parent = null;
                    }

                    else//if root is not larger than 1st then it is clear it is not larger than the next element (a<b and b<c -> a<c) - more common case aka regular procedure
                    {
                        Node r = new Node();//future(next) root -r
                                            // r.s = '\0';
                        r.f = root.f + charnodes[i].f;//next root's freq val is sum of current's root and ith node i.e. sum of a set of two min freq value nodes left in list
                        r.left = root;//current root will become left child of next root 
                        r.right = charnodes[i];// ith node i.e. second from the set of two min freq bla bla 
                        charnodes[i].parent = r;
                        root.parent = r;
                        root = r;//finally next root becomes a man
                        root.parent = null;
                        root.left.c = "0";
                        root.right.c = "1";


                    }
                    if (i == charnodes.Count - 1 && islast == true)
                    {
                        Node r = new Node();//future(next) root -r
                                            // r.s = '\0';
                        r.f = root.f + charnodes[i].f;//next root's freq val is sum of current's root and ith node i.e. sum of a set of two min freq value nodes left in list
                        r.left = root;//current root will become left child of next root 
                        r.right = charnodes[i];// ith node i.e. second from the set of two min freq bla bla 
                        charnodes[i].parent = r;
                        root.parent = r;
                        root = r;//finally next root becomes a man
                        root.parent = null;
                        root.left.c = "0";
                        root.right.c = "1";
                    }

                }

                /* else//when we reach the last element it will be the most frequent anyway and will be the right's child of the root so just create a future star root node and link childs properly
                 {//nvm 2 else-stmnts same ->  delete  above else
                     Node r = new Node();
                     r.f = root.f + charnodes[i].f;
                     r.left = root;
                     r.right = charnodes[i];
                     charnodes[i].parent = r;
                     root.parent = r;
                     root = r;
                     root.left.c = "0";
                     root.right.c = "1"; 
                
                 }*/
            }

            return root;
        }
        String print = "";
        public String printPreorder(Node node)
        {
            if (node == null)
                return print;
            else
            {
                // first recur on left subtree
                printPreorder(node.left);

                // then recur on right subtree
                printPreorder(node.right);

                // now deal with the node
                print = print + "," + node.f;

            }
            return print;


        }
        private static void QuickSort(List<Node> N, int st, int end)
        {
            int p = Partition(N, st, end);

            if (p - 1 > st)
            {
                QuickSort(N, st, p - 1);
            }
            if (p + 1 < end)
            {
                QuickSort(N, p + 1, end);
            }

        }
        private static int Partition(List<Node> N, int st, int end)
        {
            int pivot = N[end].f;
            Node pivotrepl = N[end];

            for (int i = st; i < end; i++)
            {
                if (N[i].f < pivot)
                {
                    Node temp = N[st];
                    N[st] = N[i];
                    N[i] = temp;
                    st++;
                }
            }

            Node temp1 = N[st];
            N[st] = pivotrepl;
            N[end] = temp1;

            return st;
        }
        public int freqOf(char x)
        {
            foreach (Node n in charnodes)
            {
                if (n.s.Equals(x))
                {
                    return n.f;
                }
            }
            return 0;
        }

        //string res = "";
        public void assignCodes(Node root,String res)
        {
            if (root.left == null && root.right == null)
            {
                root.c = res;
                //res = "";
                return ;
            }

            if (root.left != null)
            {
                res = res + "0";
                assignCodes(root.left ,res);

            }
            if (root.right != null)
            {
                res = res + "1";
                assignCodes(root.right, res);
            }
           
        }

        Dictionary<char, String> dict = new Dictionary<char, String>(); 
        String p = "";
        public virtual void printPaths()
        {
            p = "";
            assignCodes(root, "");
            printPathsRecur(root);
        }

        /* Recursive helper function -- given a node, and an array
           containing the path from the root node up to but not 
           including this node, print out all the root-leaf paths.*/
        public void printPathsRecur(Node node)
        {
            if (node == null)
            {
                return;
            }

            /* append this node to the path array */
            p =p + node.c;

            /* it's a leaf, so print the path that led to here  */
            if (node.left == null && node.right == null)
            {
                addToDict(node, p);
                p = "";
            }
            else
            {
                /* otherwise try both subtrees */
                printPathsRecur(node.left);
                printPathsRecur(node.right);
            }
        }
        public void addToDict(Node n, String code)
        {
            dict.Add(n.s, code);
        }
        
        public void assignCodes1(Node root)
        {
            if (root.left == null && root.right == null)
            {
                
                return;
            }

            if (root.left != null)
            {
                root.left.c =  "0";
                assignCodes1(root.left);

            }
            if (root.right != null)
            {
                root.right.c= "1";
                assignCodes1(root.right);
            }

        }
        public Dictionary<char, String> getDict()
            {
            assignCodes1(root);

            Dictionary<char, String> dic = new Dictionary<char, String>();


            foreach (Node n in charnodes)
            {
                if (n != null)
                {
                    dic.Add(n.s, n.c);
                    
                }
            }
            return dic;
        }

        public String dictToString(Dictionary<char,String> d)
        {
            string s = "";
            foreach(Node n in charnodes)
            {
                s=n.s +"          "+n.c+Environment.NewLine;    
            }
            return s;
        }


        String res = "";
        public String SearchCode(Node r, Node x)
        {
            if (r != null)
            {
                if (r.s != null && r.s==x.s)
                    return res;
                else if(r.left!= null)
                {
                    res = res + r.c;
                    SearchCode(r.left, x);
                }
                else if(r.right!= null)
                {
                    res = res + r.c;
                    SearchCode(r.right, x);
                }
            }
            return res;

        }

        public Dictionary<char, String> CharCodesTable()
        {
            Dictionary<char, String> dic = new Dictionary<char, String>();


            foreach (Node x in charnodes)
            {
                if (x != null)
                {
                    dic.Add(x.s, SearchCode(root, x));
                    res = "";
                }
            }
            return dic;
        }


        public String printDictreserve()
        {
            String res = "";

            foreach (KeyValuePair<char, String> pair in dict)
            {

                res += "| " + pair.Key.ToString() + "             |         " + pair.Value + "    |    " + freqOf(pair.Key) + "|" + Environment.NewLine + "============" + Environment.NewLine;
            }
            return res; 
        }
       
        /*
        public int freqOf(char x)
        { 
            foreach(Node n in charnodes)
            {
                if (n.s.Equals(x))
                {
                    return n.f;
                }
            }
            return 0;
        }

        string res="";
        
        public String SearchCode(Node n)
        {
            if(n!=null)
            {
                if (n.c == null)
                    return res;
                else 
                {
                    res =n.c.ToString()+res;
                    SearchCode(n.parent);
                }
            }
            return res;

         }

        public  Dictionary<char,String> CharCodesTable()
        {
            Dictionary<char, String> dic = new Dictionary<char, String>();


            foreach (Node n in charnodes)
            {
                if (n != null)
                {
                    dic.Add(n.s, SearchCode(n));
                    res = "";
                }
            }
            return dic;
        }

       
        public String printDict()
        {
            Dictionary<char, String> table = CharCodesTable();
            String  result=String.Empty;
            
            foreach(KeyValuePair<char,String> pair in table)
            {
                
                result +="| "+ pair.Key.ToString()+"             |         "+pair.Value +"    |    "+ freqOf(pair.Key)+"|"+Environment.NewLine+ "============" + Environment.NewLine;
            }
            return result;
        }
        String print = "";
        public static void PrintTree(Node n, String indent, bool last)
        {
            
           for(int i = 0; i< charnodes.Count(); i++)   
            {
                int sum = charnodes[i].f + charnodes[i + 1].f;
                if ( sum == charnodes[i].parent.f && sum == charnodes[i + 1].parent.f )
                {

                }
            }
        }*/




    }
}
