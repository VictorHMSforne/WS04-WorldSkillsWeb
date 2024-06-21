using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WS.Models
{
    [Table("Pressao")]
    public class Pressao
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        [Display(Name = "Digite Sua Sístole")]
        public int Sistole { get; set; }
        [NotNull]
        [Display(Name = "Digite Sua Díastole")]
        public int Diastole { get; set; }
        [NotNull]
        public string Data { get; set; }
        [NotNull]
        public string Hora { get; set; }

    }
}
