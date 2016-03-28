using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace IrisTry
{
    class Program
    {
        static List<Iris> List = new List<Iris>();
        //static List<Iris>[] List = {new List<Iris>(), new List<Iris>(), new List<Iris>(), new List<Iris>(), new List<Iris>()};
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
                for (int i = 0; i < this.minmax[N].Count; i++)
                {
                    Console.WriteLine(this.minmax[N][i]);
                }
                Console.WriteLine("_________________________________________________________________________");
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
                List.Add(new Iris(input[4], double.Parse(input[0]), double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3])));
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
        

        
        private static void Findminmax(int N, Type[] T) 
        {
            
            for (int j = 0; j < T.Length; j++)
            {
                Console.WriteLine(T[j].Name);
              string read = Console.ReadLine();
              string[] input = read.Split(' ');
                for (int i = 0; i < input.Length; i++)
                {
                    T[j].minmax[N - 1].Add(double.Parse(input[i]));
                }
            }
        }
        
        private static int FindError(int N) 
        {
            Read();
            bool er;
            int error = 0;
            for (int i = 0; i < List.Count; i++)
            {
                for (int j = 0; j < T.Length; j++)
                {
                    if (List[i].Name == T[j].Name)
                    {
                        er = false;
                        for (int g = 1; g < T[j].minmax[N].Count; g++)
                        {
                            if ((List[i].D[N+1] >= T[j].minmax[N][g - 1]) && (List[i].D[N+1] < T[j].minmax[N][g])) { er = true; }
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
            Findminmax(1,T);
            Findminmax(2,T);
            Findminmax(3,T);
            Findminmax(4,T);
           

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
