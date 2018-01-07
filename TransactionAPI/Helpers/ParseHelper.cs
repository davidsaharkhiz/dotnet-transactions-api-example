using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TransactionAPI.Helpers
{
	/// <summary>
	/// A collection of static methods to aid with parsing data
	/// </summary>
	public class ParseHelper
	{

		/// <summary>
		/// Since we're not working with standard JSON here, we've defined a means to parse a generic response into something more malleable. 
		/// We assume the first line is a keys headers line.
		/// Headers are trimmed.
		/// </summary>
		/// <throws>ArgumentException on poorly formatted response</throws>
		/// <returns>A dictionary of keys and values representing the supplied data</returns>
		public static Dictionary<string, List<string>> BuildDictionaryFromTabbedAPIResponse(string rawData) {

			var resultDictionary = new Dictionary<string, List<string>>();
			var exceptionMessage = $"API Response is poorly formatted and could not be parsed by {nameof(BuildDictionaryFromTabbedAPIResponse)} ";
			List<string> headersList;
			var stringReader = new StringReader(rawData);

			// We assume the first line is a keys headers line
			var headersLine = stringReader.ReadLine();
			if(headersLine != null) {
				headersList = headersLine.Split('\t').ToList();
				foreach(var header in headersList)
				{
					resultDictionary.Add(header.Trim(), new List<string>());
				}
			}
			else {
				throw new ArgumentException(exceptionMessage);
			}
			
			// March over the entries and insert into the dictionary
			while (true)
			{
				var currentLine = stringReader.ReadLine();
				if (currentLine != null)
				{
					var currentItemValues = currentLine.Split('\t').ToList();

					if(currentItemValues.Count() != currentItemValues.Count()) {
						throw new ArgumentException($"{exceptionMessage} the column count for the details for one of the items does not match the headers.");
					}
					for (var i = 0; i < headersList.Count(); i++)
					{
						resultDictionary.ElementAt(i).Value.Add(currentItemValues[i]);
					}
				}
				else
				{
					break;
				}
			}

			return resultDictionary;
		}

		/// <summary>
		/// Some of our API partners like to use () notation to denote a negative value
		/// </summary>
		/// <param name="amount">raw string data from an API</param>
		/// <returns></returns>
		public static decimal CoerceSignedStringToDecimal(string amount) {
			amount = Regex.Replace(amount, "[^a-zA-Z0-9_.()]+", "", RegexOptions.Compiled);
			return Decimal.Parse(amount, 
									  NumberStyles.AllowParentheses |
									  NumberStyles.AllowThousands |
									  NumberStyles.AllowDecimalPoint |
									  NumberStyles.AllowCurrencySymbol);
		}
		

	}
}