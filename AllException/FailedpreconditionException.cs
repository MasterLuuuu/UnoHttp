using System;
using System.Collections.Generic;
using System.Text;

namespace UnoHttp
{
	internal class FailedpreconditionException : Exceptioninterface
	{
		internal FailedpreconditionException(Dictionary<String, Object> errorData) : base(errorData)
		{ 
		
		}
	}
}
