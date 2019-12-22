using AutoMapper;
using Geolocation.Main.Entities;
using Geolocation.Main.Interfaces;
using Geolocation.Main.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Geolocation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IDataUser _dataUser;
        private readonly IMapper _mapper;

        public LocationController(IDataUser dataUser,IMapper mapper)
        {
            _dataUser = dataUser;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResponse> Get(string ipAddress)
        {
            var location = _dataUser.GetData(ipAddress);
            var result = _mapper.Map<LocationViewModel>(location);

            return new ActionResponse
            {
                Status = System.Net.HttpStatusCode.OK,
                Result = result
            };
        }
    }
}