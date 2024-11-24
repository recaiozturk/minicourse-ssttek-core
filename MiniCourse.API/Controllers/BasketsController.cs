﻿using Microsoft.AspNetCore.Mvc;
using MiniCourse.Service.Baskets;
using MiniCourse.Service.Baskets.DTOs;

namespace MiniCourse.API.Controllers
{
    public class BasketsController(IBasketService basketService, ILogger<BasketsController> logger) : CustomControllerBase
    {
        [HttpPost("add-to-basket")]
        public async Task<IActionResult> AddToBasketAsync(AddBasketRequest request)
        {
            //test
            //int x = 0;
            //int y = 1;

            //var result2 = 0;

            //try
            //{
            //    result2 = y / x;
            //}
            //catch (Exception ex)
            //{

            //    logger.LogError(ex, ex.Message);
            //}

            var result = await basketService.AddToBasketAsync(request);
            return CreateObjectResult(result);
        }

        [HttpGet("get-basket")]
        public async Task<IActionResult> GetBasketByUserIdAsync(string userId)
        {
            var result = await basketService.GetBasketByUserIdAsync(userId);
            return CreateObjectResult(result);
        }

        [HttpGet("get-basket-detail")]
        public async Task<IActionResult> GetBasketDetailAsync(string userId)
        {
            var result = await basketService.GetBasketDetailAsync(userId);
            return CreateObjectResult(result);
        }

        [HttpDelete("remove-from-basket")]
        public async Task<IActionResult> RemoveItemFromBasketAsync(string userId,int courseId)
        {
            var result = await basketService.RemoveItemFromBasketAsync(userId,courseId);
            return CreateObjectResult(result);
        }


    }
}
