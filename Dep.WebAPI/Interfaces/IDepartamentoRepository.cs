using Dep.WebAPI.Models;

namespace Dep.WebAPI.Interfaces
{
    public interface IDepartamentoRepository
    {
        void Incluir(Departamento departamento);
        void Alterar(Departamento departamento);
        void Excluir(Departamento departamento);

        Task<Departamento> SelecionarByPk(int id);
        Task<IEnumerable<Departamento>> SelecionarTodos();
        Task<bool> SaveAllAsync();
    }
}
