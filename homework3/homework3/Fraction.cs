using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
	class Fraction
	{
		int num;
		int den;
		public Fraction()
		{
			num = 1;
			den = 1;
		}
		public Fraction(int num, int den)
		{
			this.num = num;

			if (den == 0) throw new ArgumentException("Нельзя присвоить знаменателю 0");
			else
				this.den = den;

			this.ToReduce();

		}

		public void ToReduce()
		{
			int nod = Nod(num, den);
			if (nod != 0)
			{
				num /= nod;
				den /= nod;
			}
			if ( num < 0 && den < 0)
			{
				num = Math.Abs(num);
				den = Math.Abs(den);
			}
		}

		static int Nod(int n, int d)
		{
			int temp;
			n = Math.Abs(n);
			d = Math.Abs(d);
			while (d != 0 && n != 0)
			{
				if (n % d > 0)
				{
					temp = n;
					n = d;
					d = temp % d;
				}
				else break;
			}
			if (d != 0 && n != 0) return d;
			else return 0;
		}

		public Fraction Plus(Fraction x2)
		{
			Fraction x3 = new Fraction();

			if (x2.den == den)
			{
				x3.num = x2.num + num;
				x3.den = den;
				x3.ToReduce();
			} else
			{
				x3.num = x2.num * den + num * x2.den;
				x3.den = x2.den * den;
				x3.ToReduce();
			}

			return x3;
		}

		public Fraction Minus(Fraction x2)
		{
			Fraction x3 = new Fraction();

			if (x2.den == den)
			{
				x3.num = num - x2.den;
				x3.den = den;
				x3.ToReduce();
			}
			else
			{
				x3.num = num * x2.den - x2.num * den;
				x3.den = x2.den * den;
				x3.ToReduce();
			}

			return x3;

		}

		public Fraction Multiply(Fraction x2)
		{
			Fraction x3 = new Fraction();

			x3.num = num *  x2.num;
			x3.den = x2.den * den;
			x3.ToReduce();

			return x3;
		}

		public Fraction Division(Fraction x2)
		{
			Fraction x3 = new Fraction();

			x3.num = num * x2.den;
			x3.den = x2.num * den;
			x3.ToReduce();

			return x3;
		}

		public int Num
		{
			get { return num; }
			set
			{
				num = value;
				this.ToReduce();
			}
		}

		public int Den
		{
			get { return den; }
			set
			{
				if (value == 0) throw new ArgumentException("Нельзя присвоить знаменателю 0");
				else
				{
					this.den = value;
					this.ToReduce();
				}
					
			}
		}

		override public string ToString()
		{
			return num + " / " + den;
		}

		internal static void WriteLine(string v)
		{
			Console.WriteLine(v);
		}
	}
}
