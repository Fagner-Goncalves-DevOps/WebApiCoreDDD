using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class //Entity  ///class
    {

        Task<List<TEntity>> ObterTodos(); //GetAll OK
        Task Adicionar(TEntity entity);  //Add
        Task Atualizar(TEntity entity); //Update
        Task Remover(Guid id);         //Remove Guid id
        Task RemoverByTEntity(TEntity entity); //Remove Guid id
        Task<int> SaveChanges();     //save no repositorio


        //metodos async para pesquisar, buscar
        //void para alteração no banco
        /*
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        */

    }
}
