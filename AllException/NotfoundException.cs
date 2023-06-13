using System;
using System.Collections.Generic;
using System.Text;

namespace UnoHttp
{
	internal class NotfoundException : Exceptioninterface
	{
		internal NotfoundException(Dictionary<String, Object> errorData) : base(errorData)
		{ 
			
		}
	}
}
