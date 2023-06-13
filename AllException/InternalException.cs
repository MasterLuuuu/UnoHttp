using System;
using System.Collections.Generic;
using System.Text;

namespace UnoHttp
{
	internal class InternalException : Exceptioninterface
	{
		internal InternalException(Dictionary<String, Object> errorData) : base(errorData)
		{ 
		}
	}
}
