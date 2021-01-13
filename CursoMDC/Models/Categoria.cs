using System.ComponentModel.DataAnnotations;

namespace CursoMDC.Models
{
    public class Categoria
    {
        public int id { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo de descricao é Obrigatório")]
        public string Descricao { get; set; }
    }
}
