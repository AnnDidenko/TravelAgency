using BLLnew.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLnew.Interfaces
{
    public interface IManageTourService
    {
        void Add(TourDTO newTour);
        void Remove(int id);
    }
}
