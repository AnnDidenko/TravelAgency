using BLLnew.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLnew.Interfaces
{
    public interface IManageOrderService
    {
        void Add(OrderDTO newOrder);
        void Remove(int id);
    }
}
