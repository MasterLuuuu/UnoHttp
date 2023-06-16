using System;
using System.Collections.Generic;
using System.Text;

namespace UnoHttp
{ 
	internal class PermissiondeniedException : Exceptioninterface
	{
		internal PermissiondeniedException(Dictionary<String, Object> errorData) : base(errorData)
		{ 
		}
	}
}
