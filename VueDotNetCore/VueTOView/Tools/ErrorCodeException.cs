namespace VueTOView.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class ErrorCodeException : Exception
    {
        private const string DefaultMessage = "Undefined";

        public ErrorCodeException()
        {
        }

        [SuppressMessage("StyleCop.Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "Reviewed.")]
        public ErrorCodeException(Exception exc)
            : base(DefaultMessage, exc)
        {
            this.Code = -1;
            if (exc == null)
            {
                this.Message = string.Empty;
            }
            else
            {
                this.Message = exc.Message;
            }
        }

        public ErrorCodeException(string message)
        {
            this.Code = -1;
            this.Message = message;
        }

        public ErrorCodeException(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public ErrorCodeException(int code, string message, Exception exc)
            : base(message, exc)
        {
            this.Code = code;
            this.Message = message;
        }

        public ErrorCodeException(string message, Exception innerexception)
            : base(message, innerexception)
        {
            this.Code = -1;
            this.Message = message;
        }

        public int Code { get; private set; }

        public override string Message { get; }

        public override string ToString()
        {
            return $"[{this.Code}] {this.Message}{Environment.NewLine}{base.ToString()}";
        }
    }
}