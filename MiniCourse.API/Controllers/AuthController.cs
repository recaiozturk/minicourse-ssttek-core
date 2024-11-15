﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Auths;
using MiniCourse.Service.Auths.DTOs;

namespace MiniCourse.API.Controllers
{
    public class AuthController(IAuthService authService) : CustomControllerBase
    {

        [HttpPost("signin")]
        public async Task<IActionResult> SignInAsync(SignInRequest request)
        {
            var result = await authService.SignInAsync(request);

            return CreateObjectResult(result);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync(SignUpRequest request)
        {
            var result = await authService.SignUpAsync(request);

            return CreateObjectResult(result);
        }

    }
}