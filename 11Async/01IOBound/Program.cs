using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace _01IOBound {
	class AsyncIODemo {
		public string result = "";
		public Task<string> GetHtmlAsync() {
			// Execution is synchronous here
			var client = new HttpClient();

			return client.GetStringAsync("http://www.dotnetfoundation.org");
		}
		public async Task<string> GetFirstCharactersCountAsync(int count) {
			// Execution is synchronous here
			var client = new HttpClient();

			// Execution of GetFirstCharactersCountAsync() is yielded to the caller here
			// GetStringAsync returns a Task<string>, which is *awaited*
			var page = await client.GetStringAsync("http://www.dotnetfoundation.org");

			// Execution resumes when the client.GetStringAsync task completes,
			// becoming synchronous again.

			if (count > page.Length)
			{
				return page;
			}
			else
			{
				return page.Substring(0, count);
			}
		}
		public async Task getPage() {
			await Task.Run(() => result = GetFirstCharactersCountAsync(50000).Result);
		}
	}
	class Program {
		static void Main(string[] args) {
			AsyncIODemo ad = new AsyncIODemo();

			ad.getPage();
			int count = 0;
			while (ad.result.Length == 0)
			{
				//Console.Write(".");
				//Thread.Sleep(1);
				count++;
			}

			//Console.WriteLine(ad.result);
			Console.WriteLine(count);
		}
	}
}
