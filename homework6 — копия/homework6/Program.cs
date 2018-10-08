
//Губайдуллина

using System;
using System.IO;
using homework1;
using System.Collections;
using System.Collections.Generic;

namespace homework6
{

	class Program
	{
		/// <summary>
		/// Изменить программу вывода функции так,
		/// чтобы можно было передавать функции типа double (double,double)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="x"></param>
		/// <returns></returns>
		delegate double Fun(double a, double x);
		/// <summary>
		/// делегат для задания 2, минимума ф-ции
		/// </summary>
		/// <param name="x">переменная для ф-ции</param>
		/// <returns></returns>
		delegate double Funk(double x);

		static void Table(Fun F, double a, double x, double b)
		{
			Console.WriteLine("----- X ----- Y -----");
			while (x <= b)
			{
				Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
				x += 1;
			}
			Console.WriteLine("---------------------");
		}
		/// <summary>
		/// записывает данные функции в файла на промежутке от a до b с шагом h
		/// </summary>
		/// <param name="fileName">Имя файла</param>
		/// <param name="F">Ф-ция</param>
		/// <param name="a">нижняя граница промежутка</param>
		/// <param name="b">верхняя граница промежутка</param>
		/// <param name="h">шаг</param>
		static void SaveFunc(string fileName, Funk F, double a, double b, double h)
		{
			FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			BinaryWriter bw = new BinaryWriter(fs);
			double x = a;
			while (x <= b)
			{
				bw.Write(F(x));
				x += h;
			}
			bw.Close();
			fs.Close();
		}
		/// <summary>
		/// Параметры дляминимума ф-ции
		/// </summary>
		/// <param name="a">нижняя граница промежутка</param>
		/// <param name="b">верхняя граница промежутка</param>
		/// <param name="h">шаг</param>
		static void GetParam(out double a, out double b, out double h)
		{
			Console.WriteLine("Введите нижнюю границу промежутка");
			a = My_methods.GetValueDouble("Введите числом с ','");
			Console.WriteLine("Введите верхнюю границу промежутка");
			b = My_methods.GetValueDouble("Введите числом с ','");
			Console.WriteLine("Введите шаг");
			h = My_methods.GetValueDouble("Введите числом с ','");
		}
		/// <summary>
		/// Переделайте функцию Load, чтобы она возвращала массив считанных значений.
		/// Пусть она возвращает минимум через параметр
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="min"></param>
		/// <returns></returns>
		public static ArrayList Load(string fileName, out double min)
		{
			FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryReader bw = new BinaryReader(fs);
			ArrayList list = new ArrayList();
			min = double.MaxValue;
			double d;
			for (int i = 0; i < fs.Length / sizeof(double); i++)
			{
				// Считываем значение и переходим к следующему
				d = bw.ReadDouble();
				list.Add(d);
				if (d < min) min = d;
			}
			bw.Close();
			fs.Close();
			return list;
		}
		/// <summary>
		/// Меню выбора функции к заданию 2
		/// </summary>
		static void Menu()
		{
			int ans;
			double a, b, h, min;
			string filename = "data.txt";
			Console.WriteLine("Выберите ф-цию для нахождения минимума(введите номер): \n1)х^2\n2)sin(x)\n3)x^3\n4)2x-x^4");
			do
			{
				Console.WriteLine("Введите номер от 1 до 4");
				ans = My_methods.GetValueInt("Введите номер числом");
			} while (ans > 4 || ans < 1);
			GetParam(out a, out b, out h);
			Funk[] f = new Funk[4];
			f[0] = delegate (double x) { return x * x; };
			f[1] = delegate (double x) { return Math.Sin(x); };
			f[2] = delegate (double x) { return x * x * x; };
			f[3] = delegate (double x) { return 2 * x - x * x * x * x; };

			switch (ans)
			{
				case 1:
					SaveFunc(filename, f[0], a, b, h);
					break;
				case 2:
					SaveFunc(filename, f[1], a, b, h);
					break;
				case 3:
					SaveFunc(filename, f[2], a, b, h);
					break;
				case 4:
					SaveFunc(filename, f[3], a, b, h);
					break;
			}
			ArrayList list = new ArrayList();
			list = Load(filename, out min);
			foreach (var v in list) Console.WriteLine(v);
			Console.WriteLine("Минимальное значение: " + min);
		}


		static void Main()
		{
			Console.WriteLine("Задание 1");
			//Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x)
			Console.WriteLine("Таблица функции a*x^2:");
			Table(delegate (double a, double x) { return a * x * x; }, 2, 1, 3);

			Console.WriteLine("Таблица функции a*sin(x):");
			Table(delegate (double a, double x) { return a * Math.Sin(x); }, 2, 1, 3);
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 2");
			Menu();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 3");
			StudentsArr stlist = new StudentsArr("..\\..\\st.csv");
			Console.WriteLine(stlist.ToString());
			Console.WriteLine(stlist.FrequencyArray());
			My_methods.Pause();
			Console.WriteLine($"Количество учащихся 5-6 курса: {stlist.FindFifthUp()}");
			My_methods.Pause();
			stlist.SortAge();
			Console.WriteLine("Сортировка по возрасту\n" + stlist.ToString());
			My_methods.Pause();
			stlist.SortCourseAge();
			Console.WriteLine("Сортировка по курсу и возрасту" + stlist.ToString());
			My_methods.Pause();
			List<Predicate<Student>> dic = new List<Predicate<Student>>();
			dic.Add(e => e.age >= 19);
			dic.Add(e => e.age < 21);
			dic.Add(e => e.course == 3);
			string s = StudentsArr.ListToString(stlist.SearchParamList(dic));
			Console.WriteLine(s);
			My_methods.Pause();
			Console.Clear();
		}
	}
}
