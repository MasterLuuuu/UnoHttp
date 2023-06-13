using System;
using System.Collections.Generic;
using System.Text;

namespace UnoHttp
{
	internal static class MasterLuTool
	{
		internal static void CreateGraphQLException(ErrorType errorType, Dictionary<String, Object> errorData)  //创建相应异常
		{
			switch (errorType)
			{
				case ErrorType.UNKNOWN:
					UnknownException unknownException = new UnknownException(errorData);
					throw unknownException;
				case ErrorType.UNAVAILABLE:
					UnavailableException unavailableException = new UnavailableException(errorData);
					throw unavailableException;
				case ErrorType.UNAUTHENTICATED:
					UnauthenticatedException unauthenticatedException = new UnauthenticatedException(errorData);
					throw unauthenticatedException;
				case ErrorType.PERMISSION_DENIED:
					PermissiondeniedException permissiondeniedException = new PermissiondeniedException(errorData);
					throw permissiondeniedException;
				case ErrorType.NOT_FOUND:
					NotfoundException notfoundException = new NotfoundException(errorData);
					throw notfoundException;
				case ErrorType.INTERNAL:
					InternalException internalException = new InternalException(errorData);
					throw internalException;
				case ErrorType.FAILED_PRECONDITION:
					FailedpreconditionException failedpreconditionException = new FailedpreconditionException(errorData);
					throw failedpreconditionException;
				case ErrorType.BAD_REQUEST:
					BadrequestException badrequestException = new BadrequestException(errorData);
					throw badrequestException;
			}
			throw null;
		}
	}
}
