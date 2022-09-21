using System.ComponentModel.DataAnnotations;

namespace Dominio.Dto
{
    public class CriarTarefaDto
    {
        [Required(ErrorMessage = "O campo Descrição da Tarefa deve estar preenchido.")]
        public string DescricaoTarefa { get; set; }
    }
}