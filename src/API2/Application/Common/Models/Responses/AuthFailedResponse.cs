using System.Collections.Generic;

namespace API2.Application.Common.Models.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
