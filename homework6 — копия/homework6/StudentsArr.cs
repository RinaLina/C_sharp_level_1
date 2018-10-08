using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
	class StudentsArr
	{
		List<Student> list = new List<Student>();

		/// <summary>
		/// Создание экземпляра класса из файда .csv
		/// </summary>
		/// <param name="filename">имя файла</param>
		public StudentsArr(string filename)
		{
			StreamReader sr = new StreamReader(filename);			while (!sr.EndOfStream)
			{
				try
				{
					string[] s = sr.ReadLine().Split(';');
					list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
					if (Console.ReadKey().Key == ConsoleKey.Escape) return;
				}

			}			sr.Close();
		}

		/// <summary>
		/// Переводит список экземпляра класса в строку для вывода
		/// </summary>
		/// <returns>строка</returns>
		public string ToString()
		{
			string result = string.Empty;
			foreach (var v in list)
				result += $"Имя Фамилия курс: {v.course} возраст: {v.age}" + "\n"; // не знаю как починить кодировку русских букв
			return result;
		}

		/// <summary>
		/// Подсчитать количество студентов учащихся на 5 и 6 курсах
		/// </summary>
		/// <returns></returns>
		public int CountStAboveFifth()
		{
			int result = 0;
			foreach (var v in list)
			{
				if (Student.CourseAboveFifth(v)) result++;
			}
			return result;
		}
		/// <summary>
		/// подсчитать сколько студентов в возрасте от 18 до 20 лет 
		/// на каком курсе учатся 
		/// </summary>
		/// <returns></returns>
		public string FrequencyArray()
		{
			string result = string.Empty;
			//Словарь вида:
			//"курс" : "возраст" : количество
			//		   "возраст" : количество
			//  ...
			Dictionary<int, Dictionary<int, int>> arr = new Dictionary<int, Dictionary<int, int>>();
			// заполнение его нулями, те на каждый возраст каждому курсу присваивается по 0 студентов
			for(int i = 1; i < 7; i++)
			{
				arr.Add(i, new Dictionary<int, int>());
				for(int j = 18; j < 21; j++)
				{
					arr[i].Add(j, 0);
					//arr.Add(i, new Dictionary<int, int>() { { j, 0 } });
				}
			}
			//подсчет студентов, кто какой курс и сколько лет
			foreach (var v in list)
			{
				int[] ca = v.GetCorAge();
				if(ca[1] > 17 && ca[1] < 21)
					arr[ca[0]][ca[1]]++;
			}

			//Заполнение 
			foreach (int c in arr.Keys)
			{
				result += String.Format("Курс {0}:\n", c);
				foreach(int a in arr[c].Keys)
				{
					result += String.Format("\t{0}|",a);
					for (int i = 1; i <= arr[c][a]; i++)
					{
						result += "-";
					}
					result += "\n";					
				}
			}
			return result;
		}

		/// <summary>
		/// Сортировка по возрасту
		/// </summary>
		public void SortAge()
		{
			list.Sort(Student.SortAge);
		}

		/// <summary>
		/// Сортировка по курсу и возрасту
		/// </summary>
		public void SortCourseAge()
		{
			list.Sort(Student.SortCourseAge);
		}

		/// <summary>
		/// считает количество студентов 5-6 курсов
		/// </summary>
		/// <returns></returns>
		public int FindFifthUp()
		{
			return list.FindAll(Student.CourseAboveFifth).Count;
		}

		/// <summary>
		/// Возвращает список подходящих под условия студентов 
		/// </summary>
		/// <param name="param"></param>
		/// <returns></returns>
		public List<Student> SearchParamList(List<Predicate<Student>> param)
		{
			List<Student> paramlist = new List<Student>();
			foreach(var v in list)
			{
				if (v.SearchParam(param))
				{
					paramlist.Add(v);
				}
			}
			return paramlist;
		}

		/// <summary>
		/// перевод в строку любой список студентов
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		static public string ListToString(List<Student> list)
		{
			string result = string.Empty;
			foreach (var v in list)
				result += $"Имя Фамилия курс: {v.course} возраст: {v.age}" + "\n";
			return result;
		}

	}
}
