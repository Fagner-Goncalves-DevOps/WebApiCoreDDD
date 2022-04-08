using Application.Dtos;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITabTelecomConsolidadoService //: IRepository<TabTelecomConsolidadoDto> , ITabTelecomConsolidadoRepository
    {
        Task<IEnumerable<TabTelecomConsolidadoDto>> GetAll(); //ObterTodos
        Task Add(TabTelecomConsolidadoDto tabTelecomConsolidadoDto); //Add
        Task Atualizar(TabTelecomConsolidadoDto tabTelecomConsolidadoDto); //Update
      //  Task Remover(Guid id); //Remove
        Task RemoverByTEntity(TabTelecomConsolidadoDto tabTelecomConsolidadoDto);
    }
}
