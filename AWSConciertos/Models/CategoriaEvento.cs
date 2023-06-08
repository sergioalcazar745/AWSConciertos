using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWSConciertos.Models
{
    [Table("categoriaevento")]
    public class CategoriaEvento
    {
        [Key]
        [Column("idcategoria")]
        public int Idcategoria { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
