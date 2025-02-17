using System;

namespace WebManagement.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class SignInErrorMsg
    {
        public string MessageError { get; set; }
    }
}