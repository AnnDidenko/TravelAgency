using AutoMapper;
using BLLnew.DTO;
using BLLnew.Exceptions;
using BLLnew.Interfaces;
using DALnew.Entities;
using DALnew.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLnew.Services
{
    public class ManageOrderService : IManageOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ITourRepository tourRepository;
        private readonly IMapper mapper;

        public ManageOrderService(IOrderRepository orderRepository, ITourRepository tourRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.tourRepository = tourRepository;
            this.mapper = mapper;
        }

        public void Add(OrderDTO newOrder)
        {
            var order = mapper.Map<Order>(newOrder);
            OrderValid(order);
            orderRepository.Add(order);
        }

        public void Remove(int id)
        {
            var order = orderRepository.GetById(id);
            if(order == null)
            {
                throw new EntityDoesNotExistException("This tour doesn't exist");
            }
            orderRepository.Remove(id);
        }

        private void OrderValid(Order order)
        {
            DoesTourExist(order.TourId);
        }

        private void DoesTourExist(int tourId)
        {
            var tour = tourRepository.GetById(tourId);

            if (tour == null)
            {
                throw new EntityDoesNotExistException("This tour doesn't exist");
            }
        }
    }
}
