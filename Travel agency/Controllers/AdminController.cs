using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BLLnew.Interfaces;
using AutoMapper;
using Travel_agency.Models;
using BLLnew.DTO;

namespace Travel_agency.Controllers
{
    [Route("admin")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase
    {
        private readonly IManageOrderService manageOrders;
        private readonly IManageTourService manageTours;
        private readonly IMapper mapper;

        public  AdminController(IManageOrderService manageOrders, IManageTourService manageTours, IMapper mapper)
        {
            this.manageOrders = manageOrders;
            this.manageTours = manageTours;
            this.mapper = mapper;
        }

        [HttpPost("tours")]
        public IActionResult CreateTour([FromBody] CreateTourRequestModel newTour)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tour = mapper.Map<TourDTO>(newTour);
            manageTours.Add(tour);
            return Ok();
        }

        [HttpDelete("tours/{id}")]
        public IActionResult DeleteTour(int id)
        {
            manageTours.Remove(id);
            return Ok();
        }

        [HttpPost("orders")]
        public IActionResult CreateOrder([FromBody] CreateOrderRequestModel newOrder)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = mapper.Map<OrderDTO>(newOrder);
            manageOrders.Add(order);
            return Ok();
        }

        [HttpDelete("orders/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            manageOrders.Remove(id);
            return Ok();
        }
    }
}