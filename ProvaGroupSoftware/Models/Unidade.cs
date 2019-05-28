using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaGroupSoftware.Models
{
  public class Unidade
  {
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int UnidadeId { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Favor Informar um número válido")]
    [Display(Name = "Número da unidade")]
    public string Numero { get; set; }

    [Display(Name = "Valor do Condomínio")]
    [DataType(DataType.Currency)]
    public decimal ValorUnidade { get; set; }

    [Display(Name ="Selecione o Condomínio")]
    [Required(AllowEmptyStrings =false, ErrorMessage ="Selecione o condomínio onde encontra-se a unidade")]
    public int CondominioId { get; set; }

    [ForeignKey("CondominioId")]
    public virtual Condominio Condominio { get; set; }
  }
}