using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API2.Application.Common.Models;

namespace API2.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<string> GetUserNameAsync(string userId);
    }
}
