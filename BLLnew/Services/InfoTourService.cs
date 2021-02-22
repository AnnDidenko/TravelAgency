using AutoMapper;
using BLLnew.DTO;
using BLLnew.Interfaces;
using DALnew.Entities;
using DALnew.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLnew.Services
{
    public class InfoTourService : InfoGenericService<TourDTO, Tour>, IInfoTourService
    {
        private readonly ITourRepository tourRepository;

        public InfoTourService(ITourRepository tourRepository, IMapper mapper)
            : base(tourRepository, mapper)
        {
            this.tourRepository = tourRepository;
        }

        public List<TourDTO> GetTourByCountry(string country)
        {
            var tours = tourRepository.GetAll().ToList().Where(i => i.Country.ToUpper() == country.ToUpper());
            var toursDTO = mapper.Map<List<TourDTO>>(tours);
            return toursDTO;
        }

        public List<TourDTO> GetTourByCategory(string category)
        {
            var tours = tourRepository.GetAll().ToList().Where(i => i.Category.ToLower() == category.ToLower());
            var toursDTO = mapper.Map<List<TourDTO>>(tours);
            return toursDTO;
        }

        public List<TourDTO> GetTourByDeparturePlace(string departurePlace)
        {
            var tours = tourRepository.GetAll().ToList().Where(i => i.DeparturePlace.ToUpper() == departurePlace.ToUpper());
            var toursDTO = mapper.Map<List<TourDTO>>(tours);
            return toursDTO;
        }
    }
}
