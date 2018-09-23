using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1_Gubaydullina
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
	}
}
