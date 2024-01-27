namespace Dep.WebAPI.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
    }
}
