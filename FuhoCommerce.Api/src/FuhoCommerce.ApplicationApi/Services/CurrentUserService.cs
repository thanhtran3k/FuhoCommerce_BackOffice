using FuhoCommerce.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FuhoCommerce.ApplicationApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        //User ClaimPrinciple is only available in the Controller context
        //This service is special

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            IsAuthenticated = UserId != null;
        }

        public string UserId { get; }

        public bool IsAuthenticated { get; }
    }
}
