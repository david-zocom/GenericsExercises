using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExercises
{
	// https://github.com/lejonmanen/GenericsExercises
	class Program
	{
		static void Main(string[] args)
		{
			ListFunctions lf = new ListFunctions();
			lf.Demo();
		}
		private void TrioDemo()
		{
			Trio<string> trio = new Trio<string>();
			trio.First = "första";
			trio.Second = "andra";
			Trio2<Vehicle, Car, Bike> trio2 = new Trio2<Vehicle, Car, Bike>();
		}
	}

	public class Trio<T>
	{
		public T First { get; set; }
		public T Second { get; set; }
		public T Third { get; set; }
	}

	// 5 Ändra klassen Trio så att det kan vara tre olika generiska klasser, som är subklasser till olika fordonsklasser.
	public class Vehicle { }
	public class Car : Vehicle { }
	public class Bike : Vehicle { }

	public class Trio2<T1, T2, T3> where T1 : Vehicle where T2 : Vehicle where T3 : Vehicle
	{
		public T1 First { get; set; }
		public T2 Second { get; set; }
		public T3 Third { get; set; }
	}

	/*5 Skapa en funktion som tar en List<T> och en Func<T, T, T> delegate som parametrar och returnerar ett värde av typen T. Du bestämmer själv vilken datatyp du vill använda i stället för T. Funktionen ska heta Reduce och den ska reducera listan till ett värde. Om listan till exempel består av strängar så är ett sätt att reducera den att konkatenera alla strängar i listan och returnera resultatet. Om listan består av tal så kan man reducera listan genom att räkna ut till exempel summan, max- eller min-värdet. Delegaten ska alltså vara funktionen som utför själva reduceringen.*/
	public class ListFunctions
	{
		public void Demo()
		{
			List<int> list = new List<int>();
			list.Add(5);
			list.Add(10);
			list.Add(1000);
			int sum = Reduce(list, Sum);
			sum = Reduce(list, (x, y) => x + y);
		}

		Func<string, string, string> f = (x, y) => x + y;
		private static string Concat(string x, string y)
		{
			return x + y;
		}

		private static int Sum(int x, int y)
		{
			return x + y;
		}
		private static int Max(int x, int y)
		{
			if (x > y) return x;
			else return y;
		}
		private Func<string, string, string> ConcatDelegate = Concat;
		//Func<T, T, T> Min

		// Reduce == aggregate
		public static T Reduce<T>(List<T> list, Func<T, T, T> reducer)
		{
			T soFar = list[0];
			for (int i = 1; i < list.Count; i++)
			{
				soFar = reducer(soFar, list[i]);
			}
			return soFar;
		}
	}
}
