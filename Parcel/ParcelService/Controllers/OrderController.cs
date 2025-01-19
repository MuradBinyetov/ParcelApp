using OrderService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Dtos; 
using OrderService.Services.Abstract;
using OrderService.Services.Concrete;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace ParcelService.Controllers
{

    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [Authorize(Roles = "User")]
        [HttpPost] 
        public async Task<Response> CreateOrder([FromBody] CreateOrderDto dto)
        {
            Response response = new Response();
            try
            {
                var userId = HttpContext.User.Identity?.Name;
                var orderDto = _mapper.Map<OrderDto>(dto);
                orderDto.UserId = userId;
                orderDto = await _orderService.CreateOrderAsync(orderDto); 

                response.Code = (int)HttpStatusCode.Created;
                response.Success = true;
                response.ResponseMessage = "Success";
                response.Data = orderDto; 
            }
            catch (Exception e)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Success = false;
                response.ResponseMessage = e.Message;   
            }
            return response; 
        }

        [Authorize(Roles = "User")]
        [HttpPut("{id}/change-destination")] 
        public async Task<Response> UpdateOrderDestination(int id, string newDestination)
        {
            Response response = new Response();
            try
            {
                var orderDto = await _orderService.UpdateOrderDestination(id, newDestination);  
                response.Code = (int)HttpStatusCode.OK ;
                response.Success = true;
                response.ResponseMessage = "Success";
                response.Data = orderDto;
            }
            catch (Exception e)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Success = false;
                response.ResponseMessage = e.Message;
            }
            return response; 
        }

        [Authorize(Roles = "User")]
        [HttpPut("{id}/cancel")]
        public async Task<Response> CancelParcel(int id)
        {
            Response response = new Response();
            try
            {
                await _orderService.CancelParcel(id);

                response.Code = (int)HttpStatusCode.OK;
                response.Success = true;
                response.ResponseMessage = "Success"; 
            }
            catch (Exception e)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Success = false;
                response.ResponseMessage = e.Message;
            }
            return response; 
        }


        [Authorize(Roles = "User")]
        [HttpGet("order/{id}")]
        public async Task<Response> GetOrderById(int id)
        {
            Response response = new Response();
            try
            {
                var orderDto = await _orderService.GetOrderByIdAsync(id);

                response.Code = (int)HttpStatusCode.OK;
                response.Success = true;
                response.ResponseMessage = "Success";
                response.Data = orderDto;
            }
            catch (Exception e)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Success = false;
                response.ResponseMessage = e.Message;
            }
            return response;
        }

        [Authorize(Roles = "User")]
        [HttpGet("user-orders")]
        public async Task<Response> GetOrdersByUserId()
        {
            Response response = new Response();
            try
            {
                var userId = HttpContext.User.Identity?.Name;
                var ordersDto = await _orderService.GetAllOrdersByUser(userId);

                response.Code = (int)HttpStatusCode.OK;
                response.Success = true;
                response.ResponseMessage = "Success";
                response.Data = ordersDto;
            }
            catch (Exception e)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Success = false;
                response.ResponseMessage = e.Message;
            }
            return response;
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/change-status")]
        public async Task<Response> UpdateOrderStatus(int id, OrderStatus status)
        {
            Response response = new Response();
            try
            {
                var orderDto = await _orderService.UpdateOrderStatus(id, status);

                response.Code = (int)HttpStatusCode.OK;
                response.Success = true;
                response.ResponseMessage = "Success";
                response.Data = orderDto;
            }
            catch (Exception e)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Success = false;
                response.ResponseMessage = e.Message;
            }
            return response;
        }
         
        [Authorize(Roles = "Admin")]
        [HttpGet("orders")]
        public async Task<Response> GetAllOrders()
        {
            Response response = new Response();
            try
            {
                var ordersDto = await _orderService.GetAllOrdersAsync();

                response.Code = (int)HttpStatusCode.OK;
                response.Success = true;
                response.ResponseMessage = "Success";
                response.Data = ordersDto;
            }
            catch (Exception e)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Success = false;
                response.ResponseMessage = e.Message;
            }
            return response;
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/assign")]
        public async Task<Response> AssignToCourier(int id, string courierId)
        {
            Response response = new Response();
            try
            {
                var orderDto = await _orderService.AssignOrderToCourier(id, courierId);

                response.Code = (int)HttpStatusCode.OK;
                response.Success = true;
                response.ResponseMessage = "Success";
                response.Data = orderDto;
            }
            catch (Exception e)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Success = false;
                response.ResponseMessage = e.Message;
            }
            return response;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("orders/courier/{courierId}")]
        public async Task<Response> GetAllOrdersByCourierId(string courierId)
        {
            Response response = new Response();
            try
            {
                var ordersDto = await _orderService.GetAllOrdersByCourierId(courierId);

                response.Code = (int)HttpStatusCode.OK;
                response.Success = true;
                response.ResponseMessage = "Success";
                response.Data = ordersDto;
            }
            catch (Exception e)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Success = false;
                response.ResponseMessage = e.Message;
            }
            return response;
        }

        [Authorize(Roles = "Courier")]
        [HttpGet("courier/order/change-status/{orderId}")]
        public async Task<Response> ChangeOrderStatusByCourier(int orderId, OrderStatus status)
        {
            Response response = new Response();
            try
            {
                var userId = HttpContext.User.Identity?.Name;
                var ordersDto = await _orderService.ChangeOrderStatusByCourier(orderId,status, userId);

                response.Code = (int)HttpStatusCode.OK;
                response.Success = true;
                response.ResponseMessage = "Success";
                response.Data = ordersDto;
            }
            catch (Exception e)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Success = false;
                response.ResponseMessage = e.Message;
            }
            return response;
        }

        [Authorize(Roles = "Courier")]
        [HttpGet("orders/courier")]
        public async Task<Response> GetAllOrdersByCourier()
        {
            Response response = new Response();
            try
            {
                var userId = HttpContext.User.Identity?.Name;
                var ordersDto = await _orderService.GetAllOrdersByCourier(userId);

                response.Code = (int)HttpStatusCode.OK;
                response.Success = true;
                response.ResponseMessage = "Success";
                response.Data = ordersDto;
            }
            catch (Exception e)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Success = false;
                response.ResponseMessage = e.Message;
            }
            return response;
        }

    }
}
