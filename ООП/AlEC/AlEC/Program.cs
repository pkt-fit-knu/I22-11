using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlEC
{
    class Uzel
    {
        public IList<Uzel> parents = new List<Uzel>();
        public IList<Uzel> children = new List<Uzel>();
        public int number;

        public Uzel(int n)
        {
            this.number = n;
        }
    }

    class UzelComp : IComparer<Uzel>
    {

        public int Compare(Uzel n1, Uzel n2)
        {
            if (n1.number >= n2.number)
            {
                return -1;
            }
            else
            {
                return 1;
            }


        }

    }

    class Program
    {
     public static void V1(int v, Dictionary<int, bool> marks, Stack<int> path, Dictionary<int, Uzel> nodes)
        {
            marks[v] = true;
            Console.WriteLine("Перешли до вузла " + (v + 1));
            path.Push(v); 
            var items = nodes[v].children.OrderByDescending(a => a, new UzelComp());
            foreach (Uzel node in items)
            {
                int i = node.number;

                if (marks[i] == false)
                {
                    V1(i, marks, path, nodes);
                    int p = path.Pop(); 
                    Console.WriteLine("Повернулись до вузла " + (v + 1));
                }



            }
        }

        static void Main(string[] args)
        {

            Random rand = new Random();
            Queue<int> q = new Queue<int>();    
            string exit = "";
            int u;
            int v;
            do
            {


                u = 6;


                bool[] used = new bool[u + 1];  
                int[][] M = new int[u + 1][];   

                M[0] = new int[u + 1];
                M[0][0] = 0;
                M[0][1] = 1;
                M[0][2] = 1;
                M[0][3] = 0;
                M[0][4] = 0;
                M[0][5] = 0;
                M[0][6] = 0;

                M[1] = new int[u + 1];
                M[1][0] = 1;
                M[1][1] = 0;
                M[1][2] = 0;
                M[1][3] = 1;
                M[1][4] = 1;
                M[1][5] = 0;
                M[1][6] = 0;

                M[2] = new int[u + 1];
                M[2][0] = 1;
                M[2][1] = 0;
                M[2][2] = 0;
                M[2][3] = 0;
                M[2][4] = 0;
                M[2][5] = 1;
                M[2][6] = 0;

                M[3] = new int[u + 1];
                M[3][0] = 0;
                M[3][1] = 1;
                M[3][2] = 0;
                M[3][3] = 0;
                M[3][4] = 0;
                M[3][5] = 0;
                M[3][6] = 0;

                M[4] = new int[u + 1];
                M[4][0] = 0;
                M[4][1] = 1;
                M[4][2] = 0;
                M[4][3] = 0;
                M[4][4] = 0;
                M[4][5] = 0;
                M[4][6] = 0;

                M[5] = new int[u + 1];
                M[5][0] = 0;
                M[5][1] = 0;
                M[5][2] = 1;
                M[5][3] = 0;
                M[5][4] = 0;
                M[5][5] = 0;
                M[5][6] = 1;

                M[6] = new int[u + 1];
                M[6][0] = 0;
                M[6][1] = 0;
                M[6][2] = 0;
                M[6][3] = 0;
                M[6][4] = 0;
                M[6][5] = 1;
                M[6][6] = 0;


                for (int i = 0; i < u + 1; i++)
                {
                    Console.Write("\n({0}) вершина -->[", i + 1);
                    for (int j = 0; j < u + 1; j++)
                    {
                        Console.Write(" {0}", M[i][j]);

                    }

                    Console.Write("]\n");
                }



                Console.WriteLine("");
                Console.WriteLine("Виконуємо обхід в ширину");

                int U = 0;
                used[U] = true;  

                q.Enqueue(U);
                Console.WriteLine("Виконуємо обхід з {0} вершини", U + 1);
                while (q.Count != 0)
                {
                    U = q.Peek();
                    q.Dequeue();
                    Console.WriteLine("Перейшли до вузла {0}", U + 1);

                    for (int i = 0; i < M.Length; i++)
                    {
                        if (Convert.ToBoolean(M[U][i]))
                        {
                            v = i;
                            if (!used[v])
                            {
                                used[v] = true;
                                q.Enqueue(v);
                                Console.WriteLine("Додали в чергу вузел {0}", v + 1);
                            }
                        }
                    }
                }


            
                Console.WriteLine("");
                Console.WriteLine("Виконуємо обхід в глибину");


                Dictionary<int, bool> marks = new Dictionary<int, bool>();
                Stack<int> path = new Stack<int>();

                for (int i = 0; i < M.GetLength(0); i++)
                {
                    marks.Add(i, false);
                }

                Dictionary<int, Uzel> nodes = new Dictionary<int, Uzel>();
                for (int i = 0; i < M.GetLength(0); i++)
                {

                    Uzel node = new Uzel(i);
                    nodes.Add(i, node);
                }

                for (int i = 0; i < M.GetLength(0); i++)
                {
                    Uzel nodeI = nodes[i];
                    for (int j = 0; j < M.GetLength(0); j++)
                    {
                        if (M[i][j] == 1)
                        {
                            nodeI.children.Add(nodes[j]);
                        }

                    }

                }


                V1(0, marks, path, nodes);



                Console.WriteLine("Вийти?");
                exit = Console.ReadLine();
                Console.Clear();
            } while (exit != "y" || exit != "lf");
            Console.ReadKey();


        }

   
    }



   
}

