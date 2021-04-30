using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;
using RestSharp;
using Techverx.Test.Project.Dtos.PaySoft;

namespace Techverx.Test.Project.ProxyService
{
	public class ProxyService : IProxyService
	{
		private readonly IConfiguration _config;
		public  ProxyService(IConfiguration config)
		{
			_config = config ?? throw new ArgumentNullException(nameof(config));
		}
		public async Task<Response> Send(string data)
		{
			var client = new RestClient(_config["PaySoft:URL"]);
			var request = new RestRequest(Method.POST);
			request.AddHeader("Content-Type", _config["PaySoft:ContentType"]);
			request.AddParameter("request", request);
			request.AddParameter("Key", "key");
			var response = await client.ExecuteAsync(request);
			var serializer = new XmlSerializer(typeof(Response));
			using TextReader reader = new StringReader(response.Content);
			return (Response)serializer.Deserialize(reader);
        }
	}
}
