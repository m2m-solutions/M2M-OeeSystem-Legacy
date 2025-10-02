using System;

namespace M2M.DataCenter
{
    /// <summary>
    /// The exception is thrown when a protected operation is performed with a not logged on user
    /// </summary>
    public class UserIsNotLoggedOnException : ApplicationException { }
}