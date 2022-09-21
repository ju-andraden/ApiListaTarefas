using Dominio.Dto;
using Dominio.Entidade;

namespace Aplicacao.Interfaces
{
    public interface ITarefaService
    {
        public Task<Tarefa> CriarTarefa(CriarTarefaDto criarTarefaDto);
        public Task<Tarefa> LerTarefa(int id);
        public Task<List<Tarefa>> LerTodasAsTarefas();
        public Task<Tarefa> AtualizarTarefa(int id, AtualizarTarefaDto atualizarTarefaDto);
        public Task<string> DeletarTarefa(int id);
    }
}
