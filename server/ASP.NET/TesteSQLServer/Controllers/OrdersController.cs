﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TesteSQLServer.DTOs;
using TesteSQLServer.Services.Interfaces;

namespace TesteSQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase 
    {
        private IOrdersService OrderService;

        public OrdersController(IOrdersService orderService) 
        {
            OrderService = orderService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<ReadOrderDto> Show([FromRoute] int id)
        {
            var order = OrderService.GetOrderById(id);

            if (order != null)
            {
                return Ok(order);
            }


            return NoContent();            
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<ReadOrderDto>> Index() 
        {
            var orders = OrderService.GetAllOrdersByUserId(this.HttpContext);

            return Ok(orders);
        }

        [HttpPost]
        [Authorize]
        public ActionResult<int> Create([FromBody] CreateOrderDto createOrderDto)
        {
            var orderId = OrderService.CreateOrder(createOrderDto, this.HttpContext);

            return Ok(orderId);
        }
    }
}
