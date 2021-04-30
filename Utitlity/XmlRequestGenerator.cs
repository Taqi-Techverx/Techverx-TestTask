using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Techverx.Test.Project.Utitlity
{
	public class XmlRequestGenerator
	{
		public static string Serialize<T>(T dataToSerialize)
		{
			try
			{
				var stringWriter = new StringWriter();
				var serializer = new XmlSerializer(typeof(T));
				serializer.Serialize(stringWriter, dataToSerialize);
				return "<APIPaymentsRequest>\r\n " + stringWriter.ToString().Substring(164);
			}
			catch
			{
				throw;
			}
		}
	}
}
