using System.IO;
using System.Xml.Serialization;

namespace Techverx.Test.Project.CoreApp.RequestGenerator
{
    public class XmlRequestGenerator
    {
        public static string Serialize<T>(T dataToSerialize)
        {
            var stringWriter = new StringWriter();
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stringWriter, dataToSerialize);
            return "<APIPaymentsRequest>\r\n " + stringWriter.ToString().Substring(164);
        }
    }
}
