using CSVProcessor.Models;
using System.Text;

namespace CSVProcessor
{
	public interface IExporter
	{
		void ExportValues(CSVNode node, StringBuilder sb);
	}
}
