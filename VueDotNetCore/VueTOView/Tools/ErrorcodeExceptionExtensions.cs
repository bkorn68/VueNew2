namespace VueTOView.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ErrorcodeExceptionExtensions
    {
        public static ErrorCodeException ToErrorCodeException(this Enum code)
        {
            return new ErrorCodeException(code.ToInt(), code.AsText(), null);
        }
    }
}
