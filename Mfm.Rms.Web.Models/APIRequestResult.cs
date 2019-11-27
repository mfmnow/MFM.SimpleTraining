using System;

namespace Mfm.Rms.Web.Models
{
    public class APIRequestResult<TData>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }

        public bool ServerError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
