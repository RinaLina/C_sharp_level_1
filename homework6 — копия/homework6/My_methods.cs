using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
	class My_methods
	{

		static public void Pause()
		{
			Console.WriteLine("Ожидаем...");
			Console.ReadKey();
		}

		static public void Print(string ms, int x, int y)
		{
			Console.SetCursorPosition(x, y);
			Console.WriteLine(ms);
		}

		static public double GetValueDouble(string message)
		{
			double x;
			bool flag;
			while (true)
			{
				flag = double.TryParse(Console.ReadLine(), out x);
				if (!flag)
				{
					Console.WriteLine(message);
				}
				else
				{
					return x;
				}
			}
		}

		static public int GetValueInt(string message)
		{
			int x;
			bool flag;
			while (true)
			{
				flag = int.TryParse(Console.ReadLine(), out x);
				if (!flag)
				{
					Console.WriteLine(message);
				}
				else
				{
					return x;
				}
			}
		}
	}
}
