using homework4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace homework5
{
	class Program
	{
		static bool CheckLoginA(string login, out string answer)
		{
			bool check = true;
			bool checkR = true;
			answer = "";
			Regex login_regex = new Regex("^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9]{1,9}$");

			if (login.Length > 10 || login.Length < 2)
			{
				answer += "Длина .... не верно\n";
				check = false;
			}
			else
			{
				answer += "Длина .... верно\n";
			}
			if (Char.IsDigit(login[0]))
			{
				answer += "Первый символ не цифра .... не верно\n";
				check = false;
			} else
			{
				answer += "Первый символ не цифра .... верно\n";
			}

			for (int i = 0; i < login.Length; i++)
			{
				if (!Char.IsLetterOrDigit(login[i]))
				{
					check = false;
					answer += "Состоит только из букв и цифр .... не верно\n";
					break;					
				}
			}
			answer += "Состоит только из букв и цифр .... верно\n";

			if (login_regex.Match(login).Success)
			{
				answer += "С использованием регулярных выражений .... верно";
			}
			else
			{
				checkR = false;
				answer += "С использованием регулярных выражений .... не верно";
			}
			return check && checkR;
		}

		/// <summary>
		/// Создать программу, которая будет проверять корректность ввода логина. 
		/// Корректным логином будет строка от 2 до 10 символов, 
		/// содержащая только буквы латинского алфавита или цифры, 
		/// при этом цифра не может быть первой
		/// </summary>
		static void Login()
		{
			Console.WriteLine("Введите ваш логин:");
			string login;
			string answer;

			do
			{
				login = Console.ReadLine();
				if(CheckLoginA(login,out answer))
				{
					Console.WriteLine("Верно");
					break;
				}
				Console.WriteLine(answer);
				Console.WriteLine("Введите еще раз:");
			} while (true);
		}
		/// <summary>
		/// Разработать класс Message, 
		/// содержащий следующие статические методы для обработки
		/// </summary>
		static void MessangeWork()
		{
			Message mes = new Message("..\\..\\for_message.txt");
			Console.WriteLine("Сообщение:");
			Console.Write(mes.ToString());
			string answer = mes.FindLeterMax(4);
			Console.WriteLine("Слова, длина которые не больше 4:");
			Console.WriteLine(answer);
			answer = mes.Max();
			Console.WriteLine("Самое длинное слово:");
			Console.WriteLine(answer);
			answer = mes.MaxMessage();
			Console.WriteLine("Сообщение из самых длинных слов:");
			Console.WriteLine(answer);
			mes.DeleteWords('s');
			Console.WriteLine("Сообщение без слов, заканчивающихся на s:");
			Console.Write(mes.ToString());
		}

		static char[] SortString(string s)
		{
			char[] content = s.ToCharArray();
			Array.Sort(content);
			return content;
		}

		static bool Equal(String s, String t)
		{
			if (s.Length != t.Length)
			{
				return false;
			}
			char[] s1 = SortString(s.ToUpper());
			char[] t1 = SortString(t.ToUpper());
			for (int i = 0; i < s.Length; i++)
			{
				if((int)s1[i] != (int)t1[i])
				{
					return false;
				}
			}
			return true;
		}
		/// <summary>
		/// Для двух строк написать метод, определяющий, 
		/// является ли одна строка перестановкой другой
		/// </summary>
		static void EqualWork()
		{
			Console.WriteLine("Введте строку 1:");
			string s1 = Convert.ToString(Console.ReadLine());
			Console.WriteLine("Введте строку 2:");
			string s2 = Convert.ToString(Console.ReadLine());
			Console.WriteLine("Резултат C#:");
			Console.WriteLine(s1.Select(Char.ToUpper).OrderBy(x => x).SequenceEqual(s2.Select(Char.ToUpper).OrderBy(x => x)));
			Console.WriteLine("Резултат :");
			Console.WriteLine(Equal(s1,s2));

		}
		struct Person
		{
			public string fio;
			public double marks;
		}

		static Person[] GetInfo()
		{
			string[] sr = File.ReadAllLines("..\\..\\data.txt");
			Person[] a = new Person[sr.Length];
			for (int i = 0; i < sr.Length; i++)
			{
				string[] str = sr[i].Trim().Split(' ');
				a[i].fio = str[0] + " " + str[1];
				a[i].marks = (double)(int.Parse(str[2]) + int.Parse(str[3]) + int.Parse(str[4])) / 3;
			}
			return a;
		}
		/// <summary>
		/// Задача ЕГЭ
		/// </summary>
		static void WorstStudents()
		{ 
			StreamReader sr = new StreamReader("..\\..\\data.txt");
			Console.WriteLine("Сведения о сдаче экзаменов учениками:");
			while (!sr.EndOfStream)
			{
				Console.WriteLine(sr.ReadLine());
			}

			Person[] a = GetInfo();
			double m1 = 20, m2 = 20, m3 = 20;
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i].marks < m1)
				{
					m3 = m2;
					m2 = m1;
					m1 = a[i].marks;
				}
				else if (a[i].marks < m2)
				{
					m3 = m2;
					m2 = a[i].marks;
				}
				else if (a[i].marks < m3) m3 = a[i].marks;
			}
			Console.WriteLine("\nРезультат:");
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i].marks == m1 || a[i].marks == m2 || a[i].marks == m3)
				{
					Console.WriteLine(a[i].fio);
				}
			}

			sr.Close();
		}
		/// <summary>
		/// Написать игру «Верю. Не верю»
		/// </summary>
		static void Quest()
		{
			string[] sr = File.ReadAllLines("..\\..\\quest.txt");
			Random r = new Random();
			int max = 9, sum = 0;
			int[] x = new int[5];

			for (int i = 0; i < 5; i++)
			{
				bool contains;
				int next;
				do
				{
					next = r.Next(max);
					contains = false;
					for (int index = 0; index < i; index++)
					{
						int n = x[index];
						if (n == next)
						{
							contains = true;
							break;
						}
					}
				} while (contains);
				x[i] = next;
			}

			Console.WriteLine("Отвечайте на вопросы Да/Нет");
			for(int i = 0; i < 5; i++)
			{
				string[] str = sr[x[i]].Trim().Split('/');
				Console.WriteLine(str[0] + "?");
				string answer = Console.ReadLine();
				if (answer == str[1])
				{
					sum++;
				}
			}
			Console.WriteLine("Ваш результат: " + sum);
		}

		static void Main()
		{
			Console.WriteLine("Задание 1");
			Login();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 2");
			MessangeWork();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 3");
			EqualWork();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 4");
			WorstStudents();
			My_methods.Pause();
			Console.Clear();

			Console.WriteLine("Задание 5");
			Quest();
			My_methods.Pause();
			Console.Clear();
		}
	}
}