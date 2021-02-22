using AutoMapper;
using BLLnew.DTO;
using BLLnew.Exceptions;
using BLLnew.Interfaces;
using DALnew.Entities;
using DALnew.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLnew.Services
{
    public class ManageTourService : IManageTourService
    {
        private readonly ITourRepository tourRepository;
        private readonly IMapper mapper;

        public ManageTourService(ITourRepository tourRepository, IMapper mapper)
        {
            this.tourRepository = tourRepository;
            this.mapper = mapper;
        }

        public void Add(TourDTO newTour)
        {
            var tour = mapper.Map<Tour>(newTour);

            if (!IsExistTour(tour))
            {
                throw new EntityAlreadyExistsException("Tour already exists");
            }
            tourRepository.Add(tour);

        }

        public void Remove(int id)
        {
            var tour = tourRepository.GetById(id);
            if (tour != null)
            {
                tourRepository.Remove(id);
            }
        }

        private bool IsExistTour(Tour tour)
        {
            var check = tourRepository.GetAll().Where(i => i.Category == tour.Category
                                                            && i.Country == tour.Country
                                                            && i.DepartureDate == tour.DepartureDate
                                                            && i.DeparturePlace == tour.DeparturePlace
                                                            && i.Duration == tour.Duration).FirstOrDefault();
            return check == null;
        }
    }
}

