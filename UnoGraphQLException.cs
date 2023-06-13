using System;
using System.Collections.Generic;
using System.Text;

namespace UnoHttp
{
	internal enum ErrorType
	{
		UNKNOWN,
		INTERNAL,
		NOT_FOUND,
		UNAUTHENTICATED,
		PERMISSION_DENIED,
		BAD_REQUEST,
		UNAVAILABLE,
		FAILED_PRECONDITION
	}
	internal class UnoGraphQLException
	{
		private string message { get; set; } //客户端打印给用户的提示信息，可以为空
		internal ErrorType errorType { get; set; } //约定的异常类型
		private String errorMessage { get; set; } //用于C#构造异常对象message所需必要条目
		internal Dictionary<String, Object> errorData { get; set; } //错误具体信息，用于客户端重新异常对象 
	}
	internal abstract class Exceptioninterface :  Exception
	{
		private String errorMessage { get; set; } //用于C#构造异常对象message所需必要条目
		private Dictionary<String, Object> errorData { get; set; }//错误具体信息，用于客户端重新异常对象		
		public Exceptioninterface()
		{ 

		}
		public Exceptioninterface(Dictionary<String, Object> errorData)
		{
			this.errorData = errorData;
			String key = "errorMessage";
			Object box = new Object();
			errorData.TryGetValue(key,out box);
			this.errorMessage = (String)box;
		}
	}
}
