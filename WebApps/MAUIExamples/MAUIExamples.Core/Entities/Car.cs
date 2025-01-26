using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIExamples.Core.Entities
{
	public class Car
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime ReleaseDate { get; set; }
		public Producer? Producer { get; set; }
		public int ProducerId { get; set; }
	}
}
