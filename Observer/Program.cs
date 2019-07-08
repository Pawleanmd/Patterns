using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
	class Program
	{
		static void Main(string[] args)
		{
			ConcreteSubject subject = new ConcreteSubject();
			List<ConcreteObserver> o = new List<ConcreteObserver>();
			for (int i = 0; i < 10; i++)
			{
				o.Add(new ConcreteObserver(subject));
			}

			while (true)
			{
				Console.WriteLine("Введите значение для объекта");
				var str = Console.ReadLine();
				subject.UpdateData(str);
			}		
		}
	}




	public interface IObserver
	{
		void Update(string s);
	}

	public class ConcreteObserver : IObserver
	{
		private ISubject subject { get; set; }		
		public string Name { get; set; }
		public ConcreteObserver(ISubject s)
		{
			subject = s;
			subject.RegisterObserver(this);
		}
		public void Update(string s)
		{
			Console.WriteLine($"Object with name {Name} got new value {s}");			
		}
	}

	public interface ISubject
	{
		void RegisterObserver(IObserver o);
		void RemoveObserver(IObserver o);
		void NotifyObservers(string s);
	}

	public class ConcreteSubject : ISubject
	{
		public string UnConstantData { get; set; }

		public void UpdateData(string s)
		{
			UnConstantData = s;
			NotifyObservers(UnConstantData);
		}
		public ConcreteSubject()
		{
			observers = new List<IObserver>();
		}
		private List<IObserver> observers { get; set; }

		public void NotifyObservers( string s)
		{
			foreach (var o in observers)
			{
				o.Update(s);
			}
		}

		public void RegisterObserver(IObserver o)
		{
			observers.Add(o);
		}

		public void RemoveObserver(IObserver o)
		{
			observers.Remove(o);
		}
	}

	public interface IDisplayElement
	{
		void Display();
	}
}
