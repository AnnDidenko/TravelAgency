using BLLnew.DTO;
using DALnew.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLnew.Interfaces
{
    public interface IInfoTourService : IInfoGenericService<TourDTO, Tour>
    {
        List<TourDTO> GetTourByCountry(string country);
        List<TourDTO> GetTourByCategory(string category);
        List<TourDTO> GetTourByDeparturePlace(string departurePlace);
    }
}
