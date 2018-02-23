using System.IO;
using System.Linq;
using CsvHelper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Project2 {
	public class Program {
		public static Cell[] Records;

		public static void Main(string[] args) {
			using(TextReader text = File.OpenText("Super_Bowl_Project.csv")) {
				CsvReader csv = new CsvReader(text);
				csv.Configuration.RegisterClassMap<ThingMap>();
				Records = csv.GetRecords<Cell>().ToArray();
			}

			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) {
			return WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.Build();
		}
	}
}