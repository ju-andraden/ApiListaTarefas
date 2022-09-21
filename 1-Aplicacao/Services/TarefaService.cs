using _4_Recursos;
using Aplicacao.Interfaces;
using Dominio.Dto;
using Dominio.Entidade;
using Infraestrutura.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ApiDbContext _context;

        public TarefaService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> CriarTarefa(CriarTarefaDto criarTarefaDto)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.DescricaoTarefa = criarTarefaDto.DescricaoTarefa;
            tarefa.DataCriacao = DateTime.Now;

            await _context.ListaTarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public async Task<Tarefa> LerTarefa(int id)
        {
            var tarefa = await BuscarTarefaPeloId(id);

            if (tarefa is null)
            {
                return null;
            }
            return tarefa;
        }

        public async Task<List<Tarefa>> LerTodasAsTarefas()
        {
            return await _context.ListaTarefas.ToListAsync();
        }

        public async Task<Tarefa> AtualizarTarefa(int id, AtualizarTarefaDto
            atualizarTarefaDto)
        {
            var tarefa = await BuscarTarefaPeloId(id);

            if (tarefa is null)
            {
                return null;
            }

            AtualizarTarefaSemDadosNulos(tarefa, atualizarTarefaDto);

            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return tarefa;
        }
        public async Task<string> DeletarTarefa(int id)
        {
            var tarefa = await BuscarTarefaPeloId(id);

            if (tarefa is null)
            {
                return null;
            }

            _context.ListaTarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return Mensagens.DeletandoTarefa;
        }
        private async Task<Tarefa> BuscarTarefaPeloId(int id)
        {
            var tarefa = await _context.ListaTarefas.FirstOrDefaultAsync(tarefa
                => tarefa.IdTarefa.Equals(id));

            return tarefa;
        }

        private void AtualizarTarefaSemDadosNulos(Tarefa tarefa, AtualizarTarefaDto
            atualizarTarefaDto)
        {
            if (!string.IsNullOrEmpty(atualizarTarefaDto.DescricaoTarefa))
            {
                tarefa.DescricaoTarefa = atualizarTarefaDto.DescricaoTarefa;
            }
        }


    }
}