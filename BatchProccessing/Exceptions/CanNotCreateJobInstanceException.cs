using System.ComponentModel.DataAnnotations;

namespace BatchProccessing.Exceptions;

public class CanNotCreateJobInstanceException : ValidationException
{
    
    public CanNotCreateJobInstanceException(string message) 
        : base(message)
    {
    }
}
