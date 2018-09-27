
// Губайдуллина

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static homework3.Complex;
using static homework3.Fraction;
using static homework3.My_methods;

namespace homework3
{
	class Program
	{
		/// <summary>
		/// 1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. 
		/// Продемонстрировать работу структуры
		/// б) Дописать класс Complex, добавив методы вычитания и произведения чисел.
		/// Проверить работу класса
		/// </summary>
		static void ComplexWork()
		{
			Complex complex1;
			complex1 = new Complex(1, 1);
			Console.WriteLine($"Первое число: {complex1.ToString()}");
			Complex complex2 = new Complex(2, 2);
			complex2.Im = 3;
			Console.WriteLine($"Второе число: {complex2.ToString()}");

			Complex result;
			result = complex1.Plus(complex2);
			Console.WriteLine($"Сложение: {result.ToString()}");

			result = complex1.Minus(complex2);
			Console.WriteLine($"Вычитание: {result.ToString()}");

			result = complex1.Multiply(complex2);
			Console.WriteLine($"Умножение: {result.ToString()}");
		}

		/// <summary>
		/// б) Добавить обработку исключительных ситуаций на то, 
		/// что могут быть введены некорректные данные. 
		/// При возникновении ошибки вывести сообщение. 
		/// Напишите соответствующую функцию
		/// </summary>
		static int GetValue(string message)
		{
			int x;
			bool flag;
			while (true)
			{
				flag = int.TryParse(Console.ReadLine(), out x);
				if (!flag)
				{
					Console.WriteLine(message);
				} else
				{
					return x;
				}
			}	
		}

		/// <summary>
		/// 2. а) С клавиатуры вводятся числа, пока не будет введен 0 
		/// (каждое число в новой строке). 
		/// Требуется подсчитать сумму всех нечетных положительных чисел.
		/// Сами числа и сумму вывести на экран, используя tryParse
		/// </summary>
		static void Сount()
		{
			int sum = 0, a;
			Console.WriteLine("Вводите числа, для завершения введите 0");
			Console.WriteLine("Пожалуйста, введите число цифрами");

			do
			{
				a = GetValue("Пожалуйста, введите число цифрами");
				if (a % 2 != 0 && a > 0)
				{
					sum += a;
				}
			} while (a != 0);

			Console.WriteLine($"Ответ {sum}");
		}

		/// <summary>
		/// 3. *Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел. 
		/// Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
		/// Написать программу, демонстрирующую все разработанные элементы класса. Достаточно решить 2 задачи. 
		/// Все программы сделать в одном решении.
		///** Добавить проверку, чтобы знаменатель не равнялся 0. 
		///Выбрасывать исключение
		///ArgumentException("Знаменатель не может быть равен 0")
		///Добавить упрощение дробей.
		/// </summary>
		static void FractionWork()
		{
			Fraction complex1;
			int num1, den1, num2, den2;
			Console.WriteLine("Работа с дробями, предусмотрено сокращение");

			Console.Write("Введите числитель первой дроби: ");
			num1 =  GetValue("Пожалуйста, введите число цифрами");

			Console.Write("Введите знаменатель первой дроби: ");
			den1 = GetValue("Пожалуйста, введите число цифрами");

			complex1 = new Fraction(num1, den1);

			Console.Write("Введите числитель второй дроби: ");
			num2 = GetValue("Пожалуйста, введите число цифрами");

			Console.Write("Введите знаменатель второй дроби: ");
			den2 = GetValue("Пожалуйста, введите число цифрами");
			Fraction complex2 = new Fraction(num2, den2);


			Fraction.WriteLine($"Первая дробь: {complex1.ToString()}");
			
			Console.WriteLine($"Вторая дробь: {complex2.ToString()}");

			Fraction result;
			result = complex1.Plus(complex2);
			Console.WriteLine($"Сложение: {result.ToString()}");

			result = complex1.Minus(complex2);
			Console.WriteLine($"Вычитание: {result.ToString()}");

			result = complex1.Multiply(complex2);
			Console.WriteLine($"Умножение: {result.ToString()}");

			result = complex1.Division(complex2);
			Console.WriteLine($"Деление: {result.ToString()}");
		}
		static void Main()
		{
			Console.WriteLine("Задание 1");
			ComplexWork();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 2");
			Сount();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 3");
			FractionWork();
			My_methods.Pause();
		}
	}
}
