using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Collections.Generic;

namespace UnoHttp
{
	internal struct NetworkIntermedia<T>
	{
		public T data;
		public UnoGraphQLException error;
	}
	public	class Clientinternet
	{
		private Clientquery clientquery;
		private Clientmutation clientmutation;
		private ClientSubscribe clientsubscribe;
		public Clientinternet()
		{
			clientquery = new Clientquery(); 
			clientmutation = new Clientmutation();
			clientsubscribe = new ClientSubscribe();
		}
		public async Task<T> GetRequest<T>(string url, GraphQLRequest query,string token=null)  //查询数据
		{
			T res = await clientquery.GetRequest<T>(url, query,token);
			return res;
		}
		public async Task CreateMutation(string url, GraphQLRequest mutation, string token = null) //创建数据
		{
			 await clientmutation.CreateMutation(url, mutation,token);
		}
		public async Task UpdateMutation(string url, GraphQLRequest mutation, string token = null) //更新数据
		{
			await clientmutation.UpdateMutation(url, mutation,token);
		}
		public async Task DeleteMutation(string url, GraphQLRequest mutation, string token = null) //删除数据
		{
			await clientmutation .DeleteMutation(url, mutation,token);
		}
		public async Task ConnectServer(string uri,string token) //开启socket连接服务器
		{
			await clientsubscribe.Connectserver(uri,token);
		}
		public async Task CloseConnectServer()//与服务器断开socket连接
		{
			await clientsubscribe.Closeconnect();
		}
		public IEnumerable<T> GetSockerMsgMerable<T>() //返回反序列化队列的消息的迭代器
		{
			return ClientSubscribe.MsgMerable<T>.GetmsgmerableFunc();
		}
		public async Task SendSubscribe(string subscribegraphql)//发送订阅
		{
			await clientsubscribe.SocketSubscribe(subscribegraphql);
		}
 	}
}
