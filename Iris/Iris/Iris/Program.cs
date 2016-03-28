using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Iris
{
    class Program
    {
        static List<Iris>[] List = { new List<Iris>(), new List<Iris>(), new List<Iris>(), new List<Iris>(), new List<Iris>() };
        static Type[] T = { new Type("Iris-setosa"), new Type("Iris-versicolor"), new Type("Iris-virginica") };

        class Type
        {
            public string Name;
            public List<double>[] minmax = { new List<double>(), new List<double>(), new List<double>(), new List<double>() };

            public Type(string Name)
            {

                this.Name = Name;
            }
            public void print(int N)
            {
                Console.WriteLine(this.Name);
                for (int i =0; i < this.minmax[N].Count; i++)
                {
                    Console.WriteLine(this.minmax[N][i]);
                    
                }
                Console.WriteLine("_________________________________________________________________________");
            }

            public void Clean()
            {
                for (int N = 0; N < minmax.Length; N++)
                    for (int i = 1; i < this.minmax[N].Count; i++)
                    {
                        if (this.minmax[N][i] == this.minmax[N][i - 1])
                        {
                            this.minmax[N].RemoveAt(i);
                            this.minmax[N].RemoveAt(i - 1);
                            i--;
                        }
                        else { }

                    }

            }

        }

        class Iris
        {
            public string Name;
            public double[] D = new double[5];
            public Iris(string Name, double D1, double D2, double D3, double D4)
            {
                this.Name = Name;
                this.D[1] = D1;
                this.D[2] = D2;
                this.D[3] = D3;
                this.D[4] = D4;
            }
            public void print()
            {
                Console.WriteLine(this.D[1] + "--" + this.D[2] + "--" + this.D[3] + "--" + this.D[4] + "--" + this.Name);
            }

        }
        private static void Add(string Line)
        {
            Line = Line.Replace(',', '|');
            Line = Line.Replace('.', ',');
            string[] input = Line.Split('|');
            if (input.Length == 5)
                List[0].Add(new Iris(input[4], double.Parse(input[0]), double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3])));
            else
            {
                // Console.WriteLine("Error");
            }

        } //++++++++++++++++++++++++++++++++++
        public static void Read()
        {
            int count = System.IO.File.ReadAllLines("iris_data.txt").Length;
            for (int i = 0; i < count; i++)
            {
                string Line = File.ReadLines("iris_data.txt").Skip(i).First();
                Add(Line);
            }
        }
        public static void Sort(int S)
        {

            int n = 0;
            double min = List[0][n].D[S];
            for (int i = 0; i < List[0].Count; i++)
            {
                if (List[0][i].D[S] < min)
                {
                    min = List[0][i].D[S];
                    n = i;
                }
            }
            List[S].Add(List[0][n]);
            List[0].RemoveAt(n);
            if (List[0].Count > 0)
            {
                Sort(S);
            }
        }

        public static void SortAll()
        {
            List[0].Clear();
            Read();
            Sort(1);
            List[0].Clear();
            Read();
            Sort(2);
            List[0].Clear();
            Read();
            Sort(3);
            List[0].Clear();
            Read();
            Sort(4);
            List[0].Clear();
            Read();
        }

        private static int drop(int N, int ii, int k, Type[] T)
        {
            if ((ii + 1 < List[N].Count) && (List[N][ii + 1].Name == T[k].Name))
            {
                ii++;
                ii = drop(N, ii, k, T);
            }
            return ii;
        }

        private static void Findminmax(int N, int k, int ii, Type[] T)
        {
            int[] l = { 0, 0, 0 };
            double min = List[N][ii].D[N];
            //int k = 0; //номер виду ірису
            //int ii = 0; //номер остатнього елемента в відрізку
            /////////////////////////////////////////////////
            for (int i = ii; i < List[N].Count; i++)
            {
                for (int j = 0; j < T.Length; j++)
                {
                    if (List[N][i].Name == T[j].Name)
                    {
                        l[j]++;
                    }
                    if (l[j] == 3) { k = j; ii = i; break; }

                }
                if (l[k] == 3)
                {
                    break;
                }

            }
            ////////////////////////////////
            ii = drop(N, ii, k, T);
            if (ii != min)
            {
                T[k].minmax[N - 1].Add(min);
                T[k].minmax[N - 1].Add(List[N][ii].D[N]);
            }
            if (ii + 1 < List[N].Count)
            {
                Findminmax(N, k, ii, T);
            }
        }

        private static int FindError(int N)
        {
            Read();
            bool er;
            int error = 0;
            for (int i = 0; i < List[0].Count; i++)
            {
                for (int j = 0; j < T.Length; j++)
                {
                    if (List[0][i].Name == T[j].Name)
                    {
                        er = false;
                        for (int g = 1; g < T[j].minmax[N].Count; g++)
                        {
                            if ((List[0][i].D[N + 1] >= T[j].minmax[N][g - 1]) && (List[0][i].D[N + 1] < T[j].minmax[N][g])) { er = true; }
                            g++;
                        }
                        if (er == false) { error++; }
                    }
                }
            }
            return error;
        }

        static void Main(string[] args)
        {

            Read();
            SortAll();
            Findminmax(1, 0, 0, T);
            Findminmax(2, 0, 0, T);
            Findminmax(3, 0, 0, T);
            Findminmax(4, 0, 0, T);

            T[0].Clean();
            T[1].Clean();
            T[2].Clean();
            
            T[0].print(0); T[1].print(0); T[2].print(0);
            int error1 = FindError(0);
            Console.WriteLine(error1 + "-- за першим стовбцем");
            T[0].print(1); T[1].print(1); T[2].print(1);
            Console.WriteLine(FindError(1) + "-- за другим стовбцем");
            T[0].print(2); T[1].print(2); T[2].print(2);
            Console.WriteLine(FindError(2) + "-- за третім стовбцем");
            T[0].print(3); T[1].print(3); T[2].print(3);
            Console.WriteLine(FindError(3) + "-- за четвертим стовбцем");
            //T[1].print();
            //T[2].print();
            //for (int i = 0; i < List1.Count; i++)
            //   List1[i].print();
            // Console.WriteLine( List1[0].D1);
            Console.ReadKey();
            //ListAll[0][0].D1 = 0;
            

        }
    }
}
