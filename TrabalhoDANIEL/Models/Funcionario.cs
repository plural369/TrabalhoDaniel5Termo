using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoDANIEL.Models
{
    public class Funcionario
    {
        [Key]
        public long ID { get; set; }

        [Required(ErrorMessage = "Insira seu Nome")]

        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o Cpf")]

        public long CPF { get; set; }

        [Required(ErrorMessage = "Insira o Endereço")]
        [Display(Name = "Endereço")]

        public string Endereco { get; set; }

        [Required(ErrorMessage = "Insira o Numero de Telefone")]
        public long Telefone { get; set; }

        [Required(ErrorMessage = "Insira a Data de Nascimento")]
        [Display(Name = "Data de nascimento")]

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]

        public DateTime? Data_de_Nasc { get; set; }



    }
}
