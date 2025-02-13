﻿using Microsoft.AspNetCore.Mvc;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Models;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync orderServiceAsync;

        public OrderController(IOrderServiceAsync orderServiceAsync)
        {
            this.orderServiceAsync = orderServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await orderServiceAsync.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(OrderRequestModel orderRequestModel)
        {
            var response = await orderServiceAsync.InsertAsync(orderRequestModel);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> CheckOrderHistory(int orderId)
        {
            var orderDetails = await orderServiceAsync.CheckOrderHistoryAsync(orderId);
            return Ok(orderDetails);
        }

        [HttpGet]
        public async Task<IActionResult> CheckOrderStatus(int orderId)
        {
            var orderDetails = await orderServiceAsync.CheckOrderStatusAsync(orderId);
            return Ok(orderDetails);
        }

        [HttpPut]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            try
            {
                var response = await orderServiceAsync.CancelOrderAsync(orderId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> OrderCompleted(int orderId)
        {
            var response = await orderServiceAsync.CompleteOrderAsync(orderId);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderRequestModel orderRequestModel)
        {
            var response = await orderServiceAsync.UpdateAsync(orderRequestModel);
            return Ok(response);
        }
    }
}
