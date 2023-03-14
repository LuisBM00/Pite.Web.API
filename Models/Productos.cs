using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pite.Web.API.Models
{
    [Serializable]
    [Table("Productos")]
    public class Productos
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Nombre")]
        [Required]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Marca")]
        [Required]
        public string Marca { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Precio")]
        [Required]
        public double Precio { get; set; }
    }
}
