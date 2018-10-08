using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
	class Student
	{
		public string lastName;
		public string firstName;
		public string university;
		public string faculty;
		public int course;
		public string department;
		public int group;
		public string city;
		public int age;

		public Student(string firstName, string lastName, string university, string faculty, 
						string department, int age, int course, int group, string city)
		{
			this.lastName = lastName;
			this.firstName = firstName;
			this.university = university;
			this.faculty = faculty;
			this.department = department;
			this.course = course;
			this.age = age;
			this.group = group;
			this.city = city;
		}		public int CompareNames(Student s)
		{
			return String.Compare(this.firstName, s.firstName);
		}

		/// <summary>
		/// определяет студента 5-6 курса
		/// </summary>
		/// <returns>да,нет</returns>        public static bool CourseAboveFifth(Student s)
		{
			return s.course >= 5;
		}		/// <summary>
		/// Возрвшает массив из 2х элементов
		/// </summary>
		/// <returns>0 - курс, 1 - возраст</returns>		public int[] GetCorAge()
		{
			int[] arr = new int[2];
			arr[0] = course;
			arr[1] = age;
			return arr;
		}

		/// <summary>
		///  Сравнивает 2 студента по возрасту
		/// </summary>
		/// <param name="st1"></param>
		/// <param name="st2"></param>
		/// <returns></returns>        public static int SortAge(Student st1, Student st2)
		{
			if (st1.age < st2.age)
			{
				return -1;
			}
			else if (st1.age > st2.age)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}

		/// <summary>
		/// Сравнивает 2 студента по курсу и возрасту
		/// </summary>
		/// <param name="st1"></param>
		/// <param name="st2"></param>
		/// <returns></returns>
		public static int SortCourseAge(Student st1, Student st2)
		{
			if (st1.course < st2.course)
			{
				return -1;
			}
			else if (st1.course > st2.course)
			{
				return 1;
			}
			else
			{
				return SortAge(st1, st2);
			}
		}

		/// <summary>
		/// Реализует проверку студента по списку условий
		/// </summary>
		/// <param name="student">Студент</param>
		/// <param name="keys">Список условий в виде предикатов</param>
		/// <returns></returns>
		public bool SearchParam(List<Predicate<Student>> param)
		{
			foreach (var item in param)
			{
				if (!item(this))
				{
					return false;
				}
			}
			return true;
		}
	}
}
