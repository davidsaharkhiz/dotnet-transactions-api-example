using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

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
		/// <returns>A dictionary of keys and values representing the supplied data</returns>
		public static Dictionary<string, string> BuildDictionaryFromTabbedAPIResponse(string rawData) {
			var result = new Dictionary<string, string>();

			var strReader = new StringReader(rawData);
			string aLine;
			string aParagraph = string.Empty;



			while (true)
			{
				aLine = strReader.ReadLine();
				if (aLine != null)
				{
					aParagraph = aParagraph + aLine + " ";
				}
				else
				{
					aParagraph = aParagraph + "\n";
					break;
				}
			}



			return result;
		}
		

	}
}