using Dep.WebAPI.Interfaces;
using Dep.WebAPI.Models;
using Dep.WebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Dep.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;

        public DepartamentoController(IDepartamentoRepository departamentoRepository, IFuncionarioRepository funcionarioRepository)
        {
            _departamentoRepository = departamentoRepository;
            _funcionarioRepository = funcionarioRepository;
        }

        [HttpGet("selecionarTodos")]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        {
            return Ok(await _departamentoRepository.SelecionarTodos());
        }

        [HttpGet("selecionarFuncionarios")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios()
        {
            return Ok(await _funcionarioRepository.SelecionarFuncionarios());
        }

        [HttpPost("CadastrarDepartamento")]
        public async Task<ActionResult> CadastrarDepartamento(Departamento departamento)
        {
            _departamentoRepository.Incluir(departamento);
            if (await _departamentoRepository.SaveAllAsync())
            {
                return Ok("Departamento cadastrado com sucesso");
            }

            return BadRequest("Ocorreu um erro ao cadastrar o departamento");
        }

        [HttpPost("CadastrarFuncionario")]
        public async Task<ActionResult> CadastrarFuncionario(Funcionario funcionario)
        {
            _funcionarioRepository.Incluir(funcionario);
            if (await _funcionarioRepository.SaveAllAsync())
            {
                return Ok("Funcionario cadastrado com sucesso");
            }

            return BadRequest("Ocorreu um erro ao cadastrar o funcionario");
        }

        [HttpPut("AlterarDepartamento")]
        public async Task<ActionResult> AlterarDepartamento(Departamento departamento)
        {
            _departamentoRepository.Alterar(departamento);
            if (await _departamentoRepository.SaveAllAsync())
            {
                return Ok("Departamento alterado com sucesso");
            }

            return BadRequest("Ocorreu um erro ao altera o departamento");
        }

        [HttpPut("AlterarFuncionario")]
        public async Task<ActionResult> AlterarFuncionario(Funcionario funcionario)
        {
            _funcionarioRepository.Alterar(funcionario);
            if (await _funcionarioRepository.SaveAllAsync())
            {
                return Ok("Funcionario alterado com sucesso");
            }

            return BadRequest("Ocorreu um erro ao altera o funcionario");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirDepartamento(int id)
        {
            var departamento = await _departamentoRepository.SelecionarByPk(id);

            if (departamento == null)
            {
                return NotFound("Departamento não encontrado");
            }

            _departamentoRepository.Excluir(departamento);

            if(await _departamentoRepository.SaveAllAsync()) 
            {
                return Ok("Departamento excluido com sucesso");
            }

            return BadRequest("Ocorreu um erro ao excluir o departamento");
        }

        [HttpDelete("func{id}")]
        public async Task<ActionResult> ExcluirFuncionario(int id)
        {
            var funcionario = await _funcionarioRepository.SelecionarByPk(id);

            if (funcionario == null)
            {
                return NotFound("Funcionario não encontrado");
            }

            _funcionarioRepository.Excluir(funcionario);

            if (await _funcionarioRepository.SaveAllAsync())
            {
                return Ok("Departamento excluido com sucesso");
            }

            return BadRequest("Ocorreu um erro ao excluir o departamento");
        }
    }
}
