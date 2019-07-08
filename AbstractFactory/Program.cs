using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
	class Program
	{
		static void Main(string[] args)
		{
			Hero elf = new Hero(new ElfFactory());
			elf.Hit();
			elf.Run();

			Hero voin = new Hero(new KnightFactory());
			voin.Hit();
			voin.Run();

			Hero orc = new Hero(new OrcFactory());
			orc.Hit();
			orc.Run();
			Console.ReadLine();
		}
	}

	public abstract class Weapon
	{
		public abstract void Hit();
	}

	public abstract class Movement
	{
		public abstract void Move();
	}

	public class Arbalet : Weapon
	{
		public override void Hit()
		{
			Console.WriteLine("Стреляем из арбалета");
		}
	}

	public class Sword : Weapon
	{
		public override void Hit()
		{
			Console.WriteLine("Бьём мечом");
		}
	}

	public class Axe : Weapon
	{
		public override void Hit()
		{
			Console.WriteLine("Бьём топором");
		}
	}

	public class Fly : Movement
	{
		public override void Move()
		{
			Console.WriteLine("Летим");
		}
	}

	public class Run : Movement
	{
		public override void Move()
		{
			Console.WriteLine("Бежим");
		}
	}

	public abstract class HeroFactory
	{
		public abstract Movement CreateMovement();
		public abstract Weapon CreateWeapon();
	}

	public class ElfFactory : HeroFactory
	{
		public override Movement CreateMovement()
		{
			return  new Fly();
		}

		public override Weapon CreateWeapon()
		{
			return  new Arbalet();
		}
	}

	public class KnightFactory : HeroFactory
	{
		public override Movement CreateMovement()
		{
			return  new Run();
		}

		public override Weapon CreateWeapon()
		{
			return  new Sword();
		}
	}

	public class OrcFactory : HeroFactory
	{
		public override Movement CreateMovement()
		{
			return new Run();
		}

		public override Weapon CreateWeapon()
		{
			return new Axe();
		}
	}

	public class Hero
	{
		private Weapon weapon;
		private Movement movement;

		public Hero(HeroFactory factory)
		{
			weapon = factory.CreateWeapon();
			movement = factory.CreateMovement();
		}

		public void Run()
		{
			movement.Move();
		}

		public void Hit()
		{
			weapon.Hit();
		}
	}
}
