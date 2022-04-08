using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TabTelecomConsolidadoService : ITabTelecomConsolidadoService
    {
        private readonly ITabTelecomConsolidadoRepository _tabTelecomConsolidadoRepository;
        private readonly IMapper _mapper;

        public TabTelecomConsolidadoService(ITabTelecomConsolidadoRepository tabTelecomConsolidadoRepository,
                                            IMapper mapper) 
        {
            _tabTelecomConsolidadoRepository = tabTelecomConsolidadoRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TabTelecomConsolidadoDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<TabTelecomConsolidadoDto>>(await _tabTelecomConsolidadoRepository.ObterTodos());
        }

        public async Task Add(TabTelecomConsolidadoDto tabTelecomConsolidadoDto)
        {
           await _tabTelecomConsolidadoRepository.Adicionar( _mapper.Map<TabTelecomConsolidadoDto, TabTelecomConsolidado>(tabTelecomConsolidadoDto));
        }

        public async Task Atualizar(TabTelecomConsolidadoDto tabTelecomConsolidadoDto)
        {
            await _tabTelecomConsolidadoRepository.Atualizar( _mapper.Map<TabTelecomConsolidado>(tabTelecomConsolidadoDto));
        }
        public async Task RemoverByTEntity(TabTelecomConsolidadoDto tabTelecomConsolidadoDto)
        {
            await _tabTelecomConsolidadoRepository.RemoverByTEntity(_mapper.Map<TabTelecomConsolidado>(tabTelecomConsolidadoDto));
        }
        /*
                public async Task Remover(Guid id)
                {
                    await _tabTelecomConsolidadoRepository.Remover(id);
                }
        */
    }
}
