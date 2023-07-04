﻿using Microsoft.AspNetCore.Http;
using PizzaHutAPI.Application.Common.Interfaces;
using System.Security.Claims;

namespace PizzaHutAPI.Api.Services
{
    /// <summary>
    /// UserId
    /// </summary>
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Current userId
        /// </summary>
        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
