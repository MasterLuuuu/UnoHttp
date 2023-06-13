using System;
using System.Collections.Generic;
using System.Text;

namespace UnoHttp
{
	internal class UnknownException : Exceptioninterface
	{
		internal UnknownException(Dictionary<String, Object> errorData) :base( errorData)
		{
		}
	}
}
