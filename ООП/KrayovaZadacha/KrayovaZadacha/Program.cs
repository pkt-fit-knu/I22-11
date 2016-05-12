
using System;

namespace KrayovaZadacha
{
	class Program
	{
		public static void Main(string[] args)
		{
			MethodSkinchRizn m = new MethodSkinchRizn(0.1, 0, 2);

			Console.WriteLine("a = 0	b = 1	h = 0.1\n-----Method skinch rizn-----\nX	Y\n");
			foreach (var element in m.Execute()) 
			{
				Console.WriteLine("{0}	{1}", element.X, element.Y);
			}
			
			Console.ReadKey(true);
		}
	}
}