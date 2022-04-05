using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabTelecomConsolidadoController : ControllerBase
    {
        
        private readonly ITabTelecomConsolidadoService _tabTelecomConsolidadoService;

        public TabTelecomConsolidadoController(ITabTelecomConsolidadoService tabTelecomConsolidadoService) 
        {
            _tabTelecomConsolidadoService = tabTelecomConsolidadoService;
        }


        [HttpGet]
        public IActionResult Get() 
        {
            return Ok("DEU!");
        }


    }
}
