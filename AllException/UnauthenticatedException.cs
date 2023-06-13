using System;
using System.Collections.Generic;
using System.Text;

namespace UnoHttp
{
	internal class UnauthenticatedException : Exceptioninterface
	{
		internal UnauthenticatedException(Dictionary<String, Object> errorData) : base(errorData)
		{ 
			
		}
	}
}
