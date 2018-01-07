using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TransactionAPI.Helpers
{
	/// <summary>
	/// A collection of static methods to aid with parsing data
	/// </summary>
	public class ParseHelper
	{

		/// <summary>
		/// Since we're not working with standard JSON here, we've defined a means to parse a generic response into something more malleable
		/// </summary>
		/// <throws>ArgumentException on poorly formatted response</throws>
		/// <returns>A dictionary of keys and values representing the supplied data</returns>
		public static Dictionary<string, string> BuildDictionaryFromTabbedAPIResponse(string rawData) {
			var result = new Dictionary<string, string>();

			var exceptionMessage = $"API Response is poorly formatted and could not be parsed by {nameof(BuildDictionaryFromTabbedAPIResponse)} ";

			List<string> headersList;
			var strReader = new StringReader(rawData);
			string currentLine;

			var headersLine = strReader.ReadLine();
			if(headersLine != null) {
				headersList = headersLine.Split('\t').ToList();
			}
			else {
				throw new ArgumentException(exceptionMessage);
			}
			
			while (true)
			{
				currentLine = strReader.ReadLine();
				if (currentLine != null)
				{
					var currentItemValues = currentLine.Split('\t').ToList();

					if(currentItemValues.Count() != currentLine.Count()) {
						throw new ArgumentException($"{exceptionMessage} the details for one of the items does not match the headers.");
					}

					for(var i=0; i< headersList.Count(); i++) {
						result.Add(headersList[i], currentItemValues[i]);
					}
				}
				else
				{
					break;
				}
			}

			return result;
		}
		

	}
}