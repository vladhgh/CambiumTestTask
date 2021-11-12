using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasmartTest.Shared
{
	public class Dot
	{
		public int Id { get; set; }
		public double PositionX { get; set; }
		public double PositionY { get; set; }
		public double Radius { get; set; }
		public string Color { get; set; }
		public List<Comment> Comments { get; set; }
	}
}
