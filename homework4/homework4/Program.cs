
// Губайдуллина

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static homework4.My_methods;
using static homework4.MyArray;
using static homework4.TwoDimArray;
using System.IO;

namespace homework4
{
	class Program
	{
		/// <summary>
		/// Создайте структуру Account, содержащую Login и Password
		/// </summary>
		struct Account
		{
			public string login;
			public string password;
		}

		static void FindPairs(int[] a)
		{
			int tmp;
			for (int i = 0; i < a.Length - 1; i++)
			{
				if (a[i] % 3 == 0 || a[i + 1] % 3 == 0)
				{
					tmp = a[i] % 3 == 0 ? a[i] : a[i + 1];
					Console.WriteLine($"{a[i],6}, {a[i+1],6}| {tmp,6} делится на 3 ");
				}
			}
		}

		/// <summary>
		/// 1. Дан целочисленный массив из 20 элементов. 
		/// Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. 
		/// Написать программу, позволяющую найти и вывести количество пар элементов массива, 
		/// в которых хотя бы одно число делится на 3. 
		/// В данной задаче под парой подразумевается 
		/// два подряд идущих элемента массива. 
		/// Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
		/// </summary>
		static void ArrayWork()
		{
			int[] array = new int[20];
			Random r = new Random();

			for(int i = 0; i < 20; i++)
			{
				array[i] = r.Next(-10000, 10001);

			}
			FindPairs(array);
		}

		static void MyArrayWork()
		{
			string message = "Пожалуйста, введите число цифрами";

			Console.WriteLine("Введите число элементов массива: ");
			int n = My_methods.GetValue(message);

			Console.WriteLine("Введите первое значение: ");
			int first = My_methods.GetValue(message);

			Console.WriteLine("Введите шаг для значений: ");
			int step = My_methods.GetValue(message);


			MyArray array = new MyArray(n, first, step);

			Console.Write("Полученный массив:");
			Console.WriteLine(array.ToString());

			Console.Write("Сумма элементов: ");
			Console.WriteLine(array.Sum);

			Console.Write("Inverse: ");
			array.Inverse();
			Console.WriteLine(array.ToString());

			Console.WriteLine("Введите значение для умножения: ");
			int m = My_methods.GetValue(message);
			array.Multi(m);

			Console.Write("Результат: ");
			Console.WriteLine(array.ToString());

			Console.Write("Количество максимальных элементов: ");
			Console.WriteLine(array.MaxCount);

			Console.WriteLine("Работа с файлом:");
			MyArray array2 = new MyArray("..\\..\\array_read.txt");
			Console.WriteLine(array2.ToString());

			array2.Inverse();

			array2.WriteInFile("..\\..\\array_write.txt");

		}

		/// <summary>
		/// Решить задачу с логинами из предыдущего урока
		/// </summary>
		static bool CheckPassword()
		{
			string login, password;
			Account account;

			string[] ss = File.ReadAllLines("..\\..\\info.txt");
			account.login = ss[0];
			account.password = ss[1];

			int count = 1;
			do
			{
				Console.Write("Введите логин: ");
				login = Console.ReadLine();

				Console.Write("Введите пароль: ");
				password = Console.ReadLine();

				count++;

				if (login == account.login && password == account.password)
				{
					return true;
				}
				else
				{
					Console.WriteLine("Не верный логин или пароль");
				}

			} while (count < 4);

			return false;
		}


		static void MyDimArrayWork()
		{
			string message = "Пожалуйста, введите число цифрами";

			Console.WriteLine("Введите число строк массива: ");
			int n = My_methods.GetValue(message);

			Console.WriteLine("Введите число колонок массива: ");
			int m = My_methods.GetValue(message);


			TwoDimArray array = new TwoDimArray(n, m);

			Console.WriteLine("Полученный массив:");
			Console.WriteLine(array.ToString());

			Console.Write("Сумма элементов: ");
			Console.WriteLine(array.Sum());

			Console.WriteLine("Введите число для подсчета суммы всех элементов массива больше заданного: ");
			int max = My_methods.GetValue(message);

			Console.Write("Количество максимальных элементов: ");
			Console.WriteLine(array.SumM(max));

			Console.Write("Максимальный элемент: ");
			Console.WriteLine(array.Max);

			Console.Write("Минимальный элемент: ");
			Console.WriteLine(array.Min);

			int i, j;
			Console.Write("Hомер максимального элемента: ");
			array.NumMax(out i,out j);
			Console.WriteLine((i + 1) + " " + (j + 1)); // Для удобства


			Console.WriteLine("Работа с файлом:");
			TwoDimArray array2 = new TwoDimArray("..\\..\\dimarray_read.txt");
			Console.WriteLine(array2.ToString());

			array2.WriteInFile("..\\..\\dimarray_write.txt");

		}
		static void Main()
		{
			Console.WriteLine("Задание 1");
			ArrayWork();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 2");
			MyArrayWork();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 3");
			if (CheckPassword())
			{
				Console.WriteLine("Данные верны");
			}
			else
			{
				Console.WriteLine("Попытки закончились");
			}
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 4");
			MyDimArrayWork();
			My_methods.Pause();
			Console.Clear();
		}
	}
}
