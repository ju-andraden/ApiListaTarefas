using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidade
{
    public class Tarefa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTarefa { get; set; }
        public string DescricaoTarefa { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}