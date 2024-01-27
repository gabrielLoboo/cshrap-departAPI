using Dep.WebAPI.Data;
using Dep.WebAPI.Interfaces;
using Dep.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Dep.WebAPI.Repository
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly DataContext _context;

        public DepartamentoRepository(DataContext context)
        {
            _context = context;
        }

        public void Alterar(Departamento departamento)
        {
            _context.Entry(departamento).State = EntityState.Modified;
        }

        public void Excluir(Departamento departamento)
        {
            _context.Departamentos.Remove(departamento);
        }

        public void Incluir(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);   
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Departamento> SelecionarByPk(int id)
        {
            return await _context.Departamentos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Departamento>> SelecionarTodos()
        {
            return await _context.Departamentos.Include(depto => depto.Funcionarios).ToListAsync();
        }
    }
}
