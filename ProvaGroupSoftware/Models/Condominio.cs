using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaGroupSoftware.Models
{
  public class Condominio
  {
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int CondominioId { get; set; }

    [Display(Description = "Condomínio", Name = "Condominio")]
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Favor Informar o nome do Condomínio", AllowEmptyStrings = false)]
    public string Nome { get; set; }

    [Display(GroupName = "END", Name = "Endereço")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o Endereço do Condomínio")]
    public string Endereco { get; set; }

    [Display(GroupName = "END", Name = "Cidade")]
    public string Cidade { get; set; }

    [Compare("Cidade", ErrorMessage = "O Estado não pode ter o mesmo nome")]
    public string UF { get; set; }

    [Display(GroupName = "END", Name = "CEP")]
    [DataType(DataType.PostalCode)]
    public string Cep { get; set; }

    public virtual ICollection<Unidade> Unidades { get; set; }
  }
}