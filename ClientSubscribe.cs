using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;
using System.Threading;
using Newtonsoft.Json;
using System.Collections;
using GraphQL;

namespace UnoHttp
{
	class ClientSubscribe
	{
		private WebSocket socket;
		private Boolean offline = true; //条件变量:是否没联机
		static private Queue<NetworkIntermedia<Object>> intermediaqueue = new Queue<NetworkIntermedia<Object>>(); //存储反序列化装箱的队列
		static internal class MsgMerable<T>
		{
			static  internal IEnumerable<T> GetmsgmerableFunc()
			{
				T res = default(T);
				var intermedia = intermediaqueue.Dequeue(); //出队列
				res = (T) intermedia.data; //拆箱
				try
				{
					if (intermedia.error != null)
					{
						MasterLuTool.CreateGraphQLException(intermedia.error.errorType, intermedia.error.errorData); // 抛出error异常
					}
				} catch (Exceptioninterface e)
				{
					if (e != null)
					{
						throw e;
					}
				}
				yield return res;
			}
		}
		private void  MsgRecevied(object sender, MessageReceivedEventArgs e)        //处理接收到的消息
		{
			NetworkIntermedia<Object> intermedia = JsonConvert.DeserializeObject<NetworkIntermedia<Object>>(e.Message);//反序列化装箱
			intermediaqueue.Enqueue(intermedia); //进队列
		}
		internal async Task Connectserver(string uri,string token= null) //连接服务器
		{
			if (socket == null)
			{
				if (token != null)
				{
					socket = new WebSocket(uri,token);
				}
			}
			socket.MessageReceived += MsgRecevied; 
			await socket.OpenAsync();//开启
			StartHeatbeat();//开启心跳包
			offline = false;
		}
		private void StartHeatbeat()
		{
			if (socket.State == WebSocketState.Open)
			{
				Thread th = new Thread(new ThreadStart(Heatbeat)); //创建心跳包线程
				th.Start();
			}
		}
		private void Heatbeat() //心跳包
		{
			while (!offline)
			{
				if (socket.State == WebSocketState.Open)
				{
					socket.Send("THH");
					System.Threading.Thread.Sleep(5000); //每5秒发送一条消息
				}
			}
		}
		internal async Task SocketSubscribe(string subscribe) //订阅
		{
			if (socket.State == WebSocketState.Open)
			{
				socket.Send(subscribe);
			}
		}
		internal async Task Closeconnect() //关闭连接
		{
			if (socket.State == WebSocketState.Open)
			{
				await socket.CloseAsync();//关闭socket
				offline = true; 
			}
		}
		
	}
}
