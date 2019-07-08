using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
	class Program
	{
		static void Main(string[] args)
		{
			Beverage bev = new Espresso();
			Console.WriteLine(bev.GetDescription() +" $ "+ bev.Cost());

			Beverage bev2 = new HouseBlend();
			Console.WriteLine(bev2.GetDescription() + " $ " + bev2.Cost());

			bev2 = new Mocha(bev2);
			Console.WriteLine(bev2.GetDescription() + " $ " + bev2.Cost());
			Console.Read();
		}



		public abstract class Beverage
		{
			public string description = "Unknown beverage";

			public virtual string GetDescription()
			{
				return description;
			}
			public abstract double Cost();
		}


		public class Espresso : Beverage
		{
			public Espresso()
			{
				description = "Espresso";
			}

			public override double Cost()
			{
				return 1.99d;
			}
		}

		public class HouseBlend : Beverage
		{
			public HouseBlend()
			{
				description = "House Blend Coffee";
			}
			public override double Cost()
			{
				return .89;
			}
		}

		public class Mocha :Beverage
		{
			private Beverage Beverage { get; set; }
			public Mocha(Beverage beverage)
			{
				Beverage = beverage;
			}

			public override string GetDescription()
			{
				return Beverage.GetDescription() + " ,Mocha";
			}

			public override double Cost()
			{
				return 0.20 + Beverage.Cost();
			}
		}		
	}
}
