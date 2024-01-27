using Dep.WebAPI.Data;
using Dep.WebAPI.Interfaces;
using Dep.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Dep.WebAPI.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly DataContext _context;

        public FuncionarioRepository(DataContext context)
        {
            _context = context;
        }

        public void Alterar(Funcionario funcionario)
        {
            _context.Entry(funcionario).State = EntityState.Modified;
        }

        public void Excluir(Funcionario funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
        }

        public void Incluir(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Funcionario> SelecionarByPk(int id)
        {
            return await _context.Funcionarios.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Funcionario>> SelecionarFuncionarios()
        {
            return await _context.Funcionarios.ToListAsync();
        }
    }
}
