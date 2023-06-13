using System;
using System.Threading.Tasks;
using System.Net.Http;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using GraphQL.Client;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
namespace UnoHttp
{ 
	public class Program
	{
		public static async Task Main(string[] args)
		{
			
			HttpClient client = new HttpClient();
			GraphQLHttpClient qLHttpClient = new GraphQLHttpClient("https://baidu.com", new NewtonsoftJsonSerializer());
			var HeroRequest = new GraphQLRequest
			{
				Query = @"{
				hello
				name
				}
				"
			};
			var respose = await qLHttpClient.SendQueryAsync<HttpResponseMessage>(HeroRequest);
			var schema = Schema.For(@"
		type Query {
        hello: String
		name: String
      }
    ");
			var json = await schema.ExecuteAsync(_ =>
			{
				_.Query = "{ hello name}";
				_.Root = new { hello = "Hello World!",name ="luxiao"};
			});

			Console.WriteLine(json);
		}
	}
}