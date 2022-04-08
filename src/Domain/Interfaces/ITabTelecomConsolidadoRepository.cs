using Domain.Entities;
using Domain.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITabTelecomConsolidadoRepository : IRepository<TabTelecomConsolidado>
    {
        //Task RemoverFila(int Fila);
        /// IEnumerable<TabTelecomConsolidado> RemoverFila(int Fila);
        //void Delete(TabTelecomConsolidado tabTelecomConsolidado);
    }
}