using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaGroupSoftware.Models
{
  public class Morador
  {
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int MoradorId { get; set; }
    [Display(Name = "Morador (nome)")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o nome do Morador")]
    public string Nome { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Sobrenome do Morador é obrigatório")]
    public string Sobrenome { get; set; }

    [Display(Name = "Unidade")]
    [Required(AllowEmptyStrings = false, ErrorMessage ="Informe sua unidade")]
    public int UnidadeId { get; set; }

    [ForeignKey("UnidadeId")]
    [Display(Name = "Apartamento")]
    public virtual Unidade Unidade { get; set; }
  }
}