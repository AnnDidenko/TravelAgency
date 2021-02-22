using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLLnew.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Travel_agency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IInfoTourService tourInfoService;
        private readonly IMapper mapper;

        public InfoController(IInfoTourService tourInfoService, IMapper mapper)
        {
            this.tourInfoService = tourInfoService;
            this.mapper = mapper;
        }

        [HttpGet("tours")]
        public IActionResult GetAllTours()
        {
            var toursDTO = tourInfoService.GetAll();
            return Ok(toursDTO);
        }

        [HttpGet("tours/{id}")]
        public IActionResult GetTourById([FromRoute]int id)
        {
            var tourDTO = tourInfoService.GetById(id);
            return Ok();
        }

        [HttpGet("toursbycountry")]
        public IActionResult GetTourByCounty(string country)
        {
            var toursDTO = tourInfoService.GetTourByCountry(country);
            return Ok();
        }

        [HttpGet("toursbycategory")]
        public IActionResult GetTourByCategory(string category)
        {
            var toursDTO = tourInfoService.GetTourByCategory(category);
            return Ok();
        }

        [HttpGet("toursbydepartureplace")]
        public IActionResult GetTourByDeparturePlace(string departure)
        {
            var toursDTO = tourInfoService.GetTourByDeparturePlace(departure);
            return Ok();
        }
    }
}