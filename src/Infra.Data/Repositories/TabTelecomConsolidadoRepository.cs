using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Infra.Data.Context;
using Infra.Data.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class TabTelecomConsolidadoRepository : Repository<TabTelecomConsolidado> , ITabTelecomConsolidadoRepository
    {
        public TabTelecomConsolidadoRepository(SqlDbContext context) : base(context) { }


/*
        public virtual async  Task RemoverFila(int Fila)
        {
            Db.Remove(Fila);
            await SaveChanges();
        }

        public virtual async IEnumerable<TabTelecomConsolidado> ITabTelecomConsolidadoRepository.RemoverFila(int Fila)
        {
            Db.Remove(Fila);
        }
*/
    }
}


/*
public virtual ValidationResult Delete(TEntity entity)
{
    if (!ValidationResult.IsValid)
        return ValidationResult;

    _repository.Delete(entity);
    return _validationResult;
}
*/