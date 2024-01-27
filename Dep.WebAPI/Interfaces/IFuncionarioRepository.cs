using Dep.WebAPI.Models;

namespace Dep.WebAPI.Interfaces
{
    public interface IFuncionarioRepository
    {
        void Incluir(Funcionario funcionario);
        void Alterar(Funcionario funcionario);
        void Excluir(Funcionario funcionario);

        Task<Funcionario> SelecionarByPk(int id);
        Task<IEnumerable<Funcionario>> SelecionarFuncionarios();
        Task<bool> SaveAllAsync();       
    }
}
