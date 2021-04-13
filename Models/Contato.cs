

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud_apirest_agenda.Models {
    public class Contato{
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "O campo name é obrigatório!")]
        [MaxLength(80)]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório!")]
        [MaxLength(100)]
        public string email { get; set; }

        [Required(ErrorMessage = "O campo name é obrigatório!")]
        [MaxLength(15)]
        public string fone { get; set; }

    }
}