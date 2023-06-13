using System;
using System.Collections.Generic;
using System.Text;

namespace UnoHttp
{
	internal class UnavailableException : Exceptioninterface
	{
		internal UnavailableException(Dictionary<String, Object> errorData) :base(errorData)
		{

		}
	}
}
