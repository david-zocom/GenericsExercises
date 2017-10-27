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
}
