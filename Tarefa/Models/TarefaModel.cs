using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarefa.Models
{
    public enum StatusTarefa
    {
        Pendente = 1,
        Finalizado = 2
    }

    [Table("Tarefa")]
    public class TarefaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TarefaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }

        [StringLength(50)]
        public string? Descricao { get; set; }

        public DateTime Data {  get; set; } = DateTime.Now;

        public StatusTarefa Status { get; set;} 


        public TarefaModel()
        {
            
        }

        public TarefaModel(int tarefaId, string titulo, string? descricao, DateTime data, StatusTarefa status)
        {
            this.TarefaId = tarefaId;
            Titulo = titulo;
            Descricao = descricao;
            Data = data;
            Status = status;
        }
    }

}
