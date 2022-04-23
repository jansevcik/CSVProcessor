using System.Collections.Generic;

namespace CSVProcessor.Models
{
	public class CSVNode
	{
		public string Name { get; set; }

		public string Value { get; set; }

		public Dictionary<string, CSVNode> Subnodes { get; set; }
				
		public void AddValue(string path, string value)
		{
			if (Subnodes == null)
			{
				Subnodes = new Dictionary<string, CSVNode>();
			};

			if (path.Contains("_"))
			{
				var indexUnderscore = path.IndexOf("_");

				string leadingPath = path.Substring(0, indexUnderscore);
				
				if(Subnodes.ContainsKey(leadingPath) == false)
				{
					Subnodes[leadingPath] = new CSVNode() { Name = leadingPath, Value = null};
				}

				var remainingPath = path.Substring(indexUnderscore + 1);

				Subnodes[leadingPath].AddValue(remainingPath, value);
			}
			else
			{
				Subnodes[path] = new CSVNode() { Name = path, Value = value};
			}
		}
	}
}
