using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace UnoHttp
{
	internal class Clientquery
	{
		internal async Task<T> GetRequest<T>(string url, GraphQLRequest query,string token=null) //查询数据
		{
			T res = default(T);
			GraphQLHttpClient qLHttpClient = new GraphQLHttpClient(url, new NewtonsoftJsonSerializer()); 
			if (token != null)
			{
				qLHttpClient.HttpClient.DefaultRequestHeaders.Add("Authorization", token); //添加token请求头 
			}
			try
			{
				GraphQLResponse<NetworkIntermedia<T>> response = await qLHttpClient.SendQueryAsync<NetworkIntermedia<T>>(query); //发送graphql查询
				res = response.Data.data;
				if(response.Data.error != null)
				{
					MasterLuTool.CreateGraphQLException(response.Data.error.errorType, response.Data.error.errorData); // 抛出error异常
				}
																							  //var response = await qLHttpClient.SendQueryAsync<HttpResponseMessage>(query); //发送graphql查询
																							  //HttpResponseMessage responseMessage = response.Data;
																							  //HttpContent content = responseMessage.Content;
																							  //string r = await content.ReadAsStringAsync();
																							  //var intermedia = JsonConvert.DeserializeObject<NetworkIntermedia<T>>(r); //newton反序列化
																							  //res = intermedia.data;
																							  //if (intermedia.error != null)
																							  //{
																							  //	MasterLuTool.CreateGraphQLException(intermedia.error.errorType, intermedia.error.errorData); //生成error异常
																							  //}
			} catch (Exceptioninterface e)
			{
				return e == null ? res : throw e;
			}
			return res;
		}
	}
}
