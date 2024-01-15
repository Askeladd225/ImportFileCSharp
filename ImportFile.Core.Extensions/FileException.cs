using System.Net;

namespace ImportFile.Core.Extensions
{
    public static class FileException 
    {         
      public static string ThrowException(string error, string message)
       {
            return $"{error} : {message}";
       }
    }
}
