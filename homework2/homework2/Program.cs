
// Губайдуллина

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static homework2.My_methods;

namespace homework2
{
	class Program
	{
		/// <summary>
		/// поиск минимального числа
		/// </summary>
		static int min(int a, int b, int c)
		{
			if (a < b && a < c)
			{
				return a;
			} else if (b < c)
			{
				return b;
			} else
			{
				return c;
			}
		}
		/// <summary>
		/// 1. Написать метод, 
		/// возвращающий минимальное из трех чисел.
		/// </summary>
		static void find_min()
		{
			int a, b, c;
			Console.Write("Введите первое число: ");
			a = Convert.ToInt32(Console.ReadLine());

			Console.Write("Введите второе число: ");
			b = Convert.ToInt32(Console.ReadLine());

			Console.Write("Введите третье число: ");
			c = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine($"Минимальное число: {min(a, b, c)}");
		}

		/// <summary>
		/// подсчета количества цифр числа
		/// </summary>
		static int count(int a)
		{
			int c;

			c = 1;

			while (a > 10)
			{
				a = a / 10;
				c++;
			}

			return c;
		}
		/// <summary>
		/// 2. Написать метод подсчета количества цифр числа.
		/// </summary>
		static void count_num()
		{
			int a;

			Console.WriteLine("Введите число: ");
			a = Math.Abs(Convert.ToInt32(Console.ReadLine()));

			Console.WriteLine($"Ответ {count(a)}");
		}

		/// <summary>
		/// 3. С клавиатуры вводятся числа, пока не будет введен 0. 
		/// Подсчитать сумму всех нечетных положительных чисел.
		/// </summary>
		static void count_nech()
		{
			int sum = 0, a;
			Console.WriteLine("Вводите числа, для завершения введите 0");

			do
			{
				a = Convert.ToInt32(Console.ReadLine());
				if (a % 2 != 0 && a > 0)
				{
					sum += a;
				}
			} while (a != 0);

			Console.WriteLine($"Ответ {sum}");
		}

		/// <summary>
		/// 4. Реализовать метод проверки логина и пароля. 
		/// На вход подается логин и пароль. На выходе истина, если прошел авторизацию, 
		/// и ложь, если не прошел (Логин: root, Password: GeekBrains). 
		/// Используя метод проверки логина и пароля, написать программу:
		/// пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
		/// С помощью цикла do while ограничить ввод пароля тремя попытками.
		/// </summary>
		static bool check_password()
		{
			string login, password;
			int count = 1;
			do
			{
				Console.Write("Введите логин: ");
				login = Console.ReadLine();

				Console.Write("Введите пароль: ");
				password = Console.ReadLine();

				count++;

				if (login == "root" && password == "GeekBrains")
				{
					return true;
				} else
				{
					Console.WriteLine("Не верный логин или пароль");
				}

			} while (count < 4);

			return false;
		}

		/// <summary>
		/// 5. а) Написать программу, которая запрашивает массу и рост человека, 
		/// вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, 
		/// набрать вес или все в норме;
		/// б) *Рассчитать, на сколько кг похудеть или сколько кг набрать 
		/// для нормализации веса.
		/// </summary>
		static void imt()
		{
			double height, I;
			int weight;

			Console.Write("Введите вес(кг): ");
			weight = Convert.ToInt32(Console.ReadLine());

			Console.Write("Введите рост(см): ");
			height = Convert.ToDouble(Console.ReadLine()) / 100;

			I = weight / (height * height);

			if (I < 18.5)
			{
				Console.WriteLine($"Ваш индекс массы равен {I:f2}, у Вас дефицит массы, Вам нужно набрать {18.5 * height* height - weight} кг.");
			} else if( I < 25)
			{
				Console.WriteLine($"Ваш индекс массы равен {I:f2}, у Вас все в норме.");
			} else if (I < 30)
			{
				Console.WriteLine($"Ваш индекс массы равен {I:f2}, у Вас избыточная масса тела, Вам нужно сбросить {weight - 24.9 * height * height } кг.");
			} else if (I > 30)
			{
				Console.WriteLine($"Ваш индекс массы равен {I:f2}, у Вас oжирение, Вам нужно сбросить {weight - 24.9 * height * height } кг.");
			}
		}

		static bool count_witn_char(int num)
		{
			string num_str = num.ToString();
			int sum = 0;

			for (int i = 0; i < num_str.Length; i++)
			{
				sum += (int)Char.GetNumericValue(num_str[i]);
			}

			if (num % sum == 0)
			{
				return true;
			} else
			{
				return false;
			}
		}

		static bool count_witn_while(int num)
		{
			int testnum = num;
			int temp = 0;

			while (testnum != 0)
			{
				temp += testnum % 10;
				testnum /= 10;
			}
			if (num % temp == 0)
			{
				return true;
			} else
			{
				return false;
			}
		}
		/// <summary>
		/// 6. *Написать программу подсчета количества «Хороших» чисел 
		/// в диапазоне от 1 до 1 000 000 000. 
		/// Хорошим называется число, которое делится на сумму своих цифр. 
		/// Реализовать подсчет времени выполнения программы, используя структуру DateTime.
		/// </summary>
		static void numbers()
		{
			int goodnumcount = 0, goodnumcount2 = 0;
			TimeSpan date3;
			DateTime date1, date2;

			//date1 = DateTime.Now;
			//for (int num = 1; num <= 1000000000; num++)
			//{
			//	if (count_witn_char(num))
			//	{
			//		goodnumcount++;
			//	}
			//}
			//date2 = DateTime.Now;
			//date3 = date2.Subtract(date1);
			//Console.WriteLine($"Количество чисел {goodnumcount}");
			//Console.WriteLine($"Время выполнения {date3}");

			date1 = DateTime.Now;
			for (int num = 1; num <= 1000000000; num++)
			{
				if (count_witn_while(num))
				{
					goodnumcount2++;
				}
			}
			date2 = DateTime.Now;
			date3 = date2.Subtract(date1);
			Console.WriteLine($"Количество чисел {goodnumcount2}");
			Console.WriteLine($"Время выполнения {date3}");

		}


		/// <summary>
		/// 7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b
		/// </summary>
		static void recursion(int a, int b)
		{
			if ( a == b)
			{
				Console.Write($"{a} ");
			} else
			{
				Console.Write($"{a} ");
				recursion(a + 1, b);
			}
		}

		/// <summary>
		/// 7. б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
		/// </summary>
		static int recursion_sum(int a, int b)
		{
			if (a == b)
			{
				return a;
			}
			else
			{
				return a + recursion_sum(a + 1, b);
			}

		}


		static void Main()
		{
			Console.WriteLine("Задание 1");
			find_min();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 2");
			count_num();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 3");
			count_nech();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 4");
			if (check_password())
			{
				Console.WriteLine("Данные верны");
			}
			else
			{
				Console.WriteLine("Попытки закончились");
			}
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 5");
			imt();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 6");
			numbers();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 7");
			Console.WriteLine("Введите число: ");
			int a = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите число больше предыдушего: ");
			int b = Convert.ToInt32(Console.ReadLine());
			recursion(a, b);
			Console.WriteLine();
			Console.WriteLine($"Сумма : {recursion_sum(a, b)}");	
			My_methods.Pause();
		}
	}
}
