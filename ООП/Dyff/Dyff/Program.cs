
using System;

using ChMO_lab_duferenciyuvanna;

namespace Dyff
{
	class Program
	{
		public static void Main(string[] args)
		{
			double x = 0;
			
			Console.WriteLine("f(x)	 Method		y'		y''\nx = {0}", x);
				
//-----------------------------------------------------------------------------------------------

			Console.WriteLine("---------Cetral'nyh Roznyts---------");

			Method m2 = new CetralSubMethod_oh4(new Function1());
			Console.WriteLine("y = sin(x)\t\t{0:e}	{1:e}", m2.FirstDerivative(x), m2.SecondDerivative(x));

			m2 = new CetralSubMethod_oh4(new Function2());
			Console.WriteLine("y = cos(x)\t\t{0:e}	{1:e}", m2.FirstDerivative(x), m2.SecondDerivative(x));

			m2 = new CetralSubMethod_oh4(new Function3());
			Console.WriteLine("y = tg(x)\t\t{0:e}	{1:e}", m2.FirstDerivative(x), m2.SecondDerivative(x));

			
			m2 = new CetralSubMethod_oh4(new Function4());
			Console.WriteLine("y = |x|\t\t\t{0:e}	{1:e}", m2.FirstDerivative(x), m2.SecondDerivative(x));
			
			
			m2 = new CetralSubMethod_oh4(new Function5());
			Console.WriteLine("y = k1*(x^k2)\t\t{0:e}	{1:e}\n\n", m2.FirstDerivative(x), m2.SecondDerivative(x));
			
//-----------------------------------------------------------------------------------------------

			Console.WriteLine("---------Lahrang---------");

			Method m3 = new LahrangMethod(new Function1());
			Console.WriteLine("y = sin(x)\t\t{0:e}	{1:e}", m3.FirstDerivative(x), m3.SecondDerivative(x));

			m3 = new LahrangMethod(new Function2());
			Console.WriteLine("y = cos(x)\t\t{0:e}	{1:e}", m3.FirstDerivative(x), m3.SecondDerivative(x));

			m3 = new LahrangMethod(new Function3());
			Console.WriteLine("y = tg(x)\t\t{0:e}	{1:e}", m3.FirstDerivative(x), m3.SecondDerivative(x));

			m3 = new LahrangMethod(new Function4());
			Console.WriteLine("y = |x|\t\t\t{0:e}	{1:e}", m3.FirstDerivative(x), m3.SecondDerivative(x));

			m3 = new LahrangMethod(new Function5());
			Console.WriteLine("y = k1*(x^k2)\t\t{0:e}	{1:e}\n\n", m3.FirstDerivative(x), m3.SecondDerivative(x));

//-----------------------------------------------------------------------------------------------
			
			Console.WriteLine("---------Newton---------");

			Method m4 = new NyutonMethod(new Function1());
			Console.WriteLine("y = sin(x)\t\t{0:e}	{1:e}", m4.FirstDerivative(x), m4.SecondDerivative(x));

			m4 = new NyutonMethod(new Function2());
			Console.WriteLine("y = cos(x)\t\t{0:e}	{1:e}", m4.FirstDerivative(x), m4.SecondDerivative(x));

			m4 = new NyutonMethod(new Function3());
			Console.WriteLine("y = tg(x)\t\t{0:e}	{1:e}", m4.FirstDerivative(x), m4.SecondDerivative(x));

			m4 = new NyutonMethod(new Function4());
			Console.WriteLine("y = |x|\t\t\t{0:e}	{1:e}", m4.FirstDerivative(x), m4.SecondDerivative(x));

			m4 = new NyutonMethod(new Function5());
			Console.WriteLine("y = k1*(x^k2)\t\t{0:e}	{1:e}", m4.FirstDerivative(x), m4.SecondDerivative(x));

			Console.ReadKey(true);
		}
	}
}