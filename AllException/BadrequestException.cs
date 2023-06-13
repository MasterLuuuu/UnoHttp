using System;
using System.Collections.Generic;
using System.Text;

namespace UnoHttp
{
	internal class BadrequestException : Exceptioninterface
	{
		internal BadrequestException(Dictionary<String, Object> errorData) : base(errorData)
		{ 
		
		}
	}
}
