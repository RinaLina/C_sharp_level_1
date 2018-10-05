using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace homework5
{
	class Message
	{
		string[][] message;
		string filename;
		public Message(string filename)
		{
			if (File.Exists(filename))
			{
				this.filename = filename;
				string[] s = File.ReadAllLines(filename);
				message = new string[s.Length][];
				for (int i = 0; i < s.Length; i++)
				{
					string[] str = s[i].Trim().Split(' ');
					message[i] = new string[str.Length];
					for (int j = 0; j < str.Length; j++)
						message[i][j] = str[j].Trim();
				}

			} else Console.WriteLine("Error load file");

		}
		/// <summary>
		/// Bывести только те слова сообщения, которые содержат не более n букв
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public string FindLeterMax(int n)
		{
			string answer = "";
			for (int i = 0; i < message.Length; i++)
			{
				for (int j = 0; j < message[i].Length; j++)
				{
					if (message[i][j].Length < n)
					{
						answer += message[i][j] + " ";
					}
				}
			}

			return answer;
		}
		/// <summary>
		/// Удалить из сообщения все слова, которые заканчиваются на заданный символ
		/// </summary>
		/// <param name="simb"></param>
		public void DeleteWords(char simb)
		{
			string word;
			if (File.Exists(filename))
			{
				StreamWriter sw = new StreamWriter(filename);
				for (int i = 0; i < message.Length; i++)
				{
					for (int j = 0; j < message[i].Length; j++)
					{
						word = message[i][j];
						if (word[word.Length - 1] != simb)
						{
							sw.Write(word + " ");
						}
					}
					sw.Write("\n");
				}
				sw.Close();
				string[] s = File.ReadAllLines(filename);
				message = new string[s.Length][];
				for (int i = 0; i < s.Length; i++)
				{
					string[] str = s[i].Trim().Split(' ');
					message[i] = new string[str.Length];
					for (int j = 0; j < str.Length; j++)
						message[i][j] = str[j].Trim();
				}
			}
			else Console.WriteLine("Error load file");
		}
		/// <summary>
		/// Найти самое длинное слово сообщения
		/// </summary>
		/// <returns></returns>
		public string Max()
		{
			string max = "";
			for (int i = 0; i < message.Length; i++)
			{
				for (int j = 0; j < message[i].Length; j++)
				{					
					if (max.Length < message[i][j].Length)
					{
						max = message[i][j];
					}
				}
			}
			return max;
		}
		/// <summary>
		/// Сформировать строку с помощью StringBuilder из самых длинных слов сообщения
		/// </summary>
		/// <returns></returns>
		public string MaxMessage()
		{
			int maxLength = 0;
			StringBuilder mess = new StringBuilder();
			for (int i = 0; i < message.Length; i++)
			{
				for (int j = 0; j < message[i].Length; j++)
				{
					if (maxLength < message[i][j].Length)
					{
						maxLength = message[i][j].Length;
						mess.Remove(0, mess.Length);
						mess.Append(message[i][j]);
						mess.Append(" ");
					} else if (maxLength == message[i][j].Length)
					{
						mess.Append(message[i][j]);
						mess.Append(" ");
					}
				}
			}
			return mess.ToString();
		}

		public string ToString()
		{
			string answer = "";
			for (int i = 0; i < message.Length; i++)
			{
				for (int j = 0; j < message[i].Length; j++)
				{
					answer += message[i][j] + " ";
				}
				answer += "\n";
			}

			return answer;
		}
	}
}
