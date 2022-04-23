using CSVProcessor.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVProcessor
{
	public class CSVProcessor
	{
		private CSVNode MainTree { get; set; }

		private IExporter _exporter { get; set; }

		public CSVProcessor(IExporter exporter)
		{
			_exporter = exporter;
		}

		public void LoadCSVFile(string path)
		{
			using (var reader = new StreamReader(path))
			{
				var header = reader.ReadLine();
				var headerFields = header.Split(',');
				var data = reader.ReadLine();
				var dataValues = data.Split(',');

				MainTree = new CSVNode();
				MainTree.Subnodes = new Dictionary<string, CSVNode>();

				for (int i = 0; i < headerFields.Length; i++)
				{
					MainTree.AddValue(headerFields[i], dataValues[i]);
				}				
			}
		}

		public string Export()
		{
			StringBuilder sb = new StringBuilder();
						
			_exporter.ExportValues(MainTree, sb);

			return sb.ToString();
		}
	}
}
