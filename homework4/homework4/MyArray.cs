using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework4
{
	class MyArray
	{
		int[] a;
		public MyArray(int n)
		{
			a = new int[n];
		}

		/// <summary>
		/// конструктор, который загружают данные из файла
		/// </summary>
		public MyArray(string filename)
		{
			if(File.Exists(filename))
			{
				StreamReader sr = new StreamReader(filename);
				int n = int.Parse(sr.ReadLine());
				a = new int[n];
				int x;
				bool flag;
				for (int i = 0; i < n; i++)
				{
					flag = int.TryParse(sr.ReadLine(), out x);
					if (!flag)
					{
						a[i] = 0; // Если появится необходимость работать с "плохими" файлами, можно будет добавить обработку ошибки 
					}
					else
					{
						a[i] = x;
					}
				}
				sr.Close();
			}
			else Console.WriteLine("Error load file");
		}

		/// <summary>
		/// Реализовать конструктор, создающий массив 
		/// заданной размерности и заполняющий массив 
		/// числами от начального значения с заданным шагом
		/// </summary>
		public MyArray(int n, int first_value, int step)
		{
			a = new int[n];
			a[0] = first_value;

			for (int i = 1; i < n; i++)
			{
				a[i] = a[i - 1] + step;
			}
		}
		public int this[int i]
		{
			get { return a[i]; }
			set { a[i] = value; }
		}

		/// <summary>
		/// свойство Sum, которые возвращают сумму элементов массива
		/// </summary>
		public int Sum //Я не совсем понимаю, почему Sum, должно быть свойством,а не методом
		{
			get
			{
				int sum = 0;
				for (int i = 0; i < a.Length; i++)
				{
					sum += a[i];
				}
				return sum;
			}
		}

		/// <summary>
		/// метод Inverse, меняющий знаки у всех элементов массива
		/// </summary>
		public void Inverse()
		{
			for (int i = 0; i < a.Length; i++)
			{
				a[i] *= -1;
			}
		}

		/// <summary>
		///  метод Multi, умножающий каждый элемент массива на определенное число
		/// </summary>
		public void Multi(int m)
		{
			for (int i = 0; i < a.Length; i++)
			{
				a[i] *= m;
			}
		}

		/// <summary>
		/// свойство MaxCount, возвращающее количество максимальных элементов
		/// </summary>
		public int MaxCount
		{
			get
			{
				int max = a[0];
				int sum = 1;
				for (int i = 1; i < a.Length; i++)
				{
					if (a[i] > max)
					{
						max = a[i];
						sum = 1;
					} else if (max == a[i])
					{
						sum += a[i];
					}		
				}
				return sum;
			}
		}

		public int Length
		{
			get
			{
				return a.Length;
			}
		}
		override public string ToString()
		{
			string result = "";
			for (int i = 0; i < a.Length; i++)
			{
				if (i % 10 == 0)
				{
					result += "\n";
				}
				result += $"{a[i]} ";
			}
			return result;
		}

		/// <summary>
		/// метод, который записывает данные в файл
		/// </summary>
		public void WriteInFile(string filename)
		{
			if (File.Exists(filename))
			{
				StreamWriter sw = new StreamWriter(filename);
				sw.WriteLine(a.Length);
				for (int i = 0; i < a.Length; i++)
				{
					sw.WriteLine(a[i]);
				}
				sw.Close();
			}
			else Console.WriteLine("Error load file");
		}
	}
}
