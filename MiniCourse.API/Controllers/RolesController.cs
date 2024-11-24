﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Roles;
using MiniCourse.Service.Roles.DTOs;
using MiniCourse.Service.Users.DTOs;

namespace MiniCourse.API.Controllers
{
    [Authorize]
    public class RolesController(IRoleService roleService) : CustomControllerBase
    {      
        [HttpGet("getroles")]        
        public async Task<IActionResult> GetRolesAsync()
        {
            var result = await roleService.GetRolesAsync();
            return CreateObjectResult(result);
        }

        [HttpGet("getrolesbyuserid")]
        public async Task<IActionResult> GetRolesByUserIdAsync(string userId)
        {
            var result = await roleService.GetRolesByUserIdAsync(userId);
            return CreateObjectResult(result);
        }

        [HttpGet("getrole")]
        public async Task<IActionResult> GetRoleAsync(string roleId)
        {
            var result = await roleService.GetRoleAsync(roleId);
            return CreateObjectResult(result);
        }

        [HttpPost("createrole")]
        public async Task<IActionResult> CreateRoleAsync(CreateRoleRequest request)
        {
            var result = await roleService.CreateRoleAsync(request);
            return CreateObjectResult(result);
        }

        [HttpPost("assignRoleToUser")]
        public async Task<IActionResult> AssignRoleToUserAsync(string userId, List<AssignRoleToUserRequest> requestList)
        {
            var result = await roleService.AssignRoleToUserAsync(userId,requestList);
            return CreateObjectResult(result);
        }

        [HttpPut("updaterole")]
        public async Task<IActionResult> UpdateRoleAsync(UpdateRoleRequest request)
        {
            var result = await roleService.UpdateRoleAsync(request);
            return CreateObjectResult(result);
        }

        [HttpDelete("deleterole")]
        public async Task<IActionResult> DeleteRoleAsync(string roleId)
        {
            var result = await roleService.DeleteRoleAsync(roleId);
            return CreateObjectResult(result);
        }

    }
}
