using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using GraphQL.Client;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
namespace UnoHttp
{
	internal class Clientmutation
	{
		internal  async Task CreateMutation(string url, GraphQLRequest query, string token = null) //创建数据
		{
			GraphQLHttpClient qLHttpClient = new GraphQLHttpClient(url, new NewtonsoftJsonSerializer());
			if (token != null)
			{
				qLHttpClient.HttpClient.DefaultRequestHeaders.Add("Authorization", token); //添加token请求头 
			}
			try
			{
				var response = await qLHttpClient.SendMutationAsync<NetworkIntermedia<int>> (query); //发送创建数据请求
				if (response.Data.error != null)
				{
					MasterLuTool.CreateGraphQLException(response.Data.error.errorType, response.Data.error.errorData); // 抛出error异常
				}
			} catch (Exceptioninterface e)
			{
				if (e != null)
				{
					throw e;
				}
			}
		}
		internal async Task UpdateMutation(string url, GraphQLRequest query, string token = null)//更新数据
		{
			GraphQLHttpClient qLHttpClient = new GraphQLHttpClient(url, new NewtonsoftJsonSerializer()); 
			if (token != null)
			{
				qLHttpClient.HttpClient.DefaultRequestHeaders.Add("Authorization", token); //添加token请求头 
			}
			try
			{
				var response = await qLHttpClient.SendMutationAsync<NetworkIntermedia<int>>(query); //发送更新数据请求
				if (response.Data.error != null)
				{
					MasterLuTool.CreateGraphQLException(response.Data.error.errorType, response.Data.error.errorData); // 抛出error异常
				}
			} catch (Exceptioninterface e)
			{
				if (e != null)
				{
					throw e;
				}
			}
		}
		internal async Task DeleteMutation(string url, GraphQLRequest query, string token = null)//删除数据 
		{
			GraphQLHttpClient qLHttpClient = new GraphQLHttpClient(url, new NewtonsoftJsonSerializer()); 
			if (token != null)
			{
				qLHttpClient.HttpClient.DefaultRequestHeaders.Add("Authorization", token); //添加token请求头 
			}
			try
			{
				var response = await qLHttpClient.SendMutationAsync<NetworkIntermedia<int>>(query); //发送删除数据请求
				if (response.Data.error != null)
				{
					MasterLuTool.CreateGraphQLException(response.Data.error.errorType, response.Data.error.errorData); // 抛出error异常
				}
			} catch (Exceptioninterface e)
			{
				if (e != null)
				{
					throw e;
				}
			}
		}
	}
}
