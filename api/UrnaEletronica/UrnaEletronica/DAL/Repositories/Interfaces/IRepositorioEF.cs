using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrnaEletronica.DAL.Repositories
{
    public interface IRepositorioEF<T> 
    {
        T ObterPorId(int Id);
        IEnumerable<T> ObterTodos();
        void Salvar(T obj);
        void Alterar(T obj);
        void Excluir(T obj);

    }
}
