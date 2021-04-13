using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoDANIEL.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Nome: ")]
        [Required(ErrorMessage ="Nome Obrigatorio!!")]
        public string Nome { get; set; }

        [Display(Name = "Preço: ")]
        [Required(ErrorMessage = "Preço Obrigatorio!!")]
        public string Valor { get; set; }

        [Display(Name = "Descrição: ")]
        [Required(ErrorMessage = "Descrição Obrigatorio!!")]
        public string Descricao { get; set; }

        [Display(Name = "Peso: ")]
        [Required(ErrorMessage = "Peso Obrigatorio!!")]
        public string Peso { get; set; }

        [Display(Name = "Cor: ")]
        [Required(ErrorMessage = "Cor Obrigatorio!!")]
        public string Cor { get; set; }

    }
}
