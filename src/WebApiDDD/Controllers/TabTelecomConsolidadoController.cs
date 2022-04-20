using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDDD.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TabTelecomConsolidadoController : ControllerBase
    {

        private readonly ITabTelecomConsolidadoService _tabTelecomConsolidadoService;
  
        public TabTelecomConsolidadoController(ITabTelecomConsolidadoService tabTelecomConsolidadoService) 
        {
            _tabTelecomConsolidadoService = tabTelecomConsolidadoService;
        }


        [AllowAnonymous]
        [HttpGet("GetAll-TelecomConsolidado")]
        public async Task<IEnumerable<TabTelecomConsolidadoDto>> ObterTelecomConsolidado()
        {
            return await _tabTelecomConsolidadoService.GetAll();
        }

        [AllowAnonymous]
        [HttpPost("Add-TelecomConsolidado")]
        public async Task Adicionar(TabTelecomConsolidadoDto tabTelecomConsolidadoDto) 
        {
            await _tabTelecomConsolidadoService.Add(tabTelecomConsolidadoDto);
        }

        [AllowAnonymous]
        [HttpPut("UpDate-TelecomConsolidado")]
        public async Task Atualizar(TabTelecomConsolidadoDto tabTelecomConsolidadoDto)
        {
            await _tabTelecomConsolidadoService.Atualizar(tabTelecomConsolidadoDto);
        }

        [AllowAnonymous]
        [HttpDelete("Delete-TelecomConsolidado")]
        public async Task Deletar(TabTelecomConsolidadoDto tabTelecomConsolidadoDto)
        {
            await _tabTelecomConsolidadoService.RemoverByTEntity(tabTelecomConsolidadoDto);
        }

    }
}
