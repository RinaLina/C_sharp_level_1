using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework4
{
	class TwoDimArray
	{
		int[,] a;

		/// <summary>
		/// Реализовать конструктор, заполняющий массив случайными числами
		/// </summary>
		public TwoDimArray(int n, int m)
		{
			a = new int[n, m];
			Random r = new Random();

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					a[i, j] = r.Next(0,100); // Для примера, что бы значения не были слишком большими
				}
			}
		}

		public TwoDimArray(string filename) //Не знаю в каком формате должны содержаться данные в файле
		{
			string[] s = File.ReadAllLines(filename);
			string[] st = s[0].Trim().Split(' ');
			a = new int[s.Length,st.Length];
			for (int i = 0; i < this.Rows; i++)
			{      
				string[] str = s[i].Trim().Split(' ');
				for (int j = 0; j < str.Length; j++)
					a[i,j] = int.Parse(str[j].Trim());
			}

		}

		public int this[int i, int j]
		{
			get { return a[i, j]; }
			set { a[i, j] = value; }
		}

		/// <summary>
		/// Создать методы, которые возвращают сумму всех элементов массива
		/// </summary>
		/// <returns></returns>
		public int Sum()
		{
			int sum = 0;
			for (int i = 0; i < this.Rows; i++)
			{
				for (int j = 0; j < this.Columns; j++)
				{
					sum += a[i, j];
				}
			}
			return sum;
		}

		/// <summary>
		/// сумму всех элементов массива больше заданного
		/// </summary>
		public int SumM(int m)
		{
			int sum = 0;
			for (int i = 0; i < this.Rows; i++)
			{
				for (int j = 0; j < this.Columns; j++)
				{
					if (a[i, j] > m)
					{
						sum += a[i, j];
					}					
				}
			}
			return sum;
		}

		/// <summary>
		/// свойство, возвращающее минимальный элемент массива
		/// </summary>
		public int Min
		{
			get
			{
				int min = a[0, 0];
				for (int i = 0; i < this.Rows; i++)
				{
					for (int j = 0; j < this.Columns; j++)
					{
						if (a[i, j] < min)
						{
							min = a[i, j];
						}
					}
				}
				return min;
			}			
		}

		/// <summary>
		/// свойство, возвращающее максимальный элемент массива
		/// </summary>
		public int Max
		{
			get
			{
				int max = a[0,0];
				for (int i = 0; i < this.Rows; i++)
				{
					for (int j = 0; j < this.Columns; j++)
					{
						if (a[i, j] > max)
						{
							max = a[i, j];
						}
					}
				}
				return max;
			}
		}

		/// <summary>
		///  метод, возвращающий номер максимального элемента массива
		/// </summary>
		public void NumMax(out int n, out int m)
		{
			n = 0;
			m = 0;
			for (int i = 0; i < this.Rows; i++)
			{
				for (int j = 0; j < this.Columns; j++)
				{
					if (a[i, j] > a[n, m])
					{
						n = i;
						m = j;
					}
				}
			}
		}
		public int Rows
		{
			get
			{
				return a.GetUpperBound(0) + 1;
			}
		}

		public int Columns
		{
			get
			{
				return a.Length / this.Rows;
			}
		}

		override public string ToString()
		{
			string result = "";
			for (int i = 0; i < this.Rows; i++)
			{
				for (int j = 0; j < this.Columns; j++)
				{
					result += $"{a[i,j]} ";
				}
				result += "\n";
			}
			return result;
		}

		public void WriteInFile(string filename)
		{
			if (File.Exists(filename))
			{
				StreamWriter sw = new StreamWriter(filename);
				string str = this.ToString();
				sw.WriteLine(str);
				sw.Close();
			}
			else Console.WriteLine("Error load file");
		}
	}
}
