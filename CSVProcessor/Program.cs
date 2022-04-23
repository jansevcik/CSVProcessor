using System;

namespace CSVProcessor
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				IExporter exporter = new JsonExporter();
				CSVProcessor csvProcessor = new CSVProcessor(exporter);

				csvProcessor.LoadCSVFile(@"C:\GitHub\CSVProcessor\Data\CSVProcessorData.csv");

				var exportedData = csvProcessor.Export();

				Console.WriteLine(exportedData);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.ReadLine();
			}
		}
	}
}
