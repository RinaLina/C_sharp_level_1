
// Губайдуллина

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static homework1_Gubaydullina.My_methods;

namespace homework1_Gubaydullina
{
	class Program
	{
		/*
		 1. Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку.
			а) используя склеивание;
			б) используя форматированный вывод;
			в) *используя вывод со знаком $.
		 */
		static void profile()
		{
			string age, weight, height, first_name, last_name, result = "";
			int age_int, weight_int, height_int;
			Console.Write("Введите ваше имя: ");
			first_name = Console.ReadLine();
			result = result + "Имя: " + first_name + "\n";

			Console.Write("Введите вашу фамилию: ");
			last_name = Console.ReadLine();
			result = result + "Фамилия: " + last_name + "\n";

			Console.Write("Введите ваш возраст: ");
			age = Console.ReadLine();
			result = result + "Возраст: " + age + "\n";

			Console.Write("Введите ваш вес: ");
			weight = Console.ReadLine();
			result = result + "Имя: " + weight + "\n";

			Console.Write("Введите ваш рост: ");
			height = Console.ReadLine();
			result = result + "Рост: " + height + "\n";

			Console.WriteLine();
			Console.WriteLine("Склейка: " + result);

			age_int = Convert.ToInt32(age);
			weight_int = Convert.ToInt32(weight);
			height_int = Convert.ToInt32(height);

			Console.WriteLine();
			Console.WriteLine("Форматированный: \nИмя - {0}\nФамилия - {1}\nВозраст - {2}\nВес - {3}\nРост - {4}",
									first_name, last_name, age_int, weight_int, height_int);

			Console.WriteLine();
			Console.WriteLine($"Используя вывод со знаком $: \nИмя = {first_name}\nФамилия = {last_name}\nВозраст = {age_int}\nВес = {weight_int}\nРост = {height_int}");
		}

		/*Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах*/

		static void imt()
		{
			double height_d;
			int weight_i;
			string weight, height, result;

			Console.Write("Введите вес(кг): ");
			weight = Console.ReadLine();

			Console.Write("Введите рост(м): ");
			height = Console.ReadLine();

			weight_i = Convert.ToInt32(weight);
			height_d = Convert.ToDouble(height);

			result = $"{weight_i} / ({height_d} * {height_d}) = {weight_i / (height_d * height_d)}";
			Console.WriteLine(result);

		}

		static double distance(int x1,int y1, int x2, int y2)
		{
			return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
		}

		/*  a) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 
				по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2).
				Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
			б) *Выполните предыдущее задание, оформив вычисления расстояния между точками в виде метода;*/

		static void coord()
		{
			int x1, x2, y1, y2;
			string ans;
			double result;

			Console.Write("Введите значение x1: ");
			ans = Console.ReadLine();
			x1 = Convert.ToInt32(ans);

			Console.Write("Введите значение y1: ");
			ans = Console.ReadLine();
			y1 = Convert.ToInt32(ans);

			Console.Write("Введите значение x2: ");
			ans = Console.ReadLine();
			x2 = Convert.ToInt32(ans);

			Console.Write("Введите значение y2: ");
			ans = Console.ReadLine();
			y2 = Convert.ToInt32(ans);

			result = distance(x1, y1, x2, y2);
			Console.WriteLine("Результат: {0:f2}", result);
		}

		/*. Написать программу обмена значениями двух переменных.
			а) с использованием третьей переменной;
			б) *без использования третьей переменной.*/

		static void change()
		{
			int a = 1, b = 2, c;
			Console.WriteLine("а  = {0}, b = {1}", a, b);
			c = a;
			a = b;
			b = c;
			Console.WriteLine("а  = {0}, b = {1}", a, b);
			a = a + b;
			b = a - b;
			a = a - b;
			Console.WriteLine("а  = {0}, b = {1}", a, b);

		}

		/*а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
			б) Сделать задание, только вывод организуйте в центре экрана
			в) *Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y)*/

			
		static void name_print()
		{
			string name = "Карина Губайдуллина, Москва";
			Console.WriteLine(name);
			My_methods.Pause();
			Console.Clear();

			//Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
			//Console.WriteLine(name);
			My_methods.Print(name, Console.WindowWidth / 2, Console.WindowHeight / 2);
			My_methods.Pause();
		}
		static void Main()
		{
			Console.WriteLine("1.Анкета");
			profile();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("\n2.Расчет ИМТ");
			imt();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("\n3.Расстояние");
			coord();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("\n4.Обмен значений переменных");
			change();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("\n5.Вывод имени");
			name_print();

			My_methods.Pause();
		}
	}
}
