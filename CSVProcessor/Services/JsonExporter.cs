using CSVProcessor.Models;
using System.Text;

namespace CSVProcessor
{
	public class JsonExporter : IExporter
	{
		public void ExportValues(CSVNode node, StringBuilder sb)
		{
			if (node.Name == null)
			{
				sb.Append("{");
			}

			if (node.Subnodes == null)
			{
				sb.AppendLine();
				sb.Append(string.Format("\"{0}\": \"{1}\",", node.Name, node.Value)); //TODO: for the last item we should not end line by ","
			}
			else
			{
				if (node.Name != null)
				{
					sb.AppendLine();
					sb.Append(string.Format("\"{0}\":", node.Name));
					sb.AppendLine();
					sb.Append("{");
				}
				foreach (var subnode in node.Subnodes)
				{
					ExportValues(subnode.Value, sb);
				}
				sb.AppendLine();
				sb.Append("}");
			}
		}
	}
}
